using System;
using System.Collections.Generic;
using System.IO;

namespace libOGN_DCS_Mod_Sync
{
    public class FolderHelper
    {
        public string DetectDCSFolder()
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
                //Console.WriteLine(fullFolderName);

                if (Directory.Exists(fullFolderName))
                {
                    //Console.WriteLine("Folder found!: " + fullFolderName);
                    result = fullFolderName;
                }
            }

            return result;
        }
    }
}
