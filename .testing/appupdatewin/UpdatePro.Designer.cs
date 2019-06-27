namespace appupdatewin
{
    partial class UpdatePro
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
            this.updateBar = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.DLStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // updateBar
            // 
            this.updateBar.Location = new System.Drawing.Point(12, 46);
            this.updateBar.Name = "updateBar";
            this.updateBar.Size = new System.Drawing.Size(526, 23);
            this.updateBar.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(208, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "EJECT (3 TIMES)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // DLStatus
            // 
            this.DLStatus.AutoSize = true;
            this.DLStatus.Location = new System.Drawing.Point(12, 18);
            this.DLStatus.Name = "DLStatus";
            this.DLStatus.Size = new System.Drawing.Size(61, 13);
            this.DLStatus.TabIndex = 2;
            this.DLStatus.Text = "Preparing...";
            // 
            // UpdatePro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(550, 119);
            this.ControlBox = false;
            this.Controls.Add(this.DLStatus);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.updateBar);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "UpdatePro";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Progress";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar updateBar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label DLStatus;
    }
}