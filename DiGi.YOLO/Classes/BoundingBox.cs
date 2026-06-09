using DiGi.YOLO.Interfaces;

namespace DiGi.YOLO.Classes
{
    /// <summary>
    /// Represents a rectangular bounding box used to define the location and size of an object within an image.
    /// </summary>
    public class BoundingBox : IBoundingBox
    {
        private readonly double height;
        private readonly double width;
        private readonly double x;
        private readonly double y;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundingBox"/> class.
        /// </summary>
        /// <param name="x">The x-coordinate of the top-left corner of the bounding box.</param>
        /// <param name="y">The y-coordinate of the top-left corner of the bounding box.</param>
        /// <param name="width">The width of the bounding box.</param>
        /// <param name="height">The height of the bounding box.</param>
        public BoundingBox(double x, double y, double width, double height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Gets the height of the bounding box.
        /// </summary>
        public double Height
        {
            get
            {
                return height;
            }
        }

        /// <summary>
        /// Gets the width of the bounding box.
        /// </summary>
        public double Width
        {
            get
            {
                return width;
            }
        }

        /// <summary>
        /// Gets the x-coordinate of the top-left corner of the bounding box.
        /// </summary>
        public double X
        {
            get
            {
                return x;
            }
        }

        /// <summary>
        /// Gets the y-coordinate of the top-left corner of the bounding box.
        /// </summary>
        public double Y
        {
            get
            {
                return y;
            }
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current bounding box based on its coordinates and dimensions.
        /// </summary>
        /// <param name="object">The object to compare with the current bounding box.</param>
        /// <returns>True if the objects are equal; otherwise, false.</returns>
        public override bool Equals(object @object)
        {
            return @object != null && @object.GetType() == GetType() && ToString() == @object.ToString();
        }

        /// <summary>
        /// Returns a hash code for the current bounding box based on its string representation.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Returns a string that represents the current bounding box in the format "x y width height".
        /// </summary>
        /// <returns>A string representation of the bounding box.</returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", x, y, width, height);
        }
    }
}