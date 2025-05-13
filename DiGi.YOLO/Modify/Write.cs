using DiGi.YOLO.Classes;
using DiGi.YOLO.Enums;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DiGi.YOLO
{
    public static partial class Modify
    {
        public static bool Write(this YOLOModel yOLOModel)
        {
            if (yOLOModel == null || string.IsNullOrWhiteSpace(yOLOModel.Directory))
            {
                return false;
            }

            IEnumerable<Category> categories = yOLOModel.GetCategories();
            if (categories == null)
            {
                return false;
            }

            string directory = yOLOModel.Directory;

            ConfigurationFile configurationFile = yOLOModel.GetConfigurationFile();
            if (configurationFile == null)
            {
                configurationFile = new ConfigurationFile();
            }

            File.WriteAllText(Path.Combine(directory, "conf.yaml"), configurationFile.ToString());

            foreach (Category category in categories)
            {
                string directory_Images = yOLOModel.GetDirectory_Images(category);
                string directory_Labels = yOLOModel.GetDirectory_Labels(category);

                IEnumerable<Image> images = yOLOModel.GetImages(category);
                if (images == null || images.Count() == 0)
                {
                    continue;
                }

                if (!Directory.Exists(directory_Images))
                {
                    Directory.CreateDirectory(directory_Images);
                }

                if (!Directory.Exists(directory_Labels))
                {
                    Directory.CreateDirectory(directory_Labels);
                }

                foreach (Image image in images)
                {
                    string path = image?.Path;
                    if (string.IsNullOrWhiteSpace(path))
                    {
                        continue;
                    }

                    LabelFile labelFile = yOLOModel.GetLabelFile(path);
                    if (labelFile == null)
                    {
                        labelFile = new LabelFile();
                    }

                    string fileName_Image = Path.GetFileName(path);

                    string path_Image = Path.Combine(directory_Images, fileName_Image);

                    string path_Labels = Path.ChangeExtension(Path.Combine(directory_Labels, fileName_Image), ".txt");

                    File.Copy(path, path_Image);

                    File.WriteAllText(path_Labels, labelFile.ToString());
                }
            }

            return true;
        }
    }
}
