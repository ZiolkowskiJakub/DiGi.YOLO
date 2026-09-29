namespace DiGi.YOLO.Constants
{
    /// <summary>
    /// Provides constant values for the stdout contract of the preflight check script.
    /// </summary>
    public static class Marker
    {
        /// <summary>
        /// The line check.py prints immediately before its JSON payload.
        /// <para>The payload is the first non-empty line between this marker and <see cref="CheckJsonEnd"/>, so a caller finds it without depending on what the interpreter or ultralytics print first - a settings notice included. The markers and their use are stated in check.py in files/YOLO.</para>
        /// </summary>
        public const string CheckJsonBegin = "YOLO_CHECK_JSON_BEGIN";

        /// <summary>
        /// The line check.py prints immediately after its JSON payload.
        /// <para>Paired with <see cref="CheckJsonBegin"/>; see check.py in files/YOLO.</para>
        /// </summary>
        public const string CheckJsonEnd = "YOLO_CHECK_JSON_END";
    }
}
