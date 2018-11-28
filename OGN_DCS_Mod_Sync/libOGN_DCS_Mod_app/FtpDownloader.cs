﻿using System;
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
        //Downloads the files that require update.
        public bool DownloadFile(string URL, string destinationFilename)
        {
            bool result = false;

            using (FtpClient dlFile = new FtpClient("ftp://www.ozgamingnetwork.com.au"))
            {
                dlFile.Credentials = new NetworkCredential("dcs@ozgamingnetwork.com.au", "ozgaming");
                dlFile.Host = "ftp://www.ozgamingnetwork.com.au";
                dlFile.Connect();
                dlFile.RetryAttempts = 3;
                dlFile.DownloadFile(destinationFilename, URL, true, FtpVerify.Retry);
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
        //Gets the file last modified date and size for change comparison
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
                    FtpExists = webInfo.FileExists(URL),
                    ModifiedDate = webInfo.GetModifiedTime(URL),
                    Length = webInfo.GetFileSize(URL),
                };
            }
            return result;
        }
        public List<string> GetFilesFromDirectoryListing(string URL)
        {
            //gets the list of file names on the server
            List<string> result = new List<string>();
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
             //   public bool AcceptAllCertifications(object sender, X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
            //{ return true; }
    }
}
