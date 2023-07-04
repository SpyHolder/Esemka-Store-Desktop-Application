using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EsemkaStore2
{
    internal class connection
    {
        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection("Data Source=FY-AIR;Initial Catalog=EsemkaStore;Integrated Security=True");
            return con;
        }
    }
}
