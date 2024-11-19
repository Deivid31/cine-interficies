using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Peliculas.Objetos
{
    internal class DBMachine
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
            cmd.Connection.Close();
        }

        public bool userExist(String mail)
        {
            MySqlCommand cmd = ConnectDB();
            cmd.CommandText = "SELECT * FROM user WHERE mail = ?mail;";

            cmd.Parameters.Add("?mail", MySqlDbType.VarChar).Value = mail;

            MySqlDataReader reader = cmd.ExecuteReader();
            

            if (reader.HasRows)
            {
                cmd.Connection.Close();
                return true;
            }
            cmd.Connection.Close();
            return false;
        }

        public bool checkUser(String mail, String passwd)
        {
            MySqlCommand cmd = ConnectDB();
            cmd.CommandText = "SELECT * FROM user WHERE mail = ?mail AND passwd = ?passwd;";

            cmd.Parameters.Add("?mail", MySqlDbType.VarChar).Value = mail;
            cmd.Parameters.Add("?passwd", MySqlDbType.VarChar).Value = passwd;

            MySqlDataReader reader = cmd.ExecuteReader();


            if (reader.HasRows)
            {
                cmd.Connection.Close();
                return true;
            }
            cmd.Connection.Close();
            return false;
        }

        public bool isAdmin(String mail)
        {
            MySqlCommand cmd = ConnectDB();
            cmd.CommandText = "SELECT rol FROM user WHERE mail = ?mail";

            cmd.Parameters.Add("?mail", MySqlDbType.VarChar).Value = mail;
            cmd.Parameters.Add("?passwd", MySqlDbType.VarChar).Value = passwd;

            MySqlDataReader reader = cmd.ExecuteReader();

            reader.Read();

            if (reader.GetString("rol") == "admin")
            {
                cmd.Connection.Close();
                return true;
            }
            cmd.Connection.Close();
            return false;
        }
    }
}
