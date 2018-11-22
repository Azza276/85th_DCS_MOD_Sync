using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace libOGN_DCS_Mod_app
{
    public class FtpDownloader
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

        public WebFileInfo GetUrlInfo(string URL, string dcsFolder, string liveriesFolder)
        {
            string localFilename = Path.Combine(dcsFolder, liveriesFolder);
            WebFileInfo result = null;

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(URL);

                request.KeepAlive = true;
                request.UsePassive = true;
                request.UseBinary = true;
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                request.Credentials = new NetworkCredential("dcs@ozgamingnetwork.com.au", "ozgaming");

                //request.Method = "HEAD"; // Important - Not interested in file contents

                FtpWebResponse resp = (FtpWebResponse)request.GetResponse();

                request.Method = WebRequestMethods.Ftp.DownloadFile;

                using (Stream ftpStream = request.GetResponse().GetResponseStream())
                using (Stream fileStream = File.Create(localFilename + "dcs_file_list.txt"))
                {
                    byte[] buffer = new byte[10240];
                    int read;
                    while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, read);
                        Console.WriteLine("Downloaded {0} bytes", fileStream.Position);
                    }
                }
            
                result = new WebFileInfo()
                {
                    URL = URL,
                    ModifiedDate = resp.LastModified,
                    Length = resp.ContentLength
                };

                //try to not set off BitNinja
                //Thread.Sleep(500);
            }
            catch
            {
                Console.WriteLine("Could not get information for URL: " + URL);
            }

            return result;
        }

        public List<string> GetFilesFromDirectoryListing(string URL, string liveriesFolder)
        {
            var result = new List<string>();

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(URL);
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
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
