using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Objetos
{
    public class Pelicula
    {
        public String Titulo { get; set; }
        public int Sala { get; set; }
        public String Idioma { get; set; }
        public DateTime diaInici { get; set; }
        public DateTime diaFinal { get; set; }
        public TimeSpan Hora { get; set; }
        public int Duracion { get; set; }
        public List<String> Generos { get; set; }
        public Pelicula(String input1, int input2, String input3, DateTime input4, DateTime input5, TimeSpan input6, int input7, List<String> input8)
        {
            Titulo = input1;
            Sala = input2;
            Idioma = input3;
            diaInici = input4;
            diaFinal = input5;
            Hora = input6;
            Duracion = input7;
            Generos = input8;
        }
    }
}
