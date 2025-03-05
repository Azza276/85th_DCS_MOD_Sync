using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
//using FluentFTP;
using System.Threading.Tasks;

using System.Net.Http;
using HtmlAgilityPack;

namespace libDCS_Mod_app
{
    public class HttpsDownloader
    {
        public delegate void ProgressChangedSignature(long bytes);
        public ProgressChangedSignature OnProgressChanged;

        public delegate void StartDownloadSignature(FilePair pair);
        public StartDownloadSignature OnStartDownload;

        public delegate void FinishedDownloadSignature(FilePair pair);
        public FinishedDownloadSignature OnFinishedDownload;

        public const string HTTPS_WORKING_DIRECTORY = "85TH_Mods";

        public bool DownloadFiles(IEnumerable<FilePair> files, int concurrentDownloads)
        {
            bool result = false;

            var filesToDownload = files.Select(pair => new
            {
                Pair = pair,
                Progress = new DownloadProgressConverter(pair)
            })
            .ToList();

            //Monitor the overall progress
            var progressTaskToken = new CancellationTokenSource();
            var progressTask = Task.Factory.StartNew(() =>
            {
                while (!progressTaskToken.IsCancellationRequested)
                {
                    var totalBytesDownloaded = filesToDownload.Sum(f => f.Progress.BytesDownloaded);
                    OnProgressChanged?.Invoke(totalBytesDownloaded);
                    Thread.Sleep(100);
                }
            });

            //Start downloading files
            try
            {
                filesToDownload
                .AsParallel()
                .WithDegreeOfParallelism(concurrentDownloads)
                .ForAll(f =>
                {
                    OnStartDownload?.Invoke(f.Pair);
                    DownloadFile(f.Pair, (IProgress<long>)f.Progress);
                    OnFinishedDownload?.Invoke(f.Pair);
                });

                result = true;
            }
            catch (AggregateException)
            {
                //Do nothing. Would be worth logging at a later stage
            }

            progressTaskToken.Cancel();

            return result;
        }

        //Downloads the files that require update.

        public bool DownloadFile(FilePair pair, IProgress<long> progress)
        {
            bool result = false;

            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMinutes(30); // Set a timeout for the download

                var response = client.GetAsync(pair.RemoteFileInfo.FURL, HttpCompletionOption.ResponseHeadersRead).Result;
                response.EnsureSuccessStatusCode();

                var totalBytes = response.Content.Headers.ContentLength ?? 0L;
                using (var contentStream = response.Content.ReadAsStreamAsync().Result)
                using (var fileStream = new FileStream(pair.LocalFilename, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                {
                    var buffer = new byte[8192];
                    long totalRead = 0L;
                    int bytesRead;
                    while ((bytesRead = contentStream.ReadAsync(buffer, 0, buffer.Length).Result) > 0)
                    {
                        fileStream.WriteAsync(buffer, 0, bytesRead).Wait();
                        totalRead += bytesRead;
                        progress?.Report(totalRead);
                    }
                }

                if (File.Exists(pair.LocalFilename))
                {
                    result = true;
                }
            }

            return result;
        }

        public static async Task<List<FileInformation>> GetFilesFromDirectoryListing(string url)
        {
            var scraper = new WebScraper();
            var files = await scraper.GetFilesAsync(url, 20); // Set the maximum depth to 20
            return files;
        }
        public class FileInformation
        {
            public string FURL { get; set; }
            public long Length { get; set; }
            public DateTime ModifiedDate { get; set; }
        }
        public class WebScraper
        {
            private static readonly HttpClient client = new HttpClient();
            private readonly HashSet<string> processedUrls = new HashSet<string>();

            public async Task<List<FileInformation>> GetFilesAsync(string url, int maxDepth)
            {
                var files = new List<FileInformation>();
                await GetFilesRecursiveAsync(url, files, maxDepth);
                return files;
            }

            private async Task GetFilesRecursiveAsync(string url, List<FileInformation> files, int depth)
            {
                if (depth <= 0 || processedUrls.Contains(url))
                {
                    return;
                }

                processedUrls.Add(url);

                var response = await client.GetStringAsync(url);
                var doc = new HtmlDocument();
                doc.LoadHtml(response);

                foreach (var link in doc.DocumentNode.SelectNodes("//a[@href]"))
                {
                    var href = link.GetAttributeValue("href", string.Empty);
                    if (IsDirectory(href))
                    {
                        // It's a directory, recurse into it
                        await GetFilesRecursiveAsync(new Uri(new Uri(url), href).ToString(), files, depth - 1);
                    }
                    else if (IsFile(href))
                    {
                        // It's a file, get its information
                        var fileUrl = new Uri(new Uri(url), href).ToString();
                        var fileInfo = await GetFileInfoAsync(fileUrl);
                        files.Add(fileInfo);
                    }
                }
            }

            private bool IsDirectory(string href)
            {
                return href.EndsWith("/");
            }

            private bool IsFile(string href)
            {
                // Check if the href is a valid file link
                return !string.IsNullOrEmpty(href) && !href.EndsWith("/") && !href.Contains("?");
            }

            private async Task<FileInformation> GetFileInfoAsync(string url)
            {
                var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));
                response.EnsureSuccessStatusCode();

                var fileInfo = new FileInformation
                {
                    FURL = url,
                    Length = response.Content.Headers.ContentLength ?? 0,
                    ModifiedDate = response.Content.Headers.LastModified?.UtcDateTime ?? DateTime.MinValue
                };

                return fileInfo;
            }


        }
        
    }
}
