using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.Net;
using System.Net.Mail;

namespace MusicPlayerTokenDealer
{
    public partial class frmTokenDistributionCopyright : Form
    {
        gblClass objMainClass = new gblClass();
        Thread t2;
        Int32 User_id = 0;
        DataTable dtGetToken = new DataTable();
        DataTable dtUserToken = new DataTable();
        string MainClientEmail = "";
        string MainUserName = "";
        string UserEmail = "";
        string UserName = "";
        string LocationName = "";
        DateTime UserDateExpiry;
        string UserNoOfTitles = "";
        string UserPlayerType = "";
        string SaveMode = "New";
        Int32 ModifyUserId = 0;
        string sQrStr = "";
        Int32 LastTotalTokens = 0;
        Int32 PendingTokens = 0;
        public frmTokenDistributionCopyright()
        {
            InitializeComponent();
        }
        private frmDealerAdministrator mainForm = null;
         public frmTokenDistributionCopyright(Form callingForm)
        {
            mainForm = callingForm as frmDealerAdministrator;
            InitializeComponent();
        }  
        private void btnUnload_Click(object sender, EventArgs e)
        {
            if (t2 != null)
            {
                if (t2.IsAlive == true)
                {
                    MessageBox.Show("Work Is Process");
                    return;
                }
            }
            this.Hide();
            this.mainForm.nameOfControlVisible2 = true;
        }

        private void frmTokenDistributionCopyright_Load(object sender, EventArgs e)
        {
            try
            {
                InitilizeTokenGenerationGrid();
                FillClient();
                GetMainClientData();
                dtpCopyrightExpiry.Value = DateTime.Now.Date;
                
                sQrStr = "select distinct   Users.UserID,Users.UserName,Users.UserEmail,Users.NoofToken , ";
                sQrStr = sQrStr + " NumberofTitles, PlayerType from AMPlayerTokens ";
                sQrStr = sQrStr + " inner join Users on AMPlayerTokens.UserId= Users.UserID ";
                sQrStr = sQrStr + " where year(DateTokenDefined)=" + DateTime.Now.Year + "  and isnull(Users.MusicType,'') <>'Copyleft' and AMPlayerTokens.ClientId=" + StaticClass.DfClient_Id + " ";
                sQrStr = sQrStr + " and AMPlayerTokens.IsCopyright=1 order by Users.UserID desc  ";
                FillTokenGenerationData(sQrStr);
            }
            catch (Exception ex)
            {
            }
        }
        private void GetMainClientData()
        {
            string sQr = "";
            DataSet ds = new DataSet();
            sQr = "select count(*) as PendingToken , Email from AMPlayerTokens inner join DFClients on AMPlayerTokens.clientId= DFClients.dfclientid ";
            sQr = sQr + " where AMPlayerTokens.clientid=" + StaticClass.DfClient_Id + " and userid=0";
            sQr = sQr + " group by Email ";
            ds = objMainClass.fnFillDataSet(sQr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MainClientEmail = ds.Tables[0].Rows[0]["Email"].ToString();
                PendingTokens = Convert.ToInt32(ds.Tables[0].Rows[0]["PendingToken"]);
                lblAvailableToken.Text = PendingTokens.ToString() + " Token Available";
            }
            else
            {
                lblAvailableToken.Text = "All tokens are distribute";
                PendingTokens = 0;
            }
            sQr = "";
            sQr = "select * from DFClients where dfclientid=" + StaticClass.DfClient_Id + "";
            ds = objMainClass.fnFillDataSet(sQr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MainClientEmail = ds.Tables[0].Rows[0]["Email"].ToString();
            }
        }
        private void FillClient()
        {
            string str = "";
            str = "select DFClientID,ClientName from DFClients where CountryCode is not null and DFClientID= " + StaticClass.DfClient_Id + " order by DFClientID desc";
            objMainClass.fnFillComboBox(str, cmbSearchClientName, "DFClientID", "ClientName", "");
            objMainClass.fnFillComboBox(str, cmbClientName, "DFClientID", "ClientName", "");
            cmbClientName.SelectedValue = StaticClass.DfClient_Id;
        }

        private void InitilizeTokenGenerationGrid()
        {
            if (dgTokenGeneration.Rows.Count > 0)
            {
                dgTokenGeneration.Rows.Clear();
            }
            if (dgTokenGeneration.Columns.Count > 0)
            {
                dgTokenGeneration.Columns.Clear();
            }

            dgTokenGeneration.Columns.Add("UserId", "UserId");
            dgTokenGeneration.Columns["UserId"].Width = 0;
            dgTokenGeneration.Columns["UserId"].Visible = false;
            dgTokenGeneration.Columns["UserId"].ReadOnly = true;

            dgTokenGeneration.Columns.Add("Username", "User Name");
            dgTokenGeneration.Columns["Username"].Width = 200;
            dgTokenGeneration.Columns["Username"].Visible = true;
            dgTokenGeneration.Columns["Username"].ReadOnly = true;

            dgTokenGeneration.Columns.Add("email", "E-mail");
            dgTokenGeneration.Columns["email"].Width = 250;
            dgTokenGeneration.Columns["email"].Visible = true;
            dgTokenGeneration.Columns["email"].ReadOnly = true;

            dgTokenGeneration.Columns.Add("NoofToken", "No of token");
            dgTokenGeneration.Columns["NoofToken"].Width = 130;
            dgTokenGeneration.Columns["NoofToken"].Visible = true;
            dgTokenGeneration.Columns["NoofToken"].ReadOnly = true;

            dgTokenGeneration.Columns.Add("ExpiryDate", "Expiry Date");
            dgTokenGeneration.Columns["ExpiryDate"].Width = 100;
            dgTokenGeneration.Columns["ExpiryDate"].Visible = false;
            dgTokenGeneration.Columns["ExpiryDate"].ReadOnly = true;

            dgTokenGeneration.Columns.Add("PlayerType", "Player Type");
            dgTokenGeneration.Columns["PlayerType"].Width = 120;
            dgTokenGeneration.Columns["PlayerType"].Visible = true;
            dgTokenGeneration.Columns["PlayerType"].ReadOnly = true;

            


        }

        private void FillTokenGenerationData(string sQr)
        {
            DataTable dtDetail = new DataTable();
            InitilizeTokenGenerationGrid();



            dtDetail = objMainClass.fnFillDataTable(sQr);

            if (dtDetail.Rows.Count > 0)
            {
                for (int i = 0; i <= dtDetail.Rows.Count - 1; i++)
                {
                    dgTokenGeneration.Rows.Add();
                    dgTokenGeneration.Rows[dgTokenGeneration.Rows.Count - 1].Cells[0].Value = dtDetail.Rows[i]["UserID"];
                    dgTokenGeneration.Rows[dgTokenGeneration.Rows.Count - 1].Cells[1].Value = dtDetail.Rows[i]["UserName"];
                    dgTokenGeneration.Rows[dgTokenGeneration.Rows.Count - 1].Cells[2].Value = dtDetail.Rows[i]["UserEmail"];
                    dgTokenGeneration.Rows[dgTokenGeneration.Rows.Count - 1].Cells[3].Value = dtDetail.Rows[i]["NoofToken"];

                    //dgTokenGeneration.Rows[dgTokenGeneration.Rows.Count - 1].Cells[4].Value = string.Format("{0:dd/MMM/yyyy}", dtDetail.Rows[i]["DateTokenExpire"]);

                    dgTokenGeneration.Rows[dgTokenGeneration.Rows.Count - 1].Cells[4].Value = "";
                    dgTokenGeneration.Rows[dgTokenGeneration.Rows.Count - 1].Cells[5].Value = dtDetail.Rows[i]["PlayerType"];
                    dgTokenGeneration.Rows[dgTokenGeneration.Rows.Count - 1].Cells[6].Value = dtDetail.Rows[i]["NumberofTitles"];

                }
            }
            foreach (DataGridViewRow row in dgTokenGeneration.Rows)
            {
                row.Height = 30;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string str = "";
            if (objMainClass.CheckForInternetConnection() == false)
            {
                MessageBox.Show("Check your internet connection", "Token Dealer");
                return;
            }
            if (SubmitValidation() == false)
            {
                return;
            }

            MainUserName = cmbClientName.Text;
            UserEmail = txtEmail.Text;
            UserName = txtUserName.Text;
            UserDateExpiry = dtpCopyrightExpiry.Value;
            UserNoOfTitles = cmbNoTitles.Text;
            UserPlayerType = cmbPlayerType.Text;
            LocationName = txtLocation.Text;
            if (SaveMode == "New")
            {
                SaveTokenUser();
            }
            else
            {
                UpdateTokenUser();
            }
        }
        private void SaveTokenUser()
        {

            if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
            StaticClass.constr.Open();
            SqlCommand cmd = new SqlCommand("InsertDealerUsers", StaticClass.constr);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar));
            cmd.Parameters["@UserName"].Value = txtUserName.Text;

            cmd.Parameters.Add(new SqlParameter("@UserEmail", SqlDbType.VarChar));
            cmd.Parameters["@UserEmail"].Value = txtEmail.Text;

            cmd.Parameters.Add(new SqlParameter("@NoofToken", SqlDbType.BigInt));
            cmd.Parameters["@NoofToken"].Value = Convert.ToInt32(txtNoToken.Text);

            cmd.Parameters.Add(new SqlParameter("@PlayerType", SqlDbType.VarChar));
            cmd.Parameters["@PlayerType"].Value = cmbPlayerType.Text;

            cmd.Parameters.Add(new SqlParameter("@ClientID", SqlDbType.BigInt));
            cmd.Parameters["@ClientID"].Value = Convert.ToInt32(cmbClientName.SelectedValue);

            cmd.Parameters.Add(new SqlParameter("@Street", SqlDbType.VarChar));
            cmd.Parameters["@Street"].Value = txtStreet.Text;

            cmd.Parameters.Add(new SqlParameter("@Cityname", SqlDbType.VarChar));
            cmd.Parameters["@Cityname"].Value = txtCityname.Text;

            cmd.Parameters.Add(new SqlParameter("@TeamviewerId", SqlDbType.VarChar));
            cmd.Parameters["@TeamviewerId"].Value = txtTeamviewerId.Text;

            cmd.Parameters.Add(new SqlParameter("@TvPassword", SqlDbType.VarChar));
            cmd.Parameters["@TvPassword"].Value = txtTVPassword.Text;

            cmd.Parameters.Add(new SqlParameter("@MusicType", SqlDbType.VarChar));
            cmd.Parameters["@MusicType"].Value = "Copyright";
            cmd.Parameters.Add(new SqlParameter("@Location", SqlDbType.VarChar));
            cmd.Parameters["@Location"].Value = txtLocation.Text;

            cmd.Parameters.Add(new SqlParameter("@Vatnumber", SqlDbType.VarChar));
            cmd.Parameters["@Vatnumber"].Value = txtVatnumber.Text;

            try
            {
                User_id = Convert.ToInt32(cmd.ExecuteScalar());
                SaveTokenGeneration(User_id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                StaticClass.constr.Close();
            }
        }
        private void SaveTokenGeneration(Int32 Return_UserId)
        {
            int TotalToken = 0;
            string CurrentTokenNo = "";
            string str = "";
            DataTable dtGetTokenDetail = new DataTable();

            if (SaveMode == "New")
            {
                TotalToken = Convert.ToInt16(txtNoToken.Text);
            }
            else
            {
                TotalToken = Convert.ToInt16(txtNoToken.Text) - LastTotalTokens;
            }
            pBar.Maximum = TotalToken;
            str = "select top " + TotalToken + " * from AMPlayerTokens where clientid=" + StaticClass.DfClient_Id + " and userid=0";
            dtGetTokenDetail = objMainClass.fnFillDataTable(str);


            for (int i = 1; i <= TotalToken; i++)
            {

                if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                StaticClass.constr.Open();
                SqlCommand cmd = new SqlCommand("spDealer_AMTokensClient", StaticClass.constr);
                cmd.CommandType = CommandType.StoredProcedure;

                if (CurrentTokenNo == "")
                {
                    CurrentTokenNo = dtGetTokenDetail.Rows[i - 1]["TokenId"].ToString();
                }
                else
                {
                    CurrentTokenNo = CurrentTokenNo + "," + dtGetTokenDetail.Rows[i - 1]["TokenId"].ToString();
                }
                cmd.Parameters.Add(new SqlParameter("@Tokenid", SqlDbType.BigInt));
                cmd.Parameters["@Tokenid"].Value = Convert.ToInt32(dtGetTokenDetail.Rows[i - 1]["TokenId"]);

                cmd.Parameters.Add(new SqlParameter("@DFClientID", SqlDbType.BigInt));
                cmd.Parameters["@DFClientID"].Value = Convert.ToInt32(cmbClientName.SelectedValue);

                cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.BigInt));
                cmd.Parameters["@UserId"].Value = Return_UserId;

                cmd.Parameters.Add(new SqlParameter("@InNumberofTitles", SqlDbType.BigInt));
                cmd.Parameters["@InNumberofTitles"].Value = Convert.ToInt32(cmbNoTitles.Text);

                cmd.Parameters.Add(new SqlParameter("@InDateExp", SqlDbType.DateTime));
                cmd.Parameters["@InDateExp"].Value = dtpCopyrightExpiry.Value;
                cmd.Parameters.Add(new SqlParameter("@IsDam", SqlDbType.Int));
                cmd.Parameters["@IsDam"].Value = "0";

                cmd.Parameters.Add(new SqlParameter("@DamExpiryDate", SqlDbType.DateTime));
                cmd.Parameters["@DamExpiryDate"].Value = "01-01-1900";
                cmd.Parameters.Add(new SqlParameter("@IsSanjivani", SqlDbType.Int));
                cmd.Parameters["@IsSanjivani"].Value = "0";
                cmd.Parameters.Add(new SqlParameter("@SanjivaniExpiryDate", SqlDbType.DateTime));
                cmd.Parameters["@SanjivaniExpiryDate"].Value = "01-01-1900";
                cmd.Parameters.Add(new SqlParameter("@IsCopyRight", SqlDbType.Int));
                cmd.Parameters["@IsCopyRight"].Value = "1";
                pBar.Value = i;
                cmd.ExecuteNonQuery();
            }

            str = "select * from AMPlayerTokens where UserId=" + Return_UserId + " and tokenid in(" + CurrentTokenNo + ") and code is null";
            dtGetToken = objMainClass.fnFillDataTable(str);
            dtUserToken = objMainClass.fnFillDataTable(str);


           SendEmail();
           SendEmailMainClient();
            ClearFields();
        }
        private void UpdateTokenUser()
        {
            string str = "";
            if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
            StaticClass.constr.Open();
            SqlCommand cmd = new SqlCommand("UpdateDealerUsers", StaticClass.constr);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Userid", SqlDbType.BigInt));
            cmd.Parameters["@Userid"].Value = ModifyUserId;

            cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar));
            cmd.Parameters["@UserName"].Value = txtUserName.Text;

            cmd.Parameters.Add(new SqlParameter("@UserEmail", SqlDbType.VarChar));
            cmd.Parameters["@UserEmail"].Value = txtEmail.Text;

            cmd.Parameters.Add(new SqlParameter("@NoofToken", SqlDbType.BigInt));
            cmd.Parameters["@NoofToken"].Value = Convert.ToInt32(txtNoToken.Text);

            cmd.Parameters.Add(new SqlParameter("@PlayerType", SqlDbType.VarChar));
            cmd.Parameters["@PlayerType"].Value = cmbPlayerType.Text;

            cmd.Parameters.Add(new SqlParameter("@Street", SqlDbType.VarChar));
            cmd.Parameters["@Street"].Value = txtStreet.Text;

            cmd.Parameters.Add(new SqlParameter("@Cityname", SqlDbType.VarChar));
            cmd.Parameters["@Cityname"].Value = txtCityname.Text;

            cmd.Parameters.Add(new SqlParameter("@TeamviewerId", SqlDbType.VarChar));
            cmd.Parameters["@TeamviewerId"].Value = txtTeamviewerId.Text;

            cmd.Parameters.Add(new SqlParameter("@TvPassword", SqlDbType.VarChar));
            cmd.Parameters["@TvPassword"].Value = txtTVPassword.Text;

            cmd.Parameters.Add(new SqlParameter("@Location", SqlDbType.VarChar));
            cmd.Parameters["@Location"].Value = txtLocation.Text;

            cmd.Parameters.Add(new SqlParameter("@Vatnumber", SqlDbType.VarChar));
            cmd.Parameters["@Vatnumber"].Value = txtVatnumber.Text;

            try
            {
                cmd.ExecuteNonQuery();
                if (LastTotalTokens < Convert.ToInt32(txtNoToken.Text))
                {
                    SaveTokenGeneration(ModifyUserId);
                }
                else
                {
                    str = "select * from AMPlayerTokens where UserId=" + ModifyUserId + "  and code is null";
                    dtGetToken = objMainClass.fnFillDataTable(str);
                    dtUserToken = objMainClass.fnFillDataTable(str);
                    SendEmail();
                    SendEmailMainClient();
                    ClearFields();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                StaticClass.constr.Close();
            }
        }
        private void ClearFields()
        {
            string sQr = "";
            sQr = "select distinct   Users.UserID,Users.UserName,Users.UserEmail,Users.NoofToken , ";
            sQr = sQr + " NumberofTitles, PlayerType from AMPlayerTokens ";
            sQr = sQr + " inner join Users on AMPlayerTokens.UserId= Users.UserID ";
            sQr = sQr + " where year(DateTokenDefined)=" + DateTime.Now.Year + "  and isnull(Users.MusicType,'') <>'Copyleft' and AMPlayerTokens.clientid=" + StaticClass.DfClient_Id + " ";
            sQr = sQr + " and AMPlayerTokens.IsCopyright=1 order by Users.UserID desc  ";
            FillClient();
            dtpCopyrightExpiry.Value = DateTime.Now.Date;
            FillTokenGenerationData(sQr);
            txtUserName.Text = "";
            txtEmail.Text = "";
            txtNoToken.Text = "";
            cmbNoTitles.Text = "";
            cmbPlayerType.Text = "";
            txtLocation.Text = "";
            txtVatnumber.Text = "";
            cmbSearchPlayerType.Text = "";
            SaveMode = "New";
            ModifyUserId = 0;
            cmbClientName.Enabled = true;
            txtNoToken.Enabled = true;
            cmbNoTitles.Enabled = true;
            PendingTokens = 0;
            GetMainClientData();
            txtStreet.Text = "";
            txtCityname.Text = "";
            txtTeamviewerId.Text = "";
            txtTVPassword.Text = "";
            LastTotalTokens = 0;
            pBar.Value = 0;
            txtNoToken.Enabled = true;
        }
        private Boolean SubmitValidation()
        {
            Int32 intValue;
            string str = "";
            DataSet dsValidation = new DataSet();
            DataSet dsEmail = new DataSet();
            if (SaveMode == "New")
            {
                str = "select * from Users where UserName='" + txtUserName.Text + "' ";
                //str = str + " and UserEmail='" + txtEmail.Text + "' and Playertype='" + cmbPlayerType.Text + "'";
            }
            else
            {
                str = "select * from Users where UserName='" + txtUserName.Text + "'  and userId <>" + ModifyUserId;
                //                str = str + " and UserEmail='" + txtEmail.Text + "' and Playertype='" + cmbPlayerType.Text + "

            }
            dsValidation = objMainClass.fnFillDataSet(str);


            str = "";
            if (SaveMode == "New")
            {
                str = "select * from Users where UserEmail='" + txtEmail.Text + "'";
            }
            else
            {
                str = "select * from Users where UserEmail='" + txtEmail.Text + "' and userId <>" + ModifyUserId;
            }
            dsEmail = objMainClass.fnFillDataSet(str);
            if (Convert.ToInt32(cmbClientName.SelectedValue) == 0)
            {
                MessageBox.Show("Client name cannot be blank", "Token Dealer");
                cmbClientName.Focus();
                return false;
            }
            else if (txtUserName.Text == "")
            {
                MessageBox.Show("User name cannot be blank", "Token Dealer");
                txtUserName.Focus();
                return false;
            }
            //else if (gblClass.EmailIsValid(txtEmail.Text) == false)
            //{
            //    MessageBox.Show("Enter a valid e-mail address", "Token Dealer");
            //    txtEmail.Focus();
            //    return false;
            //}
            else if (Convert.ToInt32(txtNoToken.Text) > 100)
            {
                MessageBox.Show("Only one time 100 tokens are generated", "Token Dealer");
                txtNoToken.Focus();
                return false;
            }
            else if (LastTotalTokens > Convert.ToInt32(txtNoToken.Text))
            {
                MessageBox.Show("You are not add less than old tokens", "Token Dealer");
                txtNoToken.Focus();
                return false;
            }
            else if ((PendingTokens+LastTotalTokens) < Convert.ToInt32(txtNoToken.Text))
            {
                MessageBox.Show("You are not add more than available tokens", "Token Dealer");
                txtNoToken.Focus();
                return false;
            }
        //else if (dsEmail.Tables[0].Rows.Count > 0)
            //{
            //    MessageBox.Show("Email already exist for this player type", "Token Dealer");
            //    txtEmail.Focus();
            //    return false;
            //}
            else if (txtLocation.Text == "")
            {
                MessageBox.Show("Location cannot be blank", "Token Dealer");
                txtLocation.Focus();
                return false;
            }
            else if (cmbNoTitles.Text == "")
            {
                MessageBox.Show("Select no of titles", "Token Dealer");
                cmbNoTitles.Focus();
                return false;
            }
            else if (cmbPlayerType.Text == "")
            {
                MessageBox.Show("Select a player type", "Token Dealer");
                cmbPlayerType.Focus();
                return false;
            }
            else if (txtTeamviewerId.Text == "")
            {
                MessageBox.Show("Teamviewer Id cannot be blank", "Token Dealer");
                txtTeamviewerId.Focus();
                return false;
            }
            else if (txtTVPassword.Text == "")
            {
                MessageBox.Show("Teamviewer password cannot be blank", "Token Dealer");
                txtTVPassword.Focus();
                return false;
            }
            else if (txtVatnumber.Text == "")
            {
                MessageBox.Show("Vat number cannot be blank", "Token Dealer");
                txtVatnumber.Focus();
                return false;
            }
            //else if (dsValidation.Tables[0].Rows.Count > 0)
            //{
            //    MessageBox.Show("User name allready used", "Token Dealer");
            //    txtUserName.Focus();
            //    return false;
            //}
            if (LastTotalTokens < Convert.ToInt32(txtNoToken.Text))
            {
                if (chkCopyright.Checked == false)
                {
                    MessageBox.Show("Select atleast one subscription", "Token Dealer");
                    chkCopyright.Focus();
                    return false;
                }
            }
            if (SaveMode == "New")
            {
                if (chkCopyright.Checked == false)
                {
                    MessageBox.Show("Select atleast one subscription", "Token Dealer");
                    chkCopyright.Focus();
                    return false;
                }

            }
            if (Int32.TryParse(txtNoToken.Text, out intValue))
            {
            }
            else
            {
                MessageBox.Show("No's of token only in numeric", "Token Dealer");
                txtNoToken.Focus();
                return false;
            }
            return true;

        }

        private void btnRefersh_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void SendEmail()
        {
            t2 = new Thread(SendEmailUser);
            t2.IsBackground = true;
            t2.Start();
        }

        private void SendEmailUser()
        {
            try
            {
                var fromAddress = "noreply@eufory.org";
                var toAddress = UserEmail;
                const string fromPassword = "12345";
                string subject = "Regarding Tokens";
                string body = "Hello " + UserName + " \n";
                body += "\n";
                body += "This email contains the information required for you to install Eufory Music Player. \n";
                body += "Please follow the instructions carefully for the best result. \n";
                body += "The installation is required to be done in Chrome. \n";
                body += "1) Click on the link and follow the instructions: http://eufory.org/musicplayer/copyright/publish.htm \n";
                body += "2) Once the installation is started you will need to use Token and Clientname to complete the installation. \n";
                body += "Your installation user name: " + MainUserName + " \n";
                body += "Your dealer code: " + StaticClass.DealerCode + " \n";
                if (dtUserToken.Rows.Count > 0)
                {
                    for (int i = 0; i <= dtUserToken.Rows.Count - 1; i++)
                    {
                        body += "Your installation token no: " + dtUserToken.Rows[i]["Token"].ToString() + " \n";
                    }
                }

                body += "Your token no expiry date: " + UserDateExpiry + " \n";
                body += "Your song download limit: " + UserNoOfTitles + " \n";
                body += "Your player type: " + UserPlayerType + " \n";
                body += "3) After starting up the player there is a username (admin) and pasword (admin) to fill in and tick the box to remember. \n";
                body += "WARNING:  Install the player on the network what you normally use LAN or WIFI. \n";
                body += "Switching or changing your network interface will make you player inoperative until it is switched back to the initial settings. \n";
                body += "\n";
                body += "The Eufory Team";
                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "juniper.arvixe.com";
                    smtp.Port = 26;
                    smtp.EnableSsl = false;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                    smtp.Timeout = 999999999;
                }
                smtp.Send(fromAddress, toAddress, subject, body);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SendEmailMainClient()
        {
            t2 = new Thread(SendEmailMainClientData);
            t2.IsBackground = true;
            t2.Start();
        }

        private void SendEmailMainClientData()
        {
            try
            {
                var fromAddress = "noreply@eufory.org";
                var toAddress = MainClientEmail;
                const string fromPassword = "12345";
                string subject = "Regarding Tokens";
                string body = "Hello " + MainUserName + " \n";
                body += "\n";
                body += "This email contains the information required for you to install Eufory Music Player. \n";
                body += "Please follow the instructions carefully for the best result. \n";
                body += "The installation is required to be done in Chrome. \n";
                body += "1) Click on the link and follow the instructions: http://eufory.org/musicplayer/copyright/publish.htm \n";
                body += "2) Once the installation is started you will need to use Token and Clientname to complete the installation. \n";
                body += "Your installation user name: " + MainUserName + " \n";
                body += "Your dealer code: " + StaticClass.DealerCode + " \n";
                body += "Your installation location: " + LocationName + " \n";

                if (dtGetToken.Rows.Count > 0)
                {
                    for (int i = 0; i <= dtGetToken.Rows.Count - 1; i++)
                    {
                        body += "Your installation token no: " + dtGetToken.Rows[i]["Token"].ToString() + " \n";
                    }
                }

                body += "Your token no expiry date: " + UserDateExpiry + " \n";
                body += "Your song download limit: " + UserNoOfTitles + " \n";
                body += "Your player type: " + UserPlayerType + " \n";
                body += "3) After starting up the player there is a username (admin) and pasword (admin) to fill in and tick the box to remember. \n";
                body += "WARNING:  Install the player on the network what you normally use LAN or WIFI. \n";
                body += "Switching or changing your network interface will make you player inoperative until it is switched back to the initial settings. \n";
                body += "\n";
                body += "The Eufory Team";
                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "juniper.arvixe.com";
                    smtp.Port = 26;
                    smtp.EnableSsl = false;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                    smtp.Timeout = 999999999;
                }
                smtp.Send(fromAddress, toAddress, subject, body);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgTokenGeneration_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dtModify = new DataTable();
            DataTable dtExprie = new DataTable();
            string sQr = "";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == 7)
            {

                sQr = "select distinct AMPlayerTokens.ClientID,  Users.UserID,Users.UserName,Users.UserEmail,Users.NoofToken , ";
                sQr = sQr + " DateTokenExpire,NumberofTitles, PlayerType,Street, Cityname, TeamviewerId , TvPassword, Users.Location , Users.Vatnumber from AMPlayerTokens ";
                sQr = sQr + " inner join Users on AMPlayerTokens.UserId= Users.UserID ";
                sQr = sQr + " where Users.UserID=" + Convert.ToInt32(dgTokenGeneration.Rows[e.RowIndex].Cells[0].Value) + " ";
                dtModify = objMainClass.fnFillDataTable(sQr);
                if (dtModify.Rows.Count > 0)
                {
                    SaveMode = "Modify";
                    cmbClientName.SelectedValue = Convert.ToInt32(dtModify.Rows[0]["ClientID"]);
                    ModifyUserId = Convert.ToInt32(dtModify.Rows[0]["UserID"]);
                    txtUserName.Text = dtModify.Rows[0]["UserName"].ToString();
                    txtEmail.Text = dtModify.Rows[0]["UserEmail"].ToString();
                    cmbNoTitles.Text = dtModify.Rows[0]["NumberofTitles"].ToString();
                    txtLocation.Text = dtModify.Rows[0]["Location"].ToString();
                    txtVatnumber.Text = dtModify.Rows[0]["Vatnumber"].ToString();
                    //sQr = "select top 1 * from AMPlayerTokens where userid= " + ModifyUserId;
                    //dtExprie = objMainClass.fnFillDataTable(sQr);
                    //dtpExpiryDate.Value = Convert.ToDateTime(dtExprie.Rows[0]["DateTokenExpire"]);

                    txtNoToken.Text = dtModify.Rows[0]["NoofToken"].ToString();
                    LastTotalTokens = Convert.ToInt32(txtNoToken.Text);
                    cmbPlayerType.Text = dtModify.Rows[0]["PlayerType"].ToString();
                    txtStreet.Text = dtModify.Rows[0]["Street"].ToString();
                    txtCityname.Text = dtModify.Rows[0]["Cityname"].ToString();
                    txtTeamviewerId.Text = dtModify.Rows[0]["TeamviewerId"].ToString();
                    txtTVPassword.Text = dtModify.Rows[0]["TvPassword"].ToString();

                    cmbClientName.Enabled = false;
                    //txtNoToken.Enabled = false;
                    //cmbNoTitles.Enabled = false;
                    //chkCopyright.Enabled = false;
                    //chkFitness.Enabled = false;
                }
            }
            else if (e.ColumnIndex == 8)
            {
                result = MessageBox.Show("Are you sure to delete this user ?", "Token Dealer", buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                    StaticClass.constr.Open();
                    SqlCommand cmd = new SqlCommand("Delete_User", StaticClass.constr);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.BigInt));
                    cmd.Parameters["@UserId"].Value = Convert.ToInt32(dgTokenGeneration.Rows[e.RowIndex].Cells[0].Value);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        //                        SendDeleteEmail();
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        StaticClass.constr.Close();
                    }

                }
                else if (result == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }
        }

        private void SendDeleteEmail()
        {
            t2 = new Thread(GetData);
            t2.IsBackground = true;
            t2.Start();
        }

        private void GetData()
        {
            try
            {
                var fromAddress = "noreply@eufory.org";
                var toAddress = MainClientEmail;
                const string fromPassword = "12345";
                string subject = "!! Account Delete  !!";
                string body = "Hello " + MainUserName + "\n";
                body += "Your user account ( " + UserName + " ) is deleted by Eufory admin";
                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "juniper.arvixe.com";
                    smtp.Port = 26;
                    smtp.EnableSsl = false;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                    smtp.Timeout = 999999999;
                }
                smtp.Send(fromAddress, toAddress, subject, body);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbSearchClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sQr = "";
            if (Convert.ToInt32(cmbSearchClientName.SelectedValue) > 0)
            {
                txtSearchUserName.Text = "";
                cmbSearchPlayerType.Text = "";
                sQr = "select distinct   Users.UserID,Users.UserName,Users.UserEmail,Users.NoofToken , ";
                sQr = sQr + " NumberofTitles, PlayerType from AMPlayerTokens ";
                sQr = sQr + " inner join Users on AMPlayerTokens.UserId= Users.UserID ";
                sQr = sQr + " where AMPlayerTokens.clientId=" + Convert.ToInt32(cmbSearchClientName.SelectedValue) + "  and isnull(Users.MusicType,'') <>'Copyleft' ";
                sQr = sQr + " and AMPlayerTokens.IsCopyright=1  order by Users.UserID desc  ";
                FillTokenGenerationData(sQr);
            }
            else
            {
                FillTokenGenerationData(sQrStr);
            }
        }

        private void txtSearchUserName_KeyDown(object sender, KeyEventArgs e)
        {
            string sQr = "";
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSearchUserName.Text.Length <= 0)
                {
                    MessageBox.Show("Atleast enter one character for search", "Token Dealer");
                    return;
                }
                if (txtSearchUserName.Text.Length >= 1)
                {
                    cmbSearchClientName.Text = "";
                    cmbSearchPlayerType.Text = "";
                    sQr = "select distinct   Users.UserID,Users.UserName,Users.UserEmail,Users.NoofToken , ";
                    sQr = sQr + " NumberofTitles, PlayerType from AMPlayerTokens ";
                    sQr = sQr + " inner join Users on AMPlayerTokens.UserId= Users.UserID ";
                    sQr = sQr + " where Users.UserName like '%" + txtSearchUserName.Text + "%'  and isnull(Users.MusicType,'') <>'Copyleft' and AMPlayerTokens.clientId=" + StaticClass.DfClient_Id + "";
                    sQr = sQr + " and AMPlayerTokens.IsCopyright=1  order by Users.UserID desc  ";
                    FillTokenGenerationData(sQr);
                }
                else
                {
                    FillTokenGenerationData(sQrStr);
                }


            }
        }

        private void cmbSearchPlayerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sQr = "";
            if (cmbSearchPlayerType.Text != "")
            {
                cmbSearchClientName.Text = "";
                txtSearchUserName.Text = "";
                sQr = "select distinct   Users.UserID,Users.UserName,Users.UserEmail,Users.NoofToken , ";
                sQr = sQr + " NumberofTitles, PlayerType from AMPlayerTokens ";
                sQr = sQr + " inner join Users on AMPlayerTokens.UserId= Users.UserID ";
                sQr = sQr + " where PlayerType='" + cmbSearchPlayerType.Text + "'  and isnull(Users.MusicType,'') <>'Copyleft' and AMPlayerTokens.clientId=" + StaticClass.DfClient_Id + "";
                sQr = sQr + " and AMPlayerTokens.IsCopyright=1  order by Users.UserID desc  ";
                FillTokenGenerationData(sQr);
            }
            else
            {
                FillTokenGenerationData(sQrStr);
            }
        }

        private void chkCopyright_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCopyright.Checked == true)
            {
                dtpCopyrightExpiry.Enabled = true;
            }
            else
            {
                dtpCopyrightExpiry.Enabled = false;
            }
        }


        private void cmbClientName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
