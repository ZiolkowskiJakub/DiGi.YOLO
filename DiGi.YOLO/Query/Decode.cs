﻿namespace DiGi.YOLO
{
    public static partial class Query
    {
        public static string Decode(string path)
        {
            if(string.IsNullOrWhiteSpace(path))
            {
                return string.Empty;
            }

            return path.Replace("%20", " ").Replace("/", @"\");
        }
    }
}
