using DiGi.YOLO.Classes;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DiGi.YOLO
{
    public static partial class Create
    {
        public static LabelFile LabelFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                return null;
            }

            List<string> lines = File.ReadAllLines(path).ToList();
            if (lines == null || lines.Count == 0)
            {
                return null;
            }

            LabelFile result = new LabelFile();
            foreach(string line in lines)
            {
                string[] values = line.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries);
                if(values.Length < 5)
                {
                    continue;
                }

                if(!int.TryParse(values[0], out int tagIndex))
                {
                    continue;
                }

                if (!double.TryParse(values[1], out double x))
                {
                    continue;
                }

                if (!double.TryParse(values[2], out double y))
                {
                    continue;
                }

                if (!double.TryParse(values[3], out double width))
                {
                    continue;
                }

                if (!double.TryParse(values[4], out double height))
                {
                    continue;
                }

                result.Add(tagIndex, new Classes.BoundingBox(x, y, width, height));
            }

            return result;

        }
    }
}
