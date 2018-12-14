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
        private static string DetectSubfolder(string subfolderName)
        {
            string result = null;

            string dcsFolder = DetectDCSFolder();
            string potentialPath = Path.Combine(dcsFolder, subfolderName);
            if (Directory.Exists(potentialPath))
            {
                result = potentialPath;
            }

            return result;
        }

        public static string DetectLiveriesFolder()
        {
            string result = DetectSubfolder("Liveries");

            return result;
        }

        public static string DetectOGNModsFolder()
        {
            string dcsFolder = DetectDCSFolder();
            string result = Path.Combine(dcsFolder, "OGN_Mods");

            return result;
        }
    }
}
