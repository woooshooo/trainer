namespace SharpUpdate
{
    partial class SharpUpdateInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SharpUpdateInfoForm));
            this.CloseLabel = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.desc_label = new System.Windows.Forms.Label();
            this.back_btn = new System.Windows.Forms.Button();
            this.lblVersions = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CloseLabel
            // 
            this.CloseLabel.AutoSize = true;
            this.CloseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CloseLabel.Location = new System.Drawing.Point(334, 9);
            this.CloseLabel.Name = "CloseLabel";
            this.CloseLabel.Size = new System.Drawing.Size(26, 25);
            this.CloseLabel.TabIndex = 5;
            this.CloseLabel.Text = "X";
            this.CloseLabel.Click += new System.EventHandler(this.CloseLabel_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtDescription.ForeColor = System.Drawing.Color.White;
            this.txtDescription.Location = new System.Drawing.Point(12, 58);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(173, 169);
            this.txtDescription.TabIndex = 6;
            this.txtDescription.TabStop = false;
            this.txtDescription.Text = "";
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescription_KeyDown);
            // 
            // desc_label
            // 
            this.desc_label.AutoSize = true;
            this.desc_label.ForeColor = System.Drawing.Color.White;
            this.desc_label.Location = new System.Drawing.Point(12, 31);
            this.desc_label.Name = "desc_label";
            this.desc_label.Size = new System.Drawing.Size(60, 13);
            this.desc_label.TabIndex = 7;
            this.desc_label.Text = "Description";
            // 
            // back_btn
            // 
            this.back_btn.Location = new System.Drawing.Point(54, 236);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(75, 23);
            this.back_btn.TabIndex = 8;
            this.back_btn.Text = "Back";
            this.back_btn.UseVisualStyleBackColor = true;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // lblVersions
            // 
            this.lblVersions.AutoSize = true;
            this.lblVersions.ForeColor = System.Drawing.Color.White;
            this.lblVersions.Location = new System.Drawing.Point(228, 60);
            this.lblVersions.Name = "lblVersions";
            this.lblVersions.Size = new System.Drawing.Size(102, 13);
            this.lblVersions.TabIndex = 9;
            this.lblVersions.Text = "Label Versions Here";
            // 
            // SharpUpdateInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::SharpUpdate.Properties.Resources.rock;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(372, 271);
            this.Controls.Add(this.lblVersions);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.desc_label);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.CloseLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SharpUpdateInfoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SharpUpdateInfoForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SharpUpdateInfoForm_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CloseLabel;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label desc_label;
        private System.Windows.Forms.Button back_btn;
        private System.Windows.Forms.Label lblVersions;
    }
}