using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace libOGN_DCS_Mod_app
{
    public class FilePair
    {
        public string URL;
        public readonly string LocalFilename;
        private readonly string PathToDisplay;
        public readonly string DcsFolder;
        public WebFileInfo WebFileInfo;

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

            var downloader = new FtpDownloader();

            var localFileInfo = new FileInfo(LocalFilename);
            WebFileInfo = downloader.GetUrlInfo(URL);

            if (File.Exists(LocalFilename) && (!WebFileInfo.FtpExists == true)) File.Delete(LocalFilename);
            if (!File.Exists(LocalFilename)) result = true;
            if (File.Exists(LocalFilename) && (WebFileInfo.ModifiedDate > localFileInfo.LastWriteTime)) result = true;
            if (File.Exists(LocalFilename) && (WebFileInfo.Length != localFileInfo.Length)) result = true;

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
