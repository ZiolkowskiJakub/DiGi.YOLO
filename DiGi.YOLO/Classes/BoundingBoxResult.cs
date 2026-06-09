namespace DiGi.YOLO.Classes
{
    /// <summary>
    /// Represents the result of a bounding box detection, containing spatial coordinates, label information, and confidence score.
    /// </summary>
    public class BoundingBoxResult : BoundingBox
    {
        private readonly double confidence;
        private readonly int labelIndex;
        private readonly string? name;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundingBoxResult"/> class.
        /// </summary>
        /// <param name="name">The name of the detected object.</param>
        /// <param name="labelIndex">The index of the label associated with the detection.</param>
        /// <param name="x">The X coordinate of the bounding box.</param>
        /// <param name="y">The Y coordinate of the bounding box.</param>
        /// <param name="width">The width of the bounding box.</param>
        /// <param name="height">The height of the bounding box.</param>
        /// <param name="confidence">The confidence score of the detection.</param>
        public BoundingBoxResult(string? name, int labelIndex, double x, double y, double width, double height, double confidence)
            : base(x, y, width, height)
        {
            this.name = name;
            this.labelIndex = labelIndex;
            this.confidence = confidence;
        }

        /// <summary>
        /// Gets the confidence score of the detected object.
        /// </summary>
        public double Confidence
        {
            get
            {
                return confidence;
            }
        }

        /// <summary>
        /// Gets the index of the label for the detected object.
        /// </summary>
        public int LabelIndex
        {
            get
            {
                return labelIndex;
            }
        }

        /// <summary>
        /// Gets the name of the detected object.
        /// </summary>
        public string? Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current bounding box result based on its string representation.
        /// </summary>
        /// <param name="object">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the objects are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object @object)
        {
            return @object != null && @object.GetType() == GetType() && ToString() == @object.ToString();
        }

        /// <summary>
        /// Gets the hash code for the current bounding box result.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Returns a string representation of the bounding box result, including name, label index, coordinates, dimensions, and confidence.
        /// </summary>
        /// <returns>A tab-separated string containing the detection details.</returns>
        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", name, labelIndex, X, Y, Width, Height, confidence);
        }
    }
}