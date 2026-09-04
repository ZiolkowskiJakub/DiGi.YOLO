using DiGi.YOLO.Classes;
using System.Collections.Generic;
using System.IO;

namespace DiGi.YOLO
{
    public static partial class Create
    {
        /// <summary>
        /// Reads a file from the specified path and parses its contents into a <see cref="Classes.BoundingBoxResultFile"/> collection.
        /// </summary>
        /// <param name="path">The file system path to the bounding box result file.</param>
        /// <returns>A <see cref="Classes.BoundingBoxResultFile"/> instance containing the parsed results if the file exists and is valid; otherwise, <c>null</c>.</returns>
        public static BoundingBoxResultFile? BoundingBoxResultFile(string? path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                return null;
            }

            return BoundingBoxResultFile(File.ReadAllLines(path));
        }

        /// <summary>
        /// Parses lines of a bounding box result file into a <see cref="Classes.BoundingBoxResultFile"/> collection.
        /// <para>Lines that do not hold a complete detection are skipped rather than rejecting the whole file. predict.py writes one such line, holding only the image name, for every image it scored and found nothing on.</para>
        /// </summary>
        /// <param name="values">The lines to parse.</param>
        /// <returns>A <see cref="Classes.BoundingBoxResultFile"/> instance containing the parsed results, or <c>null</c> when there are no lines to parse.</returns>
        public static BoundingBoxResultFile? BoundingBoxResultFile(IEnumerable<string>? values)
        {
            if (values == null)
            {
                return null;
            }

            BoundingBoxResultFile result = [];

            foreach (string value in values)
            {
                BoundingBoxResult? boundingBoxResult = BoundingBoxResult(value);
                if (boundingBoxResult == null)
                {
                    continue;
                }

                result.Add(boundingBoxResult);
            }

            return result;
        }

        /// <summary>
        /// Parses the detections a prediction run produced into a <see cref="Classes.BoundingBoxResultFile"/> collection.
        /// </summary>
        /// <param name="yOLOPredictionResult">The result of the prediction run.</param>
        /// <returns>A <see cref="Classes.BoundingBoxResultFile"/> instance containing the parsed results, or <c>null</c> when the run did not complete or produced no result file.</returns>
        public static BoundingBoxResultFile? BoundingBoxResultFile(this YOLOPredictionResult? yOLOPredictionResult)
        {
            if (yOLOPredictionResult == null || !yOLOPredictionResult.Succeeded)
            {
                return null;
            }

            return BoundingBoxResultFile(yOLOPredictionResult.Values);
        }
    }
}