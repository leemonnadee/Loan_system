using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_system
{
    internal class connection
    {

        public static string ipconnection = "datasource=localhost;username=root;password=;database=loan_db;pooling=false;";

        //public static string ipconnection = "DataSource=localhost;Connection Timeout=30;username=root;password=;database=loan_db; Min Pool Size=20; Max Pool Size=200; Incr Pool Size=10; Decr Pool Size=5;";
        //MySqlConnection conn = new MySqlConnection(ipconnection);
      
//File.Open(str1, FileMode.Open, FileAccess.Read, FileShare.None);



    }
}
