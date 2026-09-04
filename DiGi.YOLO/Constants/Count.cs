namespace DiGi.YOLO.Constants
{
    /// <summary>
    /// Provides constant counts used to bound the data collected while running the YOLO scripts.
    /// </summary>
    public static class Count
    {
        /// <summary>
        /// The number of trailing lines kept from each of the prediction process output streams.
        /// <para>predict.py prints a line for every image it processes and ultralytics prints more on top of that, so a county sized run writes megabytes to its output streams. Only the tail is kept, because that is the part carrying the reason a run ended the way it did.</para>
        /// </summary>
        public const int OutputLines = 200;
    }
}