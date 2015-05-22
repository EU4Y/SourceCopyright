using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace MusicPlayerCopyright
{
    public static class StaticClass
    {
        public static string Is_Admin = "";
        public static string UserId = "";
        public static string TokenId = "";
        public static string TotalTitles = "";
        public static string LocalUserId = "";
        public static string isRemove = "";
        public static string isDownload = "";
        public static SqlConnection constr;
        public static OleDbConnection LocalCon= new OleDbConnection();
        public static string PlayerExpiryMessage = "";
        public static string FitnessExpiryMessage = "";
        public static Boolean IsCopyright = false;
        public static Boolean IsFitness = false;
        public static string MainwindowMessage = "";
        public static Boolean IsStream = false;
        public static string StreamExpiryMessage = "";
        public static Int32 LeftStreamtDays = 0;
    }
    //user name=IN- Paras Technologies
    //token no=FOHM-FRML-EFLD-EEGS-AYXD
}
