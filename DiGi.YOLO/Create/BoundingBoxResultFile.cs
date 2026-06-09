using DiGi.YOLO.Classes;
using System.IO;

namespace DiGi.YOLO
{
    public static partial class Create
    {
        /// <summary>
        /// Reads a file from the specified path and parses its contents into a <see cref="BoundingBoxResultFile"/> collection.
        /// </summary>
        /// <param name="path">The file system path to the bounding box result file.</param>
        /// <returns>A <see cref="BoundingBoxResultFile"/> instance containing the parsed results if the file exists and is valid; otherwise, <c>null</c>.</returns>
        public static BoundingBoxResultFile? BoundingBoxResultFile(string? path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                return null;
            }

            BoundingBoxResultFile result = [];

            string[] values = File.ReadAllLines(path);
            if (values != null && values.Length != 0)
            {
                foreach (string value in values)
                {
                    BoundingBoxResult? boundingBoxResult = BoundingBoxResult(value);
                    if (boundingBoxResult == null)
                    {
                        continue;
                    }

                    result.Add(boundingBoxResult);
                }
            }

            return result;
        }
    }
}