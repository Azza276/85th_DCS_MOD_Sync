using libOGN_DCS_Mod_Sync;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OGN_DCS_Mod_Sync
{
    class Program
    {
        static void Main(string[] args)
        {
            //Determine DCS Users Directory
            var folderHelper = new FolderHelper();
            string dcsFolder = folderHelper.DetectDCSFolder();

            if (dcsFolder == null)
            {
                Console.WriteLine("Could not find DCS folder");
                return;
            }

            //Create the Liveries folder if it doesn't exist
            string liveriesFolder = Path.Combine(dcsFolder, "Liveries");
            if (!Directory.Exists(liveriesFolder))
            {
                Directory.CreateDirectory(liveriesFolder);
            }

            string dcsModsURL = "https://www.ozgamingnetwork.com.au/DCS_Mods/";

            Console.WriteLine("Getting file list from web server...");
            var downloader = new Downloader();
            var allFilesOnWebserver = downloader.GetFilesFromDirectoryListing(dcsModsURL, liveriesFolder);

            var pairs = allFilesOnWebserver.Select(url =>
            {
                string relativeURL = url.Replace(dcsModsURL, string.Empty);
                string decodedRelativeURL = System.Net.WebUtility.UrlDecode(relativeURL);
                string localFilename = Path.Combine(dcsFolder, decodedRelativeURL);

                var pair = new FilePair(dcsFolder, url, localFilename);

                return pair;
            })
            .ToList();

            //Check if files need updating
            int downloadCount = 0;
            var filesThatRequireUpdate = pairs
                                            .Where(pair => pair.RequiresUpdate())
                                            .ToList();

            Console.WriteLine();

            if (filesThatRequireUpdate.Count == 0)
            {
                Console.WriteLine("All files are up to date. No downloads required.");
            }
            else
            {
                //Ask the user if they would like to update.
                string[] validKeys = new string[] { "Y", "N" };
                string userInput = null;

                do
                {
                    Console.Write("{0} files require an update. Would you like to download them? [Y/N] ", filesThatRequireUpdate.Count);
                    userInput = Console.ReadLine().ToUpper();
                } while (!validKeys.Contains(userInput));

                if (userInput == "Y")
                {
                    foreach (var pair in filesThatRequireUpdate)
                    {
                        bool downloaded = pair.Download();
                        if (downloaded)
                        {
                            downloadCount++;
                        }
                    }

                    Console.WriteLine("Finished. Downloaded {0} files.", downloadCount);
                }

                if (userInput == "N")
                {
                    Console.WriteLine("Exiting without downloading.");
                }
            }

            Console.WriteLine("Press any key to key to continue...");
            Console.ReadKey();
        }
    }
}
