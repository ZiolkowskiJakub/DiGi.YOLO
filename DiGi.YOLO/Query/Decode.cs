namespace DiGi.YOLO
{
    public static partial class Query
    {
        /// <summary>
        /// Decodes a given path string by replacing URL-encoded spaces with actual spaces and converting forward slashes to backslashes.
        /// </summary>
        /// <param name="path">The encoded path string to be decoded.</param>
        /// <returns>The decoded path string, or an empty string if the provided path is null or whitespace.</returns>
        public static string? Decode(string? path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return string.Empty;
            }

            return path!.Replace("%20", " ").Replace("/", @"\");
        }
    }
}