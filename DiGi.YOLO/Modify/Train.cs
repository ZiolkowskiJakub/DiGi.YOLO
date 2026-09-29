using DiGi.YOLO.Classes;
using DiGi.YOLO.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

namespace DiGi.YOLO
{
    public static partial class Modify
    {
        /// <summary>
        /// Runs the YOLO training script in a CPython process and reports the identity of the weights it started from and of the weights it wrote.
        /// <para>The scripts are rewritten in the working directory before every run, so a directory never trains with a train.py of an older build; the conf.yaml of a dataset in that directory is left alone. The start weights are hashed here, before the process starts, because the output streams keep only their tail. A checkpoint start file is preflighted with <see cref="Query.YOLOEnvironmentResult(string?, string?, string?, CancellationToken)"/>, which rejects an ultralytics too old for it.</para>
        /// <para>The run directory is created under <see cref="YOLOTrainingOptions.Project"/>, always passed as an absolute path. A run whose project folder lies inside a YOLO\models folder is refused, and ultralytics numbers a run name that is already taken rather than reusing its directory, so no run can replace the frozen model.pt. The ultralytics settings file is isolated in the .yolo-config folder of the working directory.</para>
        /// <para>The weights identity is read from the success block train.py prints last and confirmed against the file on disk; a digest that does not match is dropped and the result does not succeed. ultralytics may download yolo26n.pt into the "weights" folder of the working directory for its AMP check and falls back to full precision without it - <see cref="YOLOTrainingResult.Amp"/> reports the precision actually used.</para>
        /// <para>The run is synchronous and can take hours. Cancelling it kills the interpreter and returns a result carrying a non-zero exit code rather than throwing; torch worker processes can outlive the cancellation.</para>
        /// </summary>
        /// <param name="yOLOTrainingOptions">The settings for the run.</param>
        /// <param name="cancellationToken">The token that cancels the run.</param>
        /// <returns>The result of the run, or <c>null</c> when the options are missing the interpreter, the start weights or the configuration file.</returns>
        public static YOLOTrainingResult? Train(this YOLOTrainingOptions? yOLOTrainingOptions, CancellationToken cancellationToken = default)
        {
            if (yOLOTrainingOptions == null)
            {
                return null;
            }

            string? pythonPath = yOLOTrainingOptions.PythonPath;
            string? modelPath = yOLOTrainingOptions.ModelPath;
            string? configurationFilePath = yOLOTrainingOptions.ConfigurationFilePath;

            if (string.IsNullOrWhiteSpace(pythonPath) || string.IsNullOrWhiteSpace(modelPath) || string.IsNullOrWhiteSpace(configurationFilePath))
            {
                return null;
            }

            //Resolved once, so that the files the runner checks and hashes are the files the process is told to read. The process runs in a directory of its own, so a relative path would not mean the same thing on both sides.
            modelPath = Query.NormalizedPath(modelPath) ?? modelPath;
            configurationFilePath = Query.NormalizedPath(configurationFilePath) ?? configurationFilePath;

            string? workingDirectory = Query.NormalizedPath(yOLOTrainingOptions.WorkingDirectory) ?? Query.NormalizedPath(Path.GetDirectoryName(configurationFilePath));
            if (string.IsNullOrWhiteSpace(workingDirectory))
            {
                return null;
            }

            string project = Query.NormalizedPath(yOLOTrainingOptions.Project) ?? Path.Combine(workingDirectory, "runs", "detect");

            ModelKind modelKind = Query.ModelKind(modelPath);

            DateTimeOffset start = DateTimeOffset.Now;

            YOLOTrainingResult Refused(string message)
            {
                return new YOLOTrainingResult(-1, modelPath, null, modelKind, null, null, null, null, null, [message], start, DateTimeOffset.Now);
            }

            if (modelKind == ModelKind.Undefined)
            {
                return Refused(string.Format("Start weights are neither a .pt checkpoint nor a .yaml definition: {0}", modelPath));
            }

            if (!File.Exists(modelPath))
            {
                return Refused(string.Format("Start weights do not exist: {0}", modelPath));
            }

            if (!File.Exists(configurationFilePath))
            {
                return Refused(string.Format("Configuration file does not exist: {0}", configurationFilePath));
            }

            if (yOLOTrainingOptions.Epochs < 1 || yOLOTrainingOptions.Patience < 0 || yOLOTrainingOptions.ImageSize < 32 || yOLOTrainingOptions.Batch < 1)
            {
                return Refused(string.Format(CultureInfo.InvariantCulture, "Invalid hyperparameters: epochs {0}, patience {1}, imgsz {2}, batch {3}.", yOLOTrainingOptions.Epochs, yOLOTrainingOptions.Patience, yOLOTrainingOptions.ImageSize, yOLOTrainingOptions.Batch));
            }

            //The run directory is project\name\weights, and ultralytics numbers a run name that is taken rather than reusing its directory. What remains is a project placed where the frozen weights live, which no run may write into
            string modelsSegment = string.Concat(Path.DirectorySeparatorChar, Constants.DirectoryName.YOLO, Path.DirectorySeparatorChar, "models", Path.DirectorySeparatorChar);
            if (string.Concat(project, Path.DirectorySeparatorChar).IndexOf(modelsSegment, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return Refused(string.Format("Refusing to write a run under '{0}': it is inside a YOLO\\models folder, where the frozen weights live.", project));
            }

            string? startModelSHA256 = Query.FileSHA256(modelPath);
            if (string.IsNullOrWhiteSpace(startModelSHA256))
            {
                return Refused(string.Format("Start weights could not be read: {0}", modelPath));
            }

            try
            {
                if (!Directory.Exists(workingDirectory))
                {
                    Directory.CreateDirectory(workingDirectory);
                }

                //Always rewritten, never only when missing: a working directory persists between runs, and a train.py of an older build ignores every argument and trains on its own defaults
                WriteScripts(workingDirectory);
            }
            catch (Exception exception)
            {
                return Refused(string.Format("Failed to prepare working directory '{0}': {1}", workingDirectory, exception.Message));
            }

            if (modelKind == ModelKind.Checkpoint)
            {
                YOLOEnvironmentResult yOLOEnvironmentResult = Query.YOLOEnvironmentResult(pythonPath, modelPath, workingDirectory, cancellationToken);
                if (!yOLOEnvironmentResult.Runnable)
                {
                    List<string> messages = ["Environment preflight failed."];
                    if (yOLOEnvironmentResult.Messages != null)
                    {
                        messages.AddRange(yOLOEnvironmentResult.Messages);
                    }

                    return new YOLOTrainingResult(-1, modelPath, startModelSHA256, modelKind, null, null, null, null, null, messages, start, DateTimeOffset.Now);
                }

                pythonPath = yOLOEnvironmentResult.PythonPath ?? pythonPath;
            }

            static string Quoted(string? value)
            {
                return string.Concat("\"", value, "\"");
            }

            //argparse parses every number with int(), which reads invariant digits only
            StringBuilder stringBuilder_Arguments = new();
            stringBuilder_Arguments.Append(Quoted(Path.Combine(workingDirectory, Constants.FileName.Train)));
            stringBuilder_Arguments.Append(" --model ").Append(Quoted(modelPath));
            stringBuilder_Arguments.Append(" --data ").Append(Quoted(configurationFilePath));
            stringBuilder_Arguments.Append(" --epochs ").Append(yOLOTrainingOptions.Epochs.ToString(CultureInfo.InvariantCulture));
            stringBuilder_Arguments.Append(" --patience ").Append(yOLOTrainingOptions.Patience.ToString(CultureInfo.InvariantCulture));
            stringBuilder_Arguments.Append(" --imgsz ").Append(yOLOTrainingOptions.ImageSize.ToString(CultureInfo.InvariantCulture));
            stringBuilder_Arguments.Append(" --batch ").Append(yOLOTrainingOptions.Batch.ToString(CultureInfo.InvariantCulture));
            stringBuilder_Arguments.Append(" --seed ").Append(yOLOTrainingOptions.Seed.ToString(CultureInfo.InvariantCulture));
            stringBuilder_Arguments.Append(" --project ").Append(Quoted(project));

            if (!string.IsNullOrWhiteSpace(yOLOTrainingOptions.Name))
            {
                stringBuilder_Arguments.Append(" --name ").Append(Quoted(yOLOTrainingOptions.Name));
            }

            if (!string.IsNullOrWhiteSpace(yOLOTrainingOptions.Device))
            {
                stringBuilder_Arguments.Append(" --device ").Append(Quoted(yOLOTrainingOptions.Device));
            }

            stringBuilder_Arguments.Append(yOLOTrainingOptions.Amp ? " --amp" : " --no-amp");

            //Isolates the ultralytics settings file in the working directory, so the run never reads or rewrites the shared machine-wide settings file another ultralytics version uses
            Dictionary<string, string> environmentVariables = Query.ConfigEnvironmentVariables(workingDirectory!);

            (int exitCode, List<string> standardOutput, List<string> standardError) = Query.ExecuteProcess(pythonPath!, stringBuilder_Arguments.ToString(), workingDirectory!, environmentVariables, cancellationToken);

            (string? weightsPath, long? bytes, string? sHA256, bool? amp) = Query.YOLOTrainingOutput(standardOutput);

            //The printed identity is only trusted once the file on disk agrees with it
            if (!string.IsNullOrWhiteSpace(weightsPath))
            {
                weightsPath = Query.NormalizedPath(weightsPath) ?? weightsPath;

                if (!File.Exists(weightsPath))
                {
                    standardError.Add(string.Format("Reported weights do not exist: {0}", weightsPath));
                    sHA256 = null;
                }
                else if (sHA256 != null)
                {
                    long bytes_File = new FileInfo(weightsPath).Length;
                    string? sHA256_File = Query.FileSHA256(weightsPath);
                    if (bytes != bytes_File || !string.Equals(sHA256, sHA256_File, StringComparison.OrdinalIgnoreCase))
                    {
                        standardError.Add(string.Format(CultureInfo.InvariantCulture, "Reported weights identity ({0} bytes, {1}) does not match the file ({2} bytes, {3}).", bytes, sHA256, bytes_File, sHA256_File));
                        sHA256 = null;
                    }
                }
            }

            return new YOLOTrainingResult(exitCode, modelPath, startModelSHA256, modelKind, weightsPath, bytes, sHA256, amp, standardOutput, standardError, start, DateTimeOffset.Now);
        }
    }
}
