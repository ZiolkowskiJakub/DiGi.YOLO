using DiGi.YOLO.Classes;

namespace DiGi.YOLO
{
    public static partial class Create
    {
        public static BoundingBox BoundingBox(double imageWidth, double imageHeight, double topLeftX, double topLeftY, double width, double height)
        {
            if(double.IsNaN(imageWidth) ||
                double.IsNaN(imageHeight) ||
                double.IsNaN(topLeftX) ||
                double.IsNaN(topLeftY) ||
                double.IsNaN(width) ||
                double.IsNaN(height))
            {
                return null;
            }

            double centerX = topLeftX  + (width / 2);
            double centerY = topLeftY - (height / 2);

            return new BoundingBox(centerX / imageWidth, centerY / imageHeight, width / imageWidth, height / imageHeight);
        }
    }
}
