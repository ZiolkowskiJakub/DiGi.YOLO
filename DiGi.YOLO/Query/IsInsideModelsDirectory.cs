using System;
using System.IO;

namespace DiGi.YOLO
{
    public static partial class Query
    {
        /// <summary>
        /// Checks whether a path is a YOLO\models folder or lies anywhere inside one - the place the frozen weights live, which no training run may write into.
        /// <para>The path is made absolute first and compared with a trailing separator, case-insensitively, so "...\YOLO\models" itself and "...\yolo\MODELS\run" both count while a sibling such as "...\YOLO\models_old" does not. The folder names are <see cref="Constants.DirectoryName.YOLO"/> and <see cref="Constants.DirectoryName.Models"/>.</para>
        /// <para>A relative path is resolved against the current directory of the calling process, so a caller handing the path to another process resolves it the way that process will before asking.</para>
        /// <para>A null, blank or unformable path returns <c>false</c>: it names no folder, and every caller refuses such a path for its own, more specific reason.</para>
        /// </summary>
        /// <param name="path">The directory path to check.</param>
        /// <returns><c>true</c> when the path is, or lies inside, a YOLO\models folder; otherwise <c>false</c>.</returns>
        public static bool IsInsideModelsDirectory(string? path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            string path_Full;

            try
            {
                path_Full = Path.GetFullPath(path!);
            }
            catch
            {
                return false;
            }

            string segment = string.Concat(Path.DirectorySeparatorChar, Constants.DirectoryName.YOLO, Path.DirectorySeparatorChar, Constants.DirectoryName.Models, Path.DirectorySeparatorChar);

            return string.Concat(path_Full.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar), Path.DirectorySeparatorChar).IndexOf(segment, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
