using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading;

namespace MusicPlayerTokenDealer
{
    public static class StaticClass
    {
        public static SqlConnection constr;
        public static SqlConnection constrOnline;
        public static SqlConnection constemp;
        public static Thread tGetOnline;
        public static string TotalLeftDays = "";
        public static Int32 DfClient_Id = 0;
        public static string ClientName = "";
        public static string DealerCode = "";
    }
}
