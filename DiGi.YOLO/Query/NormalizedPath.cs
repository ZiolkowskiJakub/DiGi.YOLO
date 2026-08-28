using System.IO;

namespace DiGi.YOLO
{
    public static partial class Query
    {
        /// <summary>
        /// Returns the full form of a path with any trailing directory separator removed.
        /// <para>The separator matters because these paths are handed to a process on its command line. On Windows a backslash immediately before a closing quote escapes that quote, so a directory written as "C:\scratch\" swallows the argument that follows it and the process sees something entirely different from what was intended.</para>
        /// <para>A root such as "C:\" keeps its separator, because removing it would leave a drive letter that names the current directory of that drive rather than its root.</para>
        /// </summary>
        /// <param name="path">The path to normalize.</param>
        /// <returns>The normalized path, or <c>null</c> when the path is null, empty, or cannot be resolved to a full path.</returns>
        public static string? NormalizedPath(string? path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            string result;

            try
            {
                result = Path.GetFullPath(path!);
            }
            catch
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(result))
            {
                return null;
            }

            string result_Trimmed = result.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

            if (string.IsNullOrWhiteSpace(result_Trimmed) || result_Trimmed.EndsWith(Path.VolumeSeparatorChar.ToString()))
            {
                return result;
            }

            return result_Trimmed;
        }
    }
}
