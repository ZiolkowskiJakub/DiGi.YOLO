using DiGi.YOLO.Classes;
using System.Collections.Generic;
using System.IO;

namespace DiGi.YOLO
{
    public static partial class Modify
    {
        public static bool Append(this BoundingBoxResultFile boundingBoxResultFile, string path)
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

            File.AppendAllLines(path, values);
            return true;
        }
    }
}
