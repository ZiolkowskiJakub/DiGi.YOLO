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
        private SortedDictionary<int, Tag> tags = new SortedDictionary<int, Tag>();
        
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

        public bool Add(string tagName)
        {
            int index = TagIndex(tagName);
            if(index != -1)
            {
                return false;
            }

            int tagIndex = tags.Count == 0 ? 0 : tags.Keys.Last() + 1;

            tags[tagIndex] = new Tag(tagIndex, tagName);
            return true;
        }

        public bool Add(Tag tag)
        {
            if(tag == null)
            {
                return false;
            }

            tags[tag.Index] = tag;
            return true;
        }

        public bool Add(string path, string tagName, BoundingBox boundingBox)
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

            int tagIndex = TagIndex(tagName);
            if (tagIndex == -1)
            {
                tagIndex = tags.Count == 0 ? 0 : tags.Keys.Last() + 1;
                tags[tagIndex] = new Tag(tagIndex, tagName);
            }

            return image.Add(tagIndex, boundingBox);
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
                Tag tag = GetTag(labelFile.GetTagIndex(i));
                if (tag == null)
                {
                    continue;
                }

                if(Add(path, tag.Name, labelFile.GetBoundingBox(i)))
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

            if (configurationFile.Tags != null)
            {
                foreach (Tag tag in configurationFile.Tags)
                {
                    Add(tag);
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
                tags.Values);

            return result;
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

        public Tag GetTag(int tagIndex)
        {
            if (!tags.TryGetValue(tagIndex, out Tag result) || result == null)
            {
                return null;
            }

            return result;
        }

        public IEnumerable<Tag> GetTags()
        {
            return tags.Values;
        }

        public IEnumerable<Tag> GetTags(string path)
        {
            IEnumerable<int> tagIndexes = GetImage(path)?.TagIndexes;
            if (tagIndexes == null)
            {
                return null;
            }

            List<Tag> result = new List<Tag>();
            foreach (int tagIndex in tagIndexes)
            {
                if (tags.TryGetValue(tagIndex, out Tag tag) && tag != null)
                {
                    result.Add(tag);
                }
            }

            return result;
        }
        
        public int TagIndex(string tagName)
        {
            foreach(KeyValuePair<int, Tag> keyValuePair in tags)
            {
                if(keyValuePair.Value?.Name == tagName)
                {
                    return keyValuePair.Key;
                }
            }

            return -1;
        }
    }
}
