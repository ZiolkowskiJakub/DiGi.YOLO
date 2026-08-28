using DiGi.YOLO.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

namespace DiGi.YOLO
{
    public static partial class Modify
    {
        /// <summary>
        /// Runs the YOLO prediction script over a directory of images in a CPython process and reports how the run went.
        /// <para>The scripts are laid down in the working directory when they are not already there, a stale result file is removed so a failed run cannot be mistaken for this one, and the process is then run with its output streams captured. A source directory holding no images is answered without starting a process at all, because predict.py writes no result file in that case and the missing file would otherwise be indistinguishable from a crash.</para>
        /// <para>The run is synchronous. Cancelling it kills the interpreter and returns a result carrying a non-zero exit code rather than throwing. Only the interpreter is killed - this targets netstandard2.0, which has no overload for killing a whole process tree, so torch worker processes can outlive the cancellation.</para>
        /// </summary>
        /// <param name="yOLOPredictionOptions">The settings for the run.</param>
        /// <param name="cancellationToken">The token that cancels the run.</param>
        /// <returns>The result of the run, or <c>null</c> when the options are missing the interpreter, the weights, the source directory or the output path.</returns>
        public static YOLOPredictionResult? Predict(this YOLOPredictionOptions? yOLOPredictionOptions, CancellationToken cancellationToken = default)
        {
            if (yOLOPredictionOptions == null)
            {
                return null;
            }

            string? pythonPath = yOLOPredictionOptions.PythonPath;
            string? modelPath = yOLOPredictionOptions.ModelPath;
            string? sourceDirectory = yOLOPredictionOptions.SourceDirectory;
            string? outputPath = yOLOPredictionOptions.OutputPath;
            string? workingDirectory = yOLOPredictionOptions.WorkingDirectory;

            if (string.IsNullOrWhiteSpace(pythonPath) || string.IsNullOrWhiteSpace(modelPath) || string.IsNullOrWhiteSpace(sourceDirectory) || string.IsNullOrWhiteSpace(outputPath))
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(workingDirectory))
            {
                workingDirectory = Path.GetDirectoryName(outputPath);
                if (string.IsNullOrWhiteSpace(workingDirectory))
                {
                    return null;
                }
            }

            //Resolved once, so that the file the runner deletes and reads back is the file the process is told to write. The process runs in a directory of its own, so a relative path would not mean the same thing on both sides.
            modelPath = Query.NormalizedPath(modelPath) ?? modelPath;
            outputPath = Query.NormalizedPath(outputPath) ?? outputPath;
            sourceDirectory = Query.NormalizedPath(sourceDirectory) ?? sourceDirectory;
            workingDirectory = Query.NormalizedPath(workingDirectory) ?? workingDirectory;

            if (!Directory.Exists(sourceDirectory))
            {
                return new YOLOPredictionResult(-1, 0, outputPath, null, null, [string.Format("Source directory does not exist: {0}", sourceDirectory)], DateTimeOffset.Now, DateTimeOffset.Now);
            }

            //The extensions predict.py globs for
            List<string> paths_Image = [];
            foreach (string searchPattern in new string[] { "*.jpg", "*.jpeg", "*.png" })
            {
                paths_Image.AddRange(Directory.GetFiles(sourceDirectory, searchPattern));
            }

            DateTimeOffset start = DateTimeOffset.Now;

            if (paths_Image.Count == 0)
            {
                return new YOLOPredictionResult(0, 0, outputPath, [], null, null, start, DateTimeOffset.Now);
            }

            if (!Directory.Exists(workingDirectory))
            {
                Directory.CreateDirectory(workingDirectory);
            }

            //predict.py imports utils.py, and Python resolves that against the directory the script sits in, so the two have to be written together
            if (!File.Exists(Path.Combine(workingDirectory, Constants.FileName.Predict)) || !File.Exists(Path.Combine(workingDirectory, Constants.FileName.Utils)))
            {
                WriteScripts(workingDirectory);
            }

            string? directory_Output = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(directory_Output) && !Directory.Exists(directory_Output))
            {
                Directory.CreateDirectory(directory_Output);
            }

            //A result file left by an earlier run would otherwise be read back as this run's answer
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            string Quoted(string? value)
            {
                return string.Concat("\"", value, "\"");
            }

            StringBuilder stringBuilder_Arguments = new();
            stringBuilder_Arguments.Append(Quoted(Path.Combine(workingDirectory, Constants.FileName.Predict)));
            stringBuilder_Arguments.Append(" --model ").Append(Quoted(modelPath));
            stringBuilder_Arguments.Append(" --source ").Append(Quoted(sourceDirectory));
            stringBuilder_Arguments.Append(" --output ").Append(Quoted(outputPath));

            //argparse parses --conf with float(), which reads a decimal point and nothing else
            stringBuilder_Arguments.Append(" --conf ").Append(yOLOPredictionOptions.Confidence.ToString("R", CultureInfo.InvariantCulture));

            ProcessStartInfo processStartInfo = new()
            {
                Arguments = stringBuilder_Arguments.ToString(),
                CreateNoWindow = true,
                FileName = pythonPath,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                StandardErrorEncoding = Encoding.UTF8,
                StandardOutputEncoding = Encoding.UTF8,
                UseShellExecute = false,
                WorkingDirectory = workingDirectory
            };

            Queue<string> standardError = new();
            Queue<string> standardOutput = new();

            void Collect(Queue<string> values, string? value)
            {
                if (value == null)
                {
                    return;
                }

                lock (values)
                {
                    values.Enqueue(value);

                    while (values.Count > Constants.Count.OutputLines)
                    {
                        values.Dequeue();
                    }
                }
            }

            int exitCode;

            using (Process process = new() { StartInfo = processStartInfo })
            {
                process.ErrorDataReceived += (sender, dataReceivedEventArgs) => Collect(standardError, dataReceivedEventArgs.Data);
                process.OutputDataReceived += (sender, dataReceivedEventArgs) => Collect(standardOutput, dataReceivedEventArgs.Data);

                try
                {
                    process.Start();
                }
                catch (Exception exception)
                {
                    return new YOLOPredictionResult(-1, paths_Image.Count, outputPath, null, null, [exception.Message], start, DateTimeOffset.Now);
                }

                //Both streams are read as they arrive; draining one to its end would deadlock as soon as the process filled the other
                process.BeginErrorReadLine();
                process.BeginOutputReadLine();

                bool cancelled = false;

                while (!process.WaitForExit(250))
                {
                    if (!cancellationToken.IsCancellationRequested)
                    {
                        continue;
                    }

                    cancelled = true;

                    try
                    {
                        process.Kill();
                    }
                    catch
                    {
                    }

                    break;
                }

                //The timed overload returns before the output handlers have run to completion; this one waits for them
                process.WaitForExit();

                exitCode = cancelled ? -1 : process.ExitCode;
            }

            List<string>? values = exitCode == 0 && File.Exists(outputPath) ? [.. File.ReadAllLines(outputPath)] : null;

            return new YOLOPredictionResult(exitCode, paths_Image.Count, outputPath, values, standardOutput, standardError, start, DateTimeOffset.Now);
        }

        /// <summary>
        /// Runs the YOLO prediction script over a directory of images in a CPython process and returns the detections it found.
        /// <para>A convenience over <see cref="Predict(YOLOPredictionOptions?, CancellationToken)"/> for callers that only want the detections. A run that did not complete gives <c>null</c>, with no account of why - take the other overload when that matters, which for an unattended run it does.</para>
        /// </summary>
        /// <param name="pythonPath">The path of the CPython interpreter, or the name of one on PATH. Null searches PATH.</param>
        /// <param name="modelPath">The path of the trained weights file to score with.</param>
        /// <param name="sourceDirectory">The directory holding the images to score.</param>
        /// <param name="outputPath">The path of the bounding box result file to write.</param>
        /// <param name="cancellationToken">The token that cancels the run.</param>
        /// <returns>The detections, or <c>null</c> when the options could not be built or the run did not complete.</returns>
        public static BoundingBoxResultFile? Predict(string? pythonPath, string? modelPath, string? sourceDirectory, string? outputPath, CancellationToken cancellationToken = default)
        {
            YOLOPredictionOptions? yOLOPredictionOptions = Create.YOLOPredictionOptions(pythonPath, modelPath, sourceDirectory, outputPath);
            if (yOLOPredictionOptions == null)
            {
                return null;
            }

            return Create.BoundingBoxResultFile(Predict(yOLOPredictionOptions, cancellationToken: cancellationToken));
        }
    }
}
