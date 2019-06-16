namespace DCS_Mod_Sync_App
{
    partial class DCS_options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCS_options));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.downloadThreads = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAutoDownloadAfterVerification = new System.Windows.Forms.CheckBox();
            this.chkAutoBuildLinksAfterDownload = new System.Windows.Forms.CheckBox();
            this.FolderSettings = new DCS_Mod_Sync_App.ucAutodetectAndOverrideFolder();
            this.liveriesFolderSettings = new DCS_Mod_Sync_App.ucAutodetectAndOverrideFolder();
            ((System.ComponentModel.ISupportInitialize)(this.downloadThreads)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(464, 174);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(545, 174);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Liveries Folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mods Folder";
            // 
            // downloadThreads
            // 
            this.downloadThreads.Location = new System.Drawing.Point(123, 101);
            this.downloadThreads.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.downloadThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.downloadThreads.Name = "downloadThreads";
            this.downloadThreads.Size = new System.Drawing.Size(53, 20);
            this.downloadThreads.TabIndex = 7;
            this.downloadThreads.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Download Threads";
            // 
            // chkAutoDownloadAfterVerification
            // 
            this.chkAutoDownloadAfterVerification.AutoSize = true;
            this.chkAutoDownloadAfterVerification.Location = new System.Drawing.Point(15, 143);
            this.chkAutoDownloadAfterVerification.Name = "chkAutoDownloadAfterVerification";
            this.chkAutoDownloadAfterVerification.Size = new System.Drawing.Size(215, 17);
            this.chkAutoDownloadAfterVerification.TabIndex = 9;
            this.chkAutoDownloadAfterVerification.Text = "Automatically download after verification";
            this.chkAutoDownloadAfterVerification.UseVisualStyleBackColor = true;
            // 
            // chkAutoBuildLinksAfterDownload
            // 
            this.chkAutoBuildLinksAfterDownload.AutoSize = true;
            this.chkAutoBuildLinksAfterDownload.Location = new System.Drawing.Point(15, 178);
            this.chkAutoBuildLinksAfterDownload.Name = "chkAutoBuildLinksAfterDownload";
            this.chkAutoBuildLinksAfterDownload.Size = new System.Drawing.Size(210, 17);
            this.chkAutoBuildLinksAfterDownload.TabIndex = 10;
            this.chkAutoBuildLinksAfterDownload.Text = "Automatically build links after download";
            this.chkAutoBuildLinksAfterDownload.UseVisualStyleBackColor = true;
            // 
            // FolderSettings
            // 
            this.FolderSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderSettings.Autodetect = false;
            this.FolderSettings.BackColor = System.Drawing.Color.SteelBlue;
            this.FolderSettings.Folder = "";
            this.FolderSettings.Location = new System.Drawing.Point(123, 12);
            this.FolderSettings.Name = "FolderSettings";
            this.FolderSettings.Size = new System.Drawing.Size(497, 24);
            this.FolderSettings.TabIndex = 6;
            this.FolderSettings.ValueForAutodetect = null;
            // 
            // liveriesFolderSettings
            // 
            this.liveriesFolderSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.liveriesFolderSettings.Autodetect = false;
            this.liveriesFolderSettings.BackColor = System.Drawing.Color.SteelBlue;
            this.liveriesFolderSettings.Folder = "";
            this.liveriesFolderSettings.Location = new System.Drawing.Point(123, 56);
            this.liveriesFolderSettings.Name = "liveriesFolderSettings";
            this.liveriesFolderSettings.Size = new System.Drawing.Size(497, 24);
            this.liveriesFolderSettings.TabIndex = 4;
            this.liveriesFolderSettings.ValueForAutodetect = null;
            // 
            // DCS_options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(632, 209);
            this.Controls.Add(this.chkAutoBuildLinksAfterDownload);
            this.Controls.Add(this.chkAutoDownloadAfterVerification);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.downloadThreads);
            this.Controls.Add(this.FolderSettings);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.liveriesFolderSettings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DCS_options";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.DCS_options_Load);
            ((System.ComponentModel.ISupportInitialize)(this.downloadThreads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private ucAutodetectAndOverrideFolder liveriesFolderSettings;
        private System.Windows.Forms.Label label2;
        private ucAutodetectAndOverrideFolder FolderSettings;
        private System.Windows.Forms.NumericUpDown downloadThreads;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkAutoDownloadAfterVerification;
        private System.Windows.Forms.CheckBox chkAutoBuildLinksAfterDownload;
    }
}