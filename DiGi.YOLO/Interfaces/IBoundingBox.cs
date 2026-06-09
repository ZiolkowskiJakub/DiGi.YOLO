namespace DiGi.YOLO.Interfaces
{
    /// <summary>
    /// Defines a contract for a 2D bounding box used to specify the location and size of an object within an image.
    /// </summary>
    public interface IBoundingBox
    {
        /// <summary>
        /// Gets the x-coordinate of the top-left corner of the bounding box.
        /// </summary>
        public double X { get; }

        /// <summary>
        /// Gets the y-coordinate of the top-left corner of the bounding box.
        /// </summary>
        public double Y { get; }

        /// <summary>
        /// Gets the width of the bounding box.
        /// </summary>
        public double Width { get; }

        /// <summary>
        /// Gets the height of the bounding box.
        /// </summary>
        public double Height { get; }
    }
}