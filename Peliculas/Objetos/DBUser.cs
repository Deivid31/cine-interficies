using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Peliculas.Objetos
{
    internal class DBUser
    {
        private String Host = "localhost";
        private String User = "root";
        private String passwd = "";
        private String db = "cine_interficies";


        private MySqlCommand ConnectDB()
        {
            MySqlConnection c = new MySqlConnection("host=" + Host + ";user=" + User + ";password=" + passwd + ";database=" + db + ";");
            c.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = c;
            return cmd;
        }

        public void addUser(String mail, String passwd)
        {
            MySqlCommand cmd = ConnectDB();
            cmd.CommandText = "INSERT INTO user (mail, passwd) VALUES (?mail, ?passwd);";

            cmd.Parameters.Add("?mail", MySqlDbType.VarChar).Value = mail;
            cmd.Parameters.Add("?passwd", MySqlDbType.VarChar).Value = passwd;

            cmd.ExecuteNonQuery();
        }
    }
}
