using System;
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
            for (int i = 0; i < standardOutput.Count; i++)
            {
                if (standardOutput[i].Trim() == Constants.Marker.CheckJsonBegin)
                {
                    for (int j = i + 1; j < standardOutput.Count; j++)
                    {
                        if (standardOutput[j].Trim() == Constants.Marker.CheckJsonEnd)
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
