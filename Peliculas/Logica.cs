using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Peliculas.Objetos;

namespace Peliculas
{
    public class Logica
    {
        public DBMachine dBMachine;
        public ObservableCollection<Pelicula> listFilms { get; set; }
        public ObservableCollection<Pelicula> filtFilms { get; set; }

        public Logica()
        {
            DBMachine dBMachine = new DBMachine();
            this.dBMachine = dBMachine;
            listFilms = new ObservableCollection<Pelicula>(dBMachine.take_Films());
        }

        /* 
        Función para hacer el filtrado de las peliculas, recibe como argumento las propiedades, las cuales pueden ser NULL,
        se instancia la lista de peliculas filtradas, basandose en la lista de todas las peliculas
        y luego dependiendo si la propiedad pasada es NULL o no (Excepto el dia, ya que siempre se especifica)
        entonces filtrara con el Where las peliculas, dejando solo las que cumplan con el criterio
        */
        public void Filtrar(String genre, String lang, DateTime? dayIn, TimeSpan? hourIn)
        {
            filtFilms = new ObservableCollection<Pelicula>(listFilms);
            filtFilms = new ObservableCollection<Pelicula>(filtFilms.Where(p => p.diaInici <= dayIn && dayIn <= p.diaFinal));
            if (!string.IsNullOrEmpty(genre))
            {
                filtFilms = new ObservableCollection<Pelicula>(filtFilms.Where(p => p.Generos.Contains(genre)));
            }
            if (!string.IsNullOrEmpty(lang))
            {
                filtFilms = new ObservableCollection<Pelicula>(filtFilms.Where(p => p.Idioma == lang));
            }
            if (hourIn.HasValue)
            {
                filtFilms = new ObservableCollection<Pelicula>(filtFilms.Where(p => p.Hora == hourIn));
            }
        }
    }
}
