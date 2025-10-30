using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Winform_KLCN
{
    internal class KetNoi
    {
        //hcbxcbh
        //akdjshdczcj
        public static SqlConnection TaoKetNoi()
        {
            string conString = ConfigurationManager
                .ConnectionStrings["Winform_KLCN.Properties.Settings.QL_TUQ_NEWConnectionString"]
                .ConnectionString;
            return new SqlConnection(conString);
        }
    }
}
