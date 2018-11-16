using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace libOGN_DCS_Mod_Sync
{
    public class FilePair
    {
        public string URL;
        public readonly string LocalFilename;
        private readonly string PathToDisplay;
        public readonly string DcsFolder;

        public FilePair(string dcsFolder, string url, string localFilename)
        {
            DcsFolder = dcsFolder;
            URL = url;
            LocalFilename = localFilename;
            PathToDisplay = localFilename.Replace(dcsFolder, "");
        }

        public bool RequiresUpdate()
        {
            bool result = false;

            var downloader = new Downloader();

            var localFileInfo = new FileInfo(LocalFilename);
            var webFileInfo = downloader.GetUrlInfo(URL);

            Console.WriteLine("Checking {0}", PathToDisplay);

            if (!File.Exists(LocalFilename)) result = true;
            if (File.Exists(LocalFilename) && (webFileInfo.ModifiedDate > localFileInfo.LastWriteTime)) result = true;
            if (File.Exists(LocalFilename) && (webFileInfo.Length != localFileInfo.Length)) result = true;


            return result;
        }

        public bool Download()
        {
            bool result = false;

            var downloader = new Downloader();

            //create the folder for the file
            string localFilePath = Path.GetDirectoryName(LocalFilename);
            Directory.CreateDirectory(localFilePath);

            Console.WriteLine("   Downloading: " + PathToDisplay);

            downloader.DownloadFile(URL, LocalFilename);

            if (File.Exists(LocalFilename))
            {
                result = true;
            }

            return result;
        }
    }
}
