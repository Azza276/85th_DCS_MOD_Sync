namespace DCS_Mod_Sync_App
{
    partial class Updateconfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Updateconfirm));
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_Update = new System.Windows.Forms.Button();
            this.Btn_Link = new System.Windows.Forms.Button();
            this.text1 = new System.Windows.Forms.Label();
            this.Versiontitle = new System.Windows.Forms.Label();
            this.Dateupdatedtitle = new System.Windows.Forms.Label();
            this.Filenametitle = new System.Windows.Forms.Label();
            this.Filesizetitle = new System.Windows.Forms.Label();
            this.Filenametxt = new System.Windows.Forms.Label();
            this.Versiontxt = new System.Windows.Forms.Label();
            this.Dateupdatedtxt = new System.Windows.Forms.Label();
            this.Filesizetxt = new System.Windows.Forms.Label();
            this.Installpathtxt = new System.Windows.Forms.Label();
            this.Installpathtitle = new System.Windows.Forms.Label();
            this.toolTip_appfolder = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_Cancel.Location = new System.Drawing.Point(235, 183);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancel.TabIndex = 0;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Btn_Update
            // 
            this.Btn_Update.Location = new System.Drawing.Point(127, 183);
            this.Btn_Update.Name = "Btn_Update";
            this.Btn_Update.Size = new System.Drawing.Size(102, 23);
            this.Btn_Update.TabIndex = 1;
            this.Btn_Update.Text = "Update for Me";
            this.Btn_Update.UseVisualStyleBackColor = true;
            this.Btn_Update.Click += new System.EventHandler(this.Btn_Update_Click);
            // 
            // Btn_Link
            // 
            this.Btn_Link.Location = new System.Drawing.Point(12, 183);
            this.Btn_Link.Name = "Btn_Link";
            this.Btn_Link.Size = new System.Drawing.Size(109, 23);
            this.Btn_Link.TabIndex = 2;
            this.Btn_Link.Text = "Download Myself";
            this.Btn_Link.UseVisualStyleBackColor = true;
            this.Btn_Link.Click += new System.EventHandler(this.Btn_Link_Click);
            // 
            // text1
            // 
            this.text1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.text1.AutoSize = true;
            this.text1.Location = new System.Drawing.Point(71, 12);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(185, 26);
            this.text1.TabIndex = 3;
            this.text1.Text = "An update is available for the \r\n85th SQN DCS Mod Sync Application";
            this.text1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Versiontitle
            // 
            this.Versiontitle.AutoSize = true;
            this.Versiontitle.Location = new System.Drawing.Point(12, 77);
            this.Versiontitle.Name = "Versiontitle";
            this.Versiontitle.Size = new System.Drawing.Size(45, 13);
            this.Versiontitle.TabIndex = 4;
            this.Versiontitle.Text = "Version:";
            this.Versiontitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Dateupdatedtitle
            // 
            this.Dateupdatedtitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Dateupdatedtitle.AutoSize = true;
            this.Dateupdatedtitle.Location = new System.Drawing.Point(12, 103);
            this.Dateupdatedtitle.Name = "Dateupdatedtitle";
            this.Dateupdatedtitle.Size = new System.Drawing.Size(77, 13);
            this.Dateupdatedtitle.TabIndex = 5;
            this.Dateupdatedtitle.Text = "Date Updated:";
            this.Dateupdatedtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Filenametitle
            // 
            this.Filenametitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Filenametitle.AutoSize = true;
            this.Filenametitle.Location = new System.Drawing.Point(12, 51);
            this.Filenametitle.Name = "Filenametitle";
            this.Filenametitle.Size = new System.Drawing.Size(57, 13);
            this.Filenametitle.TabIndex = 6;
            this.Filenametitle.Text = "File Name:";
            this.Filenametitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Filesizetitle
            // 
            this.Filesizetitle.AutoSize = true;
            this.Filesizetitle.Location = new System.Drawing.Point(12, 129);
            this.Filesizetitle.Name = "Filesizetitle";
            this.Filesizetitle.Size = new System.Drawing.Size(52, 13);
            this.Filesizetitle.TabIndex = 7;
            this.Filesizetitle.Text = "File Size: ";
            this.Filesizetitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Filenametxt
            // 
            this.Filenametxt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Filenametxt.AutoEllipsis = true;
            this.Filenametxt.AutoSize = true;
            this.Filenametxt.Location = new System.Drawing.Point(112, 51);
            this.Filenametxt.Name = "Filenametxt";
            this.Filenametxt.Size = new System.Drawing.Size(27, 13);
            this.Filenametxt.TabIndex = 8;
            this.Filenametxt.Text = "N/A";
            this.Filenametxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Versiontxt
            // 
            this.Versiontxt.AutoEllipsis = true;
            this.Versiontxt.AutoSize = true;
            this.Versiontxt.Location = new System.Drawing.Point(112, 77);
            this.Versiontxt.Name = "Versiontxt";
            this.Versiontxt.Size = new System.Drawing.Size(27, 13);
            this.Versiontxt.TabIndex = 9;
            this.Versiontxt.Text = "N/A";
            this.Versiontxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Dateupdatedtxt
            // 
            this.Dateupdatedtxt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Dateupdatedtxt.AutoEllipsis = true;
            this.Dateupdatedtxt.AutoSize = true;
            this.Dateupdatedtxt.Location = new System.Drawing.Point(112, 103);
            this.Dateupdatedtxt.Name = "Dateupdatedtxt";
            this.Dateupdatedtxt.Size = new System.Drawing.Size(27, 13);
            this.Dateupdatedtxt.TabIndex = 10;
            this.Dateupdatedtxt.Text = "N/A";
            this.Dateupdatedtxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Filesizetxt
            // 
            this.Filesizetxt.AutoEllipsis = true;
            this.Filesizetxt.AutoSize = true;
            this.Filesizetxt.Location = new System.Drawing.Point(112, 129);
            this.Filesizetxt.Name = "Filesizetxt";
            this.Filesizetxt.Size = new System.Drawing.Size(27, 13);
            this.Filesizetxt.TabIndex = 11;
            this.Filesizetxt.Text = "N/A";
            this.Filesizetxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Installpathtxt
            // 
            this.Installpathtxt.AutoEllipsis = true;
            this.Installpathtxt.AutoSize = true;
            this.Installpathtxt.Location = new System.Drawing.Point(112, 155);
            this.Installpathtxt.Name = "Installpathtxt";
            this.Installpathtxt.Size = new System.Drawing.Size(27, 13);
            this.Installpathtxt.TabIndex = 13;
            this.Installpathtxt.Text = "N/A";
            this.Installpathtxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Installpathtitle
            // 
            this.Installpathtitle.AutoSize = true;
            this.Installpathtitle.Location = new System.Drawing.Point(12, 155);
            this.Installpathtitle.Name = "Installpathtitle";
            this.Installpathtitle.Size = new System.Drawing.Size(94, 13);
            this.Installpathtitle.TabIndex = 12;
            this.Installpathtitle.Text = "Application Folder:";
            this.Installpathtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolTip_appfolder
            // 
            this.toolTip_appfolder.IsBalloon = true;
            this.toolTip_appfolder.Tag = "Tag";
            this.toolTip_appfolder.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip_appfolder.ToolTipTitle = "Application Folder";
            // 
            // Updateconfirm
            // 
            this.AcceptButton = this.Btn_Update;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.CancelButton = this.Btn_Cancel;
            this.ClientSize = new System.Drawing.Size(322, 218);
            this.Controls.Add(this.Installpathtxt);
            this.Controls.Add(this.Installpathtitle);
            this.Controls.Add(this.Filesizetxt);
            this.Controls.Add(this.Dateupdatedtxt);
            this.Controls.Add(this.Versiontxt);
            this.Controls.Add(this.Filenametxt);
            this.Controls.Add(this.Filesizetitle);
            this.Controls.Add(this.Filenametitle);
            this.Controls.Add(this.Dateupdatedtitle);
            this.Controls.Add(this.Versiontitle);
            this.Controls.Add(this.text1);
            this.Controls.Add(this.Btn_Link);
            this.Controls.Add(this.Btn_Update);
            this.Controls.Add(this.Btn_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Updateconfirm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "Update Available";
            this.Text = "Update Available";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_Update;
        private System.Windows.Forms.Button Btn_Link;
        private System.Windows.Forms.Label text1;
        private System.Windows.Forms.Label Versiontitle;
        private System.Windows.Forms.Label Dateupdatedtitle;
        private System.Windows.Forms.Label Filenametitle;
        private System.Windows.Forms.Label Filesizetitle;
        private System.Windows.Forms.Label Filenametxt;
        private System.Windows.Forms.Label Versiontxt;
        private System.Windows.Forms.Label Dateupdatedtxt;
        private System.Windows.Forms.Label Filesizetxt;
        private System.Windows.Forms.Label Installpathtxt;
        private System.Windows.Forms.Label Installpathtitle;
        private System.Windows.Forms.ToolTip toolTip_appfolder;
    }
}

