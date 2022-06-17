namespace RanOnlineTrainer
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.login_label = new System.Windows.Forms.Label();
            this.useraccount_tb = new System.Windows.Forms.TextBox();
            this.login_btn = new System.Windows.Forms.Button();
            this.MinimizeLabel = new System.Windows.Forms.Label();
            this.CloseLabel = new System.Windows.Forms.Label();
            this.invalidaccess_label = new System.Windows.Forms.Label();
            this.username_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.adminlogin_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // login_label
            // 
            this.login_label.AutoSize = true;
            this.login_label.ForeColor = System.Drawing.Color.White;
            this.login_label.Location = new System.Drawing.Point(24, 55);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(71, 13);
            this.login_label.TabIndex = 0;
            this.login_label.Text = "User account";
            // 
            // useraccount_tb
            // 
            this.useraccount_tb.BackColor = System.Drawing.Color.White;
            this.useraccount_tb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.useraccount_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useraccount_tb.ForeColor = System.Drawing.SystemColors.InfoText;
            this.useraccount_tb.Location = new System.Drawing.Point(27, 76);
            this.useraccount_tb.Name = "useraccount_tb";
            this.useraccount_tb.Size = new System.Drawing.Size(179, 22);
            this.useraccount_tb.TabIndex = 1;
            this.useraccount_tb.UseSystemPasswordChar = true;
            this.useraccount_tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.useraccount_tb_KeyDown);
            this.useraccount_tb.MouseHover += new System.EventHandler(this.useraccount_tb_MouseHover);
            // 
            // login_btn
            // 
            this.login_btn.Location = new System.Drawing.Point(27, 104);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(75, 23);
            this.login_btn.TabIndex = 2;
            this.login_btn.Text = "Login";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // MinimizeLabel
            // 
            this.MinimizeLabel.AutoSize = true;
            this.MinimizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MinimizeLabel.Location = new System.Drawing.Point(325, 4);
            this.MinimizeLabel.Name = "MinimizeLabel";
            this.MinimizeLabel.Size = new System.Drawing.Size(24, 25);
            this.MinimizeLabel.TabIndex = 3;
            this.MinimizeLabel.Text = "—";
            this.MinimizeLabel.Click += new System.EventHandler(this.MinimizeLabel_Click);
            // 
            // CloseLabel
            // 
            this.CloseLabel.AutoSize = true;
            this.CloseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CloseLabel.Location = new System.Drawing.Point(346, 3);
            this.CloseLabel.Name = "CloseLabel";
            this.CloseLabel.Size = new System.Drawing.Size(26, 25);
            this.CloseLabel.TabIndex = 4;
            this.CloseLabel.Text = "X";
            this.CloseLabel.Click += new System.EventHandler(this.CloseLabel_Click);
            // 
            // invalidaccess_label
            // 
            this.invalidaccess_label.BackColor = System.Drawing.Color.Transparent;
            this.invalidaccess_label.ForeColor = System.Drawing.Color.Red;
            this.invalidaccess_label.Location = new System.Drawing.Point(24, 142);
            this.invalidaccess_label.Name = "invalidaccess_label";
            this.invalidaccess_label.Size = new System.Drawing.Size(141, 52);
            this.invalidaccess_label.TabIndex = 5;
            this.invalidaccess_label.Text = "User Account not valid or has used alll allowed access.";
            // 
            // username_tooltip
            // 
            this.username_tooltip.ForeColor = System.Drawing.Color.Ivory;
            // 
            // adminlogin_btn
            // 
            this.adminlogin_btn.Location = new System.Drawing.Point(274, 335);
            this.adminlogin_btn.Name = "adminlogin_btn";
            this.adminlogin_btn.Size = new System.Drawing.Size(75, 23);
            this.adminlogin_btn.TabIndex = 6;
            this.adminlogin_btn.Text = "Admin Login";
            this.adminlogin_btn.UseVisualStyleBackColor = true;
            this.adminlogin_btn.Click += new System.EventHandler(this.adminlogin_btn_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::RanOnlineTrainer.Properties.Resources.rock;
            this.ClientSize = new System.Drawing.Size(372, 370);
            this.ControlBox = false;
            this.Controls.Add(this.adminlogin_btn);
            this.Controls.Add(this.invalidaccess_label);
            this.Controls.Add(this.CloseLabel);
            this.Controls.Add(this.MinimizeLabel);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.useraccount_tb);
            this.Controls.Add(this.login_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login";
            this.Load += new System.EventHandler(this.login_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.login_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label login_label;
        private System.Windows.Forms.TextBox useraccount_tb;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Label MinimizeLabel;
        private System.Windows.Forms.Label CloseLabel;
        private System.Windows.Forms.Label invalidaccess_label;
        private System.Windows.Forms.ToolTip username_tooltip;
        public System.Windows.Forms.Button adminlogin_btn;
    }
}