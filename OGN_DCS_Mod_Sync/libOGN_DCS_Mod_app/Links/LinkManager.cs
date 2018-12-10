using System.IO;
using System.Linq;
using libOGN_DCS_Mod_app.Links.Providers;

namespace libOGN_DCS_Mod_app
{
    public class LinkManager
    {
        public string DCSFolder { get; }
        public string OgnModsFolder { get; }
        public LinkUtility LinkUtility { get; }

        public LinkManager(string dcsFolder, string ognModsFolder, LinkUtility linkUtility)
        {
            DCSFolder = dcsFolder;
            OgnModsFolder = ognModsFolder;
            LinkUtility = linkUtility;
        }

        public void DeleteCurrentLinks()
        {
            //Delete existing links that point to the OGN mods folder
            var linksToDelete = Directory.GetDirectories(DCSFolder, "*.*", SearchOption.AllDirectories)
                                        .Select(folder => new DirectoryInfo(folder))
                                        .Where(folder => LinkUtility.IsLink(folder))
                                        .Where(folder => LinkUtility.GetLinkTarget(folder).StartsWith(OgnModsFolder))
                                        .ToList();

            linksToDelete.ForEach(link =>
            {
                link.Delete();
            });
        }

        public void CreateLinks()
        {
            var linksPairs = Directory.GetDirectories(OgnModsFolder, "*.*", SearchOption.AllDirectories)
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
                    LinkSource = DCSFolder + d.RelativePath,
                    LinkTarget = d.FullPath
                })
                .ToList();

            linksPairs.ForEach(pair =>
            {
                //create the parent into which the link will be placed
                var parent = Directory.GetParent(pair.LinkSource).FullName;
                Directory.CreateDirectory(parent);

                LinkUtility.CreateLink(pair.LinkSource, pair.LinkTarget);
            });
        }
    }
}
