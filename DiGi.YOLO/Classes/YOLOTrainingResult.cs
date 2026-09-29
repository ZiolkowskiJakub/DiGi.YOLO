using DiGi.Core.Classes;
using DiGi.YOLO.Enums;
using DiGi.YOLO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.YOLO.Classes
{
    /// <summary>
    /// Describes how one run of the YOLO training script went: its exit code and output, the identity of the weights it started from and of the weights it wrote, and when it ran.
    /// <para>The start weights are identified by the runner itself, before the process starts, rather than read back from the script's output: the output keeps only its tail, which a long run fills with training progress. The written weights are read from the success block train.py prints last and checked against the file on disk.</para>
    /// </summary>
    public class YOLOTrainingResult : SerializableResult, IYOLOSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Amp))]
        private readonly bool? amp;

        [JsonInclude, JsonPropertyName(nameof(Bytes))]
        private readonly long? bytes;

        [JsonInclude, JsonPropertyName(nameof(End))]
        private readonly DateTimeOffset? end;

        [JsonInclude, JsonPropertyName(nameof(ExitCode))]
        private readonly int exitCode;

        [JsonInclude, JsonPropertyName(nameof(SHA256))]
        private readonly string? sHA256;

        [JsonInclude, JsonPropertyName(nameof(StandardError))]
        private readonly List<string>? standardError;

        [JsonInclude, JsonPropertyName(nameof(StandardOutput))]
        private readonly List<string>? standardOutput;

        [JsonInclude, JsonPropertyName(nameof(Start))]
        private readonly DateTimeOffset? start;

        [JsonInclude, JsonPropertyName(nameof(StartModelKind))]
        private readonly ModelKind startModelKind;

        [JsonInclude, JsonPropertyName(nameof(StartModelPath))]
        private readonly string? startModelPath;

        [JsonInclude, JsonPropertyName(nameof(StartModelSHA256))]
        private readonly string? startModelSHA256;

        [JsonInclude, JsonPropertyName(nameof(WeightsPath))]
        private readonly string? weightsPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOTrainingResult"/> class with the specified values.
        /// </summary>
        /// <param name="exitCode">The exit code of the interpreter; -1 when it could not be started, was cancelled, or the runner refused the run.</param>
        /// <param name="startModelPath">The absolute path of the start weights.</param>
        /// <param name="startModelSHA256">The lowercase hexadecimal SHA-256 digest of the start weights.</param>
        /// <param name="startModelKind">Whether the start weights are a checkpoint or an architecture definition.</param>
        /// <param name="weightsPath">The absolute path of the best weights the run wrote.</param>
        /// <param name="bytes">The size of the best weights in bytes.</param>
        /// <param name="sHA256">The lowercase hexadecimal SHA-256 digest of the best weights.</param>
        /// <param name="amp">The automatic mixed precision the run actually used.</param>
        /// <param name="standardOutput">The tail of the lines the script wrote to standard output.</param>
        /// <param name="standardError">The tail of the lines the script wrote to standard error, followed by any message of the runner.</param>
        /// <param name="start">When the run started.</param>
        /// <param name="end">When the run ended.</param>
        public YOLOTrainingResult(
            int exitCode,
            string? startModelPath,
            string? startModelSHA256,
            ModelKind startModelKind,
            string? weightsPath,
            long? bytes,
            string? sHA256,
            bool? amp,
            IEnumerable<string>? standardOutput,
            IEnumerable<string>? standardError,
            DateTimeOffset? start,
            DateTimeOffset? end)
        {
            this.exitCode = exitCode;
            this.startModelPath = startModelPath;
            this.startModelSHA256 = startModelSHA256;
            this.startModelKind = startModelKind;
            this.weightsPath = weightsPath;
            this.bytes = bytes;
            this.sHA256 = sHA256;
            this.amp = amp;
            this.standardOutput = standardOutput == null ? null : [.. standardOutput];
            this.standardError = standardError == null ? null : [.. standardError];
            this.start = start;
            this.end = end;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOTrainingResult"/> class by copying an existing result.
        /// </summary>
        /// <param name="yOLOTrainingResult">The source result to copy from.</param>
        public YOLOTrainingResult(YOLOTrainingResult? yOLOTrainingResult)
            : base(yOLOTrainingResult)
        {
            if (yOLOTrainingResult != null)
            {
                amp = yOLOTrainingResult.amp;
                bytes = yOLOTrainingResult.bytes;
                end = yOLOTrainingResult.end;
                exitCode = yOLOTrainingResult.exitCode;
                sHA256 = yOLOTrainingResult.sHA256;
                standardError = yOLOTrainingResult.standardError == null ? null : [.. yOLOTrainingResult.standardError];
                standardOutput = yOLOTrainingResult.standardOutput == null ? null : [.. yOLOTrainingResult.standardOutput];
                start = yOLOTrainingResult.start;
                startModelKind = yOLOTrainingResult.startModelKind;
                startModelPath = yOLOTrainingResult.startModelPath;
                startModelSHA256 = yOLOTrainingResult.startModelSHA256;
                weightsPath = yOLOTrainingResult.weightsPath;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOTrainingResult"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the result.</param>
        public YOLOTrainingResult(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the automatic mixed precision the run actually used, or <c>null</c> when the script did not report it. False although AMP was requested means the AMP check failed, typically offline.
        /// </summary>
        [JsonIgnore]
        public bool? Amp
        {
            get
            {
                return amp;
            }
        }

        /// <summary>
        /// Gets the size of the best weights in bytes, or <c>null</c> when the run wrote none.
        /// </summary>
        [JsonIgnore]
        public long? Bytes
        {
            get
            {
                return bytes;
            }
        }

        /// <summary>
        /// Gets how long the run took, or <c>null</c> when either end of it is unknown.
        /// </summary>
        [JsonIgnore]
        public TimeSpan? Duration
        {
            get
            {
                if (start == null || end == null)
                {
                    return null;
                }

                return end.Value - start.Value;
            }
        }

        /// <summary>
        /// Gets when the run ended.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset? End
        {
            get
            {
                return end;
            }
        }

        /// <summary>
        /// Gets the exit code of the interpreter; -1 when it could not be started, was cancelled, or the runner refused the run.
        /// </summary>
        [JsonIgnore]
        public int ExitCode
        {
            get
            {
                return exitCode;
            }
        }

        /// <summary>
        /// Gets the lowercase hexadecimal SHA-256 digest of the best weights, or <c>null</c> when the run wrote none or the digest the script printed does not match the file.
        /// </summary>
        [JsonIgnore]
        public string? SHA256
        {
            get
            {
                return sHA256;
            }
        }

        /// <summary>
        /// Gets the tail of the lines the script wrote to standard error, followed by any message of the runner.
        /// </summary>
        [JsonIgnore]
        public List<string>? StandardError
        {
            get
            {
                return standardError;
            }
        }

        /// <summary>
        /// Gets the tail of the lines the script wrote to standard output.
        /// </summary>
        [JsonIgnore]
        public List<string>? StandardOutput
        {
            get
            {
                return standardOutput;
            }
        }

        /// <summary>
        /// Gets when the run started.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset? Start
        {
            get
            {
                return start;
            }
        }

        /// <summary>
        /// Gets whether the start weights were a checkpoint or an architecture definition.
        /// </summary>
        [JsonIgnore]
        public ModelKind StartModelKind
        {
            get
            {
                return startModelKind;
            }
        }

        /// <summary>
        /// Gets the absolute path of the start weights.
        /// </summary>
        [JsonIgnore]
        public string? StartModelPath
        {
            get
            {
                return startModelPath;
            }
        }

        /// <summary>
        /// Gets the lowercase hexadecimal SHA-256 digest of the start weights - what a provenance table records as "started from".
        /// </summary>
        [JsonIgnore]
        public string? StartModelSHA256
        {
            get
            {
                return startModelSHA256;
            }
        }

        /// <summary>
        /// Gets whether the run completed and wrote weights whose identity was confirmed: a zero exit code, a weights path and a digest that matches the file.
        /// </summary>
        [JsonIgnore]
        public bool Succeeded
        {
            get
            {
                return exitCode == 0 && !string.IsNullOrWhiteSpace(weightsPath) && !string.IsNullOrWhiteSpace(sHA256);
            }
        }

        /// <summary>
        /// Gets the absolute path of the best weights the run wrote, or <c>null</c> when it wrote none.
        /// </summary>
        [JsonIgnore]
        public string? WeightsPath
        {
            get
            {
                return weightsPath;
            }
        }
    }
}
