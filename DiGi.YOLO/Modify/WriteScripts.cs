using System;
using System.IO;
using System.Reflection;

namespace DiGi.YOLO
{
    public static partial class Modify
    {
        /// <summary>
        /// Writes the YOLO Python runner scripts and configuration files into the specified directory.
        /// <para>The scripts ship inside this assembly, so this works in any host that loads it. A YOLO folder sitting beside the assembly is used in preference, which lets a script be edited in a build output and tried without rebuilding.</para>
        /// <para>predict.py imports utils.py, and Python resolves that against the directory the script sits in, so the files are only useful written together.</para>
        /// </summary>
        /// <param name="directory">The target directory path where scripts will be written.</param>
        /// <returns>True if every script file was written; otherwise, false.</returns>
        public static bool WriteScripts(string? directory)
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                return false;
            }

            Assembly assembly = Assembly.GetExecutingAssembly();

            string? assemblyDirectory = Path.GetDirectoryName(assembly.Location);
            if (string.IsNullOrWhiteSpace(assemblyDirectory))
            {
                assemblyDirectory = AppDomain.CurrentDomain.BaseDirectory;
            }

            string directory_Source = Path.Combine(assemblyDirectory, Constants.DirectoryName.YOLO);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string[] fileNames =
            [
                Constants.FileName.Train,
                Constants.FileName.Predict,
                Constants.FileName.Check,
                Constants.FileName.Export,
                Constants.FileName.Utils,
                Constants.FileName.Requirements,
                Constants.FileName.Conf
            ];

            bool result = true;

            foreach (string fileName in fileNames)
            {
                string path_Target = Path.Combine(directory, fileName);

                string path_Source = Path.Combine(directory_Source, fileName);
                if (File.Exists(path_Source))
                {
                    File.Copy(path_Source, path_Target, true);
                    continue;
                }

                string resourceName = string.Format("{0}.{1}.{2}", typeof(Query).Namespace, Constants.DirectoryName.YOLO, fileName);

                using Stream? stream = assembly.GetManifestResourceStream(resourceName);
                if (stream == null)
                {
                    result = false;
                    continue;
                }

                using (FileStream fileStream = File.Create(path_Target))
                {
                    stream.CopyTo(fileStream);
                }
            }

            return result;
        }
    }
}