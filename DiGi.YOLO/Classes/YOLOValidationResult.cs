using DiGi.Core.Classes;
using DiGi.YOLO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.YOLO.Classes
{
    /// <summary>
    /// Describes how one run of the YOLO validation script went: its exit code and output, the weights and split it validated, the box mAP it measured, and when it ran.
    /// </summary>
    public class YOLOValidationResult : SerializableResult, IYOLOSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(End))]
        private readonly DateTimeOffset? end;

        [JsonInclude, JsonPropertyName(nameof(ExitCode))]
        private readonly int exitCode;

        [JsonInclude, JsonPropertyName(nameof(MAP50))]
        private readonly double? mAP50;

        [JsonInclude, JsonPropertyName(nameof(MAP50_95))]
        private readonly double? mAP50_95;

        [JsonInclude, JsonPropertyName(nameof(ModelPath))]
        private readonly string? modelPath;

        [JsonInclude, JsonPropertyName(nameof(ModelSHA256))]
        private readonly string? modelSHA256;

        [JsonInclude, JsonPropertyName(nameof(Split))]
        private readonly Enums.Category split;

        [JsonInclude, JsonPropertyName(nameof(StandardError))]
        private readonly List<string>? standardError;

        [JsonInclude, JsonPropertyName(nameof(StandardOutput))]
        private readonly List<string>? standardOutput;

        [JsonInclude, JsonPropertyName(nameof(Start))]
        private readonly DateTimeOffset? start;

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOValidationResult"/> class with the specified values.
        /// </summary>
        /// <param name="exitCode">The exit code of the interpreter; -1 when it could not be started, was cancelled, or the runner refused the run.</param>
        /// <param name="modelPath">The absolute path of the validated weights.</param>
        /// <param name="modelSHA256">The lowercase hexadecimal SHA-256 digest of the validated weights.</param>
        /// <param name="split">The dataset split validated on.</param>
        /// <param name="mAP50">The box mAP at IoU 0.5.</param>
        /// <param name="mAP50_95">The box mAP averaged over IoU 0.5 to 0.95.</param>
        /// <param name="standardOutput">The tail of the lines the script wrote to standard output.</param>
        /// <param name="standardError">The tail of the lines the script wrote to standard error, followed by any message of the runner.</param>
        /// <param name="start">When the run started.</param>
        /// <param name="end">When the run ended.</param>
        public YOLOValidationResult(
            int exitCode,
            string? modelPath,
            string? modelSHA256,
            Enums.Category split,
            double? mAP50,
            double? mAP50_95,
            IEnumerable<string>? standardOutput,
            IEnumerable<string>? standardError,
            DateTimeOffset? start,
            DateTimeOffset? end)
        {
            this.exitCode = exitCode;
            this.modelPath = modelPath;
            this.modelSHA256 = modelSHA256;
            this.split = split;
            this.mAP50 = mAP50;
            this.mAP50_95 = mAP50_95;
            this.standardOutput = standardOutput == null ? null : [.. standardOutput];
            this.standardError = standardError == null ? null : [.. standardError];
            this.start = start;
            this.end = end;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOValidationResult"/> class by copying an existing result.
        /// </summary>
        /// <param name="yOLOValidationResult">The source result to copy from.</param>
        public YOLOValidationResult(YOLOValidationResult? yOLOValidationResult)
            : base(yOLOValidationResult)
        {
            if (yOLOValidationResult != null)
            {
                end = yOLOValidationResult.end;
                exitCode = yOLOValidationResult.exitCode;
                mAP50 = yOLOValidationResult.mAP50;
                mAP50_95 = yOLOValidationResult.mAP50_95;
                modelPath = yOLOValidationResult.modelPath;
                modelSHA256 = yOLOValidationResult.modelSHA256;
                split = yOLOValidationResult.split;
                standardError = yOLOValidationResult.standardError == null ? null : [.. yOLOValidationResult.standardError];
                standardOutput = yOLOValidationResult.standardOutput == null ? null : [.. yOLOValidationResult.standardOutput];
                start = yOLOValidationResult.start;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="YOLOValidationResult"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the result.</param>
        public YOLOValidationResult(JsonObject? jsonObject)
            : base(jsonObject)
        {
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
        /// Gets the box mAP at IoU 0.5, or <c>null</c> when the script did not report it.
        /// </summary>
        [JsonIgnore]
        public double? MAP50
        {
            get
            {
                return mAP50;
            }
        }

        /// <summary>
        /// Gets the box mAP averaged over IoU 0.5 to 0.95, or <c>null</c> when the script did not report it.
        /// </summary>
        [JsonIgnore]
        public double? MAP50_95
        {
            get
            {
                return mAP50_95;
            }
        }

        /// <summary>
        /// Gets the absolute path of the validated weights.
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
        /// Gets the lowercase hexadecimal SHA-256 digest of the validated weights, so a gate table can name exactly which file each row measured.
        /// </summary>
        [JsonIgnore]
        public string? ModelSHA256
        {
            get
            {
                return modelSHA256;
            }
        }

        /// <summary>
        /// Gets the dataset split validated on.
        /// </summary>
        [JsonIgnore]
        public Enums.Category Split
        {
            get
            {
                return split;
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
        /// Gets whether the run completed and reported both mAP values.
        /// </summary>
        [JsonIgnore]
        public bool Succeeded
        {
            get
            {
                return exitCode == 0 && mAP50 != null && mAP50_95 != null;
            }
        }
    }
}
