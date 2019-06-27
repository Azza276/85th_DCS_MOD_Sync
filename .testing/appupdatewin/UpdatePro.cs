using Git_Release_Update_Check;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appupdatewin
{
    public partial class UpdatePro : Form
    {
        public bool dl_finished = false;
        public UpdatePro(Uri asset_uri, string download_file, string extract_path)
        {
            InitializeComponent();
            WebClient wb = new WebClient();
            wb.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.33 Safari/537.36");
            wb.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Appupdate.DownloadProgressCallback);
            wb.DownloadFileCompleted += (AsyncCompletedEventHandler, AsyncCompletedEventArgs) => { dl_finished = true; };
            wb.DownloadFileAsync(asset_uri, download_file);

            while (dl_finished != true) { };

            Appupdate.Zipextractor(download_file, extract_path);

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
