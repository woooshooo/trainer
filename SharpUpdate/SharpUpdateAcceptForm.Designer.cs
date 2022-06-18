namespace SharpUpdate
{
    partial class SharpUpdateAcceptForm
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
            this.updateavail_label = new System.Windows.Forms.Label();
            this.newVersion_label = new System.Windows.Forms.Label();
            this.yes_btn = new System.Windows.Forms.Button();
            this.no_btn = new System.Windows.Forms.Button();
            this.details_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // updateavail_label
            // 
            this.updateavail_label.AutoSize = true;
            this.updateavail_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateavail_label.ForeColor = System.Drawing.Color.White;
            this.updateavail_label.Location = new System.Drawing.Point(66, 36);
            this.updateavail_label.Name = "updateavail_label";
            this.updateavail_label.Size = new System.Drawing.Size(191, 40);
            this.updateavail_label.TabIndex = 0;
            this.updateavail_label.Text = "An Update is Available.\r\nWould you like to update?\r\n";
            this.updateavail_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // newVersion_label
            // 
            this.newVersion_label.AutoSize = true;
            this.newVersion_label.ForeColor = System.Drawing.Color.White;
            this.newVersion_label.Location = new System.Drawing.Point(22, 98);
            this.newVersion_label.Name = "newVersion_label";
            this.newVersion_label.Size = new System.Drawing.Size(71, 13);
            this.newVersion_label.TabIndex = 1;
            this.newVersion_label.Text = "version here..";
            // 
            // yes_btn
            // 
            this.yes_btn.Location = new System.Drawing.Point(48, 149);
            this.yes_btn.Name = "yes_btn";
            this.yes_btn.Size = new System.Drawing.Size(75, 23);
            this.yes_btn.TabIndex = 2;
            this.yes_btn.Text = "Yes";
            this.yes_btn.UseVisualStyleBackColor = true;
            this.yes_btn.Click += new System.EventHandler(this.yes_btn_Click);
            // 
            // no_btn
            // 
            this.no_btn.Location = new System.Drawing.Point(129, 149);
            this.no_btn.Name = "no_btn";
            this.no_btn.Size = new System.Drawing.Size(75, 23);
            this.no_btn.TabIndex = 3;
            this.no_btn.Text = "No";
            this.no_btn.UseVisualStyleBackColor = true;
            this.no_btn.Click += new System.EventHandler(this.no_btn_Click);
            // 
            // details_btn
            // 
            this.details_btn.Location = new System.Drawing.Point(210, 149);
            this.details_btn.Name = "details_btn";
            this.details_btn.Size = new System.Drawing.Size(75, 23);
            this.details_btn.TabIndex = 4;
            this.details_btn.Text = "Details";
            this.details_btn.UseVisualStyleBackColor = true;
            this.details_btn.Click += new System.EventHandler(this.details_btn_Click);
            // 
            // SharpUpdateAcceptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::SharpUpdate.Properties.Resources.rock;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(340, 193);
            this.Controls.Add(this.details_btn);
            this.Controls.Add(this.no_btn);
            this.Controls.Add(this.yes_btn);
            this.Controls.Add(this.newVersion_label);
            this.Controls.Add(this.updateavail_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SharpUpdateAcceptForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SharpUpdateAcceptForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SharpUpdateAcceptForm_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label updateavail_label;
        private System.Windows.Forms.Label newVersion_label;
        private System.Windows.Forms.Button yes_btn;
        private System.Windows.Forms.Button no_btn;
        private System.Windows.Forms.Button details_btn;
    }
}