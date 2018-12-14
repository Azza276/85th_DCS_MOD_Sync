using OGN_DCS_Mod_Sync_App.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OGN_DCS_Mod_Sync_App
{
    public partial class OGN_DCS_options : Form
    {
        public Settings Settings { get; }
        public string SettingsFilename { get; }

        public delegate void NewSettingsAppliedSignature();
        public NewSettingsAppliedSignature NewSettingsApplied;

        public OGN_DCS_options(Settings settings, string settingsFilename, string autodetectedOGNModsFolder, string autodetectedLiveriesFolder)
        {
            InitializeComponent();

            Settings = settings;
            SettingsFilename = settingsFilename;

            ognFolderSettings.ValueForAutodetect = autodetectedOGNModsFolder;
            liveriesFolderSettings.ValueForAutodetect = autodetectedLiveriesFolder;

            SettingsToGUI(settings);
        }

        private void SettingsToGUI(Settings settings)
        {
            if (settings.AutodetectOgnModsFolder)
            {
                ognFolderSettings.Autodetect = true;
            }
            else
            {
                ognFolderSettings.Autodetect = false;
                ognFolderSettings.Folder = settings.OgnModsFolderOverride;
            }

            if (settings.AutodetectLiveriesFolder)
            {
                liveriesFolderSettings.Autodetect = true;                
            }
            else
            {
                liveriesFolderSettings.Autodetect = false;
                liveriesFolderSettings.Folder = settings.LiveriesFolderOverride;
            }

            downloadThreads.Value = Math.Min(settings.DownloadThreads, downloadThreads.Maximum);

            chkAutoDownloadAfterVerification.Checked = settings.AutomaticallyDownloadAfterVerification;
            chkAutoBuildLinksAfterDownload.Checked = settings.AutomaticallyBuildLinksAfterDownload;
        }

        public void GUIToSettings()
        {
            Settings.AutodetectOgnModsFolder = ognFolderSettings.Autodetect;
            Settings.OgnModsFolderOverride = ognFolderSettings.Folder;

            Settings.AutodetectLiveriesFolder = liveriesFolderSettings.Autodetect;
            Settings.LiveriesFolderOverride = liveriesFolderSettings.Folder;

            Settings.DownloadThreads = (int)downloadThreads.Value;

            Settings.AutomaticallyDownloadAfterVerification = chkAutoDownloadAfterVerification.Checked;
            Settings.AutomaticallyBuildLinksAfterDownload = chkAutoBuildLinksAfterDownload.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OGN_DCS_options_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            GUIToSettings();
            Settings.SaveToFile(SettingsFilename, Settings);
            Close();

            NewSettingsApplied?.Invoke();
        }
    }
}
