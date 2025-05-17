using DiGi.YOLO.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DiGi.YOLO.Classes
{
    public class YOLOModel
    {
        private Dictionary<string, HashSet<Category>> categories = new Dictionary<string, HashSet<Category>>();
        private string directory;
        private Dictionary<Category, string> directoryNames = new Dictionary<Category, string>();
        private Dictionary<string, Image> images = new Dictionary<string, Image>();
        private SortedDictionary<int, Label> labels = new SortedDictionary<int, Label>();
        
        public YOLOModel()
        {
            directoryNames[Category.Train] = Path.Combine(Constans.DirectoryName.Images, Query.DirectoryName(Category.Train));
            directoryNames[Category.Validate] = Path.Combine(Constans.DirectoryName.Images, Query.DirectoryName(Category.Validate));
            directoryNames[Category.Test] = Path.Combine(Constans.DirectoryName.Images, Query.DirectoryName(Category.Test));
        }

        public YOLOModel(ConfigurationFile configurationFile)
        {
            Add(configurationFile);
        }

        public YOLOModel(string directory)
        {
            this.directory = directory;

            directoryNames[Category.Train] = Path.Combine(Constans.DirectoryName.Images, Query.DirectoryName(Category.Train));
            directoryNames[Category.Validate] = Path.Combine(Constans.DirectoryName.Images, Query.DirectoryName(Category.Validate));
            directoryNames[Category.Test] = Path.Combine(Constans.DirectoryName.Images, Query.DirectoryName(Category.Test));
        }

        public string Directory
        {
            get
            {
                return directory;
            }

            set
            {
                directory = value;
            }
        }

        public bool Add(string path, params Category[] categories)
        {
            if(string.IsNullOrEmpty(path))
            {
                return false;
            }

            if(!images.TryGetValue(path, out Image image) || image == null)
            {
                image = new Image(path);
                images[path] = image;
            }

            if (this.categories != null)
            {
                if (!this.categories.TryGetValue(path, out HashSet<Category> categories_Temp) || categories_Temp == null)
                {
                    categories_Temp = new HashSet<Category>();
                    this.categories[path] = categories_Temp;
                }

                foreach (Category category in categories)
                {
                    this.categories[path].Add(category);
                }
            }

            return true;
        }

        public bool Add(string labelName)
        {
            int index = LabelIndex(labelName);
            if(index != -1)
            {
                return false;
            }

            int labelIndex = labels.Count == 0 ? 0 : labels.Keys.Last() + 1;

            labels[labelIndex] = new Label(labelIndex, labelName);
            return true;
        }

        public bool Add(Label label)
        {
            if(label == null)
            {
                return false;
            }

            labels[label.Index] = label;
            return true;
        }

        public bool Add(string path, string labelName, BoundingBox boundingBox)
        {
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }

            if (!images.TryGetValue(path, out Image image) || image == null)
            {
                image = new Image(path);
                images[path] = image;
            }

            int labelIndex = LabelIndex(labelName);
            if (labelIndex == -1)
            {
                labelIndex = labels.Count == 0 ? 0 : labels.Keys.Last() + 1;
                labels[labelIndex] = new Label(labelIndex, labelName);
            }

            return image.Add(labelIndex, boundingBox);
        }

        public bool Add(string path, LabelFile labelFile)
        {
            if(string.IsNullOrWhiteSpace(path) || labelFile == null)
            {
                return false;
            }

            bool result = false;

            for (int i = 0; i < labelFile.Count; i++)
            {
                Label label = GetLabel(labelFile.GetLabelIndex(i));
                if (label == null)
                {
                    continue;
                }

                if(Add(path, label.Name, labelFile.GetBoundingBox(i)))
                {
                    result = true;
                }
            }

            return result;
        }

        public bool Add(ConfigurationFile configurationFile)
        {
            if(configurationFile == null)
            {
                return false;
            }

            directory = configurationFile.Directory;

            if (configurationFile.Labels != null)
            {
                foreach (Label label in configurationFile.Labels)
                {
                    Add(label);
                }
            }

            IEnumerable<Category> categories = configurationFile.GetCategories();
            if(categories != null)
            {
                foreach(Category category in categories)
                {
                    directoryNames[category] = configurationFile.GetDirectoryNames(category);
                }
            }

            return true;
        }

        public IEnumerable<Category> GetCategories(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            if (!categories.TryGetValue(path, out HashSet<Category> result))
            {
                return result;
            }

            return result;
        }

        public IEnumerable<Category> GetCategories()
        {
            HashSet<Category> result = new HashSet<Category>();
            foreach (KeyValuePair<string, HashSet<Category>> keyValuePair in categories)
            {
                if (keyValuePair.Value == null)
                {
                    continue;
                }

                foreach (Category category in keyValuePair.Value)
                {
                    result.Add(category);
                }
            }

            return result;
        }

        public ConfigurationFile GetConfigurationFile()
        {
            if (!directoryNames.TryGetValue(Category.Train, out string trainDirectoryName))
            {
                trainDirectoryName = null;
            }

            if (!directoryNames.TryGetValue(Category.Validate, out string validateDirectoryName))
            {
                validateDirectoryName = null;
            }

            if (!directoryNames.TryGetValue(Category.Test, out string testDirectoryName))
            {
                testDirectoryName = null;
            }

            ConfigurationFile result = new ConfigurationFile(
                directory,
                trainDirectoryName,
                validateDirectoryName,
                testDirectoryName,
                labels.Values);

            return result;
        }

        public string GetDirectory_Images()
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                return null;
            }

            return Path.Combine(directory, Constans.DirectoryName.Images);
        }

        public string GetDirectory_Images(string directory, Category category)
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                return null;
            }

            if (!directoryNames.TryGetValue(category, out string directoryName))
            {
                directoryName = Query.DirectoryName(category);
            }

            string result = null;
            if (!string.IsNullOrWhiteSpace(directoryName))
            {
                result = Path.Combine(directory, directoryName);
            }
            else
            {
                result = Path.Combine(directory, Constans.DirectoryName.Images, Query.DirectoryName(category));
            }

            return result;
        }

        public string GetDirectory_Images(Category category)
        {
            return GetDirectory_Images(directory, category);
        }

        public string GetDirectory_Labels()
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                return null;
            }

            string directory_Images = GetDirectory_Images();

            string[] values = directory_Images.Replace('/', '\\').Split('\\');

            int lastIndex = Array.LastIndexOf(values, Constans.DirectoryName.Images);

            if (lastIndex == -1)
            {
                return directory;
            }

            values[lastIndex] = Constans.DirectoryName.Labels;

            return string.Join("\\", values);
        }

        public string GetDirectory_Labels(string directory, Category category)
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                return null;
            }

            string directory_Images = GetDirectory_Images(directory, category);

            string[] values = directory_Images.Replace('/', '\\').Split('\\');

            int lastIndex = Array.LastIndexOf(values, Constans.DirectoryName.Images);

            if (lastIndex == -1)
            {
                return directory;
            }

            values[lastIndex] = Constans.DirectoryName.Labels;

            return string.Join("\\", values);
        }

        public string GetDirectory_Labels(Category category)
        {
            return GetDirectory_Labels(directory, category);
        }

        public Image GetImage(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            if (!images.TryGetValue(path, out Image result))
            {
                return result;
            }

            return result;
        }

        public IEnumerable<Image> GetImages(Category category)
        {
            List<Image> result = new List<Image>();
            foreach (KeyValuePair<string, Image> keyValuePair in images)
            {
                if (!categories.TryGetValue(keyValuePair.Key, out HashSet<Category> categories_Temp) || categories_Temp == null)
                {
                    continue;
                }

                if (categories_Temp.Contains(category))
                {
                    result.Add(keyValuePair.Value);
                }
            }

            return result;
        }

        public LabelFile GetLabelFile(string path)
        {
            Image image = GetImage(path);
            if (image == null)
            {
                return null;
            }

            return image?.GetLabelFile();
        }

        public Label GetLabel(int labelIndex)
        {
            if (!labels.TryGetValue(labelIndex, out Label result) || result == null)
            {
                return null;
            }

            return result;
        }

        public IEnumerable<Label> GetLabels()
        {
            return labels.Values;
        }

        public IEnumerable<Label> GetLabels(string path)
        {
            IEnumerable<int> labelIndexes = GetImage(path)?.LabelIndexes;
            if (labelIndexes == null)
            {
                return null;
            }

            List<Label> result = new List<Label>();
            foreach (int labelIndex in labelIndexes)
            {
                if (labels.TryGetValue(labelIndex, out Label label) && label != null)
                {
                    result.Add(label);
                }
            }

            return result;
        }
        
        public int LabelIndex(string labelName)
        {
            foreach(KeyValuePair<int, Label> keyValuePair in labels)
            {
                if(keyValuePair.Value?.Name == labelName)
                {
                    return keyValuePair.Key;
                }
            }

            return -1;
        }
    }
}
