using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace libOGN_DCS_Mod_app
{
    public class Downloader
    {
        public bool DownloadFile(string URL, string destinationFilename)
        {
            bool result = false;

            using (var client = new WebClient())
            {
                client.DownloadFile(URL, destinationFilename);

                if (File.Exists(destinationFilename))
                {
                    result = true;
                }
            }

            return result;
        }

        public WebFileInfo GetUrlInfo(string URL)
        {
            WebFileInfo result = null;

            try
            {


                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "HEAD"; // Important - Not interested in file contents

                HttpWebResponse resp = (HttpWebResponse)request.GetResponse();

                result = new WebFileInfo()
                {
                    URL = URL,
                    ModifiedDate = resp.LastModified,
                    Length = resp.ContentLength
                };
            } catch
            {
                Console.WriteLine("Could not get information for URL: " + URL);
            }

            return result;
        }

        public List<string> GetFilesFromDirectoryListing(string URL, string liveriesFolder)
        {
            var result = new List<string>();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string html = reader.ReadToEnd();

                    var lines = html.Split('\n');

                    var trLines = lines.Where(line => line.StartsWith("<tr><td valign")).Skip(1).ToList();

                    foreach (var trLine in trLines)
                    {
                        string relativeURL = trLine.Split(new string[] { "<a href=\"", "\">" }, StringSplitOptions.None)[2];
                        string fullURL = Path.Combine(URL, relativeURL);

                        if (fullURL.EndsWith("/"))
                        {
                            //this is a folder. Recursively get its contents
                            var subfolderContents = GetFilesFromDirectoryListing(fullURL, liveriesFolder);
                            result.AddRange(subfolderContents);
                        }
                        else
                        {
                            result.Add(fullURL);
                        }
                    }
                }
            }

            return result;
        }
    }
}
