using System;
using System.Net;
using System.Threading.Tasks;
using Octokit;
using System.IO;
using Git_Release_Update_Check;

namespace Git_Test
{
    class Git_Update_Main
    {
        static async Task Main()
        {
            //Setup some Variables/Statics.
            long repo_id = 157181568;
            bool dl_finished = false;

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

            //Details of the updated file.
            Console.WriteLine(
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
            Console.ReadLine();

            //Webclient to Download the file.
            WebClient wb = new WebClient();
            wb.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.33 Safari/537.36");
            wb.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Appupdate.DownloadProgressCallback);
            wb.DownloadFileCompleted += (AsyncCompletedEventHandler, AsyncCompletedEventArgs) => {dl_finished = true;};
            wb.DownloadFileAsync(asset_uri, download_file);

            //Wait for the download to finish.
            while (dl_finished != true) {};
            Console.WriteLine("Download Complete");
            Console.WriteLine("Extracting File");
            Appupdate.Zipextractor(download_file, extract_path);
            Console.WriteLine("File Extraction Complete. Press Enter to Close this Console");
            Console.ReadLine();
        }
    }
}