using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.IO.Packaging;
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
using Peliculas.cosas;
using Peliculas.Objetos;

namespace Peliculas
{
    /// <summary>
    /// Interaction logic for Cargar_Peliculas.xaml
    /// </summary>
    public partial class Cargar_Peliculas : Window
    {
        public VerPelis verpelis;
        public DBMachine db;
        public ObservableCollection<Pelicula> listFilms {  get; set; }
        public List<String> listGenres { get; set; }
        public List<String> listLanguages { get; set; }
        public List<String> listHours { get; set; }
        public List<String> listMinutes { get; set; }
        public List<String> listDuration { get; set; }
        public List<int> listSala { get; set; }
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
            db = new DBMachine();
            verpelis = new VerPelis();
            listGenres = new List<String> { "Acción", "Aventura", "Ciencia Ficción", "Comedia", "Documental", "Drama", "Fantasía", "Musical", "Suspense", "Terror" };
            listLanguages = new List<String> { "V.O", "Castellano" };
            listHours = new List<String> { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" };
            listMinutes = new List<String> { "00", "15", "30", "45" };
            listSala = new List<int> { 1, 2, 3 };
            listDuration = new List<String> { "30", "60", "90", "120", "150", "180", "210" };
            
            this.DataContext = this;
            filmsGrid.DataContext = verpelis;
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
            if (!string.IsNullOrWhiteSpace(titulo_txtBox.Text) &&
                salaBox.SelectedItem != null &&
                !string.IsNullOrWhiteSpace(langBox.Text) &&
                diaInBox.SelectedDate.HasValue &&
                hourBox.SelectedItem != null &&
                minuteBox.SelectedItem != null &&
                durationBox.SelectedItem != null &&
                Generos.Count > 0)
            {
                try
                {
                    string titulo = titulo_txtBox.Text;
                    int sala = int.Parse(salaBox.SelectedItem.ToString());
                    string idioma = langBox.SelectedItem.ToString();
                    DateTime diaInici = diaInBox.SelectedDate.Value;
                    DateTime diaFinal = diaInBox.SelectedDate.Value.AddDays(28);
                    TimeSpan hora = new TimeSpan(int.Parse(hourBox.SelectedItem.ToString()), int.Parse(minuteBox.SelectedItem.ToString()), 0);
                    int duracion = int.Parse(durationBox.SelectedItem.ToString());

                    Pelicula nuevaPelicula = new Pelicula(titulo, sala, idioma, diaInici, diaFinal, hora, duracion, Generos.ToList());

                    verpelis.AddFilm(nuevaPelicula);
                    if (idioma.Equals("V.0"))
                    {
                        db.insert_Films(titulo, sala, 2, diaInici, diaFinal, hora, duracion, Generos.ToList());
                    }
                    else
                    {
                        db.insert_Films(titulo, sala, 1, diaInici, diaFinal, hora, duracion, Generos.ToList());
                    }
                    
                    cleanButton_Click(sender, e);

                    MessageBox.Show("Película añadida con éxito.", "Confirmación", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al añadir la película: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, completa todos los campos antes de añadir una película.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
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
