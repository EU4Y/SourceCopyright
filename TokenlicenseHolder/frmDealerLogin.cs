using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Data.SqlClient;
namespace MusicPlayerTokenDealer
{
    public partial class frmDealerLogin : Form
    {
        gblClass ObjMainClass = new gblClass();

        Int32 User_id = 0;
        Int32 OnlineUserId = 0;
        Int32 MainClientId = 0;
        Int32 OldMainClientId = 0;
        public frmDealerLogin()
        {
            InitializeComponent();
            CheckIfRememberedUser();
        }

        private void frmDealerLogin_Load(object sender, EventArgs e)
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
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //if (ObjMainClass.CheckForInternetConnection() == false)
            //{
            //    MessageBox.Show("Check your internet connection and try again", "Token Dealer");
            //    return;
            //}
            if (SubmitValidation() == true)
            {
                CheckPlayerUpdateVersion();
                DealerLogin();
            }
        }
        private void DealerLogin()
        {
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

            frmDealerAdministrator objMainWindow = new frmDealerAdministrator();
            objMainWindow.Show();
            this.Hide();
        }
        public Boolean SubmitValidation()
        {
            string str = "";
            try
            {
                DataSet dsExpire = new DataSet();
                str = "select * from tbDealerLogin where LoginName='" + txtloginUserName.Text + "' and Loginpassword='" + txtLoginPassword.Text + "'";
                DataSet ds = new DataSet();
                ds = ObjMainClass.fnFillDataSet(str);

                str = "spGetDealershipExpiryStatus '" + txtloginUserName.Text + "', '" + txtLoginPassword.Text + "'";
                dsExpire = ObjMainClass.fnFillDataSet(str);

                if (txtloginUserName.Text == "")
                {
                    MessageBox.Show("Login user name cannot be blank", "Token Dealer");
                    txtloginUserName.Focus();
                    return false;
                }
                else if (txtLoginPassword.Text == "")
                {
                    MessageBox.Show("Login password cannot be blank", "Token Dealer");
                    txtLoginPassword.Focus();
                    return false;
                }
                else if (ds.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show("Login user/password is wrong", "Token Dealer");
                    txtloginUserName.Text = "";
                    txtLoginPassword.Text = "";
                    txtloginUserName.Focus();
                    return false;
                }
                else if (dsExpire.Tables[0].Rows[0]["ExpiryStatus"].ToString() == "Yes")
                {
                    MessageBox.Show("Your dealership is expire", "Token Dealer");
                    txtloginUserName.Focus();
                    return false;
                }
                if (Convert.ToInt32(dsExpire.Tables[0].Rows[0]["LeftDays"]) <= 10)
                {
                    StaticClass.TotalLeftDays = Convert.ToString(dsExpire.Tables[0].Rows[0]["LeftDays"]) + " days left for renewal of dealership";
                }
                StaticClass.DfClient_Id = Convert.ToInt32(ds.Tables[0].Rows[0]["DfClientId"]);
                StaticClass.DealerCode = ds.Tables[0].Rows[0]["DealerCode"].ToString();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }
         
    }
}
