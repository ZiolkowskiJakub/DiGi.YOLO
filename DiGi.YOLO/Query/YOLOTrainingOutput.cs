using System.Collections.Generic;
using System.Globalization;

namespace DiGi.YOLO
{
    public static partial class Query
    {
        /// <summary>
        /// Reads the success block train.py prints at the end of a run - the path, size and SHA-256 digest of the best weights and the automatic mixed precision actually used - from its standard output.
        /// <para>The output is scanned from the end and the last line under each prefix wins. That is where the block is, and <see cref="ExecuteProcess(string, string, string, Dictionary{string, string}?, System.Threading.CancellationToken)"/> keeps only the tail of a stream, which a long run fills with training progress. Numbers are read with the invariant culture, the only form the script writes.</para>
        /// </summary>
        /// <param name="standardOutput">The lines train.py wrote to standard output.</param>
        /// <returns>The weights path, the size in bytes, the lowercase hexadecimal digest and the precision; each is <c>null</c> when its line is missing or cannot be read.</returns>
        public static (string? WeightsPath, long? Bytes, string? SHA256, bool? Amp) YOLOTrainingOutput(IEnumerable<string>? standardOutput)
        {
            string? weightsPath = null;
            long? bytes = null;
            string? sHA256 = null;
            bool? amp = null;

            if (standardOutput == null)
            {
                return (weightsPath, bytes, sHA256, amp);
            }

            List<string> lines = [.. standardOutput];

            for (int i = lines.Count - 1; i >= 0; i--)
            {
                string? line = lines[i]?.Trim();
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                if (weightsPath == null && line!.StartsWith(Constants.OutputPrefix.Weights))
                {
                    string value = line.Substring(Constants.OutputPrefix.Weights.Length).Trim();
                    weightsPath = value.Length == 0 ? null : value;
                }
                else if (bytes == null && line!.StartsWith(Constants.OutputPrefix.Bytes))
                {
                    if (long.TryParse(line.Substring(Constants.OutputPrefix.Bytes.Length).Trim(), NumberStyles.None, CultureInfo.InvariantCulture, out long value))
                    {
                        bytes = value;
                    }
                }
                else if (sHA256 == null && line!.StartsWith(Constants.OutputPrefix.SHA256))
                {
                    string value = line.Substring(Constants.OutputPrefix.SHA256.Length).Trim().ToLowerInvariant();
                    sHA256 = value.Length == 64 ? value : null;
                }
                else if (amp == null && line!.StartsWith(Constants.OutputPrefix.AMP))
                {
                    if (bool.TryParse(line.Substring(Constants.OutputPrefix.AMP.Length).Trim(), out bool value))
                    {
                        amp = value;
                    }
                }

                if (weightsPath != null && bytes != null && sHA256 != null && amp != null)
                {
                    break;
                }
            }

            return (weightsPath, bytes, sHA256, amp);
        }
    }
}
