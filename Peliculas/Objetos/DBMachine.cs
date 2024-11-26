using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySqlConnector;

namespace Peliculas.Objetos
{
    public class DBMachine
    {
        private String Host = "localhost";
        private String User = "root";
        private String passwd = "";
        private String db = "cine_interficies";


        public MySqlCommand ConnectDB()
        {
            try
            {
                MySqlConnection c = new MySqlConnection("host=" + Host + ";user=" + User + ";password=" + passwd + ";database=" + db + ";");
                c.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = c;
                return cmd;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido establecer conexión con al base de datos", "Error de inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }

        }

        public void addUser(User user)
        {
            MySqlCommand cmd = ConnectDB();
            if (cmd != null)
            {
                cmd.CommandText = "INSERT INTO user (mail, passwd) VALUES (?mail, ?passwd);";

                cmd.Parameters.Add("?mail", MySqlDbType.VarChar).Value = user.mail;
                cmd.Parameters.Add("?passwd", MySqlDbType.VarChar).Value = user.passwd;

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public bool userExist(User user)
        {
            MySqlCommand cmd = ConnectDB();
            if (cmd != null)
            {
                cmd.CommandText = "SELECT * FROM user WHERE mail = ?mail;";

                cmd.Parameters.Add("?mail", MySqlDbType.VarChar).Value = user.mail;

                MySqlDataReader reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    cmd.Connection.Close();
                    return true;
                }
                cmd.Connection.Close();
                return false;
            }
            return false;

        }

        public bool checkUser(User user)
        {
            MySqlCommand cmd = ConnectDB();
            cmd.CommandText = "SELECT * FROM user WHERE mail = ?mail AND passwd = ?passwd;";

            cmd.Parameters.Add("?mail", MySqlDbType.VarChar).Value = user.mail;
            cmd.Parameters.Add("?passwd", MySqlDbType.VarChar).Value = user.passwd;

            MySqlDataReader reader = cmd.ExecuteReader();


            if (reader.HasRows)
            {
                cmd.Connection.Close();
                return true;
            }
            cmd.Connection.Close();
            return false;
        }

        public bool isAdmin(User user)
        {
            MySqlCommand cmd = ConnectDB();
            cmd.CommandText = "SELECT rol FROM user WHERE mail = ?mail";

            cmd.Parameters.Add("?mail", MySqlDbType.VarChar).Value = user.mail;

            MySqlDataReader reader = cmd.ExecuteReader();

            reader.Read();

            if (reader.GetString("rol") == "admin")
            {
                cmd.Connection.Close();
                user.admin = true;
                return true;
            }
            cmd.Connection.Close();
            user.admin = false;
            return false;
        }
        public List<Pelicula> take_Films()
        {
            List<Pelicula> films = new List<Pelicula>();
            MySqlCommand cmd = ConnectDB();
            cmd.CommandText = @"
            SELECT f.film_id, f.title, f.room, l.name AS language, f.start_date, f.end_date, f.hour, f.duration
            FROM film f
            JOIN language l ON f.language_id = l.language_id
            JOIN `film-genre` fg ON f.film_id = fg.film_id";

            MySqlDataReader reader = cmd.ExecuteReader();

            List<Pelicula> peliculasList = new List<Pelicula>();

            while (reader.Read())
            {
                int filmId = reader.GetInt32("film_id");
                MySqlCommand cmd2 = ConnectDB();
                cmd2.CommandText = "SELECT name FROM genre JOIN `film-genre` ON `film-genre`.genre_id = genre.genre_id JOIN film ON film.film_id = `film-genre`.film_id WHERE film.film_id = ?filmId;";
                cmd2.Parameters.Add("?filmid", MySqlDbType.Int32).Value = filmId;
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                List<String> generos = new List<String>();
                while (reader2.Read())
                {
                    generos.Add(reader2.GetString("name"));
                }
                reader2.Close();
                cmd2.Connection.Close();
                Pelicula pelicula = new Pelicula
                (
                    reader.GetString("title"),
                    reader.GetInt32("room"),
                    reader.GetString("language"),
                    reader.GetDateTime("start_date"),
                    reader.GetDateTime("end_date"),
                    reader.GetTimeSpan("hour"),
                    reader.GetInt32("duration"),
                    generos
                );
                peliculasList.Add(pelicula);


            }

            reader.Close();
            cmd.Connection.Close();

            return peliculasList;
        }
        public void insert_Films()
        {
            List<Pelicula> films = new List<Pelicula>();
            MySqlCommand cmd = ConnectDB();
            cmd.CommandText = @"
SELECT f.film_id, f.title, f.room, l.name AS language, f.start_date, f.end_date, f.hour, f.duration
FROM film f
JOIN language l ON f.language_id = l.language_id
JOIN `film-genre` fg ON f.film_id = fg.film_id";

            MySqlDataReader reader = cmd.ExecuteReader();

            List<Pelicula> peliculasList = new List<Pelicula>();

            while (reader.Read())
            {
                int filmId = reader.GetInt32("film_id");
                cmd.CommandText = @"SELECT name FROM genre JOIN `film-genre` ON `film-genre`.genre_id = genre.genre_id JOIN film ON film.film_id = `film-genre`.film_id WHERE film.film_id = " + filmId + ";";
                MySqlDataReader reader2 = cmd.ExecuteReader();
                List<String> generos = new List<String>();
                while (reader2.Read())
                {
                    generos.Add(reader2.GetString("name"));
                }
                Pelicula pelicula = new Pelicula
                (
                    reader.GetString("title"),
                    reader.GetInt32("room"),
                    reader.GetString("language"),
                    reader.GetDateTime("start_date"),
                    reader.GetDateTime("end_date"),
                    reader.GetTimeSpan("hour"),
                    reader.GetInt32("duration"),
                    generos
                );
                peliculasList.Add(pelicula);


            }

            reader.Close();
            cmd.Connection.Close();
        }
    }
}