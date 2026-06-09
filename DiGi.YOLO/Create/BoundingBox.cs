using DiGi.YOLO.Classes;

namespace DiGi.YOLO
{
    public static partial class Create
    {
        /// <summary>
        /// Creates a normalized BoundingBox based on the provided image dimensions and bounding box coordinates.
        /// </summary>
        /// <param name="imageWidth">The total width of the image.</param>
        /// <param name="imageHeight">The total height of the image.</param>
        /// <param name="topLeftX">The X-coordinate of the top-left corner of the bounding box.</param>
        /// <param name="topLeftY">The Y-coordinate of the top-left corner of the bounding box.</param>
        /// <param name="width">The width of the bounding box.</param>
        /// <param name="height">The height of the bounding box.</param>
        /// <returns>A normalized <see cref="BoundingBox"/> instance if all inputs are valid; otherwise, null.</returns>
        public static BoundingBox? BoundingBox(double imageWidth, double imageHeight, double topLeftX, double topLeftY, double width, double height)
        {
            if (double.IsNaN(imageWidth) ||
                double.IsNaN(imageHeight) ||
                double.IsNaN(topLeftX) ||
                double.IsNaN(topLeftY) ||
                double.IsNaN(width) ||
                double.IsNaN(height))
            {
                return null;
            }

            double centerX = topLeftX + (width / 2);
            double centerY = topLeftY + (height / 2);

            return new BoundingBox(centerX / imageWidth, centerY / imageHeight, width / imageWidth, height / imageHeight);
        }
    }
}