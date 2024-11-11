using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Peliculas.Objetos;

namespace Peliculas
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            string path = "D:/Github/cine-interficies/cine-interficies/peliculas.txt";
            List<Pelicula> pelis = new List<Pelicula>();
            string[] lineas = File.ReadAllLines(path);
            foreach (string linea in lineas)
            {
                if (linea.Contains(';'))
                {
                    string[] parts = linea.Split(';');
                    string titol = parts[0];
                    int sala = int.Parse(parts[1]);
                    string idioma = parts[2];
                    DateTime startDate = DateTime.ParseExact(parts[3], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime endDate = DateTime.ParseExact(parts[4], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    TimeSpan startTime = TimeSpan.ParseExact(parts[5], "hh\\:mm", CultureInfo.InvariantCulture);
                    int duration = int.Parse(parts[6]);
                    List<string> genres = new List<string>();
                    if (lineas.Length > 7)
                    {
                        for (int i = 7; i < parts.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(parts[i]))
                            {
                                genres.Add(parts[i]);
                            }
                        }
                    }
                    Pelicula movie = new Pelicula(titol, sala, idioma, startDate, endDate, startTime, duration, genres);
                    pelis.Add(movie);
                }
            }
        }

    }
}
