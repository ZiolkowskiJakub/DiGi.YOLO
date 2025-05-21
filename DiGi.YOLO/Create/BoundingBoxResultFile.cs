using DiGi.YOLO.Classes;
using System.IO;

namespace DiGi.YOLO
{
    public static partial class Create
    {
        public static BoundingBoxResultFile BoundingBoxResultFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                return null;
            }

            BoundingBoxResultFile result = new BoundingBoxResultFile();

            string[] values = File.ReadAllLines(path);
            if (values != null && values.Length != 0)
            {
                foreach (string value in values)
                {
                    BoundingBoxResult boundingBoxResult = BoundingBoxResult(value);
                    if (boundingBoxResult == null)
                    {
                        continue;
                    }

                    result.Add(boundingBoxResult);
                }
            }

            return result;
        }
    }
}
