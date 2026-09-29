namespace DiGi.YOLO.Constants
{
    /// <summary>
    /// Provides constant values for standard directory names used in YOLO dataset structures.
    /// </summary>
    public static class DirectoryName
    {
        /// <summary>
        /// The name of the directory containing image files.
        /// </summary>
        public const string Images = "images";

        /// <summary>
        /// The name of the directory containing label files.
        /// </summary>
        public const string Labels = "labels";

        /// <summary>
        /// The name of the directory containing YOLO deployment scripts and configuration files.
        /// </summary>
        public const string YOLO = "YOLO";

        /// <summary>
        /// The name of the directory holding the ultralytics settings isolated to the working directory a run executes in.
        /// <para>Each run points the YOLO_CONFIG_DIR environment variable at this folder, so the settings file an ultralytics version reads and writes lives in the working directory instead of the shared machine-wide one. Without it, switching ultralytics versions between runs rewrites the other's settings, prints a settings notice on stdout and loses custom values such as runs_dir.</para>
        /// </summary>
        public const string YoloConfig = ".yolo-config";
    }
}