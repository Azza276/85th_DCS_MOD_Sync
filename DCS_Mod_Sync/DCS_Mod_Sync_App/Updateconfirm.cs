using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DCS_Mod_Sync_App
{
    public partial class Updateconfirm : Form
    {
        public string ReleaseUrl;
        public string Asset_Url;
        public Uri asset_uri;
        public string download_file;
        public string extract_path;

        public Updateconfirm(string Filename, string Version, DateTimeOffset? DateFull, double Size, Uri Asset_Uri, string Download_file, string Extract_path, string Releaseurl)
        {
            InitializeComponent();

            string Sizetext = Size.ToString() + " kB";
            DateTimeOffset? Date = DateFull?.ToOffset(new TimeSpan(+10, 0, 0));
            string Datetext = Date.ToString();
            Asset_Url = Asset_Uri.ToString();
            ReleaseUrl = Releaseurl;
            asset_uri = Asset_Uri;
            download_file = Download_file;
            extract_path = Extract_path;

            File_text(Filename, Version, Datetext, Sizetext, Extract_path);


        }

        public Updateconfirm()
        {
        }

        private void Btn_Link_Click(object sender, EventArgs e)
        {
            Process.Start(ReleaseUrl);
            Close();
            //Environment.Exit(0);
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            UpdatePro progresswin = new UpdatePro(asset_uri, download_file, extract_path);
            progresswin.ShowDialog();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {

        }

        private void File_text(string filename, string version, string date, string size, string ExtractPath)
        {
            Filenametxt.Text = filename;
            Versiontxt.Text = version;
            Dateupdatedtxt.Text = date;
            Filesizetxt.Text = size;
            Installpathtxt.Text = ExtractPath;
        }
    }
}
