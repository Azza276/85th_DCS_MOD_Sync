using Monitor.Core.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDCS_Mod_app.Links.Providers
{
    public class JunctionUtility : LinkUtility
    {
        public void CreateLink(string source, string target)
        {
            JunctionPoint.Create(source, target, true);
        }

        public string GetLinkTarget(DirectoryInfo directoryInfo)
        {
            string result = JunctionPoint.GetTarget(directoryInfo.FullName);
            return result;
        }

        public bool IsLink(DirectoryInfo directoryInfo)
        {
            bool result = JunctionPoint.Exists(directoryInfo.FullName);
            return result;
        }
    }
}
