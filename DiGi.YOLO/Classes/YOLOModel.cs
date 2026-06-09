using DiGi.YOLO.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DiGi.YOLO.Classes
{
    /// <summary>
    /// Represents a YOLO model structure that manages images, labels, and their associated categories and bounding boxes.
    /// </summary>
    public class YOLOModel
    {
        private readonly Dictionary<string, HashSet<Category>> categories = [];
        private string? directory;
        private readonly Dictionary<Category, string?> directoryNames = [];
        private readonly Dictionary<string, Image> images = [];
        private readonly SortedDictionary<int, Label> labels = [];

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOModel"/> class and sets up default directory paths for train, validate, and test categories.
        /// </summary>
        public YOLOModel()
        {
            directoryNames[Category.Train] = Path.Combine(Constants.DirectoryName.Images, Query.DirectoryName(Category.Train));
            directoryNames[Category.Validate] = Path.Combine(Constants.DirectoryName.Images, Query.DirectoryName(Category.Validate));
            directoryNames[Category.Test] = Path.Combine(Constants.DirectoryName.Images, Query.DirectoryName(Category.Test));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOModel"/> class using the provided configuration file.
        /// </summary>
        /// <param name="configurationFile">The configuration file to initialize the model with.</param>
        public YOLOModel(ConfigurationFile? configurationFile)
        {
            Add(configurationFile);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOModel"/> class with a specified root directory and sets up default category paths.
        /// </summary>
        /// <param name="directory">The base directory path for the model.</param>
        public YOLOModel(string? directory)
        {
            this.directory = directory;

            directoryNames[Category.Train] = Path.Combine(Constants.DirectoryName.Images, Query.DirectoryName(Category.Train));
            directoryNames[Category.Validate] = Path.Combine(Constants.DirectoryName.Images, Query.DirectoryName(Category.Validate));
            directoryNames[Category.Test] = Path.Combine(Constants.DirectoryName.Images, Query.DirectoryName(Category.Test));
        }

        /// <summary>
        /// Gets or sets the base directory path for the model data.
        /// </summary>
        public string? Directory
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

        /// <summary>
        /// Associates an image at the specified path with one or more categories.
        /// </summary>
        /// <param name="path">The file path of the image.</param>
        /// <param name="categories">An array of categories to assign to the image.</param>
        /// <returns>True if the image and categories were successfully added; otherwise, false.</returns>
        public bool Add(string? path, params Category[]? categories)
        {
            if (string.IsNullOrEmpty(path) || categories is null)
            {
                return false;
            }

            if (!images.TryGetValue(path!, out Image image) || image == null)
            {
                image = new Image(path);
                images[path!] = image;
            }

            if (this.categories != null)
            {
                if (!this.categories.TryGetValue(path!, out HashSet<Category> categories_Temp) || categories_Temp == null)
                {
                    categories_Temp = [];
                    this.categories[path!] = categories_Temp;
                }

                foreach (Category category in categories)
                {
                    this.categories[path!].Add(category);
                }
            }

            return true;
        }

        /// <summary>
        /// Adds a new label name to the model's labels collection if it does not already exist.
        /// </summary>
        /// <param name="labelName">The name of the label to add.</param>
        /// <returns>True if the label was added; false if the label already exists or is invalid.</returns>
        public bool Add(string? labelName)
        {
            int index = LabelIndex(labelName);
            if (index != -1)
            {
                return false;
            }

            int labelIndex = labels.Count == 0 ? 0 : labels.Keys.Last() + 1;

            labels[labelIndex] = new Label(labelIndex, labelName);
            return true;
        }

        /// <summary>
        /// Adds a specific <see cref="Label"/> object to the model's labels collection.
        /// </summary>
        /// <param name="label">The label object to add.</param>
        /// <returns>True if the label was successfully added; otherwise, false.</returns>
        public bool Add(Label? label)
        {
            if (label == null)
            {
                return false;
            }

            labels[label.Index] = label;
            return true;
        }

        /// <summary>
        /// Adds a bounding box for a specific label to an image at the given path.
        /// </summary>
        /// <param name="path">The file path of the image.</param>
        /// <param name="labelName">The name of the label associated with the bounding box.</param>
        /// <param name="boundingBox">The bounding box coordinates and dimensions.</param>
        /// <returns>True if the bounding box was successfully added to the image; otherwise, false.</returns>
        public bool Add(string? path, string? labelName, BoundingBox? boundingBox)
        {
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }

            if (!images.TryGetValue(path!, out Image image) || image == null)
            {
                image = new Image(path);
                images[path!] = image;
            }

            int labelIndex = LabelIndex(labelName);
            if (labelIndex == -1)
            {
                labelIndex = labels.Count == 0 ? 0 : labels.Keys.Last() + 1;
                labels[labelIndex] = new Label(labelIndex, labelName);
            }

            return image.Add(labelIndex, boundingBox);
        }

        /// <summary>
        /// Adds all labels and bounding boxes contained within a label file to an image at the given path.
        /// </summary>
        /// <param name="path">The file path of the image.</param>
        /// <param name="labelFile">The label file containing annotation data.</param>
        /// <returns>True if at least one bounding box was successfully added; otherwise, false.</returns>
        public bool Add(string? path, LabelFile? labelFile)
        {
            if (string.IsNullOrWhiteSpace(path) || labelFile == null)
            {
                return false;
            }

            bool result = false;

            for (int i = 0; i < labelFile.Count; i++)
            {
                Label? label = GetLabel(labelFile.GetLabelIndex(i));
                if (label == null)
                {
                    continue;
                }

                if (Add(path, label.Name, labelFile.GetBoundingBox(i)))
                {
                    result = true;
                }
            }

            return result;
        }

/// <summary>
        /// Adds the specified configuration file settings to the YOLO model.
        /// </summary>
        /// <param name="configurationFile">The configuration file containing directory and label information.</param>
        /// <returns>True if the configuration was successfully added; otherwise, false.</returns>
        public bool Add(ConfigurationFile? configurationFile)
        {
            if (configurationFile == null)
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
            if (categories != null)
            {
                foreach (Category category in categories)
                {
                    directoryNames[category] = configurationFile.GetDirectoryNames(category);
                }
            }

            return true;
        }

        /// <summary>
        /// Retrieves the collection of categories associated with the specified path.
        /// </summary>
        /// <param name="path">The directory path to look up categories for.</param>
        /// <returns>An enumerable of <see cref="Category"/> if found; otherwise, null.</returns>
        public IEnumerable<Category>? GetCategories(string? path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            if (!categories.TryGetValue(path!, out HashSet<Category> result))
            {
                return result;
            }

            return result;
        }

        /// <summary>
        /// Retrieves a collection of all unique categories currently stored in the model.
        /// </summary>
        /// <returns>An enumerable containing all registered <see cref="Category"/> values.</returns>
        public IEnumerable<Category>? GetCategories()
        {
            HashSet<Category> result = [];
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

        /// <summary>
        /// Creates and returns a <see cref="ConfigurationFile"/> instance based on the current model configuration.
        /// </summary>
        /// <returns>A <see cref="ConfigurationFile"/> object representing the current settings.</returns>
        public ConfigurationFile? GetConfigurationFile()
        {
            if (!directoryNames.TryGetValue(Category.Train, out string? trainDirectoryName))
            {
                trainDirectoryName = null;
            }

            if (!directoryNames.TryGetValue(Category.Validate, out string? validateDirectoryName))
            {
                validateDirectoryName = null;
            }

            if (!directoryNames.TryGetValue(Category.Test, out string? testDirectoryName))
            {
                testDirectoryName = null;
            }

            ConfigurationFile result = new(
                directory,
                trainDirectoryName,
                validateDirectoryName,
                testDirectoryName,
                labels.Values);

            return result;
        }

        /// <summary>
        /// Retrieves the full path to the base images directory.
        /// </summary>
        /// <returns>The combined path string if the base directory is set; otherwise, null.</returns>
        public string? GetDirectory_Images()
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                return null;
            }

            return Path.Combine(directory, Constants.DirectoryName.Images);
        }

        /// <summary>
        /// Retrieves the full path to the images directory for a specific category within a provided root directory.
        /// </summary>
        /// <param name="directory">The root directory path.</param>
        /// <param name="category">The category (e.g., Train, Validate, Test) to locate.</param>
        /// <returns>The combined path string if the root directory is valid; otherwise, null.</returns>
        public string? GetDirectory_Images(string? directory, Category category)
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                return null;
            }

            if (!directoryNames.TryGetValue(category, out string? directoryName))
            {
                directoryName = Query.DirectoryName(category);
            }

            string? result;
            if (!string.IsNullOrWhiteSpace(directoryName))
            {
                result = Path.Combine(directory, directoryName);
            }
            else
            {
                result = Path.Combine(directory, Constants.DirectoryName.Images, Query.DirectoryName(category));
            }

            return result;
        }

        /// <summary>
        /// Retrieves the full path to the images directory for the specified category using the model's current base directory.
        /// </summary>
        /// <param name="category">The category (e.g., Train, Validate, Test) to locate.</param>
        /// <returns>The combined path string if successful; otherwise, null.</returns>
        public string? GetDirectory_Images(Category category)
        {
            return GetDirectory_Images(directory, category);
        }

        /// <summary>
        /// Retrieves the full path to the labels directory by deriving it from the images directory path.
        /// </summary>
        /// <returns>The combined path string for labels if successful; otherwise, null.</returns>
        public string? GetDirectory_Labels()
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                return null;
            }

            string? directory_Images = GetDirectory_Images();

            string[]? values = directory_Images?.Replace('/', '\\').Split('\\');
            if (values == null)
            {
                return null;
            }

            int lastIndex = Array.LastIndexOf(values, Constants.DirectoryName.Images);

            if (lastIndex == -1)
            {
                return directory;
            }

            values[lastIndex] = Constants.DirectoryName.Labels;

            return string.Join("\\", values);
        }

/// <summary>
        /// Retrieves the labels directory path based on a provided image directory and category.
        /// </summary>
        /// <param name="directory">The base directory path to evaluate.</param>
        /// <param name="category">The category associated with the directories.</param>
        /// <returns>The calculated path to the labels directory, or <c>null</c> if the provided directory is null or whitespace.</returns>
        public string? GetDirectory_Labels(string? directory, Category category)
        {
            if (string.IsNullOrWhiteSpace(directory))
            {
                return null;
            }

            string? directory_Images = GetDirectory_Images(directory, category);

            string[]? values = directory_Images?.Replace('/', '\\').Split('\\');
            if (values == null)
            {
                return null;
            }

            int lastIndex = Array.LastIndexOf(values, Constants.DirectoryName.Images);

            if (lastIndex == -1)
            {
                return directory;
            }

            values[lastIndex] = Constants.DirectoryName.Labels;

            return string.Join("\\", values);
        }

        /// <summary>
        /// Retrieves the labels directory path for a specific category using the model's internal directory state.
        /// </summary>
        /// <param name="category">The category associated with the directories.</param>
        /// <returns>The calculated path to the labels directory, or <c>null</c>.</returns>
        public string? GetDirectory_Labels(Category category)
        {
            return GetDirectory_Labels(directory, category);
        }

        /// <summary>
        /// Retrieves an image object associated with the specified file path.
        /// </summary>
        /// <param name="path">The file path of the image.</param>
        /// <returns>The <see cref="Image"/> object if found in the model; otherwise, <c>null</c>.</returns>
        public Image? GetImage(string? path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            if (!images.TryGetValue(path!, out Image result))
            {
                return result;
            }

            return result;
        }

        /// <summary>
        /// Retrieves all images that belong to a specific category.
        /// </summary>
        /// <param name="category">The category used to filter the images.</param>
        /// <returns>An enumerable collection of <see cref="Image"/> objects belonging to the specified category.</returns>
        public IEnumerable<Image> GetImages(Category category)
        {
            List<Image> result = [];
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

        /// <summary>
        /// Retrieves the label file associated with the image at the specified path.
        /// </summary>
        /// <param name="path">The file path of the image.</param>
        /// <returns>The <see cref="LabelFile"/> object if found; otherwise, <c>null</c>.</returns>
        public LabelFile? GetLabelFile(string? path)
        {
            Image? image = GetImage(path);
            if (image == null)
            {
                return null;
            }

            return image?.GetLabelFile();
        }

        /// <summary>
        /// Retrieves a label based on its unique integer index.
        /// </summary>
        /// <param name="labelIndex">The index of the label to retrieve.</param>
        /// <returns>The <see cref="Label"/> object if found; otherwise, <c>null</c>.</returns>
        public Label? GetLabel(int labelIndex)
        {
            if (!labels.TryGetValue(labelIndex, out Label result) || result == null)
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Retrieves all labels defined within the model.
        /// </summary>
        /// <returns>An enumerable collection of all available <see cref="Label"/> objects.</returns>
        public IEnumerable<Label> GetLabels()
        {
            return labels.Values;
        }

        /// <summary>
        /// Retrieves all labels associated with the image at the specified path.
        /// </summary>
        /// <param name="path">The file path of the image.</param>
        /// <returns>An enumerable collection of <see cref="Label"/> objects associated with the image, or <c>null</c> if no labels are found.</returns>
        public IEnumerable<Label>? GetLabels(string? path)
        {
            IEnumerable<int>? labelIndexes = GetImage(path)?.LabelIndexes;
            if (labelIndexes == null)
            {
                return null;
            }

            List<Label> result = [];
            foreach (int labelIndex in labelIndexes)
            {
                if (labels.TryGetValue(labelIndex, out Label label) && label != null)
                {
                    result.Add(label);
                }
            }

            return result;
        }

        /// <summary>
        /// Retrieves the index of a label based on its name.
        /// </summary>
        /// <param name="labelName">The name of the label to search for.</param>
        /// <returns>The integer index of the label if found; otherwise, -1.</returns>
        public int LabelIndex(string? labelName)
        {
            foreach (KeyValuePair<int, Label> keyValuePair in labels)
            {
                if (keyValuePair.Value?.Name == labelName)
                {
                    return keyValuePair.Key;
                }
            }

            return -1;
        }
    }
}