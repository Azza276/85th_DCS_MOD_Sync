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
        }

        private void LinkSite_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        System.Diagnostics.Process.Start("www.ozgamingnetwork.com.au/forums");

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Task downloadTask;
        public bool update_status = false;
        public object update_pairs = null;

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

            if (update_status == true)
            {
                return;
            }

            downloadTask = Task.Factory.StartNew(() =>
            {
                {
                    //Reset the progress bar
                    Invoke(new MethodInvoker(() =>
                    {
                        progressBar1.Visible = false;
                        progressBar1.Value = 0;
                        progressBar1.Maximum = 1;
                    }));

                    //Determine DCS Users Directory
                    var folderHelper = new FolderHelper();
                    string dcsFolder = folderHelper.DetectDCSFolder();

                    if (dcsFolder == null)
                    {
                        SetCurrentAction("Could not find DCS folder");
                        return;
                    }

                    //Create the Liveries folder if it doesn't exist
                    string liveriesFolder = Path.Combine(dcsFolder, "Liveries");
                    if (!Directory.Exists(liveriesFolder))
                    {
                        Directory.CreateDirectory(liveriesFolder);
                    }

                    //Create OGN Mod and Liveries Folder if it doesn't exist
                    string ognModFolder = Path.Combine(dcsFolder, "OGN_Mods");
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

                    SetCurrentAction("Updating Local files (deleting files removed from server)");
                    FilePair.DeleteOld


                    var FtpDownloader = new FtpDownloader();









                }
            });
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
                update_status = false;
                updateStatus.BackgroundImage = Properties.Resources.red_light;

                //Determine DCS Users Directory
                var folderHelper = new FolderHelper();
                string dcsFolder = folderHelper.DetectDCSFolder();

                if (dcsFolder == null)
                {
                    SetCurrentAction("Could not find DCS folder");
                    return;
                }

                //Create the Liveries folder if it doesn't exist
                string liveriesFolder = Path.Combine(dcsFolder, "Liveries");
                if (!Directory.Exists(liveriesFolder))
                {
                    Directory.CreateDirectory(liveriesFolder);
                }

                //Create OGN Mod and Liveries Folder if it doesn't exist
                string ognModFolder = Path.Combine(dcsFolder, "OGN_Mods");
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

                var pairs = allFilesOnWebserver.Select(url =>
                {
                    string relativeURL = url; //url.Replace(dcsModsURL, string.Empty);
                    string localFilename = Path.Combine(dcsFolder, relativeURL);

                    var pair = new FilePair(ognModFolder, url, localFilename);

                    return pair;
                })
                .ToList();

                                //Check if files need updating
                List<FilePair> filesThatRequireUpdate = new List<FilePair>();

                Invoke(new MethodInvoker(() =>
                {
                    progressBar1.Visible = true;
                    progressBar1.Maximum = pairs.Count();
                }));

            pairs.ForEach(pair =>
            {
            SetCurrentAction("Checking " + Path.GetDirectoryName(pair.LocalFilename) + @"\" + Path.GetFileNameWithoutExtension(pair.LocalFilename));
                    Invoke(new MethodInvoker(() =>
                    {
                        progressBar1.Increment(1);
                    }));

                    if (pair.RequiresUpdate())
                    {
                        filesThatRequireUpdate.Add(pair);
                    }
                });

                if (filesThatRequireUpdate.Count == 0)
                {
                    SetCurrentAction("All files are up to date. No downloads are required.");
                    update_status = true;
                    updateStatus.BackgroundImage = Properties.Resources.green_light;
                }
                else
                {
                    var totalBytesToDownload = filesThatRequireUpdate.Sum(f => f.WebFileInfo.Length);
                    var totalBytesToDownloadAsString = BytesToString(totalBytesToDownload);

                    string sizeString = $"{filesThatRequireUpdate.Count} files, totalling {totalBytesToDownloadAsString} require an update.";
                    SetCurrentAction(sizeString);

                }

                update_pairs = pairs;

                //Reset the progress bar
                Invoke(new MethodInvoker(() =>
                {
                    progressBar1.Visible = false;
                    progressBar1.Value = 0;
                    progressBar1.Maximum = 1;
                }));




            });
        }
    }
}
