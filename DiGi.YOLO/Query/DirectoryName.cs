namespace DiGi.YOLO
{
    public static partial class Query
    {
        public static string DirectoryName(this Enums.Category category)
        {
            switch(category)
            {
                case Enums.Category.Validate:
                    return "val";

                case Enums.Category.Train:
                    return "train";

                case Enums.Category.Test:
                    return "test";
            }

            return null;
        }
    }
}
