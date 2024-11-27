using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peliculas.Objetos;

namespace Peliculas.cosas
{
    public class VerPelis
    {
        public DBMachine dBMachine;
        public ObservableCollection<Pelicula> listFilms { get; set; }

        public VerPelis()
        {
            DBMachine dBMachine = new DBMachine();
            this.dBMachine = dBMachine;
            listFilms = new ObservableCollection<Pelicula>(dBMachine.take_Films());
        }
        
    }
}
