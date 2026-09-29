using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DiGi.YOLO
{
    public static partial class Query
    {
        /// <summary>
        /// Computes the SHA-256 digest of a file as lowercase hexadecimal - the form train.py and export.py print and the README provenance tables record.
        /// </summary>
        /// <param name="path">The path of the file to hash.</param>
        /// <returns>The 64-character lowercase hexadecimal digest, or <c>null</c> when the path is empty, the file does not exist or cannot be read.</returns>
        public static string? FileSHA256(string? path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                return null;
            }

            byte[] bytes;

            try
            {
                using FileStream fileStream = File.OpenRead(path);
                using SHA256 sHA256 = SHA256.Create();
                bytes = sHA256.ComputeHash(fileStream);
            }
            catch (IOException)
            {
                return null;
            }
            catch (UnauthorizedAccessException)
            {
                return null;
            }

            StringBuilder stringBuilder = new(bytes.Length * 2);
            foreach (byte @byte in bytes)
            {
                stringBuilder.Append(@byte.ToString("x2", CultureInfo.InvariantCulture));
            }

            return stringBuilder.ToString();
        }
    }
}
