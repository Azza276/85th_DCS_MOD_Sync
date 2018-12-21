using System;
using System.Collections.Generic;
using System.IO;

namespace libOGN_DCS_Mod_app
{
    public static class FolderHelper
    {
        private static string DetectDCSFolder()
        {
            string result = null;

            var folderLocations = new List<string>()
            {
                @"C:\Users\[Username]\Saved Games\DCS",
                @"C:\Users\[Username]\Saved Games\DCS.openbeta",
                @"C:\Users\[Username]\Saved Games\DCS World",
                @"C:\Users\[Username]\Saved Games\DCS.openalpha"
            };

            foreach (string folder in folderLocations)
            {
                string fullFolderName = folder.Replace("[Username]", Environment.UserName);

                if (Directory.Exists(fullFolderName))
                {
                    result = fullFolderName;
                    break;
                }
            }

            return result;
        }

        private static string ConstructSubfolder(string subfolderName)
        {
            string result = null;
            string dcsFolder = DetectDCSFolder();

            if (!string.IsNullOrEmpty(dcsFolder))
            {
                result = Path.Combine(dcsFolder, subfolderName);
            }

            return result;
        }

        public static string DetectLiveriesFolder()
        {
            string result = ConstructSubfolder("Liveries");

            return result;
        }

        public static string DetectOGNModsFolder()
        {
            string result = ConstructSubfolder("OGN_Mods");

            return result;
        }
    }
}
