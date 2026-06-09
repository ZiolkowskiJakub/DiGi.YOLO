using DiGi.YOLO.Classes;
using DiGi.YOLO.Enums;
using System;
using System.IO;

namespace DiGi.YOLO
{
    public static partial class Modify
    {
        /// <summary>
        /// Clears the data associated with the specified YOLO model, including cache files and images/labels for various categories.
        /// </summary>
        /// <param name="yOLOModel">The YOLO model instance whose data should be cleared.</param>
        /// <returns>True if any files were successfully deleted; otherwise, false.</returns>
        public static bool ClearData(this YOLOModel? yOLOModel)
        {
            if (yOLOModel == null)
            {
                return false;
            }

            bool result = false;

            foreach (string? directory in new string?[] { yOLOModel.GetDirectory_Images(), yOLOModel.GetDirectory_Labels() })
            {
                if (string.IsNullOrWhiteSpace(directory) || !Directory.Exists(directory))
                {
                    continue;
                }

                foreach (string path in Directory.GetFiles(directory, "*.cache"))
                {
                    File.Delete(path);
                    result = true;
                }
            }

            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                if (category == Category.Test)
                {
                    continue;
                }

                foreach (string? directory in new string?[] { yOLOModel.GetDirectory_Images(category), yOLOModel.GetDirectory_Labels(category) })
                {
                    if (string.IsNullOrWhiteSpace(directory) || !Directory.Exists(directory))
                    {
                        continue;
                    }

                    foreach (string path in Directory.GetFiles(directory))
                    {
                        File.Delete(path);
                        result = true;
                    }
                }
            }

            return result;
        }
    }
}