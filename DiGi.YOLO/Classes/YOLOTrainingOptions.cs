using DiGi.Core.Classes;
using DiGi.YOLO.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.YOLO.Classes
{
    /// <summary>
    /// Provides the settings one run of the YOLO training script needs: which interpreter runs it, which start weights and dataset it trains from, the training hyperparameters, and where the run directory is created.
    /// <para>The constructors only assign. Use <see cref="Create.YOLOTrainingOptions(string?, string?, string?, string?)"/> to resolve the interpreter, tidy the paths and reject a combination that cannot make a run.</para>
    /// </summary>
    public class YOLOTrainingOptions : SerializableOptions, IYOLOSerializableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOTrainingOptions"/> class with default values.
        /// </summary>
        public YOLOTrainingOptions()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOTrainingOptions"/> class by copying an existing options instance.
        /// </summary>
        /// <param name="yOLOTrainingOptions">The source options instance to copy from.</param>
        public YOLOTrainingOptions(YOLOTrainingOptions? yOLOTrainingOptions)
            : base(yOLOTrainingOptions)
        {
            if (yOLOTrainingOptions != null)
            {
                Amp = yOLOTrainingOptions.Amp;
                Batch = yOLOTrainingOptions.Batch;
                ConfigurationFilePath = yOLOTrainingOptions.ConfigurationFilePath;
                Device = yOLOTrainingOptions.Device;
                Epochs = yOLOTrainingOptions.Epochs;
                ImageSize = yOLOTrainingOptions.ImageSize;
                ModelPath = yOLOTrainingOptions.ModelPath;
                Name = yOLOTrainingOptions.Name;
                Patience = yOLOTrainingOptions.Patience;
                Project = yOLOTrainingOptions.Project;
                PythonPath = yOLOTrainingOptions.PythonPath;
                Seed = yOLOTrainingOptions.Seed;
                WorkingDirectory = yOLOTrainingOptions.WorkingDirectory;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOTrainingOptions"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the configuration settings.</param>
        public YOLOTrainingOptions(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets or sets whether automatic mixed precision is requested, passed to train.py as --amp or --no-amp.
        /// <para>The default is on. ultralytics checks AMP before training by downloading yolo26n.pt into the "weights" folder of the working directory; when that fails - offline - it silently trains in full precision. <see cref="YOLOTrainingResult.Amp"/> reports what was actually used.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Amp))]
        public bool Amp { get; set; } = true;

        /// <summary>
        /// Gets or sets the training batch size, passed to train.py as --batch. The default is 16, the batch train8 used.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Batch))]
        public int Batch { get; set; } = 16;

        /// <summary>
        /// Gets or sets the absolute path of the dataset configuration file (conf.yaml), passed to train.py as --data.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(ConfigurationFilePath))]
        public string? ConfigurationFilePath { get; set; } = null;

        /// <summary>
        /// Gets or sets the device to train on, such as "0", "0,1" or "cpu", passed to train.py as --device. Null lets ultralytics choose.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Device))]
        public string? Device { get; set; } = null;

        /// <summary>
        /// Gets or sets the upper bound of training epochs, passed to train.py as --epochs. With <see cref="Patience"/> the run stops earlier when validation stops improving. The default is 150.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Epochs))]
        public int Epochs { get; set; } = 150;

        /// <summary>
        /// Gets or sets the square training image size, passed to train.py as --imgsz. The default is 640, the size inference and the ONNX export use.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(ImageSize))]
        public int ImageSize { get; set; } = 640;

        /// <summary>
        /// Gets or sets the absolute path of the start weights, passed to train.py as --model: a checkpoint (.pt) - model.pt to continue train8, or a base checkpoint such as yolo26x.pt - or an architecture definition (.yaml) for random initialisation.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(ModelPath))]
        public string? ModelPath { get; set; } = null;

        /// <summary>
        /// Gets or sets the name of the run directory, passed to train.py as --name, such as "train9_fresh". Null uses the ultralytics default ("train", numbered when taken).
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Name))]
        public string? Name { get; set; } = null;

        /// <summary>
        /// Gets or sets the number of epochs without validation improvement after which training stops, passed to train.py as --patience. The default is 50.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Patience))]
        public int Patience { get; set; } = 50;

        /// <summary>
        /// Gets or sets the absolute path of the directory the run directory is created in, passed to train.py as --project.
        /// <para>Always passed explicitly: an interpreter from a virtual environment can resolve the ultralytics default runs directory against the repository its package sits in rather than against the working directory.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Project))]
        public string? Project { get; set; } = null;

        /// <summary>
        /// Gets or sets the path of the CPython interpreter that runs the script.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(PythonPath))]
        public string? PythonPath { get; set; } = null;

        /// <summary>
        /// Gets or sets the random seed, passed to train.py as --seed. The default is 0, the seed train8 used; both candidates of a comparison use the same one.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Seed))]
        public int Seed { get; set; } = 0;

        /// <summary>
        /// Gets or sets the directory the process runs in and the scripts are kept in.
        /// <para>train.py imports utils.py, and Python resolves that import against the directory the script itself sits in, so the two files have to stay together. The ultralytics settings of the run are isolated in its .yolo-config folder.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(WorkingDirectory))]
        public string? WorkingDirectory { get; set; } = null;
    }
}
