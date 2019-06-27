using Octokit;
using System;
using System.IO;
using System.Threading.Tasks;

namespace appupdatewin
{
    static class Updatecode
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

            var update = new Updateconfirm(asset.Name, latest.TagName, latest.PublishedAt, Math.Round((double)asset.Size / 1024, 2), asset_uri, download_file, extract_path, latest.HtmlUrl);
            update.ShowDialog();

            //Details of the updated file.
            /*Console.WriteLine(
                "The latest release of the {0} is version {1}, updated on {2}.",
                latest.Name,
                latest.TagName,
                latest.PublishedAt);
            Console.WriteLine(
                "You are about to download the file {0} (ID {1}). It is " + Math.Round((double)asset.Size / 1024, 3) + "kB in size. It has been Downloaded {3} times.",
                asset.Name,
                asset.Id,
                asset.ContentType,
                asset.DownloadCount);
            Console.WriteLine("Press the Enter Key to begin the update");
            Console.ReadLine();*/

            //var update = new Updateconfirm(asset.Name, latest.TagName, latest.PublishedAt, Math.Round((double)asset.Size / 1024, 2), asset_uri, download_file, extract_path, latest.HtmlUrl);
            //update.ShowDialog();
        }
    }
}
