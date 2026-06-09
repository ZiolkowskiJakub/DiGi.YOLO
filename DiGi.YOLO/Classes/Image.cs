using DiGi.YOLO.Interfaces;
using System.Collections.Generic;

namespace DiGi.YOLO.Classes
{
    /// <summary>
    /// Represents an image associated with a collection of bounding boxes categorized by label indices.
    /// </summary>
    /// <typeparam name="TBoundingBox">The type of the bounding box, which must implement <see cref="IBoundingBox"/>.</typeparam>
    public class Image<TBoundingBox> where TBoundingBox : IBoundingBox
    {
        /// <summary>
        /// The dictionary containing bounding boxes grouped by label indices.
        /// </summary>
        protected Dictionary<int, HashSet<TBoundingBox>> boundingBoxes = [];

        /// <summary>
        /// The file path to the image.
        /// </summary>
        protected string? path;

        /// <summary>
        /// Initializes a new instance of the <see cref="Image{TBoundingBox}"/> class.
        /// </summary>
        /// <param name="path">The file path to the image.</param>
        public Image(string? path)
        {
            this.path = path;
        }

        /// <summary>
        /// Gets the file path of the image.
        /// </summary>
        public string? Path
        {
            get
            {
                return path;
            }
        }

        /// <summary>
        /// Gets the collection of label indices that have associated bounding boxes in this image.
        /// </summary>
        public IEnumerable<int> LabelIndexes
        {
            get
            {
                return boundingBoxes.Keys;
            }
        }

        /// <summary>
        /// Gets the set of bounding boxes associated with the specified label index.
        /// </summary>
        /// <param name="labelIndex">The index of the label to retrieve bounding boxes for.</param>
        /// <returns>An enumerable of bounding boxes for the given label index, or null if no bounding boxes exist for that label.</returns>
        public IEnumerable<TBoundingBox>? this[int labelIndex]
        {
            get
            {
                if (!boundingBoxes.TryGetValue(labelIndex, out HashSet<TBoundingBox> result))
                {
                    return null;
                }

                return result;
            }
        }

        /// <summary>
        /// Adds a bounding box to the image for the specified label index.
        /// </summary>
        /// <param name="labelIndex">The index of the label.</param>
        /// <param name="boundingBox">The bounding box instance to add.</param>
        /// <returns>True if the bounding box was successfully added; otherwise, false.</returns>
        public bool Add(int labelIndex, TBoundingBox? boundingBox)
        {
            if (boundingBox == null)
            {
                return false;
            }

            if (!boundingBoxes.TryGetValue(labelIndex, out HashSet<TBoundingBox> boundingBoxes_Temp) || boundingBoxes_Temp == null)
            {
                boundingBoxes_Temp = [];
                boundingBoxes[labelIndex] = boundingBoxes_Temp;
            }

            return boundingBoxes_Temp.Add(boundingBox);
        }
    }

    /// <summary>
    /// Represents an image associated with a collection of <see cref="BoundingBox"/> instances.
    /// </summary>
    public class Image : Image<BoundingBox>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        /// <param name="path">The file path to the image.</param>
        public Image(string? path)
            : base(path)
        {
        }

        /// <summary>
        /// Creates and populates a <see cref="LabelFile"/> containing all bounding boxes associated with this image.
        /// </summary>
        /// <returns>A <see cref="LabelFile"/> instance populated with the image's bounding box data.</returns>
        public LabelFile GetLabelFile()
        {
            LabelFile result = new();

            foreach (KeyValuePair<int, HashSet<BoundingBox>> keyValuePair in boundingBoxes)
            {
                if (keyValuePair.Value == null)
                {
                    continue;
                }

                foreach (BoundingBox boundingBox in keyValuePair.Value)
                {
                    result.Add(keyValuePair.Key, boundingBox);
                }
            }

            return result;
        }
    }
}