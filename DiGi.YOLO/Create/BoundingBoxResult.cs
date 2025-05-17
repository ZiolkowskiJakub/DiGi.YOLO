using DiGi.YOLO.Classes;

namespace DiGi.YOLO
{
    public static partial class Create
    {
        public static BoundingBoxResult BoundingBoxResult(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            string[] values = text.Split('\t');
            if (values == null || values.Length < 7)
            {
                return null;
            }

            string name = values[0];

            if (!int.TryParse(values[1], out int labelIndex))
            {
                return null;
            }

            if (!double.TryParse(values[2], out double x))
            {
                return null;
            }

            if (!double.TryParse(values[3], out double y))
            {
                return null;
            }

            if (!double.TryParse(values[4], out double width))
            {
                return null;
            }

            if (!double.TryParse(values[5], out double height))
            {
                return null;
            }

            if (!double.TryParse(values[6], out double confidence))
            {
                return null;
            }

            return new BoundingBoxResult(name, labelIndex, x, y, width, height, confidence);
        }
    }
}
