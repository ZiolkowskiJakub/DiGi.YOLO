using DiGi.Core.Classes;
using DiGi.YOLO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.YOLO.Classes
{
    /// <summary>
    /// Represents the preflight check result of probing the CPython environment and YOLO dependencies on a machine.
    /// <para>Reports whether the interpreter can run YOLO, its version, installed dependency versions, CUDA availability, model compatibility, and any diagnostic messages explaining why the environment is not runnable.</para>
    /// </summary>
    public class YOLOEnvironmentResult : SerializableResult, IYOLOSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Checked))]
        private readonly DateTimeOffset? checkedTime;

        [JsonInclude, JsonPropertyName(nameof(CudaAvailable))]
        private readonly bool? cudaAvailable;

        [JsonInclude, JsonPropertyName(nameof(Messages))]
        private readonly List<string>? messages;

        [JsonInclude, JsonPropertyName(nameof(ModelPath))]
        private readonly string? modelPath;

        [JsonInclude, JsonPropertyName(nameof(ModelUltralyticsVersion))]
        private readonly string? modelUltralyticsVersion;

        [JsonInclude, JsonPropertyName(nameof(PythonPath))]
        private readonly string? pythonPath;

        [JsonInclude, JsonPropertyName(nameof(PythonVersion))]
        private readonly string? pythonVersion;

        [JsonInclude, JsonPropertyName(nameof(Runnable))]
        private readonly bool runnable;

        [JsonInclude, JsonPropertyName(nameof(TorchVersion))]
        private readonly string? torchVersion;

        [JsonInclude, JsonPropertyName(nameof(UltralyticsVersion))]
        private readonly string? ultralyticsVersion;

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOEnvironmentResult"/> class.
        /// </summary>
        /// <param name="runnable">A value indicating whether the probed Python interpreter can execute YOLO prediction workloads.</param>
        /// <param name="pythonPath">The full path of the Python interpreter that was probed.</param>
        /// <param name="pythonVersion">The Python version reported by the interpreter.</param>
        /// <param name="ultralyticsVersion">The installed version of the ultralytics package, or <c>null</c> when import failed.</param>
        /// <param name="torchVersion">The installed version of PyTorch, or <c>null</c> when import failed.</param>
        /// <param name="cudaAvailable">A value indicating whether PyTorch reports CUDA acceleration available.</param>
        /// <param name="modelPath">The path of the model checkpoint probed, or <c>null</c> when none was provided.</param>
        /// <param name="modelUltralyticsVersion">The ultralytics version recorded inside the model checkpoint, or <c>null</c> when unreadable.</param>
        /// <param name="messages">The diagnostic messages detailing why the environment is not runnable or warnings encountered.</param>
        /// <param name="checkedTime">The moment the preflight probe completed.</param>
        public YOLOEnvironmentResult(
            bool runnable,
            string? pythonPath,
            string? pythonVersion,
            string? ultralyticsVersion,
            string? torchVersion,
            bool? cudaAvailable,
            string? modelPath,
            string? modelUltralyticsVersion,
            IEnumerable<string>? messages,
            DateTimeOffset? checkedTime)
        {
            this.runnable = runnable;
            this.pythonPath = pythonPath;
            this.pythonVersion = pythonVersion;
            this.ultralyticsVersion = ultralyticsVersion;
            this.torchVersion = torchVersion;
            this.cudaAvailable = cudaAvailable;
            this.modelPath = modelPath;
            this.modelUltralyticsVersion = modelUltralyticsVersion;
            this.messages = messages == null ? null : new List<string>(messages);
            this.checkedTime = checkedTime;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOEnvironmentResult"/> class by copying an existing result.
        /// </summary>
        /// <param name="yOLOEnvironmentResult">The source result instance to copy from.</param>
        public YOLOEnvironmentResult(YOLOEnvironmentResult? yOLOEnvironmentResult)
            : base(yOLOEnvironmentResult)
        {
            if (yOLOEnvironmentResult != null)
            {
                checkedTime = yOLOEnvironmentResult.checkedTime;
                cudaAvailable = yOLOEnvironmentResult.cudaAvailable;
                messages = yOLOEnvironmentResult.messages == null ? null : new List<string>(yOLOEnvironmentResult.messages);
                modelPath = yOLOEnvironmentResult.modelPath;
                modelUltralyticsVersion = yOLOEnvironmentResult.modelUltralyticsVersion;
                pythonPath = yOLOEnvironmentResult.pythonPath;
                pythonVersion = yOLOEnvironmentResult.pythonVersion;
                runnable = yOLOEnvironmentResult.runnable;
                torchVersion = yOLOEnvironmentResult.torchVersion;
                ultralyticsVersion = yOLOEnvironmentResult.ultralyticsVersion;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOEnvironmentResult"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the result data.</param>
        public YOLOEnvironmentResult(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the moment the preflight probe completed.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset? Checked
        {
            get
            {
                return checkedTime;
            }
        }

        /// <summary>
        /// Gets a value indicating whether PyTorch reports CUDA GPU hardware acceleration available.
        /// </summary>
        [JsonIgnore]
        public bool? CudaAvailable
        {
            get
            {
                return cudaAvailable;
            }
        }

        /// <summary>
        /// Gets the diagnostic messages detailing why the environment is not runnable or warnings encountered during probing.
        /// </summary>
        [JsonIgnore]
        public List<string>? Messages
        {
            get
            {
                return messages;
            }
        }

        /// <summary>
        /// Gets the path of the model checkpoint probed, or <c>null</c> when no model path was supplied.
        /// </summary>
        [JsonIgnore]
        public string? ModelPath
        {
            get
            {
                return modelPath;
            }
        }

        /// <summary>
        /// Gets the ultralytics version recorded inside the model checkpoint file, or <c>null</c> when unreadable.
        /// </summary>
        [JsonIgnore]
        public string? ModelUltralyticsVersion
        {
            get
            {
                return modelUltralyticsVersion;
            }
        }

        /// <summary>
        /// Gets the full path of the CPython interpreter that was probed.
        /// </summary>
        [JsonIgnore]
        public string? PythonPath
        {
            get
            {
                return pythonPath;
            }
        }

        /// <summary>
        /// Gets the Python version string reported by the interpreter.
        /// </summary>
        [JsonIgnore]
        public string? PythonVersion
        {
            get
            {
                return pythonVersion;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the probed Python interpreter can execute YOLO prediction workloads.
        /// </summary>
        [JsonIgnore]
        public bool Runnable
        {
            get
            {
                return runnable;
            }
        }

        /// <summary>
        /// Gets the installed version of PyTorch, or <c>null</c> when import failed.
        /// </summary>
        [JsonIgnore]
        public string? TorchVersion
        {
            get
            {
                return torchVersion;
            }
        }

        /// <summary>
        /// Gets the installed version of the ultralytics package, or <c>null</c> when import failed.
        /// </summary>
        [JsonIgnore]
        public string? UltralyticsVersion
        {
            get
            {
                return ultralyticsVersion;
            }
        }
    }
}
