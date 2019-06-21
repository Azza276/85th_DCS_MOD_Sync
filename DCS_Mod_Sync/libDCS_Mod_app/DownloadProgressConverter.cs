using FluentFTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDCS_Mod_app
{
    public class DownloadProgressConverter : IProgress<FtpProgress>
    {
        public long BytesDownloaded { get; private set; }

        public DownloadProgressConverter(FilePair pair)
        {
            Pair = pair;
        }

        public FilePair Pair { get; }

        public void Report(FtpProgress progress)
        {
            BytesDownloaded = (long)((progress.Progress / 100d) * Pair.RemoteFileInfo.Length);
        }
    }
}
