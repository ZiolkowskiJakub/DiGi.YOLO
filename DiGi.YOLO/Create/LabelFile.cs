using DiGi.YOLO.Classes;
using System.Collections.Generic;
using System.IO;

namespace DiGi.YOLO
{
    public static partial class Create
    {
        /// <summary>
        /// Parses a YOLO label file from the specified path and returns a LabelFile object containing the bounding boxes.
        /// </summary>
        /// <param name="path">The file system path to the label file.</param>
        /// <returns>A <see cref="LabelFile"/> instance if the file exists and contains valid data; otherwise, null.</returns>
        public static LabelFile? LabelFile(string? path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                return null;
            }

            List<string> lines = [.. File.ReadAllLines(path)];
            if (lines == null || lines.Count == 0)
            {
                return null;
            }

            LabelFile result = new();
            foreach (string line in lines)
            {
                string[] values = line.Split([" "], System.StringSplitOptions.RemoveEmptyEntries);
                if (values.Length < 5)
                {
                    continue;
                }

                if (!int.TryParse(values[0], out int labelIndex))
                {
                    continue;
                }

                if (!double.TryParse(values[1], out double x))
                {
                    continue;
                }

                if (!double.TryParse(values[2], out double y))
                {
                    continue;
                }

                if (!double.TryParse(values[3], out double width))
                {
                    continue;
                }

                if (!double.TryParse(values[4], out double height))
                {
                    continue;
                }

                result.Add(labelIndex, new BoundingBox(x, y, width, height));
            }

            return result;
        }
    }
}