using System;
using System.Collections.Generic;
using System.IO;

namespace DiGi.YOLO
{
    public static partial class Query
    {
        /// <summary>
        /// Resolves the CPython interpreter that runs the YOLO scripts.
        /// <para>A path that names an existing file is taken as given. Anything else, including <c>null</c>, is looked for on PATH, trying "python" and then "python3", in PATH order.</para>
        /// <para>A Windows app execution alias is accepted like any other match even though it is a zero byte reparse point, because it is a working interpreter whenever its app is installed. When the app is not installed the alias opens the Microsoft Store instead and the run fails; that failure is reported through the result's standard error rather than avoided by guessing.</para>
        /// <para>The interpreter has to be CPython with ultralytics and torch installed. The IronPython engine in DiGi.Scripting.Python cannot host either of them, so it is not an alternative to this.</para>
        /// </summary>
        /// <param name="path">The path of an interpreter, the name of one on PATH, or <c>null</c> to search for one.</param>
        /// <returns>The full path of the interpreter, or <c>null</c> when none was found.</returns>
        public static string? PythonPath(string? path)
        {
            if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
            {
                return NormalizedPath(path);
            }

            List<string> fileNames = [];

            if (!string.IsNullOrWhiteSpace(path))
            {
                fileNames.Add(path!);
            }

            fileNames.Add("python");
            fileNames.Add("python3");

            string? value = Environment.GetEnvironmentVariable("PATH");
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            string[] extensions = Environment.OSVersion.Platform == PlatformID.Win32NT ? [".exe", ".cmd", ".bat", string.Empty] : [string.Empty];

            foreach (string fileName in fileNames)
            {
                foreach (string directory in value!.Split(Path.PathSeparator))
                {
                    if (string.IsNullOrWhiteSpace(directory))
                    {
                        continue;
                    }

                    foreach (string extension in extensions)
                    {
                        string path_Candidate;

                        try
                        {
                            path_Candidate = Path.Combine(directory, string.Concat(fileName, extension));
                        }
                        catch
                        {
                            continue;
                        }

                        //Taken as found, including a zero length Windows app execution alias, which is a working interpreter whenever its app is installed. Preferring a real executable further along PATH looks safer and is not: the alias and the executable are usually different installations with different packages, so the run then fails to import ultralytics for a reason nothing on the command line explains. PATH order is the caller's answer to which interpreter is meant.
                        if (File.Exists(path_Candidate))
                        {
                            return NormalizedPath(path_Candidate);
                        }
                    }
                }
            }

            return null;
        }
    }
}