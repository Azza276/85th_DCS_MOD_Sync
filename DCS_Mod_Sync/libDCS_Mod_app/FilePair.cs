using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using static libDCS_Mod_app.HttpsDownloader;

namespace libDCS_Mod_app
{
    public class FilePair
    {
        public readonly string LocalFilename;
        public FileInformation RemoteFileInfo;

        public FilePair(FileInformation remoteFileInfo, string localFilename)
        {
            RemoteFileInfo = remoteFileInfo;
            LocalFilename = localFilename.Replace('/', Path.DirectorySeparatorChar);
        }

        public bool RequiresUpdate()
        {
            if (RemoteFileInfo == null)
            {
                //This file isn't on the web server. It requires update (ie. to be deleted locally)
                return true;
            }

            bool result = false;

            //var downloader = new FtpDownloader();

            var localFileInfo = new FileInfo(LocalFilename);

            if (!File.Exists(LocalFilename)) result = true;
            if (File.Exists(LocalFilename) && (RemoteFileInfo.ModifiedDate > localFileInfo.LastWriteTimeUtc)) result = true;
            if (File.Exists(LocalFilename) && (RemoteFileInfo.Length != localFileInfo.Length)) result = true;
            //if (File.Exists(LocalFilename) && (!WebFileInfo.FtpExists == true)) result = true;

            return result;
        }

        public override string ToString()
        {
            string result = $"{RemoteFileInfo.FURL}   {LocalFilename}";
            return result;
        }
    }
}
