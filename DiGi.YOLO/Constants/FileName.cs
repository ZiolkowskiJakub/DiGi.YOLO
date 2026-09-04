namespace DiGi.YOLO.Constants
{
    /// <summary>
    /// Provides constant values for file names used in YOLO runner scripts and configuration files.
    /// </summary>
    public static class FileName
    {
        /// <summary>
        /// The file name of the training runner script.
        /// </summary>
        public const string Train = "train.py";

        /// <summary>
        /// The file name of the prediction runner script.
        /// </summary>
        public const string Predict = "predict.py";

        /// <summary>
        /// The file name of the preflight check script.
        /// </summary>
        public const string Check = "check.py";

        /// <summary>
        /// The file name of the ONNX export script.
        /// </summary>
        public const string Export = "export.py";

        /// <summary>
        /// The file name of the utility script.
        /// </summary>
        public const string Utils = "utils.py";

        /// <summary>
        /// The file name of the Python dependencies requirements file.
        /// </summary>
        public const string Requirements = "requirements.txt";

        /// <summary>
        /// The file name of the dataset configuration YAML file.
        /// </summary>
        public const string Conf = "conf.yaml";
    }
}