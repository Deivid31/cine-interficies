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

        public MySqlConnection ConnectionDB()
        {
            try
            {
                string connectionString = $"host={Host};user={User};password={passwd};database={db};";
                MySqlConnection connection = new MySqlConnection(connectionString);
                return connection; // Devuelve la conexión
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido establecer conexión con la base de datos", "Error de inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
        }
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
        public void insert_Films(string title, int room, int language, DateTime startdate, DateTime enddate, TimeSpan hour, int duration, List<string> genres)
        {
            using (var connection = ConnectionDB())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insertar la película
                        var cmd = connection.CreateCommand();
                        cmd.Transaction = transaction;
                        cmd.CommandText = @"INSERT INTO film (title, room, language_id, start_date, end_date, hour, duration) 
                                    VALUES (@title, @room, @language_id, @start_date, @end_date, @hour, @duration)";
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@room", room);
                        cmd.Parameters.AddWithValue("@language_id", language);
                        cmd.Parameters.AddWithValue("@start_date", startdate);
                        cmd.Parameters.AddWithValue("@end_date", enddate);
                        cmd.Parameters.AddWithValue("@hour", hour);
                        cmd.Parameters.AddWithValue("@duration", duration);
                        cmd.ExecuteNonQuery();

                        // Obtener el ID de la película
                        var cmd2 = connection.CreateCommand();
                        cmd2.Transaction = transaction;
                        cmd2.CommandText = @"SELECT film_id FROM film WHERE title = @title AND room = @room LIMIT 1";
                        cmd2.Parameters.AddWithValue("@title", title);
                        cmd2.Parameters.AddWithValue("@room", room);
                        var filmId = Convert.ToInt32(cmd2.ExecuteScalar());

                        // Insertar géneros
                        foreach (var genre in genres)
                        {
                            var cmd3 = connection.CreateCommand();
                            cmd3.Transaction = transaction;
                            cmd3.CommandText = @"SELECT genre_id FROM genre WHERE name = @name LIMIT 1";
                            cmd3.Parameters.AddWithValue("@name", genre);
                            var genreId = Convert.ToInt32(cmd3.ExecuteScalar());

                            var cmd4 = connection.CreateCommand();
                            cmd4.Transaction = transaction;
                            cmd4.CommandText = @"INSERT INTO `film-genre` (film_id, genre_id) VALUES (@film_id, @genre_id)";
                            cmd4.Parameters.AddWithValue("@film_id", filmId);
                            cmd4.Parameters.AddWithValue("@genre_id", genreId);
                            cmd4.ExecuteNonQuery();
                        }

                        // Confirmar la transacción
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Revertir la transacción en caso de error
                        transaction.Rollback();
                        throw new Exception("Error al insertar película y géneros: " + ex.Message);
                    }
                }
            }
        }

    }
}