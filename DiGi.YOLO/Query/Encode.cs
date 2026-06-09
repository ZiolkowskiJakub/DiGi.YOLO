namespace DiGi.YOLO
{
    public static partial class Query
    {
        /// <summary>
        /// Encodes a given path string by replacing spaces with "%20" and backslashes with forward slashes.
        /// </summary>
        /// <param name="path">The path string to be encoded. This value can be null.</param>
        /// <returns>An encoded version of the path, or an empty string if the provided path is null or whitespace.</returns>
        public static string Encode(string? path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return string.Empty;
            }

            return path!.Replace(" ", "%20").Replace(@"\", "/");
        }
    }
}