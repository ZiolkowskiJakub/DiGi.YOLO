using DiGi.YOLO.Classes;
using DiGi.YOLO.Enums;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

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

            string directory = yOLOModel.Directory;

            ConfigurationFile configurationFile = yOLOModel.GetConfigurationFile();
            if (configurationFile == null)
            {
                configurationFile = new ConfigurationFile();
            }

            File.WriteAllText(Path.Combine(directory, "conf.yaml"), configurationFile.ToString());

            foreach (Category category in System.Enum.GetValues(typeof(Category)))
            {
                string directory_Images = yOLOModel.GetDirectory_Images(category);
                string directory_Labels = yOLOModel.GetDirectory_Labels(category);

                IEnumerable<Image> images = yOLOModel.GetImages(category);
                if (category == Category.Test && (images == null || images.Count() == 0))
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

                if (images == null || images.Count() == 0)
                {
                    continue;
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

                    if(path != path_Image)
                    {
                        File.Copy(path, path_Image, true);
                    }

                    File.WriteAllText(path_Labels, labelFile.ToString());
                }
            }

            File.WriteAllBytes(Path.Combine(directory, "train.py"), Properties.Resources.train);
            File.WriteAllBytes(Path.Combine(directory, "predict.py"), Properties.Resources.predict);

            return true;
        }

        public static bool Write(this BoundingBoxResultFile boundingBoxResultFile, string path)
        {
            if(boundingBoxResultFile == null || string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            if(!Directory.Exists(Path.GetDirectoryName(path)))
            {
                return false;
            }

            List<string> values = new List<string>();
            foreach(BoundingBoxResult boundingBoxResult in boundingBoxResultFile)
            {
                string value = boundingBoxResult?.ToString();
                if(string.IsNullOrWhiteSpace(value))
                {
                    continue;
                }

                values.Add(value);
            }

            File.WriteAllLines(path, values);
            return true;
        }
    }
}
