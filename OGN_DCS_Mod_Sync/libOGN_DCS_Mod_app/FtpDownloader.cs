using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using FluentFTP;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace libOGN_DCS_Mod_app
{
    public class FtpDownloader
    {
        public delegate void ProgressChangedSignature(long bytes);
        public ProgressChangedSignature OnProgressChanged;

        public delegate void StartDownloadSignature(FilePair pair);
        public StartDownloadSignature OnStartDownload;

        public delegate void FinishedDownloadSignature(FilePair pair);
        public FinishedDownloadSignature OnFinishedDownload;

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
                    var totalBytesDownloaded = filesToDownload.Sum(f => f.Progress.CurrentValue);
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
                    DownloadFile(f.Pair, f.Progress);
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
        public bool DownloadFile(FilePair pair, IProgress<double> progress)
        {
            bool result = false;

            using (FtpClient dlFile = new FtpClient("ftp://www.ozgamingnetwork.com.au"))
            {
                dlFile.Credentials = new NetworkCredential("dcs@ozgamingnetwork.com.au", "ozgaming");
                dlFile.Host = "ftp://www.ozgamingnetwork.com.au";
                dlFile.Connect();
                dlFile.RetryAttempts = 3;
                dlFile.DownloadFile(pair.LocalFilename, pair.WebFileInfo.URL, true, FtpVerify.Retry, progress);

                if (File.Exists(pair.LocalFilename))
                {
                    result = true;
                }
            }

            /*FtpWebRequest request = (FtpWebRequest)WebRequest.Create(URL + " -a");
            request.KeepAlive = true;
            request.UsePassive = true;
            request.UseBinary = true;
            request.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback = AcceptAllCertifications;
            request.Credentials = new NetworkCredential("dcs@ozgamingnetwork.com.au", "ozgaming");
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII);
            var remoteFile = reader.ReadLine();
            remoteFile.Substring(62);*/

            /*using (var client = new WebClient())
            {
                client.DownloadFile(URL, destinationFilename);

                if (File.Exists(destinationFilename))
                {
                    result = true;
                }
            }*/

            return result;
        }
        //Gets the file last modified date and size for change comparison
        /*
        public WebFileInfo GetUrlInfo(string URL)
        {
            WebFileInfo result = null;

            using (FtpClient webInfo = new FtpClient("ftp://www.ozgamingnetwork.com.au"))
            {
                webInfo.Credentials = new NetworkCredential("dcs@ozgamingnetwork.com.au", "ozgaming");
                webInfo.Host = "ftp://www.ozgamingnetwork.com.au";
                webInfo.Connect();
                webInfo.GetObjectInfo(URL);

                result = new WebFileInfo()
                {
                    URL = URL,
                    ModifiedDate = webInfo.GetModifiedTime(URL),
                    Length = webInfo.GetFileSize(URL),
                };
            }
            return result;
        }
        */

        public List<WebFileInfo> GetFilesFromDirectoryListing(string URL)
        {
            //gets the list of file names on the server
            List<WebFileInfo> result = new List<WebFileInfo>();
            var streamToLines = new List<string>();

            using (FtpClient conn = new FtpClient(URL))
            {
                conn.Credentials = new NetworkCredential("dcs@ozgamingnetwork.com.au", "ozgaming");
                //Seems to not be needed at this stage.
                //conn.EncryptionMode = FtpEncryptionMode.Implicit;
                //conn.SslProtocols = SslProtocols.Tls;
                //conn.SocketKeepAlive = true;
                //conn.ValidateCertificate += new FtpSslValidation(OnValidateCertificate);

                conn.Connect();

                //void OnValidateCertificate(FtpClient control, FtpSslValidationEventArgs e)
                //{
                // add logic to test if certificate is valid here
                //    e.Accept = true;
                //}

                conn.SetWorkingDirectory("OGN_Mods");

                var list = conn.GetListing(
                    conn.GetWorkingDirectory(),
                    //FtpListOption.Modify | FtpListOption.Size | FtpListOption.DerefLinks | FtpListOption.Recursive | FtpListOption.ForceList);
                    //FtpListOption.Size | FtpListOption.DerefLinks | FtpListOption.Recursive | FtpListOption.ForceList);
                    FtpListOption.DerefLinks | FtpListOption.Recursive | FtpListOption.ForceList);

                foreach (FtpListItem item in list)
                {
                    switch (item.Type)
                    {
                        case FtpFileSystemObjectType.Directory:
                            break;
                        case FtpFileSystemObjectType.File:
                            var newWebFileInfo = new WebFileInfo()
                            {
                                URL = item.FullName,
                                Length = item.Size,
                                ModifiedDate = item.Modified
                            };
                            result.Add(newWebFileInfo);
                            break;
                        case FtpFileSystemObjectType.Link:
                            if (item.LinkObject != null)
                            {
                                // switch (item.LinkObject.Type)...
                            }
                            break;
                    }
                }

                return result;
            }
        }
        //   public bool AcceptAllCertifications(object sender, X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        //{ return true; }
    }
}
