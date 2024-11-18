using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
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
    /// Interaction logic for Cargar_Peliculas.xaml
    /// </summary>
    public partial class Cargar_Peliculas : Window
    {
        public Logica logica;
        public ObservableCollection<Pelicula> listFilms { get; set; }
        public List<String> listGenres { get; set; }
        public List<String> listLanguages { get; set; }
        public List<String> listHours { get; set; }
        public List<String> listMinutes { get; set; }
        public ObservableCollection<string> Generos = new ObservableCollection<string>();
        public string GenerosString
        {
            get { 
                String generos = "";
                for (int i = 0; i < Generos.Count; i++)
                {
                    if (i != Generos.Count - 1){
                        generos += Generos[i];
                        generos += ", ";
                    }else{
                        generos += Generos[i];
                    }
                    
                }
                return generos; 
            }
        }
        public Cargar_Peliculas()
        {
            InitializeComponent();
            Logica logica = new Logica();
            this.logica = logica;
            listGenres = new List<String> { "Acció", "Aventura", "Ciencia Ficció", "Comèdia", "Documental", "Drama", "Fantasía", "Musical", "Suspense", "Terror" };
            listLanguages = new List<String> { "V.O", "Castellano" };
            listHours = new List<String> { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" };
            listMinutes = new List<String> { "00", "15", "30", "45" };
            this.DataContext = this;
            filmsGrid.DataContext = logica;
            string path = "./../../../peliculas.txt";
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
                    listFilms.Add(movie);
                }

            }
        }
       
        

        private void cleanButton_Click(object sender, RoutedEventArgs e)
        {
            genreBox.SelectedItem = null;
            langBox.SelectedItem = null;
            diaInBox.SelectedDate = null;
            hourBox.SelectedItem = null;
            minuteBox.SelectedItem = null;
            Generos.Clear();
        }

        private void confirmarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void añadir_Button_Click(object sender, RoutedEventArgs e)
        {
            if (genreBox.SelectedItem != null)
            {
                if (Generos.Count < 3)
                {
                    if (!Generos.Contains(genreBox.SelectedItem.ToString()))
                    {
                        Generos.Add(genreBox.SelectedItem.ToString());
                        Genres_TxtB.Text = GenerosString;
                    }
                    else
                    {
                        MessageBox.Show("Ese género ya está en la lista.", "Error de Género", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Como máximo tienes permitido añadir 3 géneros", "Error de Género", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void limpiarGen_Button_Click(object sender, RoutedEventArgs e)
        {
            Generos.Clear();
            Genres_TxtB.Text = GenerosString;
        }
    }
}
