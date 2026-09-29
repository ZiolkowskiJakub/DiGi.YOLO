using System.IO;

namespace DiGi.YOLO
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the kind of start file a training run would read from its extension: .pt is a checkpoint, .yaml or .yml an architecture definition.
        /// <para>The same rule train.py applies, so the runner rejects a start file the script would reject before an interpreter is started.</para>
        /// </summary>
        /// <param name="path">The path of the start file. The file does not have to exist.</param>
        /// <returns>The kind of the file, or <see cref="Enums.ModelKind.Undefined"/> when the path is empty or has another extension.</returns>
        public static Enums.ModelKind ModelKind(string? path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return Enums.ModelKind.Undefined;
            }

            string extension = Path.GetExtension(path!).ToLowerInvariant();

            switch (extension)
            {
                case ".pt":
                    return Enums.ModelKind.Checkpoint;

                case ".yaml":
                case ".yml":
                    return Enums.ModelKind.Definition;

                default:
                    return Enums.ModelKind.Undefined;
            }
        }
    }
}
