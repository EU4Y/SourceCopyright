namespace MusicPlayerCopyright
{
    partial class Clientlogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clientlogin));
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.txtloginUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panUserDetail = new System.Windows.Forms.Panel();
            this.chkAdmin = new System.Windows.Forms.CheckBox();
            this.dgClientUserDetail = new System.Windows.Forms.DataGridView();
            this.chkDownloadSong = new System.Windows.Forms.CheckBox();
            this.chkRemoveSong = new System.Windows.Forms.CheckBox();
            this.btnUserCancel = new System.Windows.Forms.Button();
            this.btnUserSave = new System.Windows.Forms.Button();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.btnExtra = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panUserDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgClientUserDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(679, 186);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(81, 62);
            this.btnExit.TabIndex = 3;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.BackgroundImage")));
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(381, 321);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(81, 62);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoginPassword.Location = new System.Drawing.Point(381, 260);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.PasswordChar = '*';
            this.txtLoginPassword.Size = new System.Drawing.Size(190, 20);
            this.txtLoginPassword.TabIndex = 1;
            this.txtLoginPassword.Text = "admin";
            this.txtLoginPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoginPassword_KeyDown);
            // 
            // txtloginUserName
            // 
            this.txtloginUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtloginUserName.Location = new System.Drawing.Point(381, 227);
            this.txtloginUserName.Name = "txtloginUserName";
            this.txtloginUserName.Size = new System.Drawing.Size(190, 20);
            this.txtloginUserName.TabIndex = 0;
            this.txtloginUserName.Text = "admin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(185)))), ((int)(((byte)(198)))));
            this.label2.Location = new System.Drawing.Point(279, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.label2.TabIndex = 40;
            this.label2.Text = "Password   :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(185)))), ((int)(((byte)(198)))));
            this.label1.Location = new System.Drawing.Point(279, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 19);
            this.label1.TabIndex = 39;
            this.label1.Text = "User Name :";
            // 
            // panUserDetail
            // 
            this.panUserDetail.BackColor = System.Drawing.Color.Transparent;
            this.panUserDetail.Controls.Add(this.chkAdmin);
            this.panUserDetail.Controls.Add(this.dgClientUserDetail);
            this.panUserDetail.Controls.Add(this.chkDownloadSong);
            this.panUserDetail.Controls.Add(this.chkRemoveSong);
            this.panUserDetail.Controls.Add(this.btnUserCancel);
            this.panUserDetail.Controls.Add(this.btnUserSave);
            this.panUserDetail.Controls.Add(this.txtUserPassword);
            this.panUserDetail.Controls.Add(this.txtUserName);
            this.panUserDetail.Controls.Add(this.label7);
            this.panUserDetail.Controls.Add(this.label8);
            this.panUserDetail.Location = new System.Drawing.Point(0, 121);
            this.panUserDetail.Name = "panUserDetail";
            this.panUserDetail.Size = new System.Drawing.Size(91, 126);
            this.panUserDetail.TabIndex = 61;
            this.panUserDetail.Visible = false;
            // 
            // chkAdmin
            // 
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkAdmin.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(185)))), ((int)(((byte)(198)))));
            this.chkAdmin.Location = new System.Drawing.Point(346, 126);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(139, 23);
            this.chkAdmin.TabIndex = 79;
            this.chkAdmin.Text = "Is Administrator";
            this.chkAdmin.UseVisualStyleBackColor = true;
            // 
            // dgClientUserDetail
            // 
            this.dgClientUserDetail.AllowUserToAddRows = false;
            this.dgClientUserDetail.AllowUserToDeleteRows = false;
            this.dgClientUserDetail.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgClientUserDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgClientUserDetail.Location = new System.Drawing.Point(607, 64);
            this.dgClientUserDetail.Name = "dgClientUserDetail";
            this.dgClientUserDetail.ReadOnly = true;
            this.dgClientUserDetail.RowHeadersVisible = false;
            this.dgClientUserDetail.Size = new System.Drawing.Size(308, 253);
            this.dgClientUserDetail.TabIndex = 78;
            this.dgClientUserDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgClientUserDetail_CellContentClick);
            // 
            // chkDownloadSong
            // 
            this.chkDownloadSong.AutoSize = true;
            this.chkDownloadSong.BackColor = System.Drawing.Color.Transparent;
            this.chkDownloadSong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkDownloadSong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDownloadSong.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDownloadSong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(185)))), ((int)(((byte)(198)))));
            this.chkDownloadSong.Location = new System.Drawing.Point(448, 154);
            this.chkDownloadSong.Name = "chkDownloadSong";
            this.chkDownloadSong.Size = new System.Drawing.Size(139, 23);
            this.chkDownloadSong.TabIndex = 77;
            this.chkDownloadSong.Text = "Download Song";
            this.chkDownloadSong.UseVisualStyleBackColor = false;
            // 
            // chkRemoveSong
            // 
            this.chkRemoveSong.AutoSize = true;
            this.chkRemoveSong.BackColor = System.Drawing.Color.Transparent;
            this.chkRemoveSong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkRemoveSong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRemoveSong.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRemoveSong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(185)))), ((int)(((byte)(198)))));
            this.chkRemoveSong.Location = new System.Drawing.Point(316, 154);
            this.chkRemoveSong.Name = "chkRemoveSong";
            this.chkRemoveSong.Size = new System.Drawing.Size(126, 23);
            this.chkRemoveSong.TabIndex = 76;
            this.chkRemoveSong.Text = "Remove Song";
            this.chkRemoveSong.UseVisualStyleBackColor = false;
            // 
            // btnUserCancel
            // 
            this.btnUserCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnUserCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUserCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserCancel.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(185)))), ((int)(((byte)(198)))));
            this.btnUserCancel.Location = new System.Drawing.Point(463, 193);
            this.btnUserCancel.Name = "btnUserCancel";
            this.btnUserCancel.Size = new System.Drawing.Size(92, 37);
            this.btnUserCancel.TabIndex = 75;
            this.btnUserCancel.Text = "Cancel";
            this.btnUserCancel.UseVisualStyleBackColor = false;
            this.btnUserCancel.Click += new System.EventHandler(this.btnUserCancel_Click);
            // 
            // btnUserSave
            // 
            this.btnUserSave.BackColor = System.Drawing.Color.Transparent;
            this.btnUserSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUserSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserSave.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(185)))), ((int)(((byte)(198)))));
            this.btnUserSave.Location = new System.Drawing.Point(344, 193);
            this.btnUserSave.Name = "btnUserSave";
            this.btnUserSave.Size = new System.Drawing.Size(92, 37);
            this.btnUserSave.TabIndex = 74;
            this.btnUserSave.Text = "Submit";
            this.btnUserSave.UseVisualStyleBackColor = false;
            this.btnUserSave.Click += new System.EventHandler(this.btnUserSave_Click);
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserPassword.Location = new System.Drawing.Point(344, 98);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.PasswordChar = '*';
            this.txtUserPassword.Size = new System.Drawing.Size(211, 20);
            this.txtUserPassword.TabIndex = 73;
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Location = new System.Drawing.Point(344, 65);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(211, 20);
            this.txtUserName.TabIndex = 72;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(185)))), ((int)(((byte)(198)))));
            this.label7.Location = new System.Drawing.Point(249, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 19);
            this.label7.TabIndex = 71;
            this.label7.Text = "Password";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(185)))), ((int)(((byte)(198)))));
            this.label8.Location = new System.Drawing.Point(249, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 19);
            this.label8.TabIndex = 70;
            this.label8.Text = "User Name";
            // 
            // picDisplay
            // 
            this.picDisplay.BackColor = System.Drawing.Color.Transparent;
            this.picDisplay.BackgroundImage = global::MusicPlayerCopyright.Properties.Resources.Setting2;
            this.picDisplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picDisplay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDisplay.Location = new System.Drawing.Point(873, 412);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(46, 41);
            this.picDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDisplay.TabIndex = 48;
            this.picDisplay.TabStop = false;
            this.picDisplay.Visible = false;
            this.picDisplay.Click += new System.EventHandler(this.picDisplay_Click);
            // 
            // btnExtra
            // 
            this.btnExtra.Location = new System.Drawing.Point(828, 128);
            this.btnExtra.Name = "btnExtra";
            this.btnExtra.Size = new System.Drawing.Size(92, 37);
            this.btnExtra.TabIndex = 62;
            this.btnExtra.Text = "Extra";
            this.btnExtra.UseVisualStyleBackColor = true;
            this.btnExtra.Visible = false;
            this.btnExtra.Click += new System.EventHandler(this.btnExtra_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = typeof(MusicPlayerCopyright.Properties.Resources).Name;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(32, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(869, 101);
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            // 
            // chkRemember
            // 
            this.chkRemember.BackColor = System.Drawing.Color.Transparent;
            this.chkRemember.Checked = true;
            this.chkRemember.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRemember.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRemember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(185)))), ((int)(((byte)(198)))));
            this.chkRemember.Location = new System.Drawing.Point(381, 286);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(190, 29);
            this.chkRemember.TabIndex = 64;
            this.chkRemember.Text = "Remember Me";
            this.chkRemember.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(185)))), ((int)(((byte)(198)))));
            this.label6.Location = new System.Drawing.Point(401, 459);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 15);
            this.label6.TabIndex = 67;
            this.label6.Text = "Eufory Music Player";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(185)))), ((int)(((byte)(198)))));
            this.label5.Location = new System.Drawing.Point(676, 458);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(244, 15);
            this.label5.TabIndex = 66;
            this.label5.Text = "Licensed :- Jan Rooijakkers for EU4Y BVBA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(185)))), ((int)(((byte)(198)))));
            this.label4.Location = new System.Drawing.Point(4, 458);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 15);
            this.label4.TabIndex = 65;
            this.label4.Text = "Editor :- Paras Technologies";
            // 
            // Clientlogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MusicPlayerCopyright.Properties.Resources.BackgroundGraphics;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(932, 481);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkRemember);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExtra);
            this.Controls.Add(this.panUserDetail);
            this.Controls.Add(this.picDisplay);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtLoginPassword);
            this.Controls.Add(this.txtloginUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Clientlogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "© Eu4y Music Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Clientlogin_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Clientlogin_FormClosed);
            this.Load += new System.EventHandler(this.Clientlogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Clientlogin_KeyDown);
            this.Move += new System.EventHandler(this.Clientlogin_Move);
            this.panUserDetail.ResumeLayout(false);
            this.panUserDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgClientUserDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.TextBox txtloginUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Panel panUserDetail;
        private System.Windows.Forms.CheckBox chkDownloadSong;
        private System.Windows.Forms.CheckBox chkRemoveSong;
        private System.Windows.Forms.Button btnUserCancel;
        private System.Windows.Forms.Button btnUserSave;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgClientUserDetail;
        private System.Windows.Forms.CheckBox chkAdmin;
        private System.Windows.Forms.Button btnExtra;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}