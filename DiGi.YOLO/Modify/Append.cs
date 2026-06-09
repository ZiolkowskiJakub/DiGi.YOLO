using DiGi.YOLO.Classes;
using System.Collections.Generic;
using System.IO;

namespace DiGi.YOLO
{
    public static partial class Modify
    {
        /// <summary>
        /// Appends the contents of a bounding box result file to a specified file path.
        /// </summary>
        /// <param name="boundingBoxResultFile">The collection of bounding box results to append.</param>
        /// <param name="path">The destination file path where data will be appended.</param>
        /// <returns>True if the operation was successful; otherwise, false.</returns>
        public static bool Append(this BoundingBoxResultFile? boundingBoxResultFile, string? path)
        {
            if (boundingBoxResultFile == null || string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                return false;
            }

            List<string> values = [];
            foreach (BoundingBoxResult boundingBoxResult in boundingBoxResultFile)
            {
                string? value = boundingBoxResult?.ToString();
                if (string.IsNullOrWhiteSpace(value))
                {
                    continue;
                }

                values.Add(value!);
            }

            File.AppendAllLines(path, values);
            return true;
        }
    }
}