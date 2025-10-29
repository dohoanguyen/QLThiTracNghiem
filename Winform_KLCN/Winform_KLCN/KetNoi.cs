using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform_KLCN
{
    internal class KetNoi
    {
        public static string con = @"Data Source=.;Initial Catalog=QL_TUQ_NEW;Persist Security Info=True;User ID=sa;Password=123;TrustServerCertificate=True;";
        //hcbxcbh
        //akdjshdczcj
        public static SqlConnection TaoKetNoi()
        {
            return new SqlConnection(con);
        }
    }
}
