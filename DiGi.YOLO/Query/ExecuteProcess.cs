using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace DiGi.YOLO
{
    public static partial class Query
    {
        /// <summary>
        /// Executes a process with captured standard output and standard error streams while supporting cancellation.
        /// <para>Launches the process without creating a window, using UTF-8 encodings for both streams. Reading both streams asynchronously prevents deadlocks when process output buffers fill up.</para>
        /// </summary>
        /// <param name="executablePath">The full path of the executable process to run.</param>
        /// <param name="arguments">The command line arguments passed to the process.</param>
        /// <param name="workingDirectory">The working directory context for the process execution.</param>
        /// <param name="cancellationToken">The token that cancels process execution.</param>
        /// <returns>A tuple containing the process exit code, standard output lines, and standard error lines.</returns>
        public static (int ExitCode, List<string> StandardOutput, List<string> StandardError) ExecuteProcess(string executablePath, string arguments, string workingDirectory, CancellationToken cancellationToken = default)
        {
            ProcessStartInfo processStartInfo = new()
            {
                Arguments = arguments,
                CreateNoWindow = true,
                FileName = executablePath,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                StandardErrorEncoding = Encoding.UTF8,
                StandardOutputEncoding = Encoding.UTF8,
                UseShellExecute = false,
                WorkingDirectory = workingDirectory
            };

            Queue<string> queue_StandardError = new();
            Queue<string> queue_StandardOutput = new();

            static void Collect(Queue<string> values, string? value)
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
                process.ErrorDataReceived += (sender, dataReceivedEventArgs) => Collect(queue_StandardError, dataReceivedEventArgs.Data);
                process.OutputDataReceived += (sender, dataReceivedEventArgs) => Collect(queue_StandardOutput, dataReceivedEventArgs.Data);

                try
                {
                    process.Start();
                }
                catch (Exception exception)
                {
                    return (-1, [], [exception.Message]);
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

            List<string> standardOutput;
            lock (queue_StandardOutput)
            {
                standardOutput = [.. queue_StandardOutput];
            }

            List<string> standardError;
            lock (queue_StandardError)
            {
                standardError = [.. queue_StandardError];
            }

            return (exitCode, standardOutput, standardError);
        }
    }
}