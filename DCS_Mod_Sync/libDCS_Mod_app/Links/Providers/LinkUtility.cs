using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDCS_Mod_app.Links.Providers
{
    public interface LinkUtility
    {
        bool IsLink(DirectoryInfo directoryInfo);
        string GetLinkTarget(DirectoryInfo directoryInfo);
        void CreateLink(string source, string target);
    }
}
