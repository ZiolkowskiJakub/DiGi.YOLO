using DiGi.Core.Classes;
using DiGi.YOLO.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.YOLO.Classes
{
    /// <summary>
    /// Provides the settings one run of the YOLO prediction script needs: which interpreter runs it, which weights it scores with, which images it reads, and where it writes its results.
    /// <para>The constructors only assign. Use <see cref="Create.YOLOPredictionOptions(string?, string?, string?, string?, string?, double, int)"/> to resolve the interpreter, tidy the paths and reject a combination that cannot make a run.</para>
    /// </summary>
    public class YOLOPredictionOptions : SerializableOptions, IYOLOSerializableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOPredictionOptions"/> class with default values.
        /// </summary>
        public YOLOPredictionOptions()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOPredictionOptions"/> class by copying an existing options instance.
        /// </summary>
        /// <param name="yOLOPredictionOptions">The source options instance to copy from.</param>
        public YOLOPredictionOptions(YOLOPredictionOptions? yOLOPredictionOptions)
            : base(yOLOPredictionOptions)
        {
            if (yOLOPredictionOptions != null)
            {
                BatchSize = yOLOPredictionOptions.BatchSize;
                Confidence = yOLOPredictionOptions.Confidence;
                ModelPath = yOLOPredictionOptions.ModelPath;
                OutputPath = yOLOPredictionOptions.OutputPath;
                PythonPath = yOLOPredictionOptions.PythonPath;
                SourceDirectory = yOLOPredictionOptions.SourceDirectory;
                WorkingDirectory = yOLOPredictionOptions.WorkingDirectory;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOPredictionOptions"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the configuration settings.</param>
        public YOLOPredictionOptions(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets or sets the number of images passed to the prediction model in a single inference batch, passed to predict.py as --batch.
        /// <para>Batching amortizes Python call overhead and GPU kernel launches over multiple images. The default is 32. Turning it down reduces GPU memory usage.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(BatchSize))]
        public int BatchSize { get; set; } = 32;

        /// <summary>
        /// Gets or sets the confidence threshold a detection has to reach to be reported, passed to predict.py as --conf.
        /// <para>The default matches the script's own default. Lowering it returns more boxes and more false positives; the weights are frozen, so this is the only knob over how much the detector reports.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(Confidence))]
        public double Confidence { get; set; } = 0.1;

        /// <summary>
        /// Gets or sets the path of the trained weights file the prediction scores with, passed to predict.py as --model.
        /// <para>Left null the script falls back to its own search, which picks whichever training run is newest on disk. Name the file, so a run is reproducible.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(ModelPath))]
        public string? ModelPath { get; set; } = null;

        /// <summary>
        /// Gets or sets the path of the bounding box result file the prediction writes, passed to predict.py as --output.
        /// <para>The script opens it for writing rather than appending, so re-running a source directory replaces the previous answer instead of doubling it.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(OutputPath))]
        public string? OutputPath { get; set; } = null;

        /// <summary>
        /// Gets or sets the path of the CPython interpreter that runs the prediction script, or the name of one on PATH.
        /// <para>This has to be CPython with ultralytics and torch installed. The IronPython engine in DiGi.Scripting.Python cannot host either of them.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(PythonPath))]
        public string? PythonPath { get; set; } = null;

        /// <summary>
        /// Gets or sets the directory holding the images to score, passed to predict.py as --source.
        /// <para>The script reads the .jpg, .jpeg and .png files directly in the directory and does not descend into it.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(SourceDirectory))]
        public string? SourceDirectory { get; set; } = null;

        /// <summary>
        /// Gets or sets the directory the prediction process runs in, which is also where the runner keeps the Python scripts.
        /// <para>predict.py imports utils.py, and Python resolves that import against the directory the script itself sits in, so the two files have to stay together. The runner puts them there with <see cref="Modify.WriteScripts(string?)"/> when they are missing. Ultralytics also writes its own caches here.</para>
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(WorkingDirectory))]
        public string? WorkingDirectory { get; set; } = null;
    }
}
