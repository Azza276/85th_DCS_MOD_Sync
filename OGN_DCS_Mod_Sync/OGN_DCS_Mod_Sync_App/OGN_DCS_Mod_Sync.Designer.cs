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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OGN_DCS_Mod_Sync));
            this.titlePanel = new System.Windows.Forms.Panel();
            this.dcsTitle = new System.Windows.Forms.TextBox();
            this.ognTitle = new System.Windows.Forms.TextBox();
            this.dcsServerText = new System.Windows.Forms.TextBox();
            this.fileSyncStatusText = new System.Windows.Forms.TextBox();
            this.lowerTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.verifyButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.currentActionText = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.mainImage = new System.Windows.Forms.PictureBox();
            this.updateStatus = new System.Windows.Forms.PictureBox();
            this.serverStatus = new System.Windows.Forms.PictureBox();
            this.logo = new System.Windows.Forms.PictureBox();
            this.titlePanel.SuspendLayout();
            this.lowerTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            resources.ApplyResources(this.titlePanel, "titlePanel");
            this.titlePanel.BackColor = System.Drawing.Color.SteelBlue;
            this.titlePanel.Controls.Add(this.dcsTitle);
            this.titlePanel.Controls.Add(this.ognTitle);
            this.titlePanel.Controls.Add(this.updateStatus);
            this.titlePanel.Controls.Add(this.serverStatus);
            this.titlePanel.Controls.Add(this.logo);
            this.titlePanel.Controls.Add(this.dcsServerText);
            this.titlePanel.Controls.Add(this.fileSyncStatusText);
            this.titlePanel.Name = "titlePanel";
            // 
            // dcsTitle
            // 
            resources.ApplyResources(this.dcsTitle, "dcsTitle");
            this.dcsTitle.BackColor = System.Drawing.Color.SteelBlue;
            this.dcsTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dcsTitle.ForeColor = System.Drawing.Color.White;
            this.dcsTitle.Name = "dcsTitle";
            // 
            // ognTitle
            // 
            resources.ApplyResources(this.ognTitle, "ognTitle");
            this.ognTitle.BackColor = System.Drawing.Color.SteelBlue;
            this.ognTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ognTitle.ForeColor = System.Drawing.Color.White;
            this.ognTitle.Name = "ognTitle";
            // 
            // dcsServerText
            // 
            resources.ApplyResources(this.dcsServerText, "dcsServerText");
            this.dcsServerText.BackColor = System.Drawing.Color.SteelBlue;
            this.dcsServerText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dcsServerText.ForeColor = System.Drawing.Color.White;
            this.dcsServerText.Name = "dcsServerText";
            this.dcsServerText.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // fileSyncStatusText
            // 
            resources.ApplyResources(this.fileSyncStatusText, "fileSyncStatusText");
            this.fileSyncStatusText.BackColor = System.Drawing.Color.SteelBlue;
            this.fileSyncStatusText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileSyncStatusText.ForeColor = System.Drawing.Color.White;
            this.fileSyncStatusText.Name = "fileSyncStatusText";
            // 
            // lowerTablePanel
            // 
            resources.ApplyResources(this.lowerTablePanel, "lowerTablePanel");
            this.lowerTablePanel.BackColor = System.Drawing.Color.SteelBlue;
            this.lowerTablePanel.Controls.Add(this.verifyButton, 1, 0);
            this.lowerTablePanel.Controls.Add(this.downloadButton, 1, 1);
            this.lowerTablePanel.Controls.Add(this.exitButton, 1, 2);
            this.lowerTablePanel.Controls.Add(this.currentActionText, 0, 0);
            this.lowerTablePanel.Controls.Add(this.progressBar1, 0, 1);
            this.lowerTablePanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.lowerTablePanel.Name = "lowerTablePanel";
            this.lowerTablePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // verifyButton
            // 
            resources.ApplyResources(this.verifyButton, "verifyButton");
            this.verifyButton.BackColor = System.Drawing.Color.White;
            this.verifyButton.ForeColor = System.Drawing.Color.Black;
            this.verifyButton.Name = "verifyButton";
            this.verifyButton.UseVisualStyleBackColor = false;
            this.verifyButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // downloadButton
            // 
            resources.ApplyResources(this.downloadButton, "downloadButton");
            this.downloadButton.BackColor = System.Drawing.Color.White;
            this.downloadButton.ForeColor = System.Drawing.Color.Black;
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.UseVisualStyleBackColor = false;
            // 
            // exitButton
            // 
            resources.ApplyResources(this.exitButton, "exitButton");
            this.exitButton.BackColor = System.Drawing.Color.White;
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.ForeColor = System.Drawing.Color.Black;
            this.exitButton.Name = "exitButton";
            this.exitButton.UseVisualStyleBackColor = false;
            // 
            // currentActionText
            // 
            resources.ApplyResources(this.currentActionText, "currentActionText");
            this.currentActionText.BackColor = System.Drawing.Color.SteelBlue;
            this.currentActionText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.currentActionText.ForeColor = System.Drawing.Color.White;
            this.currentActionText.Name = "currentActionText";
            this.currentActionText.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // mainImage
            // 
            resources.ApplyResources(this.mainImage, "mainImage");
            this.mainImage.BackColor = System.Drawing.Color.Transparent;
            this.mainImage.BackgroundImage = global::OGN_DCS_Mod_Sync_App.Properties.Resources.Hornet_8;
            this.mainImage.ErrorImage = global::OGN_DCS_Mod_Sync_App.Properties.Resources.Hornet_8;
            this.mainImage.Name = "mainImage";
            this.mainImage.TabStop = false;
            // 
            // updateStatus
            // 
            resources.ApplyResources(this.updateStatus, "updateStatus");
            this.updateStatus.BackColor = System.Drawing.Color.Transparent;
            this.updateStatus.BackgroundImage = global::OGN_DCS_Mod_Sync_App.Properties.Resources.red_light;
            this.updateStatus.ErrorImage = global::OGN_DCS_Mod_Sync_App.Properties.Resources.red_light;
            this.updateStatus.InitialImage = global::OGN_DCS_Mod_Sync_App.Properties.Resources.red_light;
            this.updateStatus.Name = "updateStatus";
            this.updateStatus.TabStop = false;
            this.updateStatus.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // serverStatus
            // 
            resources.ApplyResources(this.serverStatus, "serverStatus");
            this.serverStatus.BackColor = System.Drawing.Color.Transparent;
            this.serverStatus.BackgroundImage = global::OGN_DCS_Mod_Sync_App.Properties.Resources.red_light;
            this.serverStatus.ErrorImage = global::OGN_DCS_Mod_Sync_App.Properties.Resources.red_light;
            this.serverStatus.InitialImage = global::OGN_DCS_Mod_Sync_App.Properties.Resources.red_light;
            this.serverStatus.Name = "serverStatus";
            this.serverStatus.TabStop = false;
            // 
            // logo
            // 
            resources.ApplyResources(this.logo, "logo");
            this.logo.BackColor = System.Drawing.Color.SteelBlue;
            this.logo.BackgroundImage = global::OGN_DCS_Mod_Sync_App.Properties.Resources._85th_SQN_2;
            this.logo.InitialImage = global::OGN_DCS_Mod_Sync_App.Properties.Resources._85th_SQN_2;
            this.logo.Name = "logo";
            this.logo.TabStop = false;
            this.logo.Click += new System.EventHandler(this.pictureBox2_Click);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OGN_DCS_Mod_Sync";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.lowerTablePanel.ResumeLayout(false);
            this.lowerTablePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel titlePanel;
        public System.Windows.Forms.PictureBox updateStatus;
        public System.Windows.Forms.PictureBox serverStatus;
        private System.Windows.Forms.TextBox dcsServerText;
        private System.Windows.Forms.TextBox fileSyncStatusText;
        public System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.TextBox dcsTitle;
        private System.Windows.Forms.TextBox ognTitle;
        private System.Windows.Forms.PictureBox mainImage;
        private System.Windows.Forms.TableLayoutPanel lowerTablePanel;
        private System.Windows.Forms.Button verifyButton;
        private System.Windows.Forms.Button downloadButton;
        public System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TextBox currentActionText;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

