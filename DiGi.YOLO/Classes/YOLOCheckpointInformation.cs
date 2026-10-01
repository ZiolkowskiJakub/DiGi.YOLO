using DiGi.Core.Classes;
using DiGi.YOLO.Interfaces;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.YOLO.Classes
{
    /// <summary>
    /// Describes an ultralytics training checkpoint read by <see cref="Query.YOLOCheckpointInformation(string?, string?, string?, System.Threading.CancellationToken)"/>: the epoch it completed, whether it can still be resumed, the dataset and run folder it records, and the raw arguments it was trained with.
    /// <para><see cref="Epoch"/> is reported 1-based - the number of epochs completed - although ultralytics stores the 0-based index of the last one. A checkpoint whose run finished, or that ultralytics wrote without optimizer state, reports <see cref="Finished"/>; a resumed run enters the epoch after <see cref="Epoch"/> and cannot change <see cref="Epochs"/>, the ceiling restored from the checkpoint.</para>
    /// </summary>
    public class YOLOCheckpointInformation : SerializableObject, IYOLOSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(BestFitness))]
        private readonly double? bestFitness;

        [JsonInclude, JsonPropertyName(nameof(DataPath))]
        private readonly string? dataPath;

        [JsonInclude, JsonPropertyName(nameof(Epoch))]
        private readonly int? epoch;

        [JsonInclude, JsonPropertyName(nameof(Epochs))]
        private readonly int? epochs;

        [JsonInclude, JsonPropertyName(nameof(Finished))]
        private readonly bool finished;

        [JsonInclude, JsonPropertyName(nameof(Name))]
        private readonly string? name;

        [JsonInclude, JsonPropertyName(nameof(Project))]
        private readonly string? project;

        [JsonInclude, JsonPropertyName(nameof(TrainArguments))]
        private readonly string? trainArguments;

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOCheckpointInformation"/> class with the specified values.
        /// </summary>
        /// <param name="bestFitness">The best validation fitness the checkpoint records, or <c>null</c> when unreadable.</param>
        /// <param name="dataPath">The dataset configuration file path the checkpoint records, or <c>null</c> when it records none.</param>
        /// <param name="epoch">The number of completed epochs (1-based), or <c>null</c> when the checkpoint records no epoch.</param>
        /// <param name="epochs">The epoch ceiling the checkpoint records, or <c>null</c> when it records none.</param>
        /// <param name="finished">A value indicating whether the checkpoint cannot be resumed: ultralytics stamped it finished or dropped its optimizer state.</param>
        /// <param name="name">The run directory name the checkpoint records, or <c>null</c> when it records none.</param>
        /// <param name="project">The run directory parent path the checkpoint records, or <c>null</c> when it records none.</param>
        /// <param name="trainArguments">The raw training arguments the checkpoint carries as a JSON object, serialized as text, or <c>null</c> when it carries none.</param>
        public YOLOCheckpointInformation(
            double? bestFitness,
            string? dataPath,
            int? epoch,
            int? epochs,
            bool finished,
            string? name,
            string? project,
            string? trainArguments)
        {
            this.bestFitness = bestFitness;
            this.dataPath = dataPath;
            this.epoch = epoch;
            this.epochs = epochs;
            this.finished = finished;
            this.name = name;
            this.project = project;
            this.trainArguments = trainArguments;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOCheckpointInformation"/> class by copying an existing information instance.
        /// </summary>
        /// <param name="yOLOCheckpointInformation">The source information instance to copy from.</param>
        public YOLOCheckpointInformation(YOLOCheckpointInformation? yOLOCheckpointInformation)
            : base(yOLOCheckpointInformation)
        {
            if (yOLOCheckpointInformation != null)
            {
                bestFitness = yOLOCheckpointInformation.bestFitness;
                dataPath = yOLOCheckpointInformation.dataPath;
                epoch = yOLOCheckpointInformation.epoch;
                epochs = yOLOCheckpointInformation.epochs;
                finished = yOLOCheckpointInformation.finished;
                name = yOLOCheckpointInformation.name;
                project = yOLOCheckpointInformation.project;
                trainArguments = yOLOCheckpointInformation.trainArguments;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOCheckpointInformation"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the checkpoint information.</param>
        public YOLOCheckpointInformation(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the best validation fitness the checkpoint records, or <c>null</c> when unreadable.
        /// </summary>
        [JsonIgnore]
        public double? BestFitness
        {
            get
            {
                return bestFitness;
            }
        }

        /// <summary>
        /// Gets the dataset configuration file path the checkpoint records, or <c>null</c> when it records none.
        /// <para>A resume is refused when this file no longer exists.</para>
        /// </summary>
        [JsonIgnore]
        public string? DataPath
        {
            get
            {
                return dataPath;
            }
        }

        /// <summary>
        /// Gets the number of epochs completed (1-based), or <c>null</c> when the checkpoint records no epoch.
        /// <para>A resumed run enters the next epoch and the consumers name it "epoch <see cref="Epoch"/> + 1 of <see cref="Epochs"/>".</para>
        /// </summary>
        [JsonIgnore]
        public int? Epoch
        {
            get
            {
                return epoch;
            }
        }

        /// <summary>
        /// Gets the epoch ceiling the checkpoint records, or <c>null</c> when it records none.
        /// <para>The ceiling is fixed by the checkpoint; a different one is a new run, not a resume.</para>
        /// </summary>
        [JsonIgnore]
        public int? Epochs
        {
            get
            {
                return epochs;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the checkpoint cannot be resumed: ultralytics stamped its epoch finished or dropped its optimizer state.
        /// </summary>
        [JsonIgnore]
        public bool Finished
        {
            get
            {
                return finished;
            }
        }

        /// <summary>
        /// Gets the run directory name the checkpoint records, or <c>null</c> when it records none.
        /// </summary>
        [JsonIgnore]
        public string? Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Gets the run directory parent path the checkpoint records, or <c>null</c> when it records none.
        /// <para>A resume whose project lies inside a YOLO\models folder is refused, as a fresh run is.</para>
        /// </summary>
        [JsonIgnore]
        public string? Project
        {
            get
            {
                return project;
            }
        }

        /// <summary>
        /// Gets the raw training arguments the checkpoint carries as a JSON object, or <c>null</c> when it carries none or they cannot be read.
        /// <para>Stored as JSON text so the object survives the serialization of this class; ultralytics restores every one of them on resume, so the runner passes none of them back.</para>
        /// </summary>
        [JsonIgnore]
        public JsonObject? TrainArguments
        {
            get
            {
                if (string.IsNullOrWhiteSpace(trainArguments))
                {
                    return null;
                }

                try
                {
                    return JsonNode.Parse(trainArguments!) as JsonObject;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
