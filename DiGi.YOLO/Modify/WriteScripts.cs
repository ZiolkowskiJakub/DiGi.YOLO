using System;
using System.IO;
using System.Reflection;

namespace DiGi.YOLO
{
    public static partial class Modify
    {
        /// <summary>
        /// Writes the YOLO Python runner scripts and configuration files from the output YOLO directory to the specified directory.
        /// </summary>
        /// <param name="directory">The target directory path where scripts will be written.</param>
        /// <returns>True if script files were successfully copied; otherwise, false.</returns>
        public static bool WriteScripts(string? directory)
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                return false;
            }

            Assembly assembly = Assembly.GetExecutingAssembly();
            string? assemblyDir = Path.GetDirectoryName(assembly.Location);
            if (string.IsNullOrWhiteSpace(assemblyDir))
            {
                assemblyDir = AppDomain.CurrentDomain.BaseDirectory;
            }

            string sourceYoloDir = Path.Combine(assemblyDir, Constants.DirectoryName.YOLO);
            if (!Directory.Exists(sourceYoloDir))
            {
                return false;
            }

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string[] fileNames =
            [
                Constants.FileName.Train,
                Constants.FileName.Predict,
                Constants.FileName.Utils,
                Constants.FileName.Requirements,
                Constants.FileName.Conf
            ];
            foreach (string fileName in fileNames)
            {
                string sourcePath = Path.Combine(sourceYoloDir, fileName);
                if (File.Exists(sourcePath))
                {
                    string targetPath = Path.Combine(directory, fileName);
                    File.Copy(sourcePath, targetPath, true);
                }
            }

            return true;
        }
    }
}
