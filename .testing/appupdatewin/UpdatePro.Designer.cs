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
            this.Btn_abort = new System.Windows.Forms.Button();
            this.DLStatus = new System.Windows.Forms.Label();
            this.Btn_go = new System.Windows.Forms.Button();
            this.Btn_done = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // updateBar
            // 
            this.updateBar.Location = new System.Drawing.Point(12, 46);
            this.updateBar.Name = "updateBar";
            this.updateBar.Size = new System.Drawing.Size(526, 23);
            this.updateBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.updateBar.TabIndex = 0;
            // 
            // Btn_abort
            // 
            this.Btn_abort.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_abort.Location = new System.Drawing.Point(208, 84);
            this.Btn_abort.Name = "Btn_abort";
            this.Btn_abort.Size = new System.Drawing.Size(134, 23);
            this.Btn_abort.TabIndex = 1;
            this.Btn_abort.Text = "EJECT (Abort)";
            this.Btn_abort.UseVisualStyleBackColor = true;
            this.Btn_abort.Click += new System.EventHandler(this.Btn_abort_Click);
            // 
            // DLStatus
            // 
            this.DLStatus.AutoSize = true;
            this.DLStatus.Location = new System.Drawing.Point(12, 18);
            this.DLStatus.Name = "DLStatus";
            this.DLStatus.Size = new System.Drawing.Size(73, 13);
            this.DLStatus.TabIndex = 2;
            this.DLStatus.Text = "Start Update?";
            // 
            // Btn_go
            // 
            this.Btn_go.Location = new System.Drawing.Point(12, 84);
            this.Btn_go.Name = "Btn_go";
            this.Btn_go.Size = new System.Drawing.Size(134, 23);
            this.Btn_go.TabIndex = 3;
            this.Btn_go.Text = "Start Download";
            this.Btn_go.UseVisualStyleBackColor = true;
            this.Btn_go.Click += new System.EventHandler(this.Btn_go_Click);
            // 
            // Btn_done
            // 
            this.Btn_done.Location = new System.Drawing.Point(404, 84);
            this.Btn_done.Name = "Btn_done";
            this.Btn_done.Size = new System.Drawing.Size(134, 23);
            this.Btn_done.TabIndex = 4;
            this.Btn_done.Text = "Done";
            this.Btn_done.UseVisualStyleBackColor = true;
            this.Btn_done.Visible = false;
            this.Btn_done.Click += new System.EventHandler(this.Btn_done_Click);
            // 
            // UpdatePro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.LightGray;
            this.CancelButton = this.Btn_abort;
            this.ClientSize = new System.Drawing.Size(550, 119);
            this.Controls.Add(this.Btn_done);
            this.Controls.Add(this.Btn_go);
            this.Controls.Add(this.DLStatus);
            this.Controls.Add(this.Btn_abort);
            this.Controls.Add(this.updateBar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(566, 158);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(566, 158);
            this.Name = "UpdatePro";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Progress";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar updateBar;
        private System.Windows.Forms.Button Btn_abort;
        private System.Windows.Forms.Label DLStatus;
        private System.Windows.Forms.Button Btn_go;
        private System.Windows.Forms.Button Btn_done;
    }
}