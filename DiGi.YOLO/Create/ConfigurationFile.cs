using DiGi.YOLO.Classes;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DiGi.YOLO
{
    public static partial class Create
    {
        public static ConfigurationFile ConfigurationFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                return null;
            }

            List<string> values = File.ReadAllLines(path).ToList();
            if (values == null || values.Count == 0)
            {
                return null;
            }

            string directory = null;
            string trainDirectoryName = null;
            string validateDirectoryName = null;
            string testDirectoryName = null;
            List<Tag> tags = new List<Tag>();

            int tagsIndex = -1;

            for (int i = 0; i < values.Count; i++)
            {
                string value = values[i].TrimStart();

                if(value.StartsWith("#"))
                {
                    continue;
                }

                if (value.StartsWith("path:"))
                {
                    directory = Query.Decode(value.Substring(5).Trim());
                }
                else if (value.StartsWith(Query.DirectoryName(Enums.Category.Validate)))
                {
                    validateDirectoryName = Query.Decode(value.Substring(4).Trim());
                }
                else if (value.StartsWith(Query.DirectoryName(Enums.Category.Train)))
                {
                    trainDirectoryName = Query.Decode(value.Substring(6).Trim());
                }
                else if (value.StartsWith(Query.DirectoryName(Enums.Category.Test)))
                {
                    testDirectoryName = Query.Decode(value.Substring(5).Trim());
                }
                else if (value.StartsWith("names:"))
                {
                    tagsIndex = i + 1;
                }
            }

            for (int i = tagsIndex; i < values.Count; i++)
            {
                string value = values[i].TrimStart();

                if (value.StartsWith("#"))
                {
                    continue;
                }


                int index = value.IndexOf(":");
                if(!int.TryParse(value.Substring(0, index), out int tagIndex))
                {
                    break;
                }

                tags.Add(new Tag(tagIndex, value.Substring(index + 1).TrimStart()));
            }


            return new ConfigurationFile(directory, trainDirectoryName, validateDirectoryName, testDirectoryName, tags);
        }
    }
}
