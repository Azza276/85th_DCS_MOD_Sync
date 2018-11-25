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

namespace libOGN_DCS_Mod_app
{
    public class FtpDownloader
    {

        public bool DownloadFile(string URL, string destinationFilename)
        {
            bool result = false;

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(URL + " -a");
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
            remoteFile.Substring(62);




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

        public WebFileInfo GetUrlInfo(string URL)
        {
            WebFileInfo result = null;

            using (FtpClient ileInfo = new FtpClient("ftp://www.ozgamingnetwork.com.au"))
            {
                ileInfo.Credentials = new NetworkCredential("dcs@ozgamingnetwork.com.au", "ozgaming");
                ileInfo.Host = "ftp://www.ozgamingnetwork.com.au";
                ileInfo.Connect();
                ileInfo.GetObjectInfo(URL);


                result = new WebFileInfo()
                {
                    URL = URL,
                    ModifiedDate = ileInfo.GetModifiedTime(URL),
                    Length = ileInfo.GetFileSize(URL),
                    };










                /*using (Stream ftpStream = request.GetResponse().GetResponseStream())
                using (Stream fileStream = File.Create(localFilename + "dcs_file_list.txt"))
                {
                    byte[] buffer = new byte[10240];
                    int read;
                    while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, read);
                        Console.WriteLine("Downloaded {0} bytes", fileStream.Position);
                    }
                }*/



                //try to not set off BitNinja
                //Thread.Sleep(500);



                

            }
            return result;
        }
        public List<string> GetFilesFromDirectoryListing(string URL)
        {
            List<string> result = new List<string>();
            var streamToLines = new List<string>();


            using (FtpClient conn = new FtpClient(URL))
            {

                conn.Credentials = new NetworkCredential("dcs@ozgamingnetwork.com.au", "ozgaming");
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

                /* Save for now
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(URL + " -a");
                request.KeepAlive = true;
                request.UsePassive = true;
                request.UseBinary = false;
                request.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback = AcceptAllCertifications;
                request.Credentials = new NetworkCredential("dcs@ozgamingnetwork.com.au", "ozgaming");

                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;*/
                conn.SetWorkingDirectory("DCS_Mods");
                foreach (FtpListItem item in conn.GetListing(conn.GetWorkingDirectory(),
                FtpListOption.Modify | FtpListOption.Size | FtpListOption.DerefLinks | FtpListOption.Recursive | FtpListOption.ForceList))
                {
                    switch (item.Type)
                    {
                        case FtpFileSystemObjectType.Directory:
                            break;
                        case FtpFileSystemObjectType.File:
                            var fileURL = item.FullName;
                            result.Add(fileURL);
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
    





            /*
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
                {

                    while (reader.EndOfStream == false)
                    {
                        streamToLines.Add(reader.ReadLine());
                    }
                    //var lines = ftpResponse.Split(new string [] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                    List<string> trLines = new List<string>();
                    if (streamToLines[0].StartsWith("d"))
                    {
                        trLines = streamToLines.Skip(2).ToList();
                    }
                    else if (streamToLines[0].StartsWith("-"))
                    {
                        trLines = streamToLines.Skip(2).ToList();
                    }
                    else
                    {
                        trLines = streamToLines.Skip(6).ToList();
                    }

                    foreach (var trLine in trLines)
                    {

                        string relativeURL = trLine.Substring(62);
                        string fullURL = Path.Combine(URL, relativeURL);

                        if (trLine.StartsWith("d"))
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

                    // reader.Close();
                }

                //response.Close();    
            }


            return result;
        }*/
            public bool AcceptAllCertifications(object sender, X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
            { return true; }
    }
}
