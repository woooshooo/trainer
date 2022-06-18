namespace SharpUpdate
{
    partial class SharpUpdateDownloadForm
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
            this.downloading_label = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progress_label = new System.Windows.Forms.Label();
            this.CloseLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // downloading_label
            // 
            this.downloading_label.AutoSize = true;
            this.downloading_label.BackColor = System.Drawing.Color.Transparent;
            this.downloading_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloading_label.ForeColor = System.Drawing.Color.White;
            this.downloading_label.Location = new System.Drawing.Point(63, 66);
            this.downloading_label.Name = "downloading_label";
            this.downloading_label.Size = new System.Drawing.Size(229, 25);
            this.downloading_label.TabIndex = 0;
            this.downloading_label.Text = "Downloading Update...";
            this.downloading_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(29, 107);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(296, 29);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 1;
            // 
            // progress_label
            // 
            this.progress_label.BackColor = System.Drawing.Color.Transparent;
            this.progress_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progress_label.ForeColor = System.Drawing.Color.White;
            this.progress_label.Location = new System.Drawing.Point(63, 156);
            this.progress_label.Name = "progress_label";
            this.progress_label.Size = new System.Drawing.Size(229, 25);
            this.progress_label.TabIndex = 2;
            this.progress_label.Text = "Download: 0 KB";
            this.progress_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CloseLabel
            // 
            this.CloseLabel.AutoSize = true;
            this.CloseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CloseLabel.Location = new System.Drawing.Point(318, 9);
            this.CloseLabel.Name = "CloseLabel";
            this.CloseLabel.Size = new System.Drawing.Size(26, 25);
            this.CloseLabel.TabIndex = 6;
            this.CloseLabel.Text = "X";
            this.CloseLabel.Click += new System.EventHandler(this.CloseLabel_Click);
            // 
            // SharpUpdateDownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::SharpUpdate.Properties.Resources.rock;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(356, 232);
            this.Controls.Add(this.CloseLabel);
            this.Controls.Add(this.progress_label);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.downloading_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SharpUpdateDownloadForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SharpUpdateDownloadForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SharpUpdateDownloadForm_FormClosed);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SharpUpdateDownloadForm_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label downloading_label;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label progress_label;
        private System.Windows.Forms.Label CloseLabel;
    }
}