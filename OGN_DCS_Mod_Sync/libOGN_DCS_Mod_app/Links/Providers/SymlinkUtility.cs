using SymbolicLinkSupport;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libOGN_DCS_Mod_app.Links.Providers
{
    public class SymlinkUtility : LinkUtility
    {
        public void CreateLink(string source, string target)
        {
            var targetDI = new DirectoryInfo(target);
            targetDI.CreateSymbolicLink(source);
        }

        public string GetLinkTarget(DirectoryInfo directoryInfo)
        {
            string result = directoryInfo.GetSymbolicLinkTarget();
            return result;
        }

        public bool IsLink(DirectoryInfo directoryInfo)
        {
            bool result = directoryInfo.IsSymbolicLink();
            return result;
        }
    }
}
