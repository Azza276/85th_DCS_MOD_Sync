using libOGN_DCS_Mod_app;
using libOGN_DCS_Mod_app.Links.Providers;
using OGN_DCS_Mod_Sync_App.Config;
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

        Settings settings;
        string settingsFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json");

        public void Init()
        {
            //Load the settings from file
            settings = Settings.LoadFromFile(settingsFilename);

            //Determine the Liveries folder
            if (settings.AutodetectLiveriesFolder)
            {
                liveriesFolder = FolderHelper.DetectLiveriesFolder();

                if (!Directory.Exists(liveriesFolder))
                {
                    SetCurrentAction("Could not autodetect Liveries folder. Please provide it using the Options window.");
                    return;
                }
            }
            else
            {
                liveriesFolder = settings.LiveriesFolderOverride;
            }

            //Determine the OGN Mods folder
            if (settings.AutodetectOgnModsFolder)
            {
                ognModFolder = FolderHelper.DetectOGNModsFolder();

                if (ognModFolder == null)
                {
                    SetCurrentAction("Could not autodetect OGN Mods folder. Please provide it using the Options window.");
                    return;
                }
            }
            else
            {
                ognModFolder = settings.OgnModsFolderOverride;
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
            if (sender != null)
            {
                //This is a user call
                if (verifyTask != null && !verifyTask.IsCompleted)
                {
                    return;
                }

                if (downloadTask != null && !downloadTask.IsCompleted)
                {
                    return;
                }
            }

            if (filesAreInSync)
            {
                return;
            }

            if (filesThatRequireUpdate.Count > 0)
            {
                downloadTask = Task.Factory.StartNew((Action)(() =>
                {
                    //Reset the progress bar
                    Invoke(new MethodInvoker(() =>
                        {
                            progressBar1.Visible = false;
                            progressBar1.Value = 0;
                            progressBar1.Maximum = 1;
                        }));

                    var filesToDownload = filesThatRequireUpdate.Where(f => f.RemoteFileInfo != null);
                    var totalFilesToDownload = filesToDownload.Count();
                    var totalBytesToDownload = filesToDownload.Sum(f => f.RemoteFileInfo.Length);

                    Invoke(new MethodInvoker(() =>
                    {
                        progressBar1.Visible = true;
                        progressBar1.Maximum = (int)totalBytesToDownload;
                    }));

                    int downloadCount = 0;

                    var ftpDownloader = new FtpDownloader();
                    ftpDownloader.OnProgressChanged += new FtpDownloader.ProgressChangedSignature((bytes) =>
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            progressBar1.Value = (int)bytes;
                        }));
                    });

                    ftpDownloader.OnStartDownload += new FtpDownloader.StartDownloadSignature((pair) =>
                    {
                        SetCurrentAction("Downloading " + Path.GetFileName(pair.LocalFilename));
                    });

                    ftpDownloader.OnFinishedDownload += new FtpDownloader.FinishedDownloadSignature((pair) =>
                    {
                        Interlocked.Increment(ref downloadCount);
                    });

                    bool allDownloadedSuccessfully = ftpDownloader.DownloadFiles(filesToDownload, settings.DownloadThreads);

                    Invoke(new MethodInvoker(() =>
                    {
                        progressBar1.Value = progressBar1.Maximum;
                    }));


                    if (!allDownloadedSuccessfully)
                    {
                        MessageBox.Show("Possible FTP Connection Problem" + Environment.NewLine + "Not all files were downloaded." + Environment.NewLine + "Please verify and try again.",
                                        "FTP Download Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    var filesToDelete = filesThatRequireUpdate.Where(f => f.RemoteFileInfo == null).ToList();
                    filesToDelete.ForEach(pair =>
                    {
                        SetCurrentAction("Removing file " + Path.GetDirectoryName(pair.LocalFilename) + @"\" + Path.GetFileNameWithoutExtension(pair.LocalFilename));
                        File.Delete(pair.LocalFilename);
                    });

                    SetCurrentAction(string.Format("Finished. Downloaded {0:N0} files.", downloadCount));

                    filesAreInSync = true;
                    updateStatus.BackgroundImage = Properties.Resources.xmas_17;

                    //Reset the progress bar
                    Invoke(new MethodInvoker(() =>
                    {
                        progressBar1.Visible = false;
                        progressBar1.Value = 0;
                    }));

                    if (settings.AutomaticallyBuildLinksAfterDownload)
                    {
                        Rebuildbutton_Click(null, null);
                    }

                    filesThatRequireUpdate.Clear();
                }));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //Povides visual indication that the client has connection to the OGN DCS server
        ServerCheck serverCheck = new ServerCheck();
        Task serverCheckTask;
        private void SetupServerCheckTimer()
        {
            serverCheckTask = Task.Factory.StartNew((Action)(() =>
            {
                while (true)
                {

                    bool serverOnline = serverCheck.GetServerResponse();

                    if (serverOnline)
                    {
                        serverStatus.BackgroundImage = Properties.Resources.xmas_17;
                    }
                    else
                    {
                        serverStatus.BackgroundImage = Properties.Resources.xmas_16;
                    }
                }
            }));
        }

        private void OGN_DCS_Mod_Sync_Shown(object sender, EventArgs e)
        {
            SetupServerCheckTimer();
            Init();
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

        string liveriesFolder;
        string ognModFolder;
        private void VerifyButton_Click(object sender, EventArgs e)
        {
            if (liveriesFolder == null || ognModFolder == null)
            {
                return;
            }

            if (verifyTask != null && !verifyTask.IsCompleted)
            {
                return;
            }

            if (downloadTask != null && !downloadTask.IsCompleted)
            {
                return;
            }

            verifyTask = Task.Factory.StartNew((Action)(() =>
            {
                filesThatRequireUpdate.Clear();

                //Create OGN Mods if it doesn't exist
                if (!Directory.Exists(ognModFolder))
                {
                    Directory.CreateDirectory(ognModFolder);
                }

                string ognLivFolder = Path.Combine(ognModFolder, "Liveries");
                if (!Directory.Exists(ognLivFolder))
                {
                    Directory.CreateDirectory(ognLivFolder);
                }

                //Reset the progress bar
                Invoke(new MethodInvoker(() =>
                {
                    progressBar1.Visible = false;
                    progressBar1.Value = 0;
                    progressBar1.Maximum = 1;
                }));

                //Reset the Update Status Light
                filesAreInSync = false;
                updateStatus.BackgroundImage = Properties.Resources.xmas_16;

                string dcsModsURL = "ftp://www.ozgamingnetwork.com.au/";

                SetCurrentAction("Getting current list of files from the server...");

                Invoke(new MethodInvoker(() =>
                {
                    progressBar1.Show();
                    progressBar1.Style = ProgressBarStyle.Marquee;
                    progressBar1.MarqueeAnimationSpeed = 50;
                }));

                var FtpDownloader = new FtpDownloader();

                List<WebFileInfo> allFilesOnWebserver;
                try
                {
                    allFilesOnWebserver = FtpDownloader.GetFilesFromDirectoryListing(dcsModsURL);
                }
                catch (Exception ex)
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        progressBar1.Style = ProgressBarStyle.Continuous;
                        progressBar1.Hide();
                    }));

                    SetCurrentAction("Could not get a file list from the server. Please try again later." + Environment.NewLine + "Cause: " + ex.Message);
                    return;
                }

                Invoke(new MethodInvoker(() =>
                {
                    progressBar1.Style = ProgressBarStyle.Continuous;
                    progressBar1.Hide();
                }));

                List<FilePair> pairs = new List<FilePair>();

                //Add the files from the web server
                pairs.AddRange(allFilesOnWebserver.Select(webFileInfo =>
                {
                    //remove the working directory from the front
                    string redactedURL = webFileInfo.URL.Replace("/" + FtpDownloader.FTP_WORKING_DIRECTORY, "");

                    string localFilename = Path.GetFullPath(ognModFolder + redactedURL);

                    var pair = new FilePair(webFileInfo, localFilename);

                    return pair;
                }));

                //Add the local files (which don't have an web counterpart)
                var localFiles = Directory.GetFiles(ognModFolder, "*.*", SearchOption.AllDirectories);
                var localFilesNotOnWebServer = localFiles
                                .Where(f => !pairs.Exists(p => p.LocalFilename.Equals(f)))
                                .Select(f => new FilePair(null, f))
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
                    updateStatus.BackgroundImage = Properties.Resources.xmas_17;
                }
                else
                {
                    var filesToDownload = filesThatRequireUpdate.Where(f => f.RemoteFileInfo != null);
                    var totalFilesToDownload = filesToDownload.Count();
                    var totalBytesToDownload = filesToDownload.Sum(f => f.RemoteFileInfo.Length);
                    var totalBytesToDownloadAsString = BytesToString(totalBytesToDownload);

                    var filesToDelete = filesThatRequireUpdate.Where(f => f.RemoteFileInfo == null);
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

                if (settings.AutomaticallyDownloadAfterVerification)
                {
                    DownloadButton_Click(null, null);
                }
            }));
        }

        private void Rebuildbutton_Click(object sender, EventArgs e)
        {
            if (liveriesFolder == null || ognModFolder == null)
            {
                return;
            }

            if (sender != null)
            {
                //This is a user call

                if (verifyTask != null && !verifyTask.IsCompleted)
                {
                    return;
                }

                if (downloadTask != null && !downloadTask.IsCompleted)
                {
                    return;
                }
            }

            try
            {
                //TODO: Based on the user's settings, use Symlinks or Junctions.
                //Junctions don't require admin rights, but can only reference local drives.
                //Symlinks require admin rights, but can reference network drivers.

                var linkUtility = new JunctionUtility();
                var linkManager = new LinkManager(liveriesFolder, ognModFolder, linkUtility);
                linkManager.DeleteCurrentLinks();
                linkManager.CreateLinks();

                if (sender != null)
                {
                    SetCurrentAction("Finished rebuilding links.");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("0x80070522"))
                {
                    MessageBox.Show("To create symlinks, the program must be run as Adminstrator", "Error rebuilding symlinks", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.ToString(), "Unknown error while rebuilding links", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            if (verifyTask != null && !verifyTask.IsCompleted)
            {
                return;
            }

            if (downloadTask != null && !downloadTask.IsCompleted)
            {
                return;
            }


            var options = new OGN_DCS_options(settings, settingsFilename, FolderHelper.DetectOGNModsFolder(), FolderHelper.DetectLiveriesFolder());

            options.NewSettingsApplied += new OGN_DCS_options.NewSettingsAppliedSignature(() =>
            {
                Init();

                //Create links to the new OGN folder
                Rebuildbutton_Click(null, null);
            });

            options.ShowDialog();
        }
    }
}
