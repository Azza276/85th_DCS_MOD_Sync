namespace DCS_Mod_Sync_App
{
    partial class UcAutodetectAndOverrideFolder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBrowse = new System.Windows.Forms.Button();
            this.ucAutoDetectAndOverride1 = new DCS_Mod_Sync_App.UcAutodetectAndOverride();
            this.lblAutodetectedFolder = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(829, 0);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // ucAutoDetectAndOverride1
            // 
            this.ucAutoDetectAndOverride1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucAutoDetectAndOverride1.BackColor = System.Drawing.Color.LightGray;
            this.ucAutoDetectAndOverride1.Location = new System.Drawing.Point(0, 0);
            this.ucAutoDetectAndOverride1.Name = "ucAutoDetectAndOverride1";
            this.ucAutoDetectAndOverride1.Size = new System.Drawing.Size(831, 25);
            this.ucAutoDetectAndOverride1.TabIndex = 0;
            // 
            // lblAutodetectedFolder
            // 
            this.lblAutodetectedFolder.AutoSize = true;
            this.lblAutodetectedFolder.Location = new System.Drawing.Point(87, 5);
            this.lblAutodetectedFolder.Name = "lblAutodetectedFolder";
            this.lblAutodetectedFolder.Size = new System.Drawing.Size(35, 13);
            this.lblAutodetectedFolder.TabIndex = 2;
            this.lblAutodetectedFolder.Text = "label1";
            // 
            // ucAutodetectAndOverrideFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.lblAutodetectedFolder);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.ucAutoDetectAndOverride1);
            this.Name = "ucAutodetectAndOverrideFolder";
            this.Size = new System.Drawing.Size(854, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UcAutodetectAndOverride ucAutoDetectAndOverride1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblAutodetectedFolder;
    }
}
