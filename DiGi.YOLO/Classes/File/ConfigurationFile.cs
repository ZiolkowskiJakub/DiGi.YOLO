using DiGi.YOLO.Enums;
using System;
using System.Collections.Generic;

namespace DiGi.YOLO.Classes
{
    public class ConfigurationFile
    {
        private string directory;
        private Dictionary<Category, string> directoryNames = new Dictionary<Category, string>();
        private HashSet<Label> labels = new HashSet<Label>();

        public ConfigurationFile() 
        { 
        }

        public ConfigurationFile(string directory, string trainDirectoryName, string validateDirectoryName, string testDirectoryName, IEnumerable<Label> labels) 
        {
            this.directory = directory;
            
            directoryNames[Category.Train] = trainDirectoryName;
            directoryNames[Category.Validate] = validateDirectoryName;
            directoryNames[Category.Test] = testDirectoryName;

            if(labels != null)
            {
                foreach (Label label in labels)
                {
                    if(label == null)
                    {
                        continue;
                    }

                    this.labels.Add(label);
                }
            }
        }

        public string Directory
        {
            get
            {
                return directory;
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            return directoryNames.Keys;
        }

        public string GetDirectory(Category category)
        {
            if(!directoryNames.TryGetValue(category, out string directoryNames_Temp) || string.IsNullOrWhiteSpace(directoryNames_Temp))
            {
                return null;
            }

            return System.IO.Path.Combine(directory, directoryNames_Temp);
        }

        public string GetDirectoryNames(Category category)
        {
            if (!directoryNames.TryGetValue(category, out string result) || string.IsNullOrWhiteSpace(result))
            {
                return null;
            }

            return result;
        }

        public IEnumerable<Label> Labels
        {
            get
            {
                return labels;
            }
        }
        
        public override string ToString()
        {
            List<string> values = new List<string>();
            values.Add(string.Format("path: {0}", Query.Encode(directory)));
            foreach(Category category in Enum.GetValues(typeof(Category)))
            {
                if(!directoryNames.TryGetValue(category, out string directoryName))
                {
                    directoryName = string.Empty;
                }

                values.Add(string.Format("{0}: {1}", category.DirectoryName(), Query.Encode(directoryName)));
            }

            values.Add("names:");
            foreach(Label label in labels)
            {
                if(label == null)
                {
                    continue;
                }
                values.Add(string.Format("   {0}", label.ToString()));
            }

            return string.Join(Environment.NewLine, values);
        }
    }
}
