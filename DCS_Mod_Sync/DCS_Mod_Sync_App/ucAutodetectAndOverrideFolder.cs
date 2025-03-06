using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCS_Mod_Sync_App
{
    public partial class UcAutodetectAndOverrideFolder : UserControl
    {
        public UcAutodetectAndOverrideFolder()
        {
            InitializeComponent();

            ucAutoDetectAndOverride1.chkAutodetect.CheckedChanged += ChkAutodetect_CheckedChanged;
        }

        private void ChkAutodetect_CheckedChanged(object sender, EventArgs e)
        {
            if (ucAutoDetectAndOverride1.chkAutodetect.Checked)
            {
                lblAutodetectedFolder.Text = ValueForAutodetect;
                lblAutodetectedFolder.Show();

                ucAutoDetectAndOverride1.txt.Text = ValueForAutodetect; // Ensure the text box is updated
                ucAutoDetectAndOverride1.txt.Hide();
                btnBrowse.Hide();
            }
            else
            {
                lblAutodetectedFolder.Hide();

                ucAutoDetectAndOverride1.txt.Show();
                btnBrowse.Show();
            }
        }

        public bool Autodetect
        {
            get
            {
                return ucAutoDetectAndOverride1.chkAutodetect.Checked;
            }

            set
            {
                ucAutoDetectAndOverride1.chkAutodetect.Checked = value;
                ChkAutodetect_CheckedChanged(null, null);
            }
        }
        public string ValueForAutodetect { get; set; }

        public string Folder
        {
            get
            {
                return ucAutoDetectAndOverride1.txt.Text;
            }

            set
            {
                ucAutoDetectAndOverride1.txt.Text = value;
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Reset();
                dialog.Description = "Please select a folder";
                dialog.ShowNewFolderButton = true;
                dialog.SelectedPath = ucAutoDetectAndOverride1.txt.Text;
                
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ucAutoDetectAndOverride1.txt.Text = dialog.SelectedPath;
                }
            }
        }
    }
}
