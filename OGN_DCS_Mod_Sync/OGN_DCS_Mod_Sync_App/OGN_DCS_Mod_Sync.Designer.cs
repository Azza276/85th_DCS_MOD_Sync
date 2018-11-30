namespace OGN_DCS_Mod_Sync_App
{
    partial class OGN_DCS_Mod_Sync
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OGN_DCS_Mod_Sync));
            this.titlePanel = new System.Windows.Forms.Panel();
            this.dcsServerText = new System.Windows.Forms.Label();
            this.fileSyncStatusText = new System.Windows.Forms.Label();
            this.squadTitle = new System.Windows.Forms.Label();
            this.ozGamingTitle = new System.Windows.Forms.Label();
            this.updateStatus = new System.Windows.Forms.PictureBox();
            this.serverStatus = new System.Windows.Forms.PictureBox();
            this.logo = new System.Windows.Forms.PictureBox();
            this.lowerTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.VerifyButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.statusLabel = new System.Windows.Forms.Label();
            this.currentAction = new System.Windows.Forms.TextBox();
            this.LinkSite = new System.Windows.Forms.LinkLabel();
            this.mainImage = new System.Windows.Forms.PictureBox();
            this.toolTipFileSync = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipDcsServer = new System.Windows.Forms.ToolTip(this.components);
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.lowerTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainImage)).BeginInit();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.SteelBlue;
            this.titlePanel.Controls.Add(this.dcsServerText);
            this.titlePanel.Controls.Add(this.fileSyncStatusText);
            this.titlePanel.Controls.Add(this.squadTitle);
            this.titlePanel.Controls.Add(this.ozGamingTitle);
            this.titlePanel.Controls.Add(this.updateStatus);
            this.titlePanel.Controls.Add(this.serverStatus);
            this.titlePanel.Controls.Add(this.logo);
            resources.ApplyResources(this.titlePanel, "titlePanel");
            this.titlePanel.Name = "titlePanel";
            // 
            // dcsServerText
            // 
            resources.ApplyResources(this.dcsServerText, "dcsServerText");
            this.dcsServerText.ForeColor = System.Drawing.Color.White;
            this.dcsServerText.Name = "dcsServerText";
            this.toolTipFileSync.SetToolTip(this.dcsServerText, resources.GetString("dcsServerText.ToolTip"));
            this.toolTipDcsServer.SetToolTip(this.dcsServerText, resources.GetString("dcsServerText.ToolTip1"));
            // 
            // fileSyncStatusText
            // 
            resources.ApplyResources(this.fileSyncStatusText, "fileSyncStatusText");
            this.fileSyncStatusText.ForeColor = System.Drawing.Color.White;
            this.fileSyncStatusText.Name = "fileSyncStatusText";
            this.toolTipFileSync.SetToolTip(this.fileSyncStatusText, resources.GetString("fileSyncStatusText.ToolTip"));
            // 
            // squadTitle
            // 
            resources.ApplyResources(this.squadTitle, "squadTitle");
            this.squadTitle.BackColor = System.Drawing.Color.SteelBlue;
            this.squadTitle.ForeColor = System.Drawing.Color.White;
            this.squadTitle.Name = "squadTitle";
            // 
            // ozGamingTitle
            // 
            resources.ApplyResources(this.ozGamingTitle, "ozGamingTitle");
            this.ozGamingTitle.ForeColor = System.Drawing.Color.White;
            this.ozGamingTitle.Name = "ozGamingTitle";
            // 
            // updateStatus
            // 
            resources.ApplyResources(this.updateStatus, "updateStatus");
            this.updateStatus.BackColor = System.Drawing.Color.Transparent;
            this.updateStatus.Name = "updateStatus";
            this.updateStatus.TabStop = false;
            this.toolTipFileSync.SetToolTip(this.updateStatus, resources.GetString("updateStatus.ToolTip"));
            // 
            // serverStatus
            // 
            resources.ApplyResources(this.serverStatus, "serverStatus");
            this.serverStatus.BackColor = System.Drawing.Color.Transparent;
            this.serverStatus.Name = "serverStatus";
            this.serverStatus.TabStop = false;
            this.toolTipFileSync.SetToolTip(this.serverStatus, resources.GetString("serverStatus.ToolTip"));
            this.toolTipDcsServer.SetToolTip(this.serverStatus, resources.GetString("serverStatus.ToolTip1"));
            // 
            // logo
            // 
            this.logo.BackColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.logo, "logo");
            this.logo.Name = "logo";
            this.logo.TabStop = false;
            // 
            // lowerTablePanel
            // 
            resources.ApplyResources(this.lowerTablePanel, "lowerTablePanel");
            this.lowerTablePanel.BackColor = System.Drawing.Color.SteelBlue;
            this.lowerTablePanel.Controls.Add(this.VerifyButton, 2, 0);
            this.lowerTablePanel.Controls.Add(this.downloadButton, 2, 1);
            this.lowerTablePanel.Controls.Add(this.exitButton, 2, 2);
            this.lowerTablePanel.Controls.Add(this.progressBar1, 0, 1);
            this.lowerTablePanel.Controls.Add(this.statusLabel, 0, 0);
            this.lowerTablePanel.Controls.Add(this.currentAction, 1, 0);
            this.lowerTablePanel.Controls.Add(this.LinkSite, 0, 2);
            this.lowerTablePanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.lowerTablePanel.Name = "lowerTablePanel";
            // 
            // VerifyButton
            // 
            resources.ApplyResources(this.VerifyButton, "VerifyButton");
            this.VerifyButton.BackColor = System.Drawing.Color.Transparent;
            this.VerifyButton.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.VerifyButton.FlatAppearance.BorderSize = 0;
            this.VerifyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.VerifyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.VerifyButton.ForeColor = System.Drawing.Color.Transparent;
            this.VerifyButton.Name = "VerifyButton";
            this.VerifyButton.UseVisualStyleBackColor = false;
            this.VerifyButton.Click += new System.EventHandler(this.VerifyButton_Click);
            // 
            // downloadButton
            // 
            resources.ApplyResources(this.downloadButton, "downloadButton");
            this.downloadButton.BackColor = System.Drawing.Color.Transparent;
            this.downloadButton.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.downloadButton.FlatAppearance.BorderSize = 0;
            this.downloadButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.downloadButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.downloadButton.ForeColor = System.Drawing.Color.Transparent;
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.UseVisualStyleBackColor = false;
            this.downloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // exitButton
            // 
            resources.ApplyResources(this.exitButton, "exitButton");
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.exitButton.ForeColor = System.Drawing.Color.Transparent;
            this.exitButton.Name = "exitButton";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.lowerTablePanel.SetColumnSpan(this.progressBar1, 2);
            this.progressBar1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // statusLabel
            // 
            resources.ApplyResources(this.statusLabel, "statusLabel");
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Name = "statusLabel";
            // 
            // currentAction
            // 
            resources.ApplyResources(this.currentAction, "currentAction");
            this.currentAction.BackColor = System.Drawing.Color.SteelBlue;
            this.currentAction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.currentAction.CausesValidation = false;
            this.currentAction.ForeColor = System.Drawing.Color.White;
            this.currentAction.Name = "currentAction";
            this.currentAction.ReadOnly = true;
            // 
            // LinkSite
            // 
            this.LinkSite.ActiveLinkColor = System.Drawing.Color.PaleTurquoise;
            resources.ApplyResources(this.LinkSite, "LinkSite");
            this.lowerTablePanel.SetColumnSpan(this.LinkSite, 2);
            this.LinkSite.LinkColor = System.Drawing.Color.White;
            this.LinkSite.Name = "LinkSite";
            this.LinkSite.TabStop = true;
            this.LinkSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkSite_LinkClicked_1);
            // 
            // mainImage
            // 
            resources.ApplyResources(this.mainImage, "mainImage");
            this.mainImage.BackColor = System.Drawing.Color.SteelBlue;
            this.mainImage.InitialImage = global::OGN_DCS_Mod_Sync_App.Properties.Resources.Hornet_8;
            this.mainImage.Name = "mainImage";
            this.mainImage.TabStop = false;
            // 
            // toolTipFileSync
            // 
            this.toolTipFileSync.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipFileSync.ToolTipTitle = "File Synchronisation Status";
            // 
            // toolTipDcsServer
            // 
            this.toolTipDcsServer.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipDcsServer.ToolTipTitle = "Oz Gaming Network DCS Server";
            // 
            // OGN_DCS_Mod_Sync
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.exitButton;
            this.Controls.Add(this.lowerTablePanel);
            this.Controls.Add(this.mainImage);
            this.Controls.Add(this.titlePanel);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "OGN_DCS_Mod_Sync";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OGN_DCS_Mod_Sync_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.OGN_DCS_Mod_Sync_Shown);
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
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label dcsServerText;
        private System.Windows.Forms.Label fileSyncStatusText;
        private System.Windows.Forms.Label squadTitle;
        private System.Windows.Forms.Label ozGamingTitle;
        private System.Windows.Forms.Label statusLabel;
        public System.Windows.Forms.TextBox currentAction;
        private System.Windows.Forms.LinkLabel LinkSite;
        private System.Windows.Forms.ToolTip toolTipFileSync;
        private System.Windows.Forms.ToolTip toolTipDcsServer;
    }
}

