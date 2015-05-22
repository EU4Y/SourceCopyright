namespace MusicPlayerTokenDealer
{
    partial class frmTokenDistributionAsian
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnUnload = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtVatNumber = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblAvailableToken = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkSanjivani = new System.Windows.Forms.CheckBox();
            this.dtpSanjivaniExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTVPassword = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTeamviewerId = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCityname = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.cmbPlayerType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbNoTitles = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoToken = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.cmbClientName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRefersh = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbSearchPlayerType = new System.Windows.Forms.ComboBox();
            this.txtSearchUserName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbSearchClientName = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgTokenGeneration = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTokenGeneration)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUnload
            // 
            this.btnUnload.BackColor = System.Drawing.Color.Transparent;
            this.btnUnload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUnload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnUnload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnUnload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnload.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnload.ForeColor = System.Drawing.Color.Yellow;
            this.btnUnload.Location = new System.Drawing.Point(638, 10);
            this.btnUnload.Name = "btnUnload";
            this.btnUnload.Size = new System.Drawing.Size(95, 38);
            this.btnUnload.TabIndex = 10;
            this.btnUnload.Text = "Cancel";
            this.btnUnload.UseVisualStyleBackColor = false;
            this.btnUnload.Click += new System.EventHandler(this.btnUnload_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(51)))), ((int)(((byte)(45)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtVatNumber);
            this.panel1.Controls.Add(this.txtLocation);
            this.panel1.Controls.Add(this.lblAvailableToken);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.chkSanjivani);
            this.panel1.Controls.Add(this.dtpSanjivaniExpiryDate);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtTVPassword);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtTeamviewerId);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtCityname);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtStreet);
            this.panel1.Controls.Add(this.cmbPlayerType);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cmbNoTitles);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNoToken);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.cmbClientName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 174);
            this.panel1.TabIndex = 15;
            // 
            // txtVatNumber
            // 
            this.txtVatNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVatNumber.Location = new System.Drawing.Point(763, 76);
            this.txtVatNumber.Name = "txtVatNumber";
            this.txtVatNumber.Size = new System.Drawing.Size(208, 23);
            this.txtVatNumber.TabIndex = 5;
            // 
            // txtLocation
            // 
            this.txtLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocation.Location = new System.Drawing.Point(428, 45);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(208, 23);
            this.txtLocation.TabIndex = 1;
            // 
            // lblAvailableToken
            // 
            this.lblAvailableToken.AutoSize = true;
            this.lblAvailableToken.BackColor = System.Drawing.Color.Transparent;
            this.lblAvailableToken.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableToken.ForeColor = System.Drawing.Color.Yellow;
            this.lblAvailableToken.Location = new System.Drawing.Point(786, 7);
            this.lblAvailableToken.Name = "lblAvailableToken";
            this.lblAvailableToken.Size = new System.Drawing.Size(178, 19);
            this.lblAvailableToken.TabIndex = 147;
            this.lblAvailableToken.Text = "All tokens are distribute";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(328, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 19);
            this.label5.TabIndex = 146;
            this.label5.Text = "Expiry Date";
            // 
            // chkSanjivani
            // 
            this.chkSanjivani.AutoSize = true;
            this.chkSanjivani.Checked = true;
            this.chkSanjivani.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSanjivani.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSanjivani.ForeColor = System.Drawing.Color.Yellow;
            this.chkSanjivani.Location = new System.Drawing.Point(661, 7);
            this.chkSanjivani.Name = "chkSanjivani";
            this.chkSanjivani.Size = new System.Drawing.Size(92, 25);
            this.chkSanjivani.TabIndex = 145;
            this.chkSanjivani.Text = "Sanjivani";
            this.chkSanjivani.UseVisualStyleBackColor = true;
            this.chkSanjivani.Visible = false;
            // 
            // dtpSanjivaniExpiryDate
            // 
            this.dtpSanjivaniExpiryDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpSanjivaniExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSanjivaniExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSanjivaniExpiryDate.Location = new System.Drawing.Point(429, 138);
            this.dtpSanjivaniExpiryDate.Name = "dtpSanjivaniExpiryDate";
            this.dtpSanjivaniExpiryDate.Size = new System.Drawing.Size(207, 23);
            this.dtpSanjivaniExpiryDate.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(6, 140);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 19);
            this.label14.TabIndex = 141;
            this.label14.Text = "Password";
            // 
            // txtTVPassword
            // 
            this.txtTVPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTVPassword.Location = new System.Drawing.Point(118, 139);
            this.txtTVPassword.Name = "txtTVPassword";
            this.txtTVPassword.Size = new System.Drawing.Size(208, 23);
            this.txtTVPassword.TabIndex = 10;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(639, 104);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 19);
            this.label15.TabIndex = 140;
            this.label15.Text = "Teamviewer Id";
            // 
            // txtTeamviewerId
            // 
            this.txtTeamviewerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeamviewerId.Location = new System.Drawing.Point(763, 104);
            this.txtTeamviewerId.Name = "txtTeamviewerId";
            this.txtTeamviewerId.Size = new System.Drawing.Size(207, 23);
            this.txtTeamviewerId.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(327, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 19);
            this.label13.TabIndex = 139;
            this.label13.Text = "City Name";
            // 
            // txtCityname
            // 
            this.txtCityname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCityname.Location = new System.Drawing.Point(429, 77);
            this.txtCityname.Name = "txtCityname";
            this.txtCityname.Size = new System.Drawing.Size(208, 23);
            this.txtCityname.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(5, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 19);
            this.label12.TabIndex = 138;
            this.label12.Text = "Street";
            // 
            // txtStreet
            // 
            this.txtStreet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreet.Location = new System.Drawing.Point(118, 76);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(207, 23);
            this.txtStreet.TabIndex = 3;
            // 
            // cmbPlayerType
            // 
            this.cmbPlayerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlayerType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPlayerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlayerType.FormattingEnabled = true;
            this.cmbPlayerType.Items.AddRange(new object[] {
            "",
            "Desktop",
            "Android",
            "Apple"});
            this.cmbPlayerType.Location = new System.Drawing.Point(429, 107);
            this.cmbPlayerType.Name = "cmbPlayerType";
            this.cmbPlayerType.Size = new System.Drawing.Size(207, 25);
            this.cmbPlayerType.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Yellow;
            this.label11.Location = new System.Drawing.Point(4, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(241, 24);
            this.label11.TabIndex = 136;
            this.label11.Text = "Token Distribution Asian";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(328, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 19);
            this.label9.TabIndex = 135;
            this.label9.Text = "Player Type";
            // 
            // cmbNoTitles
            // 
            this.cmbNoTitles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNoTitles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNoTitles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNoTitles.FormattingEnabled = true;
            this.cmbNoTitles.Items.AddRange(new object[] {
            "",
            "500",
            "1000",
            "1500",
            "2000",
            "2500",
            "3000",
            "3500",
            "4000",
            "4500",
            "5000"});
            this.cmbNoTitles.Location = new System.Drawing.Point(118, 106);
            this.cmbNoTitles.Name = "cmbNoTitles";
            this.cmbNoTitles.Size = new System.Drawing.Size(207, 25);
            this.cmbNoTitles.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(6, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 19);
            this.label4.TabIndex = 133;
            this.label4.Text = "No of Titles";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(639, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 19);
            this.label3.TabIndex = 132;
            this.label3.Text = "Vat Number";
            // 
            // txtNoToken
            // 
            this.txtNoToken.Enabled = false;
            this.txtNoToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoToken.Location = new System.Drawing.Point(341, 10);
            this.txtNoToken.MaxLength = 3;
            this.txtNoToken.Name = "txtNoToken";
            this.txtNoToken.Size = new System.Drawing.Size(40, 23);
            this.txtNoToken.TabIndex = 8;
            this.txtNoToken.Text = "1";
            this.txtNoToken.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(639, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 19);
            this.label6.TabIndex = 131;
            this.label6.Text = "E-mail";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(763, 45);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(208, 23);
            this.txtEmail.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(328, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 19);
            this.label2.TabIndex = 130;
            this.label2.Text = "Location";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(118, 45);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(208, 23);
            this.txtUserName.TabIndex = 0;
            // 
            // cmbClientName
            // 
            this.cmbClientName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClientName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClientName.FormattingEnabled = true;
            this.cmbClientName.Location = new System.Drawing.Point(416, 7);
            this.cmbClientName.Name = "cmbClientName";
            this.cmbClientName.Size = new System.Drawing.Size(215, 25);
            this.cmbClientName.TabIndex = 118;
            this.cmbClientName.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 19);
            this.label1.TabIndex = 129;
            this.label1.Text = "User Name";
            // 
            // pBar
            // 
            this.pBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(51)))), ((int)(((byte)(45)))));
            this.pBar.ForeColor = System.Drawing.Color.Yellow;
            this.pBar.Location = new System.Drawing.Point(774, 31);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(208, 23);
            this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBar.TabIndex = 137;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(51)))), ((int)(((byte)(45)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnUnload);
            this.panel2.Controls.Add(this.pBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 174);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(984, 56);
            this.panel2.TabIndex = 16;
            // 
            // btnRefersh
            // 
            this.btnRefersh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefersh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefersh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnRefersh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnRefersh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefersh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefersh.ForeColor = System.Drawing.Color.Yellow;
            this.btnRefersh.Location = new System.Drawing.Point(489, 30);
            this.btnRefersh.Name = "btnRefersh";
            this.btnRefersh.Size = new System.Drawing.Size(95, 38);
            this.btnRefersh.TabIndex = 15;
            this.btnRefersh.Text = "Refersh";
            this.btnRefersh.UseVisualStyleBackColor = false;
            this.btnRefersh.Click += new System.EventHandler(this.btnRefersh_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Yellow;
            this.btnSave.Location = new System.Drawing.Point(250, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 38);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(51)))), ((int)(((byte)(45)))));
            this.groupBox1.Controls.Add(this.cmbSearchPlayerType);
            this.groupBox1.Controls.Add(this.txtSearchUserName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cmbSearchClientName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 230);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 58);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // cmbSearchPlayerType
            // 
            this.cmbSearchPlayerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchPlayerType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSearchPlayerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchPlayerType.FormattingEnabled = true;
            this.cmbSearchPlayerType.Items.AddRange(new object[] {
            "",
            "Desktop",
            "Android",
            "Apple"});
            this.cmbSearchPlayerType.Location = new System.Drawing.Point(743, 23);
            this.cmbSearchPlayerType.Name = "cmbSearchPlayerType";
            this.cmbSearchPlayerType.Size = new System.Drawing.Size(223, 25);
            this.cmbSearchPlayerType.TabIndex = 117;
            this.cmbSearchPlayerType.SelectedIndexChanged += new System.EventHandler(this.cmbSearchPlayerType_SelectedIndexChanged);
            // 
            // txtSearchUserName
            // 
            this.txtSearchUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchUserName.Location = new System.Drawing.Point(418, 24);
            this.txtSearchUserName.Name = "txtSearchUserName";
            this.txtSearchUserName.Size = new System.Drawing.Size(205, 23);
            this.txtSearchUserName.TabIndex = 114;
            this.txtSearchUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchUserName_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(6, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 19);
            this.label7.TabIndex = 113;
            this.label7.Text = "Client Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(641, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 19);
            this.label10.TabIndex = 116;
            this.label10.Text = "Player Type";
            // 
            // cmbSearchClientName
            // 
            this.cmbSearchClientName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchClientName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSearchClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchClientName.FormattingEnabled = true;
            this.cmbSearchClientName.Location = new System.Drawing.Point(108, 22);
            this.cmbSearchClientName.Name = "cmbSearchClientName";
            this.cmbSearchClientName.Size = new System.Drawing.Size(203, 25);
            this.cmbSearchClientName.TabIndex = 112;
            this.cmbSearchClientName.SelectedIndexChanged += new System.EventHandler(this.cmbSearchClientName_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(320, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 19);
            this.label8.TabIndex = 115;
            this.label8.Text = "User Name";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnRefersh);
            this.panel3.Controls.Add(this.dgTokenGeneration);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 288);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(984, 274);
            this.panel3.TabIndex = 18;
            // 
            // dgTokenGeneration
            // 
            this.dgTokenGeneration.AllowUserToAddRows = false;
            this.dgTokenGeneration.AllowUserToDeleteRows = false;
            this.dgTokenGeneration.AllowUserToResizeColumns = false;
            this.dgTokenGeneration.AllowUserToResizeRows = false;
            this.dgTokenGeneration.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(51)))), ((int)(((byte)(45)))));
            this.dgTokenGeneration.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTokenGeneration.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgTokenGeneration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTokenGeneration.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgTokenGeneration.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgTokenGeneration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTokenGeneration.GridColor = System.Drawing.Color.Gainsboro;
            this.dgTokenGeneration.Location = new System.Drawing.Point(0, 0);
            this.dgTokenGeneration.Name = "dgTokenGeneration";
            this.dgTokenGeneration.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTokenGeneration.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgTokenGeneration.RowHeadersVisible = false;
            this.dgTokenGeneration.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTokenGeneration.Size = new System.Drawing.Size(980, 270);
            this.dgTokenGeneration.TabIndex = 2;
            this.dgTokenGeneration.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTokenGeneration_CellClick);
            // 
            // frmTokenDistributionAsian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MusicPlayerTokenDealer.Properties.Resources.BackgroundGraphics;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTokenDistributionAsian";
            this.Text = "Token Distribution Copyleft";
            this.Load += new System.EventHandler(this.frmTokenDistributionCopyleft_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTokenGeneration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUnload;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkSanjivani;
        private System.Windows.Forms.DateTimePicker dtpSanjivaniExpiryDate;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTVPassword;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTeamviewerId;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCityname;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.ComboBox cmbPlayerType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbNoTitles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNoToken;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.ComboBox cmbClientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRefersh;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbSearchPlayerType;
        private System.Windows.Forms.TextBox txtSearchUserName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbSearchClientName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgTokenGeneration;
        private System.Windows.Forms.Label lblAvailableToken;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtVatNumber;
    }
}