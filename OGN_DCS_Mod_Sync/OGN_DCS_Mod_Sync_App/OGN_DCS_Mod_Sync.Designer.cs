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
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(684, 100);
            this.titlePanel.TabIndex = 1;
            // 
            // dcsServerText
            // 
            this.dcsServerText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dcsServerText.AutoSize = true;
            this.dcsServerText.ForeColor = System.Drawing.Color.White;
            this.dcsServerText.Location = new System.Drawing.Point(471, 45);
            this.dcsServerText.Name = "dcsServerText";
            this.dcsServerText.Size = new System.Drawing.Size(180, 15);
            this.dcsServerText.TabIndex = 10;
            this.dcsServerText.Text = "Oz Gaming Network DCS Server";
            this.toolTipFileSync.SetToolTip(this.dcsServerText, "Red - DCS Server is currently Offline or you\r\nhave Internet Connection Issues\r\n\r\n" +
        "Green - DCS Server is online and ready to join.");
            this.toolTipDcsServer.SetToolTip(this.dcsServerText, "Red - DCS Server is currently Offline or you\r\nhave Internet Connection Issues\r\n\r\n" +
        "Green - DCS Server is online and ready to join.");
            // 
            // fileSyncStatusText
            // 
            this.fileSyncStatusText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fileSyncStatusText.AutoSize = true;
            this.fileSyncStatusText.ForeColor = System.Drawing.Color.White;
            this.fileSyncStatusText.Location = new System.Drawing.Point(497, 70);
            this.fileSyncStatusText.Name = "fileSyncStatusText";
            this.fileSyncStatusText.Size = new System.Drawing.Size(154, 15);
            this.fileSyncStatusText.TabIndex = 9;
            this.fileSyncStatusText.Text = "File Synchronisation Status";
            this.toolTipFileSync.SetToolTip(this.fileSyncStatusText, "Red - Files are not Synchronised or Synchronisation\r\nStatus Unknown, Click the Ve" +
        "rify Button to Check the files.\r\n\r\nGreen - Files have been recently Synchronised" +
        ".");
            // 
            // squadTitle
            // 
            this.squadTitle.AutoSize = true;
            this.squadTitle.BackColor = System.Drawing.Color.SteelBlue;
            this.squadTitle.Font = new System.Drawing.Font("Corbel", 30F, System.Drawing.FontStyle.Bold);
            this.squadTitle.ForeColor = System.Drawing.Color.White;
            this.squadTitle.Location = new System.Drawing.Point(95, 44);
            this.squadTitle.Name = "squadTitle";
            this.squadTitle.Size = new System.Drawing.Size(358, 49);
            this.squadTitle.TabIndex = 8;
            this.squadTitle.Text = "85th Squadron DCS";
            // 
            // ozGamingTitle
            // 
            this.ozGamingTitle.AutoSize = true;
            this.ozGamingTitle.Font = new System.Drawing.Font("Corbel", 18F, System.Drawing.FontStyle.Bold);
            this.ozGamingTitle.ForeColor = System.Drawing.Color.White;
            this.ozGamingTitle.Location = new System.Drawing.Point(99, 15);
            this.ozGamingTitle.Name = "ozGamingTitle";
            this.ozGamingTitle.Size = new System.Drawing.Size(220, 29);
            this.ozGamingTitle.TabIndex = 7;
            this.ozGamingTitle.Text = "Oz Gaming Network";
            // 
            // updateStatus
            // 
            this.updateStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.updateStatus.BackColor = System.Drawing.Color.Transparent;
            this.updateStatus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("updateStatus.BackgroundImage")));
            this.updateStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.updateStatus.ErrorImage = ((System.Drawing.Image)(resources.GetObject("updateStatus.ErrorImage")));
            this.updateStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.updateStatus.InitialImage = ((System.Drawing.Image)(resources.GetObject("updateStatus.InitialImage")));
            this.updateStatus.Location = new System.Drawing.Point(657, 70);
            this.updateStatus.MaximumSize = new System.Drawing.Size(16, 16);
            this.updateStatus.MinimumSize = new System.Drawing.Size(16, 16);
            this.updateStatus.Name = "updateStatus";
            this.updateStatus.Size = new System.Drawing.Size(16, 16);
            this.updateStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.updateStatus.TabIndex = 0;
            this.updateStatus.TabStop = false;
            this.toolTipFileSync.SetToolTip(this.updateStatus, "Red - Files are not Synchronised or Synchronisation\r\nStatus Unknown, Click the Ve" +
        "rify Button to Check the files.\r\n\r\nGreen - Files have been recently Synchronised" +
        ".");
            // 
            // serverStatus
            // 
            this.serverStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.serverStatus.BackColor = System.Drawing.Color.Transparent;
            this.serverStatus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("serverStatus.BackgroundImage")));
            this.serverStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.serverStatus.ErrorImage = ((System.Drawing.Image)(resources.GetObject("serverStatus.ErrorImage")));
            this.serverStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.serverStatus.InitialImage = ((System.Drawing.Image)(resources.GetObject("serverStatus.InitialImage")));
            this.serverStatus.Location = new System.Drawing.Point(657, 45);
            this.serverStatus.MaximumSize = new System.Drawing.Size(16, 16);
            this.serverStatus.MinimumSize = new System.Drawing.Size(16, 16);
            this.serverStatus.Name = "serverStatus";
            this.serverStatus.Size = new System.Drawing.Size(16, 16);
            this.serverStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.serverStatus.TabIndex = 1;
            this.serverStatus.TabStop = false;
            this.toolTipFileSync.SetToolTip(this.serverStatus, "Red - DCS Server is currently Offline or you\r\nhave Internet Connection Issues\r\n\r\n" +
        "Green - DCS Server is online and ready to join.");
            this.toolTipDcsServer.SetToolTip(this.serverStatus, "Red - DCS Server is currently Offline or you\r\nhave Internet Connection Issues\r\n\r\n" +
        "Green - DCS Server is online and ready to join.");
            // 
            // logo
            // 
            this.logo.BackColor = System.Drawing.Color.SteelBlue;
            this.logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logo.BackgroundImage")));
            this.logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.logo.InitialImage = ((System.Drawing.Image)(resources.GetObject("logo.InitialImage")));
            this.logo.Location = new System.Drawing.Point(3, 3);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(90, 90);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logo.TabIndex = 4;
            this.logo.TabStop = false;
            // 
            // lowerTablePanel
            // 
            this.lowerTablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lowerTablePanel.BackColor = System.Drawing.Color.SteelBlue;
            this.lowerTablePanel.ColumnCount = 3;
            this.lowerTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.lowerTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lowerTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.lowerTablePanel.Controls.Add(this.VerifyButton, 2, 0);
            this.lowerTablePanel.Controls.Add(this.downloadButton, 2, 1);
            this.lowerTablePanel.Controls.Add(this.exitButton, 2, 2);
            this.lowerTablePanel.Controls.Add(this.progressBar1, 0, 1);
            this.lowerTablePanel.Controls.Add(this.statusLabel, 0, 0);
            this.lowerTablePanel.Controls.Add(this.currentAction, 1, 0);
            this.lowerTablePanel.Controls.Add(this.LinkSite, 0, 2);
            this.lowerTablePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lowerTablePanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.lowerTablePanel.Location = new System.Drawing.Point(0, 373);
            this.lowerTablePanel.Name = "lowerTablePanel";
            this.lowerTablePanel.RowCount = 3;
            this.lowerTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.lowerTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.lowerTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.lowerTablePanel.Size = new System.Drawing.Size(684, 98);
            this.lowerTablePanel.TabIndex = 5;
            // 
            // VerifyButton
            // 
            this.VerifyButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.VerifyButton.BackColor = System.Drawing.Color.Transparent;
            this.VerifyButton.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.VerifyButton.FlatAppearance.BorderSize = 0;
            this.VerifyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.VerifyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.VerifyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VerifyButton.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold);
            this.VerifyButton.ForeColor = System.Drawing.Color.Transparent;
            this.VerifyButton.Image = ((System.Drawing.Image)(resources.GetObject("VerifyButton.Image")));
            this.VerifyButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VerifyButton.Location = new System.Drawing.Point(589, 5);
            this.VerifyButton.Margin = new System.Windows.Forms.Padding(5);
            this.VerifyButton.Name = "VerifyButton";
            this.VerifyButton.Size = new System.Drawing.Size(90, 22);
            this.VerifyButton.TabIndex = 0;
            this.VerifyButton.UseVisualStyleBackColor = false;
            this.VerifyButton.Click += new System.EventHandler(this.VerifyButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.downloadButton.BackColor = System.Drawing.Color.Transparent;
            this.downloadButton.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.downloadButton.FlatAppearance.BorderSize = 0;
            this.downloadButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.downloadButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadButton.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold);
            this.downloadButton.ForeColor = System.Drawing.Color.Transparent;
            this.downloadButton.Image = ((System.Drawing.Image)(resources.GetObject("downloadButton.Image")));
            this.downloadButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.downloadButton.Location = new System.Drawing.Point(589, 38);
            this.downloadButton.Margin = new System.Windows.Forms.Padding(5);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(90, 22);
            this.downloadButton.TabIndex = 1;
            this.downloadButton.UseVisualStyleBackColor = false;
            this.downloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold);
            this.exitButton.ForeColor = System.Drawing.Color.Transparent;
            this.exitButton.Image = ((System.Drawing.Image)(resources.GetObject("exitButton.Image")));
            this.exitButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.exitButton.Location = new System.Drawing.Point(589, 71);
            this.exitButton.Margin = new System.Windows.Forms.Padding(5);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(90, 23);
            this.exitButton.TabIndex = 2;
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lowerTablePanel.SetColumnSpan(this.progressBar1, 2);
            this.progressBar1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.progressBar1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.progressBar1.Location = new System.Drawing.Point(5, 44);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(574, 10);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Visible = false;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Corbel", 11.25F);
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Location = new System.Drawing.Point(5, 7);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(5, 4, 0, 5);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(51, 18);
            this.statusLabel.TabIndex = 5;
            this.statusLabel.Text = "Status:";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // currentAction
            // 
            this.currentAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.currentAction.BackColor = System.Drawing.Color.SteelBlue;
            this.currentAction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.currentAction.CausesValidation = false;
            this.currentAction.Font = new System.Drawing.Font("Corbel", 11.25F);
            this.currentAction.ForeColor = System.Drawing.Color.White;
            this.currentAction.Location = new System.Drawing.Point(59, 3);
            this.currentAction.Name = "currentAction";
            this.currentAction.ReadOnly = true;
            this.currentAction.Size = new System.Drawing.Size(522, 19);
            this.currentAction.TabIndex = 6;
            this.currentAction.WordWrap = false;
            // 
            // LinkSite
            // 
            this.LinkSite.ActiveLinkColor = System.Drawing.Color.PaleTurquoise;
            this.LinkSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkSite.AutoSize = true;
            this.lowerTablePanel.SetColumnSpan(this.LinkSite, 2);
            this.LinkSite.LinkColor = System.Drawing.Color.White;
            this.LinkSite.Location = new System.Drawing.Point(3, 75);
            this.LinkSite.Name = "LinkSite";
            this.LinkSite.Size = new System.Drawing.Size(578, 15);
            this.LinkSite.TabIndex = 7;
            this.LinkSite.TabStop = true;
            this.LinkSite.Text = "www.ozgamingnetwork.com.au/forums";
            this.LinkSite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LinkSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkSite_LinkClicked_1);
            // 
            // mainImage
            // 
            this.mainImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainImage.BackColor = System.Drawing.Color.SteelBlue;
            this.mainImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainImage.BackgroundImage")));
            this.mainImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.mainImage.ErrorImage = ((System.Drawing.Image)(resources.GetObject("mainImage.ErrorImage")));
            this.mainImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mainImage.Location = new System.Drawing.Point(0, 100);
            this.mainImage.Margin = new System.Windows.Forms.Padding(0);
            this.mainImage.Name = "mainImage";
            this.mainImage.Size = new System.Drawing.Size(684, 273);
            this.mainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mainImage.TabIndex = 4;
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CancelButton = this.exitButton;
            this.ClientSize = new System.Drawing.Size(684, 471);
            this.Controls.Add(this.lowerTablePanel);
            this.Controls.Add(this.mainImage);
            this.Controls.Add(this.titlePanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Corbel", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "OGN_DCS_Mod_Sync";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OGN DCS Mod Sync";
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

