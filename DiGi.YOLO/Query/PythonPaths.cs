using System;
using System.Collections.Generic;
using System.IO;

namespace DiGi.YOLO
{
    public static partial class Query
    {
        /// <summary>
        /// Resolves all potential CPython interpreter candidate paths on PATH.
        /// <para>If <paramref name="path"/> names an existing file, it is returned as the single candidate. Otherwise, PATH is searched for <paramref name="path"/> (if provided), "python", and "python3" in order, returning all distinct existing candidates found.</para>
        /// </summary>
        /// <param name="path">The full path of an interpreter, the command name of one on PATH, or <c>null</c> to search PATH.</param>
        /// <returns>A list of distinct resolved interpreter paths in search order.</returns>
        public static List<string> PythonPaths(string? path = null)
        {
            if (!string.IsNullOrWhiteSpace(path))
            {
                if (File.Exists(path))
                {
                    string? normalizedPath = NormalizedPath(path);
                    return normalizedPath == null ? [] : [normalizedPath];
                }

                if (Path.IsPathRooted(path!) || path!.IndexOf('/') >= 0 || path!.IndexOf('\\') >= 0)
                {
                    string normalizedPath = NormalizedPath(path) ?? path!;
                    return [normalizedPath];
                }
            }

            List<string> candidatePaths = [];
            HashSet<string> hashSet_Seen = new(StringComparer.OrdinalIgnoreCase);

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
                return candidatePaths;
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

                        if (!File.Exists(path_Candidate))
                        {
                            continue;
                        }

                        string? normalizedPath = NormalizedPath(path_Candidate) ?? path_Candidate;
                        if (hashSet_Seen.Add(normalizedPath))
                        {
                            candidatePaths.Add(normalizedPath);
                        }
                    }
                }
            }

            return candidatePaths;
        }
    }
}
