using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace MusicPlayerTokenDealer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //StaticClass.constr = new SqlConnection("Data Source=85.195.82.94;database=Eufory;uid=sa;password=phoh7Aiheeki");
           StaticClass.constr = new SqlConnection("Data Source=85.195.82.94;database=EU4YPlayerDB;uid=sa;password=phoh7Aiheeki");

            StaticClass.constrOnline = new SqlConnection("Data Source=184.168.194.68;database=Eu4yadmin;uid=chandan;password=chandan@123");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDealerLogin());
        }
    }
}
