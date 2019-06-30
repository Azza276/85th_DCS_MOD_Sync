using System;
using System.IO;
using System.IO.Compression;

namespace lib_appupdate
{
    public class Unzipper
    {
        public static void Zipextractor(string path_to_zipfile, string extract_to_path)
        {
            // Ensures that the last character on the extraction path
            // is the directory separator char. 
            // Without this, a malicious zip file could try to traverse outside of the expected
            // extraction path.
            if (!extract_to_path.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
                extract_to_path += Path.DirectorySeparatorChar;
            using (ZipArchive archive = ZipFile.OpenRead(path_to_zipfile))
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    // Gets the full path to ensure that relative segments are removed.
                    string destinationPath = Path.GetFullPath(Path.Combine(extract_to_path, entry.FullName));

                    // Ordinal match is safest, case-sensitive volumes can be mounted within volumes that
                    // are case-insensitive.
                    if (destinationPath.StartsWith(extract_to_path, StringComparison.Ordinal))
                        entry.ExtractToFile(destinationPath, true);
                }
        }
    }
}