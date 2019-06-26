using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace Git_Test
{
    class Program
    {


        static async Task Main(string[] args)
        {
            //var repo_id = 157181568;
            var client = new GitHubClient(new ProductHeaderValue("85th_DCS_MOD_Sync"));
            var releases = await client.Repository.Release.GetAll("Azza276", "85th_DCS_MOD_Sync");
            var latest = releases[0];
            Console.WriteLine(
                "The latest release is tagged at {0} and is named {1}. It's ID is {2}.",
                latest.TagName,
                latest.Name,
                latest.Id);
            var release_id = latest.Id;
            var assets = await client.Repository.Release.GetAllAssets("Azza276", "85th_DCS_MOD_Sync", release_id);
            var asset_list = assets[0];
            Console.WriteLine(
                "The latest release asset is named {1}. It's ID is {2}. It is of {0} Type. It's URL is {3}",
                asset_list.ContentType,
                asset_list.Name,
                asset_list.Id,
                asset_list.Url);

            WebClient wb = new WebClient();
            wb.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.33 Safari/537.36");
            wb.DownloadFile(asset_list.BrowserDownloadUrl, Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Downloads"));

            Console.ReadLine();
        }
    }
}
