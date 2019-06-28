using Octokit;
using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace appupdatewin
{
    static class Updateapp
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        static async Task Main()
        {
            //Setup some Variables/Statics.
            long repo_id = 157181568;

            //Get the Github Repo Release Data.
            var client = new GitHubClient(new ProductHeaderValue("85th_DCS_MOD_Sync"));
            var releases = await client.Repository.Release.GetAll(repo_id);
            var latest_rel_asset = await client.Repository.Release.GetAllAssets(repo_id, releases[0].Id);

            //Make it easier to extract the data.
            var latest = releases[0];
            var asset = latest_rel_asset[0];

            //Setup Uri to download asset from.
            Uri asset_uri = new Uri(asset.BrowserDownloadUrl);

            //Setup the Download file path and Zip extraction path.
            string download_file = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Downloads\") + asset.Name;
            string extract_path = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Saved Games\");
            // Normalizes the extract path.
            extract_path = Path.GetFullPath(extract_path);

            //Get Latest Github Version Info (to int)
            var Tag_ver = latest.TagName;
            string output = Regex.Replace(Tag_ver, "[^0-9]+", string.Empty);
            string out_t = output.Truncate(4);
            string out_p = out_t.PadRight(4, '0');
            int.TryParse(out_p, out int git_ver);
            
            //Get Application Version
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            string app_out = String.Format("{0}{1}{2}{3}", version.Major, version.Minor, version.Build, version.Revision);
            int.TryParse(app_out, out int app_ver);


            if (git_ver > app_ver)
            {
                var update = new Updateconfirm(asset.Name, latest.TagName, latest.PublishedAt, Math.Round((double)asset.Size / 1024, 2), asset_uri, download_file, extract_path, latest.HtmlUrl);
                update.ShowDialog();
            }
        
        }
        public static string Truncate(this string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars);
        }
    }
}
