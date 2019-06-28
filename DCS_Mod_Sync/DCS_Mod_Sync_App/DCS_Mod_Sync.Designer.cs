using System.Drawing;

namespace DCS_Mod_Sync_App
{
    partial class DCS_Mod_Sync
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Button optionsButton;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCS_Mod_Sync));
            this.titlePanel = new System.Windows.Forms.Panel();
            this.dcsServerText = new System.Windows.Forms.Label();
            this.fileSyncStatusText = new System.Windows.Forms.Label();
            this.squadTitle = new System.Windows.Forms.Label();
            this.btac_Title = new System.Windows.Forms.Label();
            this.updateStatus = new System.Windows.Forms.PictureBox();
            this.serverStatus = new System.Windows.Forms.PictureBox();
            this.logo = new System.Windows.Forms.PictureBox();
            this.lowerTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.version = new System.Windows.Forms.Label();
            this.rebuildbutton = new System.Windows.Forms.Button();
            this.VerifyButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.statusLabel = new System.Windows.Forms.Label();
            this.currentAction = new System.Windows.Forms.TextBox();
            this.LinkSite = new System.Windows.Forms.LinkLabel();
            this.exitButton = new System.Windows.Forms.Button();
            this.toolTipFileSync = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipDcsServer = new System.Windows.Forms.ToolTip(this.components);
            this.mainImage = new System.Windows.Forms.PictureBox();
            optionsButton = new System.Windows.Forms.Button();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.lowerTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainImage)).BeginInit();
            this.SuspendLayout();
            // 
            // optionsButton
            // 
            resources.ApplyResources(optionsButton, "optionsButton");
            optionsButton.BackColor = System.Drawing.Color.Transparent;
            optionsButton.BackgroundImage = global::DCS_Mod_Sync_App.Properties.Resources.options_b;
            optionsButton.FlatAppearance.BorderSize = 0;
            optionsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            optionsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            optionsButton.ForeColor = System.Drawing.Color.Transparent;
            optionsButton.Name = "optionsButton";
            optionsButton.UseVisualStyleBackColor = false;
            optionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.LightGray;
            this.titlePanel.Controls.Add(optionsButton);
            this.titlePanel.Controls.Add(this.dcsServerText);
            this.titlePanel.Controls.Add(this.fileSyncStatusText);
            this.titlePanel.Controls.Add(this.squadTitle);
            this.titlePanel.Controls.Add(this.btac_Title);
            this.titlePanel.Controls.Add(this.updateStatus);
            this.titlePanel.Controls.Add(this.serverStatus);
            this.titlePanel.Controls.Add(this.logo);
            resources.ApplyResources(this.titlePanel, "titlePanel");
            this.titlePanel.Name = "titlePanel";
            // 
            // dcsServerText
            // 
            resources.ApplyResources(this.dcsServerText, "dcsServerText");
            this.dcsServerText.ForeColor = System.Drawing.Color.Black;
            this.dcsServerText.Name = "dcsServerText";
            this.toolTipFileSync.SetToolTip(this.dcsServerText, resources.GetString("dcsServerText.ToolTip"));
            this.toolTipDcsServer.SetToolTip(this.dcsServerText, resources.GetString("dcsServerText.ToolTip1"));
            // 
            // fileSyncStatusText
            // 
            resources.ApplyResources(this.fileSyncStatusText, "fileSyncStatusText");
            this.fileSyncStatusText.ForeColor = System.Drawing.Color.Black;
            this.fileSyncStatusText.Name = "fileSyncStatusText";
            this.toolTipFileSync.SetToolTip(this.fileSyncStatusText, resources.GetString("fileSyncStatusText.ToolTip"));
            // 
            // squadTitle
            // 
            resources.ApplyResources(this.squadTitle, "squadTitle");
            this.squadTitle.BackColor = System.Drawing.Color.Transparent;
            this.squadTitle.ForeColor = System.Drawing.Color.Black;
            this.squadTitle.Name = "squadTitle";
            // 
            // btac_Title
            // 
            resources.ApplyResources(this.btac_Title, "btac_Title");
            this.btac_Title.ForeColor = System.Drawing.Color.Black;
            this.btac_Title.Name = "btac_Title";
            // 
            // updateStatus
            // 
            resources.ApplyResources(this.updateStatus, "updateStatus");
            this.updateStatus.BackColor = System.Drawing.Color.Transparent;
            this.updateStatus.BackgroundImage = global::DCS_Mod_Sync_App.Properties.Resources.red_light;
            this.updateStatus.ErrorImage = global::DCS_Mod_Sync_App.Properties.Resources.red_light;
            this.updateStatus.InitialImage = global::DCS_Mod_Sync_App.Properties.Resources.red_light;
            this.updateStatus.Name = "updateStatus";
            this.updateStatus.TabStop = false;
            this.toolTipFileSync.SetToolTip(this.updateStatus, resources.GetString("updateStatus.ToolTip"));
            // 
            // serverStatus
            // 
            resources.ApplyResources(this.serverStatus, "serverStatus");
            this.serverStatus.BackColor = System.Drawing.Color.Transparent;
            this.serverStatus.BackgroundImage = global::DCS_Mod_Sync_App.Properties.Resources.red_light;
            this.serverStatus.ErrorImage = global::DCS_Mod_Sync_App.Properties.Resources.red_light;
            this.serverStatus.InitialImage = global::DCS_Mod_Sync_App.Properties.Resources.red_light;
            this.serverStatus.Name = "serverStatus";
            this.serverStatus.TabStop = false;
            this.toolTipFileSync.SetToolTip(this.serverStatus, resources.GetString("serverStatus.ToolTip"));
            this.toolTipDcsServer.SetToolTip(this.serverStatus, resources.GetString("serverStatus.ToolTip1"));
            // 
            // logo
            // 
            this.logo.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.logo, "logo");
            this.logo.Name = "logo";
            this.logo.TabStop = false;
            // 
            // lowerTablePanel
            // 
            resources.ApplyResources(this.lowerTablePanel, "lowerTablePanel");
            this.lowerTablePanel.BackColor = System.Drawing.Color.LightGray;
            this.lowerTablePanel.CausesValidation = false;
            this.lowerTablePanel.Controls.Add(this.version, 0, 3);
            this.lowerTablePanel.Controls.Add(this.rebuildbutton, 3, 2);
            this.lowerTablePanel.Controls.Add(this.VerifyButton, 3, 0);
            this.lowerTablePanel.Controls.Add(this.downloadButton, 3, 1);
            this.lowerTablePanel.Controls.Add(this.progressBar1, 0, 2);
            this.lowerTablePanel.Controls.Add(this.statusLabel, 0, 0);
            this.lowerTablePanel.Controls.Add(this.currentAction, 1, 0);
            this.lowerTablePanel.Controls.Add(this.LinkSite, 2, 3);
            this.lowerTablePanel.Controls.Add(this.exitButton, 3, 3);
            this.lowerTablePanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.lowerTablePanel.Name = "lowerTablePanel";
            // 
            // version
            // 
            resources.ApplyResources(this.version, "version");
            this.lowerTablePanel.SetColumnSpan(this.version, 2);
            this.version.ForeColor = System.Drawing.Color.Black;
            this.version.Name = "version";
            // 
            // rebuildbutton
            // 
            resources.ApplyResources(this.rebuildbutton, "rebuildbutton");
            this.rebuildbutton.BackColor = System.Drawing.Color.Transparent;
            this.rebuildbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.rebuildbutton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.rebuildbutton.FlatAppearance.BorderSize = 0;
            this.rebuildbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.rebuildbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.rebuildbutton.ForeColor = System.Drawing.Color.Transparent;
            this.rebuildbutton.Name = "rebuildbutton";
            this.rebuildbutton.UseVisualStyleBackColor = false;
            this.rebuildbutton.Click += new System.EventHandler(this.Rebuildbutton_Click);
            // 
            // VerifyButton
            // 
            resources.ApplyResources(this.VerifyButton, "VerifyButton");
            this.VerifyButton.BackColor = System.Drawing.Color.Transparent;
            this.VerifyButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.VerifyButton.FlatAppearance.BorderSize = 0;
            this.VerifyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.VerifyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.VerifyButton.ForeColor = System.Drawing.Color.Transparent;
            this.VerifyButton.Name = "VerifyButton";
            this.VerifyButton.UseVisualStyleBackColor = false;
            this.VerifyButton.Click += new System.EventHandler(this.VerifyButton_Click);
            // 
            // downloadButton
            // 
            resources.ApplyResources(this.downloadButton, "downloadButton");
            this.downloadButton.BackColor = System.Drawing.Color.Transparent;
            this.downloadButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.downloadButton.FlatAppearance.BorderSize = 0;
            this.downloadButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.downloadButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.downloadButton.ForeColor = System.Drawing.Color.Transparent;
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.UseVisualStyleBackColor = false;
            this.downloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.lowerTablePanel.SetColumnSpan(this.progressBar1, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // statusLabel
            // 
            resources.ApplyResources(this.statusLabel, "statusLabel");
            this.statusLabel.ForeColor = System.Drawing.Color.Black;
            this.statusLabel.Name = "statusLabel";
            // 
            // currentAction
            // 
            resources.ApplyResources(this.currentAction, "currentAction");
            this.currentAction.BackColor = System.Drawing.Color.LightGray;
            this.currentAction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.currentAction.CausesValidation = false;
            this.lowerTablePanel.SetColumnSpan(this.currentAction, 2);
            this.currentAction.ForeColor = System.Drawing.Color.Black;
            this.currentAction.Name = "currentAction";
            this.currentAction.ReadOnly = true;
            this.lowerTablePanel.SetRowSpan(this.currentAction, 2);
            // 
            // LinkSite
            // 
            this.LinkSite.ActiveLinkColor = System.Drawing.Color.PaleTurquoise;
            resources.ApplyResources(this.LinkSite, "LinkSite");
            this.LinkSite.LinkColor = System.Drawing.Color.Black;
            this.LinkSite.Name = "LinkSite";
            this.LinkSite.TabStop = true;
            this.LinkSite.Tag = "";
            this.LinkSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkSite_LinkClicked_1);
            // 
            // exitButton
            // 
            resources.ApplyResources(this.exitButton, "exitButton");
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.exitButton.ForeColor = System.Drawing.Color.Transparent;
            this.exitButton.Name = "exitButton";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // toolTipFileSync
            // 
            this.toolTipFileSync.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipFileSync.ToolTipTitle = "File Synchronisation Status";
            // 
            // toolTipDcsServer
            // 
            this.toolTipDcsServer.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipDcsServer.ToolTipTitle = "85th SQN DCS Server";
            // 
            // mainImage
            // 
            resources.ApplyResources(this.mainImage, "mainImage");
            this.mainImage.BackColor = System.Drawing.Color.LightGray;
            this.mainImage.BackgroundImage = global::DCS_Mod_Sync_App.Properties.Resources.cat1;
            this.mainImage.ErrorImage = global::DCS_Mod_Sync_App.Properties.Resources.cat1;
            this.mainImage.InitialImage = global::DCS_Mod_Sync_App.Properties.Resources.cat1;
            this.mainImage.Name = "mainImage";
            this.mainImage.TabStop = false;
            // 
            // DCS_Mod_Sync
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.exitButton;
            this.Controls.Add(this.lowerTablePanel);
            this.Controls.Add(this.mainImage);
            this.Controls.Add(this.titlePanel);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "DCS_Mod_Sync";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DCS_Mod_Sync_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.DCS_Mod_Sync_Shown);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.lowerTablePanel.ResumeLayout(false);
            this.lowerTablePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel titlePanel;
        public System.Windows.Forms.PictureBox updateStatus;
        public System.Windows.Forms.PictureBox serverStatus;
        public System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.PictureBox mainImage;
        private System.Windows.Forms.TableLayoutPanel lowerTablePanel;
        private System.Windows.Forms.Button VerifyButton;
        private System.Windows.Forms.Button downloadButton;
        public System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label dcsServerText;
        private System.Windows.Forms.Label fileSyncStatusText;
        private System.Windows.Forms.Label squadTitle;
        private System.Windows.Forms.Label btac_Title;
        private System.Windows.Forms.Label statusLabel;
        public System.Windows.Forms.TextBox currentAction;
        private System.Windows.Forms.LinkLabel LinkSite;
        private System.Windows.Forms.ToolTip toolTipFileSync;
        private System.Windows.Forms.ToolTip toolTipDcsServer;
        public System.Windows.Forms.Button rebuildbutton;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

