using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Utility
{
    public static class SQLHelper
    {
        protected static string TMSConnectionString = "Data Source=DESKTOP-TFBH7SV;Initial Catalog=TaskManagement;Integrated Security=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(TMSConnectionString);
        }
    }
}
