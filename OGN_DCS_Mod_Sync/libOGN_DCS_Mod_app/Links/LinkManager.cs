using System.IO;
using System.Linq;
using libOGN_DCS_Mod_app.Links.Providers;

namespace libOGN_DCS_Mod_app
{
    public class LinkManager
    {
        public string LiveriesFolder { get; }
        public string OgnModsFolder { get; }
        public LinkUtility LinkUtility { get; }

        public LinkManager(string liveriesFolder, string ognModsFolder, LinkUtility linkUtility)
        {
            LiveriesFolder = liveriesFolder;
            OgnModsFolder = ognModsFolder;
            LinkUtility = linkUtility;
        }

        public void DeleteCurrentLinks()
        {
            if (!Directory.Exists(LiveriesFolder))
            {
                return;
            }

            //Delete existing links that point to the OGN mods folder
            var linksToDelete = Directory.GetDirectories(LiveriesFolder, "*.*", SearchOption.AllDirectories)
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
            var ognModsLiveries = Path.Combine(OgnModsFolder, "Liveries");

            if (!Directory.Exists(ognModsLiveries))
            {
                Directory.CreateDirectory(ognModsLiveries);
            }

            var linksPairs = Directory.GetDirectories(ognModsLiveries, "*.*", SearchOption.AllDirectories)
                .Select(d => new
                {
                    FullPath = d,
                    RelativePath = d.Replace(ognModsLiveries, ""),
                })
                .Select(d => new
                {
                    d.FullPath,
                    d.RelativePath,
                    Depth = d.RelativePath.Split(Path.DirectorySeparatorChar).Length
                })
                .Where(d => d.Depth == 3)
                .Select(d => new
                {
                    LinkSource = LiveriesFolder + d.RelativePath,
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
