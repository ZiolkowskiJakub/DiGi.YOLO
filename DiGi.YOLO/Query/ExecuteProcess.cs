using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
            return ExecuteProcess(executablePath, arguments, workingDirectory, null, cancellationToken);
        }

        /// <summary>
        /// Executes a process with captured standard output and standard error streams, additional environment variables and cancellation support.
        /// <para>Same contract as <see cref="ExecuteProcess(string, string, string, Dictionary{string, string}?, TimeSpan?, CancellationToken)"/>, without an inactivity limit.</para>
        /// </summary>
        /// <param name="executablePath">The full path of the executable process to run.</param>
        /// <param name="arguments">The command line arguments passed to the process.</param>
        /// <param name="workingDirectory">The working directory context for the process execution.</param>
        /// <param name="environmentVariables">The environment variables set on the process on top of the inherited environment, or <c>null</c>.</param>
        /// <param name="cancellationToken">The token that cancels process execution.</param>
        /// <returns>A tuple containing the process exit code, standard output lines, and standard error lines.</returns>
        public static (int ExitCode, List<string> StandardOutput, List<string> StandardError) ExecuteProcess(string executablePath, string arguments, string workingDirectory, Dictionary<string, string>? environmentVariables, CancellationToken cancellationToken = default)
        {
            (int exitCode, List<string> standardOutput, List<string> standardError, bool _) = ExecuteProcess(executablePath, arguments, workingDirectory, environmentVariables, null, cancellationToken);

            return (exitCode, standardOutput, standardError);
        }

        /// <summary>
        /// Executes a process with captured standard output and standard error streams, additional environment variables, cancellation support, and an inactivity limit that ends a process which stops producing output.
        /// <para>Launches the process without creating a window, using UTF-8 encodings for both streams. Reading both streams asynchronously prevents deadlocks when process output buffers fill up. Cancelling or reaching the limit ends the process together with every process it started.</para>
        /// </summary>
        /// <param name="executablePath">The full path of the executable process to run.</param>
        /// <param name="arguments">The command line arguments passed to the process.</param>
        /// <param name="workingDirectory">The working directory context for the process execution.</param>
        /// <param name="environmentVariables">The environment variables set on the process on top of the inherited environment, or <c>null</c>.</param>
        /// <param name="inactivityTimeout">The span without a line on either output stream after which the process is ended, or <c>null</c> for no limit. A value that is not positive disables the limit as well.</param>
        /// <param name="cancellationToken">The token that cancels process execution.</param>
        /// <returns>A tuple containing the process exit code (-1 when the process was cancelled or ended for inactivity), standard output lines, standard error lines, and whether the process was ended for inactivity.</returns>
        public static (int ExitCode, List<string> StandardOutput, List<string> StandardError, bool Stalled) ExecuteProcess(string executablePath, string arguments, string workingDirectory, Dictionary<string, string>? environmentVariables, TimeSpan? inactivityTimeout, CancellationToken cancellationToken = default)
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

            if (environmentVariables != null)
            {
                foreach (KeyValuePair<string, string> pair in environmentVariables)
                {
                    processStartInfo.EnvironmentVariables[pair.Key] = pair.Value;
                }
            }

            Queue<string> queue_StandardError = new();
            Queue<string> queue_StandardOutput = new();

            //The wait loop reads this from another thread than the stream handlers write it, so every access is under this lock
            object lock_Activity = new();
            DateTimeOffset lastActivity = DateTimeOffset.Now;

            static void KillProcessTree(Process process)
            {
                //netstandard2.0 cannot see Process.Kill(bool entireProcessTree), which .NET Core 3.0 added, and every host of this library runs on a runtime that has it; plain Kill() is the fallback should one not
                System.Reflection.MethodInfo? methodInfo = typeof(Process).GetMethod(nameof(Process.Kill), new Type[] { typeof(bool) });
                if (methodInfo == null)
                {
                    process.Kill();
                    return;
                }

                methodInfo.Invoke(process, new object[] { true });
            }

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

                lock (lock_Activity)
                {
                    lastActivity = DateTimeOffset.Now;
                }
            }

            int exitCode;
            bool stalled = false;

            using (Process process = new() { StartInfo = processStartInfo })
            {
                process.ErrorDataReceived += (sender, dataReceivedEventArgs) => Collect(queue_StandardError, dataReceivedEventArgs.Data);
                process.OutputDataReceived += (sender, dataReceivedEventArgs) => Collect(queue_StandardOutput, dataReceivedEventArgs.Data);

                try
                {
                    process.Start();

                    lock (lock_Activity)
                    {
                        lastActivity = DateTimeOffset.Now;
                    }
                }
                catch (Exception exception)
                {
                    return (-1, [], [exception.Message], false);
                }

                //Both streams are read as they arrive; draining one to its end would deadlock as soon as the process filled the other
                process.BeginErrorReadLine();
                process.BeginOutputReadLine();

                bool cancelled = false;

                while (!process.WaitForExit(250))
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        cancelled = true;
                    }
                    else if (inactivityTimeout != null && inactivityTimeout.Value > TimeSpan.Zero)
                    {
                        DateTimeOffset lastActivity_Temp;
                        lock (lock_Activity)
                        {
                            lastActivity_Temp = lastActivity;
                        }

                        if (DateTimeOffset.Now - lastActivity_Temp > inactivityTimeout.Value)
                        {
                            stalled = true;
                        }
                    }

                    if (!cancelled && !stalled)
                    {
                        continue;
                    }

                    try
                    {
                        //Ends the interpreter together with every process it started: the torch data loader workers of a silent training deadlock stay alive for hours holding the GPU
                        KillProcessTree(process);
                    }
                    catch
                    {
                    }

                    break;
                }

                //The timed overload returns before the output handlers have run to completion; this one waits for them
                process.WaitForExit();

                exitCode = cancelled || stalled ? -1 : process.ExitCode;

                if (stalled)
                {
                    DateTimeOffset lastActivity_Temp;
                    lock (lock_Activity)
                    {
                        lastActivity_Temp = lastActivity;
                    }

                    Collect(queue_StandardError, string.Format(CultureInfo.InvariantCulture, "Ended after {0} without output (last output at {1})", inactivityTimeout, lastActivity_Temp));
                }
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

            return (exitCode, standardOutput, standardError, stalled);
        }
    }
}
