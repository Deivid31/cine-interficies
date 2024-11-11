using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peliculas.Objetos;

namespace Peliculas
{
    public class Logica
    {
        public ObservableCollection<Pelicula> listFilms { get; set; }
        public ObservableCollection<Pelicula> filtFilms { get; set; }

        public Logica()
        {
            listFilms = new ObservableCollection<Pelicula>();
            listFilms.Add(new Pelicula("Jonkler", 3, "Castellano", DateTime.ParseExact("20/05/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact("30/06/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), TimeSpan.ParseExact("15:00", "hh\\:mm", CultureInfo.InvariantCulture), 70, new List<string> { "Acció", "Aventura", "Suspense" }));
            listFilms.Add(new Pelicula("Si", 1, "V.O", DateTime.ParseExact("17/03/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact("04/05/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), TimeSpan.ParseExact("13:45", "hh\\:mm", CultureInfo.InvariantCulture), 60, new List<string> { "Terror", "Suspense" }));
            listFilms.Add(new Pelicula("No", 6, "V.O", DateTime.ParseExact("09/06/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact("10/07/2024", "dd/MM/yyyy", CultureInfo.InvariantCulture), TimeSpan.ParseExact("18:00", "hh\\:mm", CultureInfo.InvariantCulture), 77, new List<string> { "Comedia", "Fantasía" }));
            filtFilms = new ObservableCollection<Pelicula>();
        }

        public void Filtrar(String genre, String lang, DateTime? dayIn, TimeSpan? hourIn)
        {
            filtFilms = new ObservableCollection<Pelicula>(listFilms); ;
            if (!string.IsNullOrEmpty(genre))
            {
                filtFilms = new ObservableCollection<Pelicula>(filtFilms.Where(p => p.Generos.Contains(genre)));
            }
            if (!string.IsNullOrEmpty(lang))
            {
                filtFilms = new ObservableCollection<Pelicula>(filtFilms.Where(p => p.Idioma == lang));
            }
            if (dayIn.HasValue)
            {
                filtFilms = new ObservableCollection<Pelicula>(filtFilms.Where(p => p.diaInici <= dayIn && dayIn <= p.diaFinal));
            }
            if (hourIn.HasValue)
            {
                filtFilms = new ObservableCollection<Pelicula>(filtFilms.Where(p => p.Hora == hourIn));
            }
            /*
            foreach (Pelicula pelicula in listFilms)
            {
                if(pelicula.Generos.Contains(genre) && pelicula.Idioma == lang && pelicula.diaInici <= dayIn && dayIn <= pelicula.diaFinal)
                {
                    AddFilm(pelicula);
                }
            }
        }
            public void AddFilm(Pelicula pelicula)
        {
            filtFilms.Add(pelicula);
        }
            */
        }
    }
}
