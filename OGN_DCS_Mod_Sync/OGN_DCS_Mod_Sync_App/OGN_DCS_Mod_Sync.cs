using libOGN_DCS_Mod_app;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace OGN_DCS_Mod_Sync_App
{
    public partial class OGN_DCS_Mod_Sync : Form
    {
        public OGN_DCS_Mod_Sync()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            //Determine DCS Users Directory
            var folderHelper = new FolderHelper();
            string dcsFolder = folderHelper.DetectDCSFolder();

            if (dcsFolder == null)
            {
                SetCurrentAction("Could not find DCS folder");
                return;
            }
        }

        List<FilePair> filesThatRequireUpdate = new List<FilePair>();

        private void LinkSite_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.ozgamingnetwork.com.au/forums");
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Task downloadTask;
        public bool filesAreInSync = false;

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            if (verifyTask != null && !verifyTask.IsCompleted)
            {
                return;
            }

            if (downloadTask != null && !downloadTask.IsCompleted)
            {
                return;
            }

            if (filesAreInSync)
            {
                return;
            }

            if (filesThatRequireUpdate.Count > 0)
            {
                downloadTask = Task.Factory.StartNew(() =>
                {
                    //Reset the progress bar
                    Invoke(new MethodInvoker(() =>
                        {
                            progressBar1.Visible = false;
                            progressBar1.Value = 0;
                            progressBar1.Maximum = 1;
                        }));

                    var totalFilesToDownload = filesThatRequireUpdate.Where(f => f.WebFileInfo != null).Count();

                    Invoke(new MethodInvoker(() =>
                    {
                        progressBar1.Visible = true;
                        progressBar1.Maximum = totalFilesToDownload;
                    }));

                    int downloadCount = 0;
                    filesThatRequireUpdate
                        .AsParallel()
                        .WithDegreeOfParallelism(4)
                        .ForAll(pair =>
                        {
                            if (pair.WebFileInfo == null)
                            {
                                SetCurrentAction("Removing file " + Path.GetDirectoryName(pair.LocalFilename) + @"\" + Path.GetFileNameWithoutExtension(pair.LocalFilename));
                                File.Delete(pair.LocalFilename);
                            }
                            else
                            {
                                var ftpDownloader = new FtpDownloader();

                                SetCurrentAction("Downloading " + Path.GetDirectoryName(pair.LocalFilename) + @"\" + Path.GetFileNameWithoutExtension(pair.LocalFilename));

                                bool downloaded = ftpDownloader.DownloadFile(pair.WebFileInfo, pair.LocalFilename);
                                if (downloaded)
                                {
                                    Interlocked.Increment(ref downloadCount);

                                    Invoke(new MethodInvoker(() =>
                                    {
                                        progressBar1.Increment(1);
                                    }));
                                }
                            }
                        });

                    SetCurrentAction(string.Format("Finished. Downloaded {0:N0} files.", downloadCount));

                    filesAreInSync = true;
                    updateStatus.BackgroundImage = Properties.Resources.green_light;

                    //Reset the progress bar
                    Invoke(new MethodInvoker(() =>
                        {
                            progressBar1.Visible = false;
                            progressBar1.Value = 0;
                        }));
                });
            }

            var symlinkManager = new SymlinkManager(dcsFolder, ognModFolder);
            symlinkManager.DeleteCurrentSymlinks();
            symlinkManager.CreateSymlinks();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //Povides visual indication that the client has connection to the OGN DCS server
        ServerCheck serverCheck = new ServerCheck();
        Task serverCheckTask;
        private void SetupServerCheckTimer()
        {
            serverCheckTask = Task.Factory.StartNew(() =>
            {
                while (true)
                {

                    bool serverOnline = serverCheck.GetServerResponse();

                    if (serverOnline)
                    {
                        serverStatus.BackgroundImage = Properties.Resources.green_light;
                    }
                    else
                    {
                        serverStatus.BackgroundImage = Properties.Resources.red_light;
                    }
                }
            });
        }

        private void OGN_DCS_Mod_Sync_Shown(object sender, EventArgs e)
        {
            SetupServerCheckTimer();
        }

        private void OGN_DCS_Mod_Sync_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        static String BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }

        Task verifyTask;

        public void SetCurrentAction(string status)
        {
            Invoke(new MethodInvoker(() =>
            {
                currentAction.Text = status;
            }));
        }

        string dcsFolder;
        string liveriesFolder;
        string ognModFolder;
        private void VerifyButton_Click(object sender, EventArgs e)
        {
            if (verifyTask != null && !verifyTask.IsCompleted)
            {
                return;
            }

            if (downloadTask != null && !downloadTask.IsCompleted)
            {
                return;
            }

            verifyTask = Task.Factory.StartNew(() =>
            {
                //Reset the progress bar
                Invoke(new MethodInvoker(() =>
                {
                    progressBar1.Visible = false;
                    progressBar1.Value = 0;
                    progressBar1.Maximum = 1;
                }));

                //Reset the Update Status Light
                filesAreInSync = false;
                updateStatus.BackgroundImage = Properties.Resources.red_light;

                //Determine DCS Users Directory
                var folderHelper = new FolderHelper();
                dcsFolder = folderHelper.DetectDCSFolder();

                if (dcsFolder == null)
                {
                    SetCurrentAction("Could not find DCS folder");
                    return;
                }

                //Create the Liveries folder if it doesn't exist
                liveriesFolder = Path.Combine(dcsFolder, "Liveries");
                if (!Directory.Exists(liveriesFolder))
                {
                    Directory.CreateDirectory(liveriesFolder);
                }

                //Create OGN Mod and Liveries Folder if it doesn't exist
                ognModFolder = Path.Combine(dcsFolder, "OGN_Mods");
                if (!Directory.Exists(ognModFolder))
                {
                    Directory.CreateDirectory(ognModFolder);
                }

                string ognLivFolder = Path.Combine(ognModFolder, "Liveries");
                if (!Directory.Exists(ognLivFolder))
                {
                    Directory.CreateDirectory(ognLivFolder);
                }

                string dcsModsURL = "ftp://www.ozgamingnetwork.com.au/";

                SetCurrentAction("Getting current list of files from the server...");

                var FtpDownloader = new FtpDownloader();
                var allFilesOnWebserver = FtpDownloader.GetFilesFromDirectoryListing(dcsModsURL);

                List<FilePair> pairs = new List<FilePair>();

                //Add the files from the web server
                pairs.AddRange(allFilesOnWebserver.Select(webFileInfo =>
                {
                    string localFilename = (dcsFolder + webFileInfo.URL);

                    var pair = new FilePair(ognModFolder, webFileInfo, localFilename);

                    return pair;
                }));

                //Add the local files (which don't have an web counterpart)
                var localFiles = Directory.GetFiles(ognModFolder, "*.*", SearchOption.AllDirectories);
                var localFilesNotOnWebServer = localFiles
                                .Where(f => !pairs.Exists(p => p.LocalFilename.Equals(f)))
                                .Select(f => new FilePair(ognModFolder, null, f))
                                .ToList();
                pairs.AddRange(localFilesNotOnWebServer);

                pairs.ForEach(pair =>
                {
                    if (pair.RequiresUpdate())
                    {
                        filesThatRequireUpdate.Add(pair);
                    }
                });

                if (filesThatRequireUpdate.Count == 0)
                {
                    SetCurrentAction("All files are up to date. No downloads are required.");
                    filesAreInSync = true;
                    updateStatus.BackgroundImage = Properties.Resources.green_light;
                }
                else
                {
                    var filesToDownload = filesThatRequireUpdate.Where(f => f.WebFileInfo != null);
                    var totalFilesToDownload = filesToDownload.Count();
                    var totalBytesToDownload = filesToDownload.Sum(f => f.WebFileInfo.Length);
                    var totalBytesToDownloadAsString = BytesToString(totalBytesToDownload);

                    var filesToDelete = filesThatRequireUpdate.Where(f => f.WebFileInfo == null);
                    var totalFilesToDelete = filesToDelete.Count();

                    string sizeString = "";
                    if (totalFilesToDownload > 0)
                    {
                        sizeString += $"{totalFilesToDownload} files, totalling {totalBytesToDownloadAsString} require downloading. ";
                    }
                    
                    if (totalFilesToDelete > 0)
                    {
                        sizeString += $"{totalFilesToDelete} files will be removed.";
                    }
                    
                    SetCurrentAction(sizeString);
                }

                //Reset the progress bar
                Invoke(new MethodInvoker(() =>
                {
                    progressBar1.Visible = false;
                    progressBar1.Value = 0;
                }));
            });
        }

    }
}
