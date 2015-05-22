using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Data.OleDb;
namespace MusicPlayerCopyright
{
    public partial class Clientlogin : Form
    {
        gblClass ObjMainClass = new gblClass();
        string mAction;
        string SubmitValidate;
        Int32 client_Rights_Id;
        public Clientlogin()
        {
            InitializeComponent();
            CheckIfRememberedUser();
        }
        private void InitilizeGrid()
        {
            if (dgClientUserDetail.Rows.Count > 0)
            {
                dgClientUserDetail.Rows.Clear();
            }
            if (dgClientUserDetail.Columns.Count > 0)
            {
                dgClientUserDetail.Columns.Clear();
            }

            dgClientUserDetail.Columns.Add("clientRightsId", "clientRightsId");
            dgClientUserDetail.Columns["clientRightsId"].Width = 0;
            dgClientUserDetail.Columns["clientRightsId"].Visible = false;
            dgClientUserDetail.Columns["clientRightsId"].ReadOnly = true;

            dgClientUserDetail.Columns.Add("UserName", "User Name");
            dgClientUserDetail.Columns["UserName"].Width = 150;
            dgClientUserDetail.Columns["UserName"].Visible = true;
            dgClientUserDetail.Columns["UserName"].ReadOnly = true;

            DataGridViewLinkColumn btnEdit = new DataGridViewLinkColumn();
            btnEdit.HeaderText = "Edit";
            btnEdit.Text = "Edit";
            btnEdit.DataPropertyName = "Edit";
            dgClientUserDetail.Columns.Add(btnEdit);
            btnEdit.UseColumnTextForLinkValue = true;
            btnEdit.Width = 70;

            DataGridViewLinkColumn btnRemove = new DataGridViewLinkColumn();
            btnRemove.HeaderText = "Remove";
            btnRemove.Text = "Remove";
            btnRemove.DataPropertyName = "Remove";
            dgClientUserDetail.Columns.Add(btnRemove);
            btnRemove.UseColumnTextForLinkValue = true;
            btnRemove.Width = 70;
        }


        private void picDisplay_Click(object sender, EventArgs e)
        {
            string str = "";
            str = "select * from tbluser_client_rights where userid= " + StaticClass.UserId;
            DataSet ds = new DataSet();
            ds = ObjMainClass.fnFillDataSet(str);
            if (ds.Tables[0].Rows.Count == 0)
            {
                panUserDetail.Visible = true;
                picDisplay.Visible = false;
                chkRemember.Visible = false;
                Clear_Controls();
                return;
            }

            if (txtloginUserName.Text == "")
            {
                MessageBox.Show("Login user name cannot be blank","Eu4y Music Player");
                return;
            }
            if (txtLoginPassword.Text == "")
            {
                MessageBox.Show("Login password cannot be blank", "Eu4y Music Player");
                return;
            }
                str = "select * from tbluser_client_rights where userid=" + StaticClass.UserId + " and isAdmin=1 and clientname='"+ txtloginUserName.Text +"' and Clientpassword = '" + txtLoginPassword.Text + "'";
                ds = ObjMainClass.fnFillDataSet(str);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show("You are not a administrator", "Eu4y Music Player");
                    return;
                }
            panUserDetail.Visible = true;
            picDisplay.Visible = false;
            chkRemember.Visible = false;
            Clear_Controls();
            PopulateInputFileTypeDetail();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUserCancel_Click(object sender, EventArgs e)
        {
            chkRemember.Visible = true;
            panUserDetail.Visible = false;
            picDisplay.Visible = true;
            txtUserName.Text = "";
            txtUserPassword.Text = "";
        }

       private void User_Client_Save()
        {
            string str = "";
            if (chkAdmin.Checked == true)
            {
                str = "select * from tbluser_client_rights where userid=" + StaticClass.UserId + " and isAdmin=1";
                DataSet ds = new DataSet();
                ds = ObjMainClass.fnFillDataSet(str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Admin user already exixts", "Eu4y Music Player");
                    return;
                }
            }
            if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
            StaticClass.constr.Open();
            SqlCommand cmd = new SqlCommand("Insert_User_Client_Rights", StaticClass.constr);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@UserID", SqlDbType.BigInt));
            cmd.Parameters["@UserID"].Value = Convert.ToInt32(StaticClass.UserId);

            cmd.Parameters.Add(new SqlParameter("@clientname", SqlDbType.NVarChar));
            cmd.Parameters["@clientname"].Value = txtUserName.Text;

            cmd.Parameters.Add(new SqlParameter("@clientPassword", SqlDbType.NVarChar));
            cmd.Parameters["@clientPassword"].Value = txtUserPassword.Text;

           if (chkRemoveSong.Checked == true)
           {
               cmd.Parameters.Add(new SqlParameter("@isRemove", SqlDbType.Int));
               cmd.Parameters["@isRemove"].Value = 1;
           }
           else
           {
               cmd.Parameters.Add(new SqlParameter("@isRemove", SqlDbType.Int));
               cmd.Parameters["@isRemove"].Value = 0;

           }


           if (chkDownloadSong.Checked == true)
           {
               cmd.Parameters.Add(new SqlParameter("@isDownload", SqlDbType.Int));
               cmd.Parameters["@isDownload"].Value = 1;
           }
           else
           {
               cmd.Parameters.Add(new SqlParameter("@isDownload", SqlDbType.Int));
               cmd.Parameters["@isDownload"].Value = 0;

           }

           if (chkAdmin.Checked == true)
           {
               cmd.Parameters.Add(new SqlParameter("@isAdmin", SqlDbType.Int));
               cmd.Parameters["@isAdmin"].Value = 1;
           }
           else
           {
               cmd.Parameters.Add(new SqlParameter("@isAdmin", SqlDbType.Int));
               cmd.Parameters["@isAdmin"].Value = 0;

           }
           try
           {
                cmd.ExecuteNonQuery();
                PopulateInputFileTypeDetail();
           }
           catch (Exception ex)
           {
               //MessageBox.Show(ex.Message);
           }
           finally
           {
               StaticClass.constr.Close();
           }
       }

       private void User_Client_Update(Int32 ClientRightsId)
       {

           string str = "";
           if (chkAdmin.Checked==true)
           {
               str = "select * from tbluser_client_rights where userid=" + StaticClass.UserId + " and isAdmin=1 and ClientRightsId != " + ClientRightsId;
               DataSet ds = new DataSet();
               ds = ObjMainClass.fnFillDataSet(str);
               if (ds.Tables[0].Rows.Count > 0)
               {
                   MessageBox.Show("Admin user already exixts", "Eu4y Music Player");
                   return;
               }
           }
           StaticClass.constr.Open();
           SqlCommand cmd = new SqlCommand("Update_User_Client_Rights", StaticClass.constr);
           cmd.CommandType = CommandType.StoredProcedure;

           cmd.Parameters.Add(new SqlParameter("@clientRightsId", SqlDbType.BigInt));
           cmd.Parameters["@clientRightsId"].Value = ClientRightsId;

           cmd.Parameters.Add(new SqlParameter("@UserID", SqlDbType.BigInt));
           cmd.Parameters["@UserID"].Value = Convert.ToInt32(StaticClass.UserId);

           cmd.Parameters.Add(new SqlParameter("@clientname", SqlDbType.NVarChar));
           cmd.Parameters["@clientname"].Value = txtUserName.Text;

           cmd.Parameters.Add(new SqlParameter("@clientPassword", SqlDbType.NVarChar));
           cmd.Parameters["@clientPassword"].Value = txtUserPassword.Text;

           if (chkRemoveSong.Checked == true)
           {
               cmd.Parameters.Add(new SqlParameter("@isRemove", SqlDbType.Int));
               cmd.Parameters["@isRemove"].Value = 1;
           }
           else
           {
               cmd.Parameters.Add(new SqlParameter("@isRemove", SqlDbType.Int));
               cmd.Parameters["@isRemove"].Value = 0;

           }


           if (chkDownloadSong.Checked == true)
           {
               cmd.Parameters.Add(new SqlParameter("@isDownload", SqlDbType.Int));
               cmd.Parameters["@isDownload"].Value = 1;
           }
           else
           {
               cmd.Parameters.Add(new SqlParameter("@isDownload", SqlDbType.Int));
               cmd.Parameters["@isDownload"].Value = 0;

           }
           if (chkAdmin.Checked == true)
           {
               cmd.Parameters.Add(new SqlParameter("@isAdmin", SqlDbType.Int));
               cmd.Parameters["@isAdmin"].Value = 1;
           }
           else
           {
               cmd.Parameters.Add(new SqlParameter("@isAdmin", SqlDbType.Int));
               cmd.Parameters["@isAdmin"].Value = 0;

           }

           try
           {
               cmd.ExecuteNonQuery();
               PopulateInputFileTypeDetail();
           }
           catch (Exception ex)
           {
               //MessageBox.Show(ex.Message);
           }
           finally
           {
               StaticClass.constr.Close();
           }
       }

       private void Clientlogin_Load(object sender, EventArgs e)
       {
           string strOpt = "";
           strOpt = "select * from dfclients where dfclientid=" + StaticClass.UserId;
           DataSet dsOption = new DataSet();
           dsOption = ObjMainClass.fnFillDataSet(strOpt);
           StaticClass.MainwindowMessage = dsOption.Tables[0].Rows[0]["ClientName"].ToString() + " (Eufory Music Player)";
           this.Text = StaticClass.MainwindowMessage;
           EncrpetSongs();
           PopulateInputFileTypeDetail();
           DeleteOgg();
           UpdateLocalDatabase();
       }
       private void UpdateLocalDatabase()
       {
           string strInsert = "CREATE TABLE tbTitleRating([TokenId] number NULL, 	[TitleId] number NULL, 	[TitleRating] int NULL )";
           if (TableExists("tbTitleRating") == false)
           {
               if (StaticClass.LocalCon.State == ConnectionState.Open) { StaticClass.LocalCon.Close(); }
               StaticClass.LocalCon.Open();
               OleDbCommand cmdTitle = new OleDbCommand();
               cmdTitle.Connection = StaticClass.LocalCon;
               cmdTitle.CommandText = strInsert;
               cmdTitle.ExecuteNonQuery();
               StaticClass.LocalCon.Close();
               return;
           }
       }
       public static bool TableExists(string table)
       {
           if (StaticClass.LocalCon.State == ConnectionState.Open) { StaticClass.LocalCon.Close(); }
           StaticClass.LocalCon.Open();
           return StaticClass.LocalCon.GetSchema("Tables", new string[4] { null, null, table, "TABLE" }).Rows.Count > 0;
       }
       private void EncrpetSongs()
       {
           string d = Application.StartupPath;
           foreach (string f in Directory.GetFiles(d, "*.ogg"))
           {
               clsSongCrypt.encrfile(new Uri(f, UriKind.Relative));
               
           }
       }
       private void DeleteOgg()
       {
           string d = Application.StartupPath;
           try
           {
               foreach (string f in Directory.GetFiles(d, "*.ogg"))
               {

                   File.Delete(f);
               }
           }
           catch(Exception ex)
           {
           }
       }
       private void User_Client_Delete(Int32 ClientRightsId)
       {
           StaticClass.constr.Open();
           SqlCommand cmd = new SqlCommand();
           cmd.Connection = StaticClass.constr;
           cmd.CommandText = "delete from tbluser_client_rights where clientRightsId=" + Convert.ToInt32(ClientRightsId) + " and userId =" + Convert.ToInt32(StaticClass.UserId);
           cmd.ExecuteNonQuery();
           StaticClass.constr.Close();
           PopulateInputFileTypeDetail();
       }

       private void PopulateInputFileTypeDetail()
       {
           string mlsSql;
           int iCtr;
           mAction = "New";
           client_Rights_Id = 0;
           SubmitValidate = "";
           Clear_Controls();
           DataTable dtDetail;
           mlsSql = "SELECT  clientRightsId, clientname FROM tbluser_client_rights where userId=" + Convert.ToInt32(StaticClass.UserId);
           dtDetail = ObjMainClass.fnFillDataTable(mlsSql);
           InitilizeGrid();
           if ((dtDetail.Rows.Count > 0))
           {
               for (iCtr = 0; (iCtr <= (dtDetail.Rows.Count - 1)); iCtr++)
               {
                   dgClientUserDetail.Rows.Add();
                   dgClientUserDetail.Rows[dgClientUserDetail.Rows.Count - 1].Cells[0].Value = dtDetail.Rows[iCtr]["clientRightsId"];
                   dgClientUserDetail.Rows[dgClientUserDetail.Rows.Count - 1].Cells[1].Value = dtDetail.Rows[iCtr]["clientname"];
               }
           }
       }

       private void btnUserSave_Click(object sender, EventArgs e)
       {
           string tempUsername = "";
           string str = "";
           str = "select * from tbluser_client_rights where userid=" + StaticClass.UserId;
           DataSet ds = new DataSet();
           ds = ObjMainClass.fnFillDataSet(str);
           for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
           {
               if (ds.Tables[0].Rows[i]["clientname"].ToString() == txtUserName.Text & ds.Tables[0].Rows[i]["clientpassword"].ToString() == txtUserPassword.Text)
               {
                   tempUsername = "Stop";
               }
           }
           
           if (txtUserName.Text == "")
           {
               MessageBox.Show("User name cannot be blank", "Eu4y Music Player");
               return;
           }
           else if (txtUserPassword.Text == "")
           {
               MessageBox.Show("Password cannot be blank", "Eu4y Music Player");
               return;
           }
           else if (tempUsername == "Stop")
           {
               MessageBox.Show("User/password already exixts", "Eu4y Music Player");
               return;
           }
            if (mAction == "New")
            {
                User_Client_Save();
            }
            else if (mAction == "Modify")
            {
                User_Client_Update(client_Rights_Id);
            }
       }
       private void Clear_Controls()
       {
           txtUserName.Text = "";
           txtUserPassword.Text = "";
           chkAdmin.Checked = false;
           chkDownloadSong.Checked = false;
           chkRemoveSong.Checked = false;
           chkAdmin.Enabled = true;
           chkDownloadSong.Enabled = true;
           chkRemoveSong.Enabled = true;

       }

       private void SubmitValidation()
       {
           string str = "";
           str = "select * from tbluser_client_rights where userid=" + StaticClass.UserId + " and clientname='" + txtloginUserName.Text + "' and clientpassword='" + txtLoginPassword.Text + "'";
           DataSet ds = new DataSet();
           ds = ObjMainClass.fnFillDataSet(str);
           if (txtloginUserName.Text == "")
           {
               MessageBox.Show("Login user name cannot be blank", "Eu4y Music Player");
               SubmitValidate = "False";
           }
           else if (txtLoginPassword.Text == "")
           {
               MessageBox.Show("Login password cannot be blank", "Eu4y Music Player");
               SubmitValidate = "False";
           }
           else if (ds.Tables[0].Rows.Count <= 0)
           {
               MessageBox.Show("Login user/password is wrong", "Eu4y Music Player");
               SubmitValidate = "False";
           }
           else if (ds.Tables[0].Rows.Count > 0)
           {
               StaticClass.LocalUserId = ds.Tables[0].Rows[0]["clientRightsId"].ToString();
               StaticClass.Is_Admin = ds.Tables[0].Rows[0]["isAdmin"].ToString();
               StaticClass.isRemove = ds.Tables[0].Rows[0]["isRemove"].ToString();
               StaticClass.isDownload = ds.Tables[0].Rows[0]["isDownload"].ToString();
               SubmitValidate = "True";
           }
       }

       private void btnLogin_Click(object sender, EventArgs e)
       {
           string strOpt = "";
           CheckPlayerUpdateVersion();
           SubmitValidation();
           if (SubmitValidate == "True")
           {
               strOpt = "select * from dfclients where dfclientid=" + StaticClass.UserId;
               DataSet dsOption = new DataSet();
               dsOption = ObjMainClass.fnFillDataSet(strOpt);
               StaticClass.MainwindowMessage = dsOption.Tables[0].Rows[0]["ClientName"].ToString() + " (" + dsOption.Tables[0].Rows[0]["email"].ToString() + ")";

                if (chkRemember.Checked== true)
                {
                    Properties.Settings.Default.RememberMeUsername = txtloginUserName.Text;
                    Properties.Settings.Default.RememberMePassword = txtLoginPassword.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {                    
                    Properties.Settings.Default.RememberMeUsername = "";
                    Properties.Settings.Default.RememberMePassword = "";
                    Properties.Settings.Default.Save(); 
                }
                
                
                    //string proc = Process.GetCurrentProcess().ProcessName;
                    //Process[] processes = Process.GetProcessesByName(proc);
                    //if (processes.Length > 1)
                    //{
                    //    Process.GetCurrentProcess().Kill();
                    //} 

                    //VersionApplicationPath = Application.StartupPath + "\\MusicPlayer.exe";
                    //System.Diagnostics.Process.Start(VersionApplicationPath);
                

               mainwindow objMainWindow = new mainwindow();
               objMainWindow.Show();
               this.Hide();
           }
       }

       private void UserDelete(Int32 ClientId)
       {
           string str = "";
           str = "select * from tbluser_client_rights where userid=" + StaticClass.UserId + " and clientRightsId=" + Convert.ToInt32(ClientId);
           DataSet ds = new DataSet();
           ds = ObjMainClass.fnFillDataSet(str);
           if (ds.Tables[0].Rows[0]["isAdmin"].ToString() == "1")
           {
               MessageBox.Show("You cannot delete admin user", "Eu4y Music Player");
           }
           else
           {
               StaticClass.constr.Open();
               SqlCommand cmd = new SqlCommand();
               cmd.Connection = StaticClass.constr;
               cmd.CommandText = "delete from tbluser_client_rights where clientRightsId=" + Convert.ToInt32(ClientId);
               cmd.ExecuteNonQuery();
               StaticClass.constr.Close();
               PopulateInputFileTypeDetail();
           }
       }

       private void dgClientUserDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
       {
           int rowindex = dgClientUserDetail.CurrentCell.RowIndex;
           int columnindex = dgClientUserDetail.CurrentCell.ColumnIndex;
           
           if (columnindex == 2)
           {        
               ShowRecord(Convert.ToInt32(dgClientUserDetail.Rows[rowindex].Cells[0].Value));
           }

           if (columnindex == 3)
           {
               UserDelete(Convert.ToInt32(dgClientUserDetail.Rows[rowindex].Cells[0].Value));
           }
       }
       private void ShowRecord(Int32 ClientId)
       {
           string str = "";
           str = "select * from tbluser_client_rights where userid=" + StaticClass.UserId + " and clientRightsId=" + Convert.ToInt32(ClientId);
           DataSet ds = new DataSet();
           ds = ObjMainClass.fnFillDataSet(str);
           if (ds.Tables[0].Rows.Count > 0) 
           {
               client_Rights_Id = Convert.ToInt32(ds.Tables[0].Rows[0]["clientRightsId"].ToString());
               mAction = "Modify";
               txtUserName.Text = ds.Tables[0].Rows[0]["clientname"].ToString();
               txtUserPassword.Text = ds.Tables[0].Rows[0]["clientPassword"].ToString();
               if (ds.Tables[0].Rows[0]["isAdmin"].ToString() == "1")
               {
                   chkAdmin.Checked = true;
                   chkAdmin.Enabled = false;
                   chkDownloadSong.Enabled = false;
                   chkRemoveSong.Enabled = false;
               }
               else
               {
                   chkAdmin.Checked = false;
                   chkAdmin.Enabled = true;
                   chkDownloadSong.Enabled = true;
                   chkRemoveSong.Enabled = true;
               }
               if (ds.Tables[0].Rows[0]["isRemove"].ToString() == "1")
               {
                   chkRemoveSong.Checked = true;
               }
               else
               {
                   chkRemoveSong.Checked=false;
               }
               if (ds.Tables[0].Rows[0]["isDownload"].ToString() == "1")
               {
                   chkDownloadSong.Checked = true;
               }
               else
               {
                   chkDownloadSong.Checked = false;
               }

           }

       }

   


       private void Clientlogin_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.Enter)
           {
               SendKeys.Send("{TAB}");
           }
       }

       private void Clientlogin_FormClosed(object sender, FormClosedEventArgs e)
       {
           //Application.Exit();
       }

       private void txtLoginPassword_KeyDown(object sender, KeyEventArgs e)
       {
           string strOpt = "";
           string VersionApplicationPath = "";
           if (e.KeyCode == Keys.Enter)
           {
               SubmitValidation();
               if (SubmitValidate == "True")
               {
                   strOpt = "select * from dfclients where dfclientid=" + StaticClass.UserId;
                   DataSet dsOption = new DataSet();
                   dsOption = ObjMainClass.fnFillDataSet(strOpt);
                   StaticClass.MainwindowMessage = dsOption.Tables[0].Rows[0]["ClientName"].ToString() + " (" + dsOption.Tables[0].Rows[0]["email"].ToString() + ")";

                   if (chkRemember.Checked == true)
                   {
                       Properties.Settings.Default.RememberMeUsername = txtloginUserName.Text;
                       Properties.Settings.Default.RememberMePassword = txtLoginPassword.Text;
                       Properties.Settings.Default.Save();
                   }
                   else
                   {
                       Properties.Settings.Default.RememberMeUsername = "";
                       Properties.Settings.Default.RememberMePassword = "";
                       Properties.Settings.Default.Save();
                   }
                   CheckPlayerUpdateVersion();
                        
                   mainwindow objMainWindow = new mainwindow();
                   objMainWindow.Show();
                   this.Hide();
               }
           }

       }
       private void CheckPlayerUpdateVersion()
       {
           string strOldVersion = "";
           string FileLocation = "";
           string strUpdateVersion = "";
           string VersionApplicationPath = "";
           DateTime VersionAvailbleDate;
           DateTime CurrentDate= DateTime.Now.Date;
           Int32 OldVersion = 0;
           Int32 UpdateVersion = 0;
           DataTable dtOldVersion = new DataTable();
           DataTable dtUpdateVersion = new DataTable();
           MessageBoxButtons buttons = MessageBoxButtons.YesNo;
           DialogResult result;
           strOldVersion = "select isnull(IsUpdated,0) as PlayerVersion from AMPlayerTokens where tokenid =" + StaticClass.TokenId;
           dtOldVersion = ObjMainClass.fnFillDataTable(strOldVersion);

           strUpdateVersion = "select * from tbPlayerUpdateVersion where UpdateId in(select MAX(UpdateId) from tbPlayerUpdateVersion where musictype='Copyright') and musictype='Copyright'";
           dtUpdateVersion = ObjMainClass.fnFillDataTable(strUpdateVersion);
           if (dtUpdateVersion.Rows.Count > 0)
           {
               OldVersion = Convert.ToInt32(dtOldVersion.Rows[0]["PlayerVersion"]);
               UpdateVersion = Convert.ToInt32(dtUpdateVersion.Rows[0]["UpdateId"]);
               VersionAvailbleDate = Convert.ToDateTime(dtUpdateVersion.Rows[0]["AviableDate"]);
               FileLocation = dtUpdateVersion.Rows[0]["FileLocation"].ToString();

               //if (VersionAvailbleDate > CurrentDate) return ;
               if (OldVersion < UpdateVersion)
               {

                   VersionApplicationPath = Application.StartupPath + "\\UpdateMusicPlayerCopyright.exe";
                   result = MessageBox.Show("New version of player is availble" + Environment.NewLine + " !! You want to update ?", "Player Update", buttons);
                   if (result == System.Windows.Forms.DialogResult.Yes)
                   {
                       
                       //if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                       //StaticClass.constr.Open();
                       //SqlCommand cmd = new SqlCommand();
                       //cmd.Connection = StaticClass.constr;
                       //cmd.CommandText = "update AMPlayerTokens set IsUpdated = " + UpdateVersion + " where tokenid=" + StaticClass.TokenId;
                       //cmd.ExecuteNonQuery();
                       //StaticClass.constr.Close();

                       #region Update

                       string localPath = Application.StartupPath + "\\UpdateMusicPlayerCopyright.exe";
                       string UpdateFileLocation = "ftp://85.195.82.94:21//MusicPlayerSetup/Copyright/UpdateMusicPlayerCopyright.exe";
                       try
                       {

                           FtpWebRequest requestFileDownload = (FtpWebRequest)WebRequest.Create(UpdateFileLocation);
                           requestFileDownload.Credentials = new NetworkCredential("harish", "Mohali123");
                           requestFileDownload.KeepAlive = true;
                           requestFileDownload.UseBinary = true;
                           requestFileDownload.UsePassive = false;
                           requestFileDownload.Method = WebRequestMethods.Ftp.DownloadFile;

                           FtpWebResponse responseFileDownload = (FtpWebResponse)requestFileDownload.GetResponse();

                           Stream responseStream = responseFileDownload.GetResponseStream();
                           FileStream writeStream = new FileStream(localPath, FileMode.Create);

                           int Length = 2048;
                           Byte[] buffer = new Byte[Length];
                           int bytesRead = responseStream.Read(buffer, 0, Length);

                           while (bytesRead > 0)
                           {
                               writeStream.Write(buffer, 0, bytesRead);
                               bytesRead = responseStream.Read(buffer, 0, Length);


                               // calculate the progress out of a base "100"

                               double dIndex = (double)(bytesRead);

                               double dTotal = (double)Length;

                               double dProgressPercentage = (dIndex / dTotal);

                               int iProgressPercentage = (int)(dProgressPercentage * 100);

                              

                           }
                           responseStream.Close();
                           writeStream.Close();

                           requestFileDownload = null;
                           responseFileDownload = null;
                       }
                       catch
                       {

                       }

                       #endregion




                       System.Diagnostics.Process.Start(VersionApplicationPath);

                       

                       
                      Process[] prs = Process.GetProcesses();
                      foreach (Process pr in prs)
                      {
                          if (pr.ProcessName == "MusicPlayer")
                              pr.Kill();
                      }
                   }
               }
           }
            
       }
       private void Clientlogin_Move(object sender, EventArgs e)
       {
          
       }
       private void CheckIfRememberedUser()
       {
           if (Properties.Settings.Default.RememberMeUsername != null && Properties.Settings.Default.RememberMeUsername != "")
           {
               txtloginUserName.Text = Properties.Settings.Default.RememberMeUsername;
               txtLoginPassword.Text = Properties.Settings.Default.RememberMePassword;
               chkRemember.Checked = true;
           }
       }

       private void Clientlogin_FormClosing(object sender, FormClosingEventArgs e)
       {
           //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
           //DialogResult result;
           //result = MessageBox.Show("Are you sure to exit ?", "Eu4y Music Player", buttons);
           //if (result == System.Windows.Forms.DialogResult.Yes)
           //{
               Application.Exit();
           //}
           //else
           //{
           //    e.Cancel = true;
           //}
       }

       private void btnExtra_Click(object sender, EventArgs e)
       {
           AdminMail();
       }

       private void AdminMail()
       {
           try
           {
               var fromAddress = "noreply@eufory.org";
               var toAddress = "talwindergur@gmail.com";
               const string fromPassword = "12345";
               string subject = "New Dealer Register";
               string body = "Hello Admin, \n";
               body = "\n";
               body += "This is to you inform that new dealer is registred on music player and credential are \n ";
               body += "Main Username:\n";
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
    }
}
