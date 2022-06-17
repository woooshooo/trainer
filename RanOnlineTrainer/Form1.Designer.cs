
namespace RanOnlineTrainer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            this.ProcessLabel = new System.Windows.Forms.Label();
            this.ProcessExeLabel = new System.Windows.Forms.Label();
            this.PIDLabel = new System.Windows.Forms.Label();
            this.PIDValueLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.StatusValueLabel = new System.Windows.Forms.Label();
            this.FormTime = new System.Windows.Forms.Timer(this.components);
            this.FormTimeLabel = new System.Windows.Forms.Label();
            this.MinimizeLabel = new System.Windows.Forms.Label();
            this.CloseLabel = new System.Windows.Forms.Label();
            this.DroneLabel = new System.Windows.Forms.Label();
            this.DroneComboBox = new System.Windows.Forms.ComboBox();
            this.AoeLabel = new System.Windows.Forms.Label();
            this.HPFLabel = new System.Windows.Forms.Label();
            this.HPFButton = new System.Windows.Forms.Button();
            this.AOELRButton = new System.Windows.Forms.Button();
            this.AOELRLABEL = new System.Windows.Forms.Label();
            this.qaplabel = new System.Windows.Forms.Label();
            this.QAPButton = new System.Windows.Forms.Button();
            this.wallhack_label = new System.Windows.Forms.Label();
            this.piercethruwallsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.attkspd_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.guid_label = new System.Windows.Forms.Label();
            this.account_label = new System.Windows.Forms.Label();
            this.lastlogin_label = new System.Windows.Forms.Label();
            this.accounts_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BGWorker
            // 
            this.BGWorker.WorkerReportsProgress = true;
            this.BGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWorker_DoWork);
            this.BGWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BGWorker_ProgressChanged);
            this.BGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWorker_RunWorkerCompleted);
            // 
            // ProcessLabel
            // 
            this.ProcessLabel.AutoSize = true;
            this.ProcessLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ProcessLabel.Location = new System.Drawing.Point(26, 25);
            this.ProcessLabel.Name = "ProcessLabel";
            this.ProcessLabel.Size = new System.Drawing.Size(48, 13);
            this.ProcessLabel.TabIndex = 0;
            this.ProcessLabel.Text = "Process:";
            // 
            // ProcessExeLabel
            // 
            this.ProcessExeLabel.AutoSize = true;
            this.ProcessExeLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ProcessExeLabel.Location = new System.Drawing.Point(72, 25);
            this.ProcessExeLabel.Name = "ProcessExeLabel";
            this.ProcessExeLabel.Size = new System.Drawing.Size(27, 13);
            this.ProcessExeLabel.TabIndex = 0;
            this.ProcessExeLabel.Text = "N/A";
            // 
            // PIDLabel
            // 
            this.PIDLabel.AutoSize = true;
            this.PIDLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.PIDLabel.Location = new System.Drawing.Point(46, 40);
            this.PIDLabel.Name = "PIDLabel";
            this.PIDLabel.Size = new System.Drawing.Size(28, 13);
            this.PIDLabel.TabIndex = 0;
            this.PIDLabel.Text = "PID:";
            // 
            // PIDValueLabel
            // 
            this.PIDValueLabel.AutoSize = true;
            this.PIDValueLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.PIDValueLabel.Location = new System.Drawing.Point(71, 40);
            this.PIDValueLabel.Name = "PIDValueLabel";
            this.PIDValueLabel.Size = new System.Drawing.Size(27, 13);
            this.PIDValueLabel.TabIndex = 0;
            this.PIDValueLabel.Text = "N/A";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.StatusLabel.Location = new System.Drawing.Point(34, 53);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(40, 13);
            this.StatusLabel.TabIndex = 0;
            this.StatusLabel.Text = "Status:";
            // 
            // StatusValueLabel
            // 
            this.StatusValueLabel.AutoSize = true;
            this.StatusValueLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.StatusValueLabel.Location = new System.Drawing.Point(72, 55);
            this.StatusValueLabel.Name = "StatusValueLabel";
            this.StatusValueLabel.Size = new System.Drawing.Size(27, 13);
            this.StatusValueLabel.TabIndex = 0;
            this.StatusValueLabel.Text = "N/A";
            // 
            // FormTime
            // 
            this.FormTime.Tick += new System.EventHandler(this.FormTime_Tick);
            // 
            // FormTimeLabel
            // 
            this.FormTimeLabel.AutoSize = true;
            this.FormTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.FormTimeLabel.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormTimeLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.FormTimeLabel.Location = new System.Drawing.Point(201, 25);
            this.FormTimeLabel.Name = "FormTimeLabel";
            this.FormTimeLabel.Size = new System.Drawing.Size(164, 33);
            this.FormTimeLabel.TabIndex = 0;
            this.FormTimeLabel.Text = "00:00:00 PM";
            // 
            // MinimizeLabel
            // 
            this.MinimizeLabel.AutoSize = true;
            this.MinimizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MinimizeLabel.Location = new System.Drawing.Point(328, 2);
            this.MinimizeLabel.Name = "MinimizeLabel";
            this.MinimizeLabel.Size = new System.Drawing.Size(24, 25);
            this.MinimizeLabel.TabIndex = 0;
            this.MinimizeLabel.Text = "—";
            this.MinimizeLabel.Click += new System.EventHandler(this.MinimizeLabel_Click);
            // 
            // CloseLabel
            // 
            this.CloseLabel.AutoSize = true;
            this.CloseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CloseLabel.Location = new System.Drawing.Point(347, 2);
            this.CloseLabel.Name = "CloseLabel";
            this.CloseLabel.Size = new System.Drawing.Size(26, 25);
            this.CloseLabel.TabIndex = 0;
            this.CloseLabel.Text = "X";
            this.CloseLabel.Click += new System.EventHandler(this.CloseLabel_Click);
            // 
            // DroneLabel
            // 
            this.DroneLabel.AutoSize = true;
            this.DroneLabel.BackColor = System.Drawing.Color.Transparent;
            this.DroneLabel.Font = new System.Drawing.Font("Arial Narrow", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DroneLabel.ForeColor = System.Drawing.Color.Linen;
            this.DroneLabel.Location = new System.Drawing.Point(35, 97);
            this.DroneLabel.Name = "DroneLabel";
            this.DroneLabel.Size = new System.Drawing.Size(63, 25);
            this.DroneLabel.TabIndex = 0;
            this.DroneLabel.Text = "Drone";
            // 
            // DroneComboBox
            // 
            this.DroneComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DroneComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DroneComboBox.FormattingEnabled = true;
            this.DroneComboBox.Location = new System.Drawing.Point(104, 101);
            this.DroneComboBox.Name = "DroneComboBox";
            this.DroneComboBox.Size = new System.Drawing.Size(67, 21);
            this.DroneComboBox.TabIndex = 1;
            this.DroneComboBox.SelectionChangeCommitted += new System.EventHandler(this.DroneComboBox_SelectionChangeCommitted);
            // 
            // AoeLabel
            // 
            this.AoeLabel.AutoSize = true;
            this.AoeLabel.BackColor = System.Drawing.Color.Transparent;
            this.AoeLabel.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AoeLabel.ForeColor = System.Drawing.Color.Linen;
            this.AoeLabel.Location = new System.Drawing.Point(105, 73);
            this.AoeLabel.Name = "AoeLabel";
            this.AoeLabel.Size = new System.Drawing.Size(62, 25);
            this.AoeLabel.TabIndex = 0;
            this.AoeLabel.Text = "Status";
            // 
            // HPFLabel
            // 
            this.HPFLabel.AutoSize = true;
            this.HPFLabel.BackColor = System.Drawing.Color.Transparent;
            this.HPFLabel.Font = new System.Drawing.Font("Arial Narrow", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HPFLabel.ForeColor = System.Drawing.Color.Linen;
            this.HPFLabel.Location = new System.Drawing.Point(1, 263);
            this.HPFLabel.Name = "HPFLabel";
            this.HPFLabel.Size = new System.Drawing.Size(97, 25);
            this.HPFLabel.TabIndex = 0;
            this.HPFLabel.Text = "HP Freeze";
            // 
            // HPFButton
            // 
            this.HPFButton.Location = new System.Drawing.Point(105, 267);
            this.HPFButton.Name = "HPFButton";
            this.HPFButton.Size = new System.Drawing.Size(68, 23);
            this.HPFButton.TabIndex = 2;
            this.HPFButton.Text = "OFF";
            this.HPFButton.UseVisualStyleBackColor = true;
            this.HPFButton.Click += new System.EventHandler(this.HPFButton_Click);
            // 
            // AOELRButton
            // 
            this.AOELRButton.Location = new System.Drawing.Point(105, 196);
            this.AOELRButton.Name = "AOELRButton";
            this.AOELRButton.Size = new System.Drawing.Size(68, 23);
            this.AOELRButton.TabIndex = 2;
            this.AOELRButton.Text = "OFF";
            this.AOELRButton.UseVisualStyleBackColor = true;
            this.AOELRButton.Click += new System.EventHandler(this.AOELRButton_Click);
            // 
            // AOELRLABEL
            // 
            this.AOELRLABEL.AutoSize = true;
            this.AOELRLABEL.BackColor = System.Drawing.Color.Transparent;
            this.AOELRLABEL.Font = new System.Drawing.Font("Arial Narrow", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AOELRLABEL.ForeColor = System.Drawing.Color.Linen;
            this.AOELRLABEL.Location = new System.Drawing.Point(7, 196);
            this.AOELRLABEL.Name = "AOELRLABEL";
            this.AOELRLABEL.Size = new System.Drawing.Size(92, 25);
            this.AOELRLABEL.TabIndex = 0;
            this.AOELRLABEL.Text = "AOE n LR";
            // 
            // qaplabel
            // 
            this.qaplabel.AutoSize = true;
            this.qaplabel.BackColor = System.Drawing.Color.Transparent;
            this.qaplabel.Font = new System.Drawing.Font("Arial Narrow", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qaplabel.ForeColor = System.Drawing.Color.Linen;
            this.qaplabel.Location = new System.Drawing.Point(63, 231);
            this.qaplabel.Name = "qaplabel";
            this.qaplabel.Size = new System.Drawing.Size(35, 25);
            this.qaplabel.TabIndex = 0;
            this.qaplabel.Text = "AP";
            // 
            // QAPButton
            // 
            this.QAPButton.Location = new System.Drawing.Point(105, 231);
            this.QAPButton.Name = "QAPButton";
            this.QAPButton.Size = new System.Drawing.Size(68, 23);
            this.QAPButton.TabIndex = 2;
            this.QAPButton.Text = "OFF";
            this.QAPButton.UseVisualStyleBackColor = true;
            this.QAPButton.Click += new System.EventHandler(this.QAPButton_Click);
            // 
            // wallhack_label
            // 
            this.wallhack_label.AutoSize = true;
            this.wallhack_label.BackColor = System.Drawing.Color.Transparent;
            this.wallhack_label.Font = new System.Drawing.Font("Arial Narrow", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wallhack_label.ForeColor = System.Drawing.Color.Linen;
            this.wallhack_label.Location = new System.Drawing.Point(3, 129);
            this.wallhack_label.Name = "wallhack_label";
            this.wallhack_label.Size = new System.Drawing.Size(95, 25);
            this.wallhack_label.TabIndex = 0;
            this.wallhack_label.Text = "Wall Hack";
            // 
            // piercethruwallsButton
            // 
            this.piercethruwallsButton.Location = new System.Drawing.Point(104, 131);
            this.piercethruwallsButton.Name = "piercethruwallsButton";
            this.piercethruwallsButton.Size = new System.Drawing.Size(68, 23);
            this.piercethruwallsButton.TabIndex = 2;
            this.piercethruwallsButton.Text = "OFF";
            this.piercethruwallsButton.UseVisualStyleBackColor = true;
            this.piercethruwallsButton.Click += new System.EventHandler(this.piercethruwallsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Linen;
            this.label1.Location = new System.Drawing.Point(19, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "AttkSpd";
            // 
            // attkspd_btn
            // 
            this.attkspd_btn.Enabled = false;
            this.attkspd_btn.Location = new System.Drawing.Point(104, 164);
            this.attkspd_btn.Name = "attkspd_btn";
            this.attkspd_btn.Size = new System.Drawing.Size(68, 23);
            this.attkspd_btn.TabIndex = 3;
            this.attkspd_btn.Text = "OFF";
            this.attkspd_btn.UseVisualStyleBackColor = true;
            this.attkspd_btn.Click += new System.EventHandler(this.attkspd_btn_Click);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(203, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 88);
            this.label2.TabIndex = 4;
            this.label2.Text = "“Don’t cheat if you don’t want to be cheated. ” — Israelmore Ayivor";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guid_label
            // 
            this.guid_label.AutoSize = true;
            this.guid_label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guid_label.Location = new System.Drawing.Point(8, 314);
            this.guid_label.Name = "guid_label";
            this.guid_label.Size = new System.Drawing.Size(58, 13);
            this.guid_label.TabIndex = 5;
            this.guid_label.Text = "Trainer for:";
            // 
            // account_label
            // 
            this.account_label.AutoSize = true;
            this.account_label.ForeColor = System.Drawing.Color.White;
            this.account_label.Location = new System.Drawing.Point(16, 329);
            this.account_label.Name = "account_label";
            this.account_label.Size = new System.Drawing.Size(50, 13);
            this.account_label.TabIndex = 6;
            this.account_label.Text = "Account:";
            // 
            // lastlogin_label
            // 
            this.lastlogin_label.AutoSize = true;
            this.lastlogin_label.ForeColor = System.Drawing.Color.White;
            this.lastlogin_label.Location = new System.Drawing.Point(11, 344);
            this.lastlogin_label.Name = "lastlogin_label";
            this.lastlogin_label.Size = new System.Drawing.Size(55, 13);
            this.lastlogin_label.TabIndex = 7;
            this.lastlogin_label.Text = "Last login:";
            // 
            // accounts_btn
            // 
            this.accounts_btn.Location = new System.Drawing.Point(290, 339);
            this.accounts_btn.Name = "accounts_btn";
            this.accounts_btn.Size = new System.Drawing.Size(75, 23);
            this.accounts_btn.TabIndex = 8;
            this.accounts_btn.Text = "Accounts";
            this.accounts_btn.UseVisualStyleBackColor = true;
            this.accounts_btn.Click += new System.EventHandler(this.accounts_btn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(372, 370);
            this.ControlBox = false;
            this.Controls.Add(this.accounts_btn);
            this.Controls.Add(this.lastlogin_label);
            this.Controls.Add(this.account_label);
            this.Controls.Add(this.guid_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.attkspd_btn);
            this.Controls.Add(this.QAPButton);
            this.Controls.Add(this.AOELRButton);
            this.Controls.Add(this.piercethruwallsButton);
            this.Controls.Add(this.HPFButton);
            this.Controls.Add(this.DroneComboBox);
            this.Controls.Add(this.StatusValueLabel);
            this.Controls.Add(this.PIDValueLabel);
            this.Controls.Add(this.ProcessExeLabel);
            this.Controls.Add(this.AoeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.qaplabel);
            this.Controls.Add(this.AOELRLABEL);
            this.Controls.Add(this.wallhack_label);
            this.Controls.Add(this.HPFLabel);
            this.Controls.Add(this.DroneLabel);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.PIDLabel);
            this.Controls.Add(this.CloseLabel);
            this.Controls.Add(this.MinimizeLabel);
            this.Controls.Add(this.FormTimeLabel);
            this.Controls.Add(this.ProcessLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Opacity = 0.8D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RanOnline Trainer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker BGWorker;
        private System.Windows.Forms.Label ProcessLabel;
        private System.Windows.Forms.Label ProcessExeLabel;
        private System.Windows.Forms.Label PIDLabel;
        private System.Windows.Forms.Label PIDValueLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label StatusValueLabel;
        private System.Windows.Forms.Timer FormTime;
        private System.Windows.Forms.Label FormTimeLabel;
        private System.Windows.Forms.Label MinimizeLabel;
        private System.Windows.Forms.Label CloseLabel;
        private System.Windows.Forms.Label DroneLabel;
        private System.Windows.Forms.ComboBox DroneComboBox;
        private System.Windows.Forms.Label AoeLabel;
        private System.Windows.Forms.Label HPFLabel;
        private System.Windows.Forms.Button HPFButton;
        private System.Windows.Forms.Button AOELRButton;
        private System.Windows.Forms.Label AOELRLABEL;
        private System.Windows.Forms.Label qaplabel;
        private System.Windows.Forms.Button QAPButton;
        private System.Windows.Forms.Label wallhack_label;
        private System.Windows.Forms.Button piercethruwallsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button attkspd_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label guid_label;
        private System.Windows.Forms.Label account_label;
        private System.Windows.Forms.Label lastlogin_label;
        private System.Windows.Forms.Button accounts_btn;
    }
}

