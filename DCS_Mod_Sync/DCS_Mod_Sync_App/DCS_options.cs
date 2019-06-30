using DCS_Mod_Sync_App.Config;
using libDCS_Mod_app;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        public DCS_options(Settings settings, string settingsFilename, string autodetectedModsFolder, string autodetectedLiveriesFolder, string defaultAppFolder)
        {
            InitializeComponent();

            Settings = settings;
            SettingsFilename = settingsFilename;

            FolderSettings.ValueForAutodetect = autodetectedModsFolder;
            liveriesFolderSettings.ValueForAutodetect = autodetectedLiveriesFolder;
            appFolderSettings.ValueForAutodetect = defaultAppFolder;

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

            if (settings.AutodetectAppFolder)
            {
                appFolderSettings.Autodetect = true;
            }
            else
            {
                appFolderSettings.Autodetect = false;
                appFolderSettings.Folder = settings.AppFolderOverride;
            }

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

            Settings.AutodetectAppFolder = appFolderSettings.Autodetect;
            Settings.AppFolderOverride = appFolderSettings.Folder;

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

            if (chkDeleteLinksandModFolder.Checked)
            {
                var linkUtility = new libDCS_Mod_app.Links.Providers.JunctionUtility();
                var linkManager = new LinkManager(liveriesFolderSettings.Folder, FolderSettings.Folder, linkUtility);
                linkManager.DeleteCurrentLinks();

                DeleteEmptyDirs(liveriesFolderSettings.Folder);


                void DeleteEmptyDirs(string dir)
                {
                    if (String.IsNullOrEmpty(dir))
                        throw new ArgumentException(
                            "Starting directory is a null reference or an empty string",
                            "dir");

                    try
                    {
                        foreach (var d in Directory.EnumerateDirectories(dir))
                        {
                            DeleteEmptyDirs(d);
                        }

                        var entries = Directory.EnumerateFileSystemEntries(dir);

                        if (!entries.Any())
                        {
                            try
                            {
                                Directory.Delete(dir);
                            }
                            catch (UnauthorizedAccessException) { }
                            catch (DirectoryNotFoundException) { }
                        }
                    }
                    catch (UnauthorizedAccessException) { }
                }
                try
                {
                    Directory.Delete(FolderSettings.Folder, true);
                    bool directoryExists = Directory.Exists(FolderSettings.Folder);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Unknown error while Deleting Files", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void ChkDeleteLinksandModFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeleteLinksandModFolder.Checked)
            {
                chkDeleteLinksandModFolder.BackColor = System.Drawing.Color.Red;
                chkDeleteLinksandModFolder.ForeColor = System.Drawing.Color.White;
            }
            if (!chkDeleteLinksandModFolder.Checked)
            {
                chkDeleteLinksandModFolder.BackColor = System.Drawing.Color.LightGray;
                chkDeleteLinksandModFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            }
        }

        private void ChkDeleteLinksandModFolder_MouseEnter(object sender, EventArgs e)
        {
            chkDeleteLinksandModFolder.ForeColor = System.Drawing.Color.Red;
        }

        private void ChkDeleteLinksandModFolder_MouseLeave(object sender, EventArgs e)
        {
            chkDeleteLinksandModFolder.ForeColor = System.Drawing.SystemColors.ControlText;
        }
    }
}
