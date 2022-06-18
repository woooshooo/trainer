namespace RanOnlineTrainer
{
    partial class admin
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
            this.CloseLabel = new System.Windows.Forms.Label();
            this.MinimizeLabel = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allowedactive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastlogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ranserver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refresh_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CloseLabel
            // 
            this.CloseLabel.AutoSize = true;
            this.CloseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CloseLabel.Location = new System.Drawing.Point(533, 9);
            this.CloseLabel.Name = "CloseLabel";
            this.CloseLabel.Size = new System.Drawing.Size(26, 25);
            this.CloseLabel.TabIndex = 6;
            this.CloseLabel.Text = "X";
            this.CloseLabel.Click += new System.EventHandler(this.CloseLabel_Click);
            // 
            // MinimizeLabel
            // 
            this.MinimizeLabel.AutoSize = true;
            this.MinimizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MinimizeLabel.Location = new System.Drawing.Point(512, 9);
            this.MinimizeLabel.Name = "MinimizeLabel";
            this.MinimizeLabel.Size = new System.Drawing.Size(24, 25);
            this.MinimizeLabel.TabIndex = 5;
            this.MinimizeLabel.Text = "—";
            this.MinimizeLabel.Click += new System.EventHandler(this.MinimizeLabel_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.username,
            this.allowedactive,
            this.active,
            this.lastlogin,
            this.ranserver});
            this.dataGridView.Location = new System.Drawing.Point(22, 40);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(537, 306);
            this.dataGridView.TabIndex = 7;
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            this.dataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_UserDeletingRow);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // username
            // 
            this.username.DataPropertyName = "username";
            this.username.HeaderText = "Username";
            this.username.Name = "username";
            // 
            // allowedactive
            // 
            this.allowedactive.DataPropertyName = "allowedactive";
            this.allowedactive.HeaderText = "Allowed Active";
            this.allowedactive.Name = "allowedactive";
            // 
            // active
            // 
            this.active.DataPropertyName = "active";
            this.active.HeaderText = "Active";
            this.active.Name = "active";
            // 
            // lastlogin
            // 
            this.lastlogin.DataPropertyName = "lastlogin";
            this.lastlogin.HeaderText = "Last Login";
            this.lastlogin.Name = "lastlogin";
            // 
            // ranserver
            // 
            this.ranserver.DataPropertyName = "ranserver";
            this.ranserver.HeaderText = "Ran Server";
            this.ranserver.Name = "ranserver";
            // 
            // refresh_btn
            // 
            this.refresh_btn.Location = new System.Drawing.Point(22, 11);
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.Size = new System.Drawing.Size(75, 23);
            this.refresh_btn.TabIndex = 8;
            this.refresh_btn.Text = "Refresh";
            this.refresh_btn.UseVisualStyleBackColor = true;
            this.refresh_btn.Click += new System.EventHandler(this.refresh_btn_Click);
            // 
            // admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::RanOnlineTrainer.Properties.Resources.rock;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(584, 370);
            this.Controls.Add(this.refresh_btn);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.CloseLabel);
            this.Controls.Add(this.MinimizeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "admin";
            this.ShowInTaskbar = false;
            this.Text = "admin";
            this.Load += new System.EventHandler(this.admin_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.admin_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CloseLabel;
        private System.Windows.Forms.Label MinimizeLabel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button refresh_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn allowedactive;
        private System.Windows.Forms.DataGridViewTextBoxColumn active;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastlogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ranserver;
    }
}