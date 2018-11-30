using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SymbolicLinkSupport;

namespace libOGN_DCS_Mod_app
{
    public class SymlinkManager
    {
        public string DCSFolder { get; }
        public string OgnModsFolder { get; }

        public SymlinkManager(string dcsFolder, string ognModsFolder)
        {
            DCSFolder = dcsFolder;
            OgnModsFolder = ognModsFolder;
        }

        public void DeleteCurrentSymlinks()
        {
            //Delete existing symlinks that point to the OGN mods folder
            var symlinksToDelete = Directory.GetDirectories(DCSFolder, "*.*", SearchOption.AllDirectories)
                                        .Select(folder => new DirectoryInfo(folder))
                                        .Where(folder => folder.IsSymbolicLink())
                                        .Where(folder => folder.GetSymbolicLinkTarget().StartsWith(OgnModsFolder))
                                        .ToList();

            symlinksToDelete.ForEach(symlink =>
            {
                symlink.Delete();
            });
        }

        public void CreateSymlinks()
        {
            var symlinkPairs = Directory.GetDirectories(OgnModsFolder, "*.*", SearchOption.AllDirectories)
                .Select(d => new
                {
                    FullPath = d,
                    RelativePath = d.Replace(OgnModsFolder, ""),
                })
                .Select(d => new
                {
                    d.FullPath,
                    d.RelativePath,
                    Depth = d.RelativePath.Split(Path.DirectorySeparatorChar).Length
                })
                .Where(d => d.Depth == 4)
                .Select(d => new
                {
                    SymlinkSource = DCSFolder + d.RelativePath,
                    SymlinkTarget = d.FullPath
                })
                .ToList();

            symlinkPairs.ForEach(pair =>
            {
                //create the parent into which the symlink will be placed
                var parent = Directory.GetParent(pair.SymlinkSource).FullName;
                Directory.CreateDirectory(parent);

                var target = new DirectoryInfo(pair.SymlinkTarget);
                target.CreateSymbolicLink(pair.SymlinkSource);
            });
        }
    }
}
