using System;
using System.Collections.Generic;

namespace DiGi.YOLO.Classes
{
    /// <summary>
    /// Represents a label file containing associations between class indices and bounding boxes for an image.
    /// </summary>
    public class LabelFile
    {
        /// <summary>
        /// The collection of tuples pairing label indices with their corresponding bounding boxes.
        /// </summary>
        public List<Tuple<int, BoundingBox>> tuples = [];

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelFile"/> class.
        /// </summary>
        public LabelFile()
        {
        }

        /// <summary>
        /// Adds a label index and its associated bounding box to the collection.
        /// </summary>
        /// <param name="labelIndex">The integer index of the label.</param>
        /// <param name="boundingBox">The bounding box associated with the label.</param>
        /// <returns>True if the pair was successfully added; otherwise, false if the bounding box is null or the index is negative.</returns>
        public bool Add(int labelIndex, BoundingBox? boundingBox)
        {
            if (boundingBox == null || labelIndex < 0)
            {
                return false;
            }

            tuples.Add(new Tuple<int, BoundingBox>(labelIndex, boundingBox));
            return true;
        }

        /// <summary>
        /// Retrieves a set of all unique tag indices present in the label file.
        /// </summary>
        /// <returns>A <see cref="HashSet{T}"/> containing the unique label indices.</returns>
        public HashSet<int> GetTagIndexes()
        {
            HashSet<int> result = [];
            foreach (Tuple<int, BoundingBox> tuple in tuples)
            {
                if (tuple == null)
                {
                    continue;
                }

                result.Add(tuple.Item1);
            }

            return result;
        }

        /// <summary>
        /// Retrieves all bounding boxes associated with a specific label index.
        /// </summary>
        /// <param name="labelIndex">The label index to filter by.</param>
        /// <returns>A list of <see cref="BoundingBox"/> objects matching the specified label index.</returns>
        public List<BoundingBox> GetBoundingBoxes(int labelIndex)
        {
            List<BoundingBox> result = [];
            foreach (Tuple<int, BoundingBox> tuple in tuples)
            {
                if (tuple == null)
                {
                    continue;
                }

                if (tuple.Item1 != labelIndex)
                {
                    continue;
                }

                result.Add(tuple.Item2);
            }

            return result;
        }

        /// <summary>
        /// Gets the total number of entries in the label file.
        /// </summary>
        public int Count
        {
            get
            {
                return tuples == null ? 0 : tuples.Count;
            }
        }

        /// <summary>
        /// Retrieves the label index at the specified position.
        /// </summary>
        /// <param name="index">The zero-based index of the entry to retrieve.</param>
        /// <returns>The label index associated with the given position.</returns>
        public int GetLabelIndex(int index)
        {
            return tuples[index].Item1;
        }

        /// <summary>
        /// Retrieves the bounding box at the specified position.
        /// </summary>
        /// <param name="index">The zero-based index of the entry to retrieve.</param>
        /// <returns>The <see cref="BoundingBox"/> associated with the given position.</returns>
        public BoundingBox GetBoundingBox(int index)
        {
            return tuples[index].Item2;
        }

        /// <summary>
        /// Returns a string representation of the label file, formatted as space-separated values per line.
        /// </summary>
        /// <returns>A string containing the labels and bounding boxes separated by new lines.</returns>
        public override string ToString()
        {
            List<string> values = [];

            if (tuples != null)
            {
                foreach (Tuple<int, BoundingBox> tuple in tuples)
                {
                    string? value = tuple?.Item2?.ToString();
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        continue;
                    }

                    values.Add(string.Format("{0} {1}", tuple!.Item1, value));
                }
            }

            return string.Join(Environment.NewLine, values);
        }
    }
}