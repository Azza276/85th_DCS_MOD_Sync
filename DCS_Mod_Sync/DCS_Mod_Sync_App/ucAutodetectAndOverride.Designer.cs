namespace DCS_Mod_Sync_App
{
    partial class UcAutodetectAndOverride
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
            this.txt = new System.Windows.Forms.TextBox();
            this.chkAutodetect = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt.Location = new System.Drawing.Point(86, 2);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(830, 20);
            this.txt.TabIndex = 2;
            // 
            // chkAutodetect
            // 
            this.chkAutodetect.AutoSize = true;
            this.chkAutodetect.BackColor = System.Drawing.Color.LightGray;
            this.chkAutodetect.Location = new System.Drawing.Point(3, 4);
            this.chkAutodetect.Name = "chkAutodetect";
            this.chkAutodetect.Size = new System.Drawing.Size(78, 17);
            this.chkAutodetect.TabIndex = 3;
            this.chkAutodetect.Text = "Autodetect";
            this.chkAutodetect.UseVisualStyleBackColor = false;
            this.chkAutodetect.CheckedChanged += new System.EventHandler(this.ChkAutodetect_CheckedChanged);
            // 
            // ucAutodetectAndOverride
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.chkAutodetect);
            this.Controls.Add(this.txt);
            this.Name = "ucAutodetectAndOverride";
            this.Size = new System.Drawing.Size(919, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.CheckBox chkAutodetect;
        public System.Windows.Forms.TextBox txt;
    }
}
