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
    public class DBMachine
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
        public List<Pelicula> take_Films()
        {
            List<Pelicula> films = new List<Pelicula>();
            MySqlCommand cmd = ConnectDB();
            cmd.CommandText = @"
        SELECT f.film_id, f.title, f.room, l.name AS language, f.start_date, f.end_date, f.hour, f.duration, g.name AS genre 
        FROM film f
        JOIN language l ON f.language_id = l.language_id
        JOIN `film-genre` fg ON f.film_id = fg.film_id
        JOIN genre g ON fg.genre_id = g.genre_id";

            MySqlDataReader reader = cmd.ExecuteReader();

            Dictionary<int, Pelicula> peliculasDict = new Dictionary<int, Pelicula>();

            while (reader.Read())
            {
                int filmId = reader.GetInt32("film_id");

                if (!peliculasDict.ContainsKey(filmId))
                {
                    Pelicula pelicula = new Pelicula
                    (
                        reader.GetString("title"),
                        reader.GetInt32("room"),
                        reader.GetString("language"),
                        reader.GetDateTime("start_date"),
                        reader.GetDateTime("end_date"),
                        reader.GetTimeSpan("hour"),
                        reader.GetInt32("duration"),
                        new List<string>()
                    );
                    peliculasDict[filmId] = pelicula;
                }

                peliculasDict[filmId].Generos.Add(reader.GetString("genre"));
            }

            reader.Close();
            cmd.Connection.Close();

            return peliculasDict.Values.ToList();
        }
        
    }
}
