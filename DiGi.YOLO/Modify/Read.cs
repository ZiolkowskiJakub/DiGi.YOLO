using DiGi.YOLO.Classes;
using DiGi.YOLO.Enums;
using System;
using System.IO;

namespace DiGi.YOLO
{
    public static partial class Modify
    {
        /// <summary>
        /// Reads a YOLO model configuration and associated image and label files from the specified path.
        /// </summary>
        /// <param name="path">The file system path to the configuration file.</param>
        /// <returns>A <see cref="YOLOModel"/> instance if the configuration is valid and found; otherwise, null.</returns>
        public static YOLOModel? Read(string? path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                return null;
            }

            ConfigurationFile? configurationFile = Create.ConfigurationFile(path);
            if (configurationFile == null)
            {
                return null;
            }

            YOLOModel result = new(configurationFile);

            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                string? directory_Images = result.GetDirectory_Images(category);
                if (!Directory.Exists(directory_Images))
                {
                    continue;
                }

                string? directory_Labels = result.GetDirectory_Labels(category);

                string[] paths_Image = Directory.GetFiles(directory_Images, "*.jpeg");
                foreach (string path_Image in paths_Image)
                {
                    result.Add(path_Image, category);

                    string fileName = Path.ChangeExtension(Path.GetFileName(path_Image), ".txt");

                    string path_Label = Path.Combine(directory_Labels, fileName);
                    if (!File.Exists(path_Label))
                    {
                        continue;
                    }

                    LabelFile? labelFile = Create.LabelFile(path_Label);
                    if (labelFile == null)
                    {
                        continue;
                    }

                    result.Add(path_Image, labelFile);
                }
            }

            return result;
        }
    }
}