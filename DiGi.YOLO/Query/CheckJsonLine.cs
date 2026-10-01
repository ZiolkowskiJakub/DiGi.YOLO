using System.Collections.Generic;

namespace DiGi.YOLO
{
    public static partial class Query
    {
        /// <summary>
        /// Finds the JSON payload line of a check.py run in its captured stdout.
        /// <para>The payload is the first non-empty line between the <see cref="Constants.Marker.CheckJsonBegin"/> and <see cref="Constants.Marker.CheckJsonEnd"/> markers, so the result does not depend on what the interpreter or ultralytics print before or after it - a settings notice included.</para>
        /// </summary>
        /// <param name="standardOutput">The captured stdout lines of the run.</param>
        /// <returns>The JSON payload line, or <c>null</c> when the markers or the payload between them are absent.</returns>
        public static string? CheckJsonLine(List<string> standardOutput)
        {
            return CheckJsonLine(standardOutput, Constants.Marker.CheckJsonBegin, Constants.Marker.CheckJsonEnd);
        }

        /// <summary>
        /// Finds the JSON payload line a YOLO script writes between a pair of marker lines in its captured stdout.
        /// <para>The payload is the first non-empty line between the begin and end markers, so the result does not depend on what the interpreter, ultralytics or the script print before or after it - a settings notice included. check.py and checkpoint.py share this contract with different marker pairs.</para>
        /// </summary>
        /// <param name="standardOutput">The captured stdout lines of the run.</param>
        /// <param name="beginMarker">The marker line the script prints immediately before its JSON payload.</param>
        /// <param name="endMarker">The marker line the script prints immediately after its JSON payload.</param>
        /// <returns>The JSON payload line, or <c>null</c> when the markers or the payload between them are absent.</returns>
        public static string? CheckJsonLine(List<string> standardOutput, string beginMarker, string endMarker)
        {
            for (int i = 0; i < standardOutput.Count; i++)
            {
                if (standardOutput[i].Trim() == beginMarker)
                {
                    for (int j = i + 1; j < standardOutput.Count; j++)
                    {
                        if (standardOutput[j].Trim() == endMarker)
                        {
                            break;
                        }

                        if (!string.IsNullOrWhiteSpace(standardOutput[j]))
                        {
                            return standardOutput[j].Trim();
                        }
                    }
                }
            }

            return null;
        }
    }
}
