using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalLayer
{
    public class Dall
    {
        public SqlConnection conn;
        public Dall()
        {
            conn = new SqlConnection("Data Source=mssql.fhict.local;Initial Catalog=dbi403879;Persist Security Info=True;User ID=dbi403879;Password=BigFish;");
        }
    }
}
