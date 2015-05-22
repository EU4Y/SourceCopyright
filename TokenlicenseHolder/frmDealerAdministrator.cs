using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Threading;
using System.Net;
using System.Net.Mail;
namespace MusicPlayerTokenDealer
{
    public partial class frmDealerAdministrator : Form
    {
        Thread t2;
         string LoginName ="";
         string LoginPassword = "";
         string DealerEmail = "";
        public frmDealerAdministrator()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show("Are you sure to exit ?", "Token Dealer", buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmDealerAdministrator_Load(object sender, EventArgs e)
        {
            lblLicence.Text = StaticClass.TotalLeftDays;
        }
       
        public Boolean nameOfControlVisible2
        {
            get { return this.panMainBackground.Visible; }
            set
            {
                this.panMainBackground.Visible = value;
                EnableCloseButton();
            }
        }
        public void DisableCloseButton()
        {
            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);
        }
        public void EnableCloseButton()
        {
            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_ENABLED);
        }
        #region Globals

        internal const int SC_CLOSE = 0xF060;           //close button's code in windows api
        internal const int MF_GRAYED = 0x1;             //disabled button status (enabled = false)
        internal const int MF_ENABLED = 0x00000000;     //enabled button status
        internal const int MF_DISABLED = 0x00000002;    //disabled button status

        [DllImport("user32.dll")] //Importing user32.dll for calling required function
        private static extern IntPtr GetSystemMenu(IntPtr HWNDValue, bool Revert);

        /// HWND: An IntPtr typed handler of the related form
        /// It is used from the Win API "user32.dll"

        [DllImport("user32.dll")] //Importing user32.dll for calling required function again
        private static extern int EnableMenuItem(IntPtr tMenu, int targetItem, int targetStatus);

        #endregion     

        private void btnTokenDistribution_Click(object sender, EventArgs e)
        {
            lblOpenType.Text = "Token";
            panTokenOption.Visible = true;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (cmbMusicType.Text == "")
            {
                MessageBox.Show("Please select a music type", "Tokan Administrator");
                cmbMusicType.Focus();
                return;
            }

            if (cmbMusicType.Text == "Copyright")
            {
                if (lblOpenType.Text == "Token")
                {
                    frmTokenDistributionCopyright frm = new frmTokenDistributionCopyright(this);
                    frm.MdiParent = this;
                    frm.Show();
                    frm.Dock = DockStyle.Fill;
                }
                else
                {
                    frmCopyrightTokenSettings frm = new frmCopyrightTokenSettings(this);
                    frm.MdiParent = this;
                    frm.Show();
                    frm.Dock = DockStyle.Fill;
                }
            }
            else if (cmbMusicType.Text == "AsianDirectLicense")
            {
                if (lblOpenType.Text == "Token")
                {
                    frmTokenDistributionAsian frm = new frmTokenDistributionAsian(this);
                    frm.MdiParent = this;
                    frm.Show();
                    frm.Dock = DockStyle.Fill;
                }
                else
                {
                    frmCopyleftTokenSettingsAsian frm = new frmCopyleftTokenSettingsAsian(this);
                    frm.MdiParent = this;
                    frm.Show();
                    frm.Dock = DockStyle.Fill;
                }

            }
            else if (cmbMusicType.Text == "Dam")
            {
                if (lblOpenType.Text == "Token")
                {
                    frmTokenDistributionCopyleft frm = new frmTokenDistributionCopyleft(this);
                    frm.MdiParent = this;
                    frm.Show();
                    frm.Dock = DockStyle.Fill;
                }
                else
                {
                    frmCopyleftTokenSettings frm = new frmCopyleftTokenSettings(this);
                    frm.MdiParent = this;
                    frm.Show();
                    frm.Dock = DockStyle.Fill;
                }
            }

            DisableCloseButton();
            panMainBackground.Visible = false;
            panTokenOption.Visible = false;
        }

        private void btnUnload_Click(object sender, EventArgs e)
        {
            panTokenOption.Visible = false;
        }

        private void btnTokenSetting_Click(object sender, EventArgs e)
        {
            panChangePassword.Visible = false;
            panTokenRequest.Visible = false;
            lblOpenType.Text = "Setting";
            panTokenOption.Visible = true;
        }

        private void btnCancelPassword_Click(object sender, EventArgs e)
        {
            txtConfirmPassword.Text = "";
            txtNewPassword.Text = "";
            panChangePassword.Visible = false;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            panTokenOption.Visible = false;
            panTokenRequest.Visible = false;
            panChangePassword.Visible = true;
            txtNewPassword.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text == "")
            {
                MessageBox.Show("New password cannot be blank","Token Dealer");
                txtNewPassword.Focus();
                return;
            }
            else if (txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Confirm password cannot be blank", "Token Dealer");
                txtConfirmPassword.Focus();
                return;
            }
            else if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                MessageBox.Show("Password not match", "Token Dealer");
                txtNewPassword.Focus();
                txtNewPassword.Text = "";
                txtConfirmPassword.Text = "";
                return;
            }
            try
            {
                if (gblClass.PasswordIsValid(txtNewPassword.Text) == false)
                {
                    MessageBox.Show("Password must be 8-10 characters long with at least one numeric,one upper case character and one special character", "Token Dealer");
                    return;
                }
                if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                StaticClass.constr.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = StaticClass.constr;
                cmd.CommandText = "update tbDealerLogin set LoginPassword='" + txtNewPassword.Text + "' where dfclientid=" + StaticClass.DfClient_Id ;
                cmd.ExecuteNonQuery();
                LoginPassword = txtNewPassword.Text;
                DealerEmail = Properties.Settings.Default.RememberMeUsername;
                StaticClass.constr.Close();
                panChangePassword.Visible = false;
                SendMailAdmin();
            }
            catch
            {

            }
            
        }
        private void SendMailAdmin()
        {
            t2 = new Thread(AdminMail);
            t2.IsBackground = true;
            t2.Start();
        }
        private void AdminMail()
        {
            try
            {
                var fromAddress = "noreply@eufory.org";
                var toAddress = "jan@eu4y.com";
                const string fromPassword = "12345";
                string subject = "Dealer Password Change";
                string body = "Hello Admin, \n";
               
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
                SendMailAdmin();
            }
        }

        private void btnTokenRequest_Click(object sender, EventArgs e)
        {
            txtTotalToken.Text = "";
            panTokenOption.Visible = false;
            panChangePassword.Visible = false;
            panTokenRequest.Visible = true;
            txtTotalToken.Focus();
        }

        private void btnSendCancel_Click(object sender, EventArgs e)
        {
            txtTotalToken.Text = "";
            panTokenRequest.Visible = false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtTotalToken.Text == "")
            {
                MessageBox.Show("Total token cannot be blank","Token Dealer");
                txtTotalToken.Focus();
                return;
            }

        }
    }
}
