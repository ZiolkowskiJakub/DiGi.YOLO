using System.Collections.Generic;
using System.IO;

namespace DiGi.YOLO
{
    public static partial class Query
    {
        /// <summary>
        /// Returns the environment variables a run in the given working directory gets, pointing ultralytics at the settings directory of that working directory.
        /// <para>The YOLO_CONFIG_DIR variable is set to the .yolo-config folder inside the working directory (created when missing), so the settings file an ultralytics version reads and writes lives in the working directory instead of the shared machine-wide one. Without it, whichever version runs after the other rewrites the file it does not expect, prints a settings notice on stdout and loses the custom values the other version had stored.</para>
        /// </summary>
        /// <param name="workingDirectory">The working directory of the run.</param>
        /// <returns>The environment variables to set on the process the run starts.</returns>
        public static Dictionary<string, string> ConfigEnvironmentVariables(string workingDirectory)
        {
            string path_Config = Path.Combine(workingDirectory, Constants.DirectoryName.YoloConfig);
            if (!Directory.Exists(path_Config))
            {
                Directory.CreateDirectory(path_Config);
            }

            //YOLO_CONFIG_DIR is the variable ultralytics reads for the settings directory; the value is the folder this run isolates them in
            Dictionary<string, string> environmentVariables = new()
            {
                ["YOLO_CONFIG_DIR"] = path_Config
            };

            return environmentVariables;
        }
    }
}
