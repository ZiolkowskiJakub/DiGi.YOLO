namespace DiGi.YOLO
{
    public static partial class Query
    {
        /// <summary>
        /// Returns the directory name associated with the specified category.
        /// </summary>
        /// <param name="category">The category for which to retrieve the directory name.</param>
        /// <returns>A string representing the directory name (e.g., "val", "train", "test"), or <c>null</c> if no mapping is found.</returns>
        public static string? DirectoryName(this Enums.Category category)
        {
            switch (category)
            {
                case Enums.Category.Validate:
                    return "val";

                case Enums.Category.Train:
                    return "train";

                case Enums.Category.Test:
                    return "test";

                default:
                    break;
            }

            return null;
        }
    }
}