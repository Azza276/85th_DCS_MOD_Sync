using libDCS_Mod_app;
using libDCS_Mod_app.Links.Providers;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCS_Mod_Sync_App
{
    public partial class UpdatePro : Form
    {
        public bool dl_finished = false;
        public Uri asset_uri;
        public string download_file;
        public string extract_path;
        public static CancellationTokenSource ts = new CancellationTokenSource();

        public UpdatePro(Uri Asset_uri, string Download_file, string AppFolder)
        {
            InitializeComponent();
            asset_uri = Asset_uri;
            download_file = Download_file;
            extract_path = AppFolder;

        }

        private static float count = 0;

        void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            count++;
            float div = count % 5;

            if (div == 0)
            {
                //Prints: "Downloaded 3.25 kB of 61.46 kB  (4%)"
                DLStatus.Text = "Downloaded "
                                + (e.BytesReceived / 1024f).ToString("#0.##") + " kB"
                                + " of "
                                + (e.TotalBytesToReceive / 1024f).ToString("#0.##") + " kB"
                                + "  (" + e.ProgressPercentage + "%)";
                DLStatus.Update();
            }
            updateBar.Value = e.ProgressPercentage;
            updateBar.Update();
        }

        void DownloadCompleteCallback(object sender, AsyncCompletedEventArgs e)
        {
            DLStatus.Text = "Unpacking...";
            DLStatus.Update();
            string newFilePath = Path.Combine(extract_path, "85th SQN DCS Mod Sync.exe");
            string oldFilePath = Path.Combine(extract_path, "85th SQN DCS Mod Sync_old.exe");
            string newReadme = Path.Combine(extract_path, "Readme.txt");
            string oldReadme = Path.Combine(extract_path, "Readme_old.txt");

            if (File.Exists(newFilePath))
            {
                File.Move(newFilePath, oldFilePath);
            }
            if (File.Exists(newReadme))
            {
                File.Move(newReadme, oldReadme);
            }
            Thread.Sleep(1000);

            Unzipper.Zipextractor(download_file, extract_path);

            //string desktop_path = Path.Combine(Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Desktop\"), "85th SQN DCS Sync.lnk");
            string desktop_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "85th SQN DCS Sync.lnk");

            CreateShortcut(desktop_path, newFilePath, extract_path);

            DLStatus.Text = "Update is Complete. Click \"Restart\" to Restart the 85th SQN DCS Mod Sync Application.";
            DLStatus.Update();
            Btn_abort.Visible = false;
            Btn_done.Visible = true;
        }

        private void Btn_abort_DoubleClick(object sender, EventArgs e)
        {
            ts.Cancel();
            Environment.Exit(0);
        }

        private void Btn_done_Click(object sender, EventArgs e)
        {
            string newFilePath = Path.Combine(extract_path, "85th SQN DCS Mod Sync.exe");
            System.Diagnostics.Process.Start(newFilePath);
            Environment.Exit(0);
        }

        private void UpdatePro_Shown(object sender, EventArgs e)
        {
            DLStatus.Text = "Preparing Download...";
            DLStatus.Update();

            var downloadTask = Task.Factory.StartNew((() =>
            {
                WebClient wb = new WebClient();
                Invoke((MethodInvoker)delegate
                {
                    wb.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.33 Safari/537.36");
                    wb.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
                    wb.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleteCallback);
                    wb.DownloadFileAsync(asset_uri, download_file);
                });
            }));
        }
        private void CreateShortcut(string Link_file, string Source_file, string App_folder)
        {
            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(Link_file);
            shortcut.Description = "85th SQN DCS Mod Sync";
            shortcut.RelativePath = App_folder;
            shortcut.TargetPath = Source_file;
            shortcut.Save();
        }
    }
}
