using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;
using System.IO; 
using System.Net;
using Microsoft.Win32;
namespace MusicPlayerCopyright
{
    
    public partial class userlogin : Form
    {
        gblClass ObjMainClass = new gblClass();
        string ExpiryCopyrightStatus = "";
        string ExpiryFitnessStatus = "";
        Int32 LeftCopyrightDays = 0;
        Int32 LeftFitnessDays = 0;
        Int32 LocalDealerDfClientId = 0;
        string IsMailSend = "";
        string strDealerCodeId = "EU4Y000";
        public userlogin()
        {
            InitializeComponent();
        }

       
        
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            IsMailSend = "No";
            lblWait.Visible = true;
            lblWait.Height = 220;
            Userlogin();
        }
        private void Userlogin()
        {
            string str = "";
            string str23 = "";
            DataSet dsDefaultUser = new DataSet();
            string strDealerCode = "";
            string DealerCo = "";
            if (txtUsername.Text == "" || txtTokenNo.Text == "")
            {
                lblWait.Visible = false;
                MessageBox.Show("Username/Token no cannot be blank");
                return;
            }

            DealerCo = txtDealerCode.Text.ToUpper();
            if (txtDealerCode.Text != "" && DealerCo != "EU4Y000")
            {
                strDealerCode = "select * from DFClients where DealerCode='" + txtDealerCode.Text + "'";
                DataSet dsDealer = new DataSet();
                dsDealer = ObjMainClass.fnFillDataSet(strDealerCode);
                if (dsDealer.Tables[0].Rows.Count <= 0)
                {
                    lblWait.Visible = false;
                    MessageBox.Show("Dealer Code is worng", "Eu4y Security");
                    txtDealerCode.Focus();
                    return;
                }
                else
                {
                    LocalDealerDfClientId = Convert.ToInt32(dsDealer.Tables[0].Rows[0]["dfClientID"]);
                    strDealerCodeId = dsDealer.Tables[0].Rows[0]["DealerCode"].ToString();
                }
            }
            str = "spGetTokenRights '" + txtUsername.Text + "', '" + txtTokenNo.Text + "' ";
            DataSet ds = new DataSet();
            ds = ObjMainClass.fnFillDataSet(str);
            if (ds.Tables[0].Rows.Count <= 0)
            {
                lblWait.Visible = false;
                MessageBox.Show("Username/Token no is worng","Eu4y Security");
                return;
            }
            else if (ds.Tables[0].Rows[0]["PlayerType"].ToString() != "Desktop")
            {
                lblWait.Visible = false;
                MessageBox.Show("Username/Token no is worng", "Eu4y Security");
                return;
            }
            else if (ds.Tables[0].Rows[0]["MusicType"].ToString() != "Copyright")
            {
                lblWait.Visible = false;
                MessageBox.Show("Username/Token no is worng", "Eu4y Security");
                return;
            }
            StaticClass.UserId = ds.Tables[0].Rows[0]["ClientID"].ToString();
            StaticClass.TotalTitles = ds.Tables[0].Rows[0]["NumberofTitles"].ToString();
            StaticClass.TokenId = ds.Tables[0].Rows[0]["tokenid"].ToString();





            //////// Checking Dealer Record ////////////////

            if (txtDealerCode.Text != "" && DealerCo != "EU4Y000")
            {
                if (LocalDealerDfClientId != Convert.ToInt32(StaticClass.UserId))
                {
                    str = "";
                    str = "select Userid from Users where clientid=" + StaticClass.UserId;
                    DataSet dsUserUpdate = new DataSet();
                    dsUserUpdate = ObjMainClass.fnFillDataSet(str);

                    str = "";
                    str = "update Users set clientid= " + LocalDealerDfClientId + " where userid=" + dsUserUpdate.Tables[0].Rows[0]["UserId"];
                    if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                    StaticClass.constr.Open();
                    SqlCommand cmdUsers = new SqlCommand();
                    cmdUsers.Connection = StaticClass.constr;
                    cmdUsers.CommandText = str;
                    cmdUsers.ExecuteNonQuery();
                    StaticClass.constr.Close();

                    str = "";
                    str = "Update AMPlayerTokens set Code='" + GenerateId.getKey(GenerateId._wvpaudi) + "'  , " +
                        "  DateTokenUsed=getdate()   , Token='used' ,DealerCode='" + strDealerCodeId + "' , ClientID=" + LocalDealerDfClientId + ", userid=" + dsUserUpdate.Tables[0].Rows[0]["UserId"] + " " +
                        " where TokenId=" + StaticClass.TokenId + "";
                    if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                    StaticClass.constr.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = StaticClass.constr;
                    cmd.CommandText = str;
                    cmd.ExecuteNonQuery();
                    StaticClass.constr.Close();
                    StaticClass.UserId = LocalDealerDfClientId.ToString();
                    AdminMail();
                }
                else
                {
                    //// Update AMPlayerTokens /////////////////////////
                    str = "";
                    str = "Update AMPlayerTokens set Code='" + GenerateId.getKey(GenerateId._wvpaudi) + "'  , " +
                        "  DateTokenUsed=getdate()   , Token='used' ,DealerCode='" + strDealerCodeId + "' " +
                        " where TokenId=" + StaticClass.TokenId + "";
                    if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                    StaticClass.constr.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = StaticClass.constr;
                    cmd.CommandText = str;
                    cmd.ExecuteNonQuery();
                    StaticClass.constr.Close();
                    IsMailSend = "Yes";
                     
                    /////////////////////////////////////////
                }
            }

            else
            {
                //// Update AMPlayerTokens /////////////////////////
                str = "";
                str = "Update AMPlayerTokens set Code='" + GenerateId.getKey(GenerateId._wvpaudi) + "'  , " +
                    "  DateTokenUsed=getdate()   , Token='used' ,DealerCode='" + strDealerCodeId + "' " +
                    " where TokenId=" + StaticClass.TokenId + "";
                if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                StaticClass.constr.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = StaticClass.constr;
                cmd.CommandText = str;
                cmd.ExecuteNonQuery();
                StaticClass.constr.Close();
                IsMailSend = "Yes";
                /////////////////////////////////////////
            }
            CreateFile(ds.Tables[0].Rows[0]["tokenid"].ToString());
            str23 = "select * from tbluser_client_rights where userid=" + StaticClass.UserId + " and isAdmin=1";
            dsDefaultUser = ObjMainClass.fnFillDataSet(str23);
            if (dsDefaultUser.Tables[0].Rows.Count <= 0)
            {
                SaveDefaultUser();
            }
            if (IsMailSend == "Yes")
            {
                GetClientRights();
                Clientlogin objClientlogin = new Clientlogin();
                objClientlogin.Show();
                this.Hide();
            }
        }

        private void AdminMail()
        {
            try
            {
                var fromAddress = "no-reply@eufory.org";
                var toAddress = "jan@eu4y.com";
                const string fromPassword = "12345";
                string subject = "New Client Register";
                string body = "Hello Admin, \n";
                body += "\n";
                body += "This is to you inform that dealer is registred new client on music player and credential are \n";
                body += "Dealer Code:" + strDealerCodeId + "\n";
                body += "Token Id:" + StaticClass.TokenId + "\n";
                body += "Music Type: Copyright \n";
                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "smtpout.secureserver.net";
                    smtp.Port = 80;
                    smtp.EnableSsl = false;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                    smtp.Timeout = 999999999;
                }
                smtp.Send(fromAddress, toAddress, subject, body);
                IsMailSend = "Yes";
            }
            catch (Exception ex)
            {
                AdminMail();
            }
        }
        private void GetClientRights()
        {
            string strOpt = "";
            string str = "";
            if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
            StaticClass.constr.Open();


            strOpt = "select ISNULL(IsCopyright,0) as Copyright, ISNULL(IsFitness,0) as Fitness, isnull(IsStream,0) as Stream from AMPlayerTokens where TokenID=" + StaticClass.TokenId;
            DataSet dsOption = new DataSet();
            dsOption = ObjMainClass.fnFillDataSet(strOpt);

            str = "spGetTokenExpiryStatus_Copyright " + Convert.ToInt32(StaticClass.TokenId) + ", " + dsOption.Tables[0].Rows[0]["Copyright"] + ", " + dsOption.Tables[0].Rows[0]["Fitness"] + ", " + dsOption.Tables[0].Rows[0]["Stream"];
            DataSet dsExpire = new DataSet();
            dsExpire = ObjMainClass.fnFillDataSet(str);


            ExpiryCopyrightStatus = dsExpire.Tables[0].Rows[0]["ExpiryCopyrightStatus"].ToString();
            LeftCopyrightDays = Convert.ToInt32(dsExpire.Tables[0].Rows[0]["LeftCopyrightDays"]);

            ExpiryFitnessStatus = dsExpire.Tables[0].Rows[0]["ExpiryFitnessStatus"].ToString();
            LeftFitnessDays = Convert.ToInt32(dsExpire.Tables[0].Rows[0]["LeftFitnessDays"]);

            StaticClass.StreamExpiryMessage = dsExpire.Tables[0].Rows[0]["ExpiryStreamStatus"].ToString();
            StaticClass.LeftStreamtDays = Convert.ToInt32(dsExpire.Tables[0].Rows[0]["LeftStreamDays"]);

            if (ExpiryCopyrightStatus == "NoLic" && ExpiryFitnessStatus == "NoLic")
            {
                MessageBox.Show("!! Purchase the subscription of music player  !!", "Eu4y Music Player");
                Application.Exit();
                return;
            }
            if (ExpiryCopyrightStatus == "Yes" && ExpiryFitnessStatus == "Yes")
            {
                MessageBox.Show("!! Music Player is Expired.Please connect your vendor !!", "Eu4y Music Player");
                Application.Exit();
                return;
            }

            if (ExpiryCopyrightStatus != "NoLic" && LeftCopyrightDays <= 10)
            {
                StaticClass.PlayerExpiryMessage = Convert.ToString(LeftCopyrightDays) + " days left to renewal of Copyright subscription";
                StaticClass.IsCopyright = true;
            }
            else if (ExpiryCopyrightStatus != "NoLic" && LeftCopyrightDays == 0)
            {
                StaticClass.PlayerExpiryMessage = "Last day to renewal of Copyright subscription";
                StaticClass.IsCopyright = true;
            }
            else
            {
                StaticClass.IsCopyright = true;
            }
            if (ExpiryCopyrightStatus == "Yes" && ExpiryFitnessStatus == "NoLic")
            {
                MessageBox.Show("!! Subscription is Expired.Please connect your vendor !!", "Eu4y Music Player");
                Application.Exit();
                return;
            }
            else if (ExpiryCopyrightStatus == "Yes" && ExpiryFitnessStatus == "No")
            {
                StaticClass.PlayerExpiryMessage = "Subscription is Expired.Please connect your vendor";
                StaticClass.IsCopyright = false;
            }
            else if (ExpiryCopyrightStatus == "NoLic" && ExpiryFitnessStatus == "No")
            {
                StaticClass.PlayerExpiryMessage = "You do not have license";
                StaticClass.IsCopyright = false;
            }


            if (ExpiryFitnessStatus != "NoLic" && LeftFitnessDays <= 10)
            {

                StaticClass.FitnessExpiryMessage = Convert.ToString(LeftFitnessDays) + " days left to renewal of Fitness subscription";
                StaticClass.IsFitness = true;
            }
            else if (ExpiryFitnessStatus != "NoLic" && LeftFitnessDays == 0)
            {
                StaticClass.FitnessExpiryMessage = "Last day to renewal of Fitness subscription";
                StaticClass.IsFitness = true;
            }
            else
            {
                StaticClass.IsFitness = true;
            }

            if (ExpiryFitnessStatus == "Yes" && ExpiryCopyrightStatus == "NoLic")
            {
                MessageBox.Show("!! Subscription is Expired.Please connect your vendor !!", "Eu4y Music Player");
                Application.Exit();
                return;
            }
            else if (ExpiryFitnessStatus == "Yes" && ExpiryCopyrightStatus == "No")
            {
                StaticClass.FitnessExpiryMessage = "Subscription is Expired.Please connect your vendor";
                StaticClass.IsFitness = false;
            }
            else if (ExpiryFitnessStatus == "NoLic" && ExpiryCopyrightStatus == "No")
            {
                StaticClass.FitnessExpiryMessage = "You do not have license";
                StaticClass.IsFitness = false;
            }

        }
        private void SaveDefaultUser()
        {
            try
            {
                if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                StaticClass.constr.Open();
                SqlCommand cmd = new SqlCommand("Insert_User_Client_Rights", StaticClass.constr);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@UserID", SqlDbType.BigInt));
                cmd.Parameters["@UserID"].Value = Convert.ToInt32(StaticClass.UserId);

                cmd.Parameters.Add(new SqlParameter("@clientname", SqlDbType.NVarChar));
                cmd.Parameters["@clientname"].Value = "admin";

                cmd.Parameters.Add(new SqlParameter("@clientPassword", SqlDbType.NVarChar));
                cmd.Parameters["@clientPassword"].Value = "admin";
                cmd.Parameters.Add(new SqlParameter("@isRemove", SqlDbType.Int));
                cmd.Parameters["@isRemove"].Value = 1;
                cmd.Parameters.Add(new SqlParameter("@isDownload", SqlDbType.Int));
                cmd.Parameters["@isDownload"].Value = 1;
                cmd.Parameters.Add(new SqlParameter("@isAdmin", SqlDbType.Int));
                cmd.Parameters["@isAdmin"].Value = 1;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
        private void userlogin_Load(object sender, EventArgs e)
        {
            
            
        }

        private void CreateFile(string TokenId)
        {
            string fileName = Application.StartupPath + "\\tid.amp";

            try
            {
                // Check if file already exists. If yes, delete it. 
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file 
                using (FileStream fs = File.Create(fileName))
                {
                    // Add some text to file
                    Byte[] title = new UTF8Encoding(true).GetBytes(TokenId);
                    fs.Write(title, 0, title.Length);
                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }  
        }

        private void btnExtra_Click(object sender, EventArgs e)
        {

        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string DownloadfileName = "db.mdb";
            string LogicalPath = Application.StartupPath;
            string localPath = LogicalPath + "\\";
            string file_song_path = LogicalPath + "\\" + DownloadfileName;
            FtpWebRequest requestFileDownload = (FtpWebRequest)WebRequest.Create("ftp://85.195.82.94:21/MusicPlayerSetup/Copyright/" + DownloadfileName);
            requestFileDownload.Credentials = new NetworkCredential("harish", "Mohali123");
            // requestFileDownload.KeepAlive = true;
            requestFileDownload.UsePassive = false;
            // requestFileDownload.UseBinary = true;
            requestFileDownload.Method = WebRequestMethods.Ftp.DownloadFile;
            FtpWebResponse responseFileDownload = (FtpWebResponse)requestFileDownload.GetResponse();
            Stream responseStream = responseFileDownload.GetResponseStream();
            FileStream writeStream = new FileStream(localPath + DownloadfileName, FileMode.Create);
            int Length = 2048;
            Byte[] buffer = new Byte[Length];
            int bytesRead = responseStream.Read(buffer, 0, Length);
            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = responseStream.Read(buffer, 0, Length);
            }
            responseStream.Close();
            writeStream.Close();
            requestFileDownload = null;
            responseFileDownload = null;
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GC.Collect();
            lblWait.Visible = false;
        }
        
    } 
    
}


