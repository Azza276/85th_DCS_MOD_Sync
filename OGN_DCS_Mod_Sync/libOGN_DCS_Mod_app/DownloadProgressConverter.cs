using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libOGN_DCS_Mod_app
{
    public class DownloadProgressConverter : IProgress<double>
    {
        public long CurrentValue { get; private set; }

        public DownloadProgressConverter(FilePair pair)
        {
            Pair = pair;
        }

        public FilePair Pair { get; }

        public void Report(double percentage)
        {
            CurrentValue = (long)((percentage / 100d) * Pair.RemoteFileInfo.Length);
        }
    }
}
