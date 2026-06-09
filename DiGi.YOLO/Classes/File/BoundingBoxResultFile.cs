using System;
using System.Collections.Generic;

namespace DiGi.YOLO.Classes
{
    /// <summary>
    /// Represents a collection of bounding box results typically associated with a result file.
    /// </summary>
    public class BoundingBoxResultFile : List<BoundingBoxResult>
    {
        /// <summary>
        /// Gets or sets the list of bounding box results.
        /// </summary>
        public List<BoundingBoxResult> boundingBoxResults = [];

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundingBoxResultFile"/> class.
        /// </summary>
        public BoundingBoxResultFile()
        {
        }

        /// <summary>
        /// Returns a string representation of the bounding box results contained in the file, 
        /// with each result on a new line.
        /// </summary>
        /// <returns>A string containing the concatenated string representations of all valid bounding box results.</returns>
        public override string? ToString()
        {
            List<string> values = [];

            if (boundingBoxResults != null)
            {
                foreach (BoundingBoxResult boundingBoxResult in boundingBoxResults)
                {
                    string? value = boundingBoxResult?.ToString();
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        continue;
                    }

                    values.Add(value!);
                }
            }

            return string.Join(Environment.NewLine, values);
        }
    }
}