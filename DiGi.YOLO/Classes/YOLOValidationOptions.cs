using DiGi.Core.Classes;
using DiGi.YOLO.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.YOLO.Classes
{
    /// <summary>
    /// Provides the settings one run of the YOLO validation script needs: which interpreter runs it, which weights it validates, and on which split of which dataset.
    /// <para>The constructors only assign. Use <see cref="Create.YOLOValidationOptions(string?, string?, string?, string?)"/> to resolve the interpreter, tidy the paths and reject a combination that cannot make a run.</para>
    /// </summary>
    public class YOLOValidationOptions : SerializableOptions, IYOLOSerializableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOValidationOptions"/> class with default values.
        /// </summary>
        public YOLOValidationOptions()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOValidationOptions"/> class by copying an existing options instance.
        /// </summary>
        /// <param name="yOLOValidationOptions">The source options instance to copy from.</param>
        public YOLOValidationOptions(YOLOValidationOptions? yOLOValidationOptions)
            : base(yOLOValidationOptions)
        {
            if (yOLOValidationOptions != null)
            {
                Batch = yOLOValidationOptions.Batch;
                Confidence = yOLOValidationOptions.Confidence;
                ConfigurationFilePath = yOLOValidationOptions.ConfigurationFilePath;
                Device = yOLOValidationOptions.Device;
                ImageSize = yOLOValidationOptions.ImageSize;
                ModelPath = yOLOValidationOptions.ModelPath;
                PythonPath = yOLOValidationOptions.PythonPath;
                Split = yOLOValidationOptions.Split;
                WorkingDirectory = yOLOValidationOptions.WorkingDirectory;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOValidationOptions"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the configuration settings.</param>
        public YOLOValidationOptions(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets or sets the validation batch size, passed to val.py as --batch. The default is 16.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Batch))]
        public int Batch { get; set; } = 16;

        /// <summary>
        /// Gets or sets the confidence threshold, passed to val.py as --conf. Null uses the ultralytics validation default, which is what mAP is normally reported at.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Confidence))]
        public double? Confidence { get; set; } = null;

        /// <summary>
        /// Gets or sets the absolute path of the dataset configuration file (conf.yaml), passed to val.py as --data.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(ConfigurationFilePath))]
        public string? ConfigurationFilePath { get; set; } = null;

        /// <summary>
        /// Gets or sets the device to validate on, such as "0" or "cpu", passed to val.py as --device. Null lets ultralytics choose.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Device))]
        public string? Device { get; set; } = null;

        /// <summary>
        /// Gets or sets the square validation image size, passed to val.py as --imgsz. The default is 640.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(ImageSize))]
        public int ImageSize { get; set; } = 640;

        /// <summary>
        /// Gets or sets the absolute path of the weights file to validate, passed to val.py as --model.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(ModelPath))]
        public string? ModelPath { get; set; } = null;

        /// <summary>
        /// Gets or sets the path of the CPython interpreter that runs the script.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(PythonPath))]
        public string? PythonPath { get; set; } = null;

        /// <summary>
        /// Gets or sets the dataset split to validate on, passed to val.py as --split. <see cref="Enums.Category.Test"/> by default; <see cref="Enums.Category.Train"/> is not a validation split and is rejected by the factory.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Split))]
        public Enums.Category Split { get; set; } = Enums.Category.Test;

        /// <summary>
        /// Gets or sets the directory the process runs in and the scripts are kept in. The ultralytics settings of the run are isolated in its .yolo-config folder.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(WorkingDirectory))]
        public string? WorkingDirectory { get; set; } = null;
    }
}
