using lib_appupdate;
using System;
using System.ComponentModel;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appupdatewin
{
    public partial class UpdatePro : Form
    {
        public bool dl_finished = false;
        public Uri asset_uri;
        public string download_file;
        public string extract_path;
        public static CancellationTokenSource ts = new CancellationTokenSource();
        CancellationToken ct = ts.Token;
        Task downloadTask;


        public UpdatePro(Uri Asset_uri, string Download_file, string Extract_path)
        {
            InitializeComponent();
            asset_uri = Asset_uri;
            download_file = Download_file;
            extract_path = Extract_path;

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
            Thread.Sleep(1000);

            Unzipper.Zipextractor(download_file, extract_path);
            DLStatus.Text = "Update is Complete. Click \"Done\" to exit.";
            DLStatus.Update();
            Btn_done.Visible = true;
        }

        private void Btn_abort_Click(object sender, EventArgs e)
        {
            ts.Cancel();
            ct.ThrowIfCancellationRequested();
            downloadTask.Dispose();
            Environment.Exit(0);
        }

        private void Btn_go_Click(object sender, EventArgs e)
        {
            Btn_go.Visible = false;
            DLStatus.Text = "Preparing Download...";
            DLStatus.Update();

            downloadTask = Task.Factory.StartNew((() =>
            {
                WebClient wb = new WebClient();
                Invoke((MethodInvoker)delegate
                {
                    wb.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.33 Safari/537.36");
                    wb.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
                    wb.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleteCallback);
                    wb.DownloadFileAsync(asset_uri, download_file);
                }, ts.Token);
            }));

        }   

        private void Btn_done_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
