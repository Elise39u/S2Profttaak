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
        public MySqlConnection conn;
        public Dall()
        {
            conn = new MySqlConnection("server=studmysql01.fhict.local;Uid=dbi419727;Database=dbi419727;pwd=Testing;");
        }
    }
}
