using DCS_Mod_Sync_App.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCS_Mod_Sync_App
{
    public partial class DCS_options : Form
    {
        public Settings Settings { get; }
        public string SettingsFilename { get; }

        public delegate void NewSettingsAppliedSignature();
        public NewSettingsAppliedSignature NewSettingsApplied;

        public DCS_options(Settings settings, string settingsFilename, string autodetectedModsFolder, string autodetectedLiveriesFolder)
        {
            InitializeComponent();

            Settings = settings;
            SettingsFilename = settingsFilename;

            FolderSettings.ValueForAutodetect = autodetectedModsFolder;
            liveriesFolderSettings.ValueForAutodetect = autodetectedLiveriesFolder;

            SettingsToGUI(settings);
        }

        private void SettingsToGUI(Settings settings)
        {
            if (settings.AutodetectModsFolder)
            {
                FolderSettings.Autodetect = true;
            }
            else
            {
                FolderSettings.Autodetect = false;
                FolderSettings.Folder = settings.ModsFolderOverride;
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
            Settings.AutodetectModsFolder = FolderSettings.Autodetect;
            Settings.ModsFolderOverride = FolderSettings.Folder;

            Settings.AutodetectLiveriesFolder = liveriesFolderSettings.Autodetect;
            Settings.LiveriesFolderOverride = liveriesFolderSettings.Folder;

            Settings.DownloadThreads = (int)downloadThreads.Value;

            Settings.AutomaticallyDownloadAfterVerification = chkAutoDownloadAfterVerification.Checked;
            Settings.AutomaticallyBuildLinksAfterDownload = chkAutoBuildLinksAfterDownload.Checked;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DCS_options_Load(object sender, EventArgs e)
        {

        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            GUIToSettings();
            Settings.SaveToFile(SettingsFilename, Settings);
            Close();

            NewSettingsApplied?.Invoke();
        }
    }
}
