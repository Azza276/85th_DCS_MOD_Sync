using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace libOGN_DCS_Mod_app
{
    public class FilePair
    {
        public readonly string LocalFilename;
        public readonly string DcsFolder;
        public WebFileInfo WebFileInfo;

        public FilePair(string dcsFolder, WebFileInfo webFileInfo, string localFilename)
        {
            DcsFolder = dcsFolder;
            WebFileInfo = webFileInfo;
            LocalFilename = localFilename.Replace('/', Path.DirectorySeparatorChar);
        }

        public bool RequiresUpdate()
        {
            if (WebFileInfo == null)
            {
                //This file isn't on the web server. It requires update (ie. to be deleted locally)
                return true;
            }

            bool result = false;

            var downloader = new FtpDownloader();

            var localFileInfo = new FileInfo(LocalFilename);

            if (!File.Exists(LocalFilename)) result = true;
            if (File.Exists(LocalFilename) && (WebFileInfo.ModifiedDate > localFileInfo.LastWriteTime)) result = true;
            if (File.Exists(LocalFilename) && (WebFileInfo.Length != localFileInfo.Length)) result = true;
            //if (File.Exists(LocalFilename) && (!WebFileInfo.FtpExists == true)) result = true;

            return result;
        }
    }
}
