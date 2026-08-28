using DiGi.YOLO.Classes;
using System.Globalization;

namespace DiGi.YOLO
{
    public static partial class Create
    {
        /// <summary>
        /// Parses a tab-separated string into a <see cref="BoundingBoxResult"/> object.
        /// <para>Numbers are read with <see cref="CultureInfo.InvariantCulture"/> because the file is written by predict.py and holds Python floats, which always use a decimal point. Reading them under the current culture rejects every line on a machine whose culture uses a comma, and the caller then sees an empty result rather than an error.</para>
        /// </summary>
        /// <param name="text">The tab-delimited string containing bounding box data (name, label index, x, y, width, height, and confidence).</param>
        /// <returns>A <see cref="BoundingBoxResult"/> instance if the input is valid; otherwise, <c>null</c>.</returns>
        public static BoundingBoxResult? BoundingBoxResult(string? text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            string[] values = text!.Split('\t');
            if (values == null || values.Length < 7)
            {
                return null;
            }

            string name = values[0];

            if (!int.TryParse(values[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out int labelIndex))
            {
                return null;
            }

            if (!double.TryParse(values[2], NumberStyles.Float, CultureInfo.InvariantCulture, out double x))
            {
                return null;
            }

            if (!double.TryParse(values[3], NumberStyles.Float, CultureInfo.InvariantCulture, out double y))
            {
                return null;
            }

            if (!double.TryParse(values[4], NumberStyles.Float, CultureInfo.InvariantCulture, out double width))
            {
                return null;
            }

            if (!double.TryParse(values[5], NumberStyles.Float, CultureInfo.InvariantCulture, out double height))
            {
                return null;
            }

            if (!double.TryParse(values[6], NumberStyles.Float, CultureInfo.InvariantCulture, out double confidence))
            {
                return null;
            }

            return new BoundingBoxResult(name, labelIndex, x, y, width, height, confidence);
        }
    }
}