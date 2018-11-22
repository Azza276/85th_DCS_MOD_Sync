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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks!");
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

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

        private void verifyButton_Click(object sender, EventArgs e)
        {
            if (verifyTask != null && !verifyTask.IsCompleted)
            {
                return;
            }

            verifyTask = Task.Factory.StartNew(() =>
            {
                //Reset the progress bar
                Invoke(new MethodInvoker(() =>
                {
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

                string dcsModsURL = "https://www.ozgamingnetwork.com.au/DCS_Mods/";

                SetCurrentAction("Getting file list from web server...");

                var downloader = new Downloader();
                var allFilesOnWebserver = downloader.GetFilesFromDirectoryListing(dcsModsURL, liveriesFolder);

                var pairs = allFilesOnWebserver.Select(url =>
                {
                    string relativeURL = url.Replace(dcsModsURL, string.Empty);
                    string decodedRelativeURL = System.Net.WebUtility.UrlDecode(relativeURL);
                    string localFilename = Path.Combine(dcsFolder, decodedRelativeURL);

                    var pair = new FilePair(dcsFolder, url, localFilename);

                    return pair;
                })
                .ToList();

                                //Check if files need updating
                List<FilePair> filesThatRequireUpdate = new List<FilePair>();

                Invoke(new MethodInvoker(() =>
                {
                    progressBar1.Maximum = pairs.Count();
                }));

                pairs.ForEach(pair =>
                {
                    SetCurrentAction("Checking " + Path.GetFileName(pair.LocalFilename));
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
                    SetCurrentAction("All files are up to date. No downloads required.");
                }
                else
                {
                    var totalBytesToDownload = filesThatRequireUpdate.Sum(f => f.WebFileInfo.Length);
                    var totalBytesToDownloadAsString = BytesToString(totalBytesToDownload);

                    string sizeString = $"{filesThatRequireUpdate.Count} files, totalling {totalBytesToDownloadAsString} require an update.";
                    SetCurrentAction(sizeString);

                    /*

                        foreach (var pair in filesThatRequireUpdate)
                        {
                            bool downloaded = pair.Download();
                            if (downloaded)
                            {
                                downloadCount++;
                            }
                        }

                        Console.WriteLine("Finished. Downloaded {0} files.", downloadCount);
                    }
                    */
                }
            });
        }
    }
}
