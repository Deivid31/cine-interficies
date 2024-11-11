using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Peliculas.Objetos;

namespace Peliculas
{
    public partial class Cartelera : Window
    {
        public Logica logica;
        public ObservableCollection<Pelicula> listFilms { get; set; }
        public List<String> listGenres { get; set; }
        public List<String> listLanguages { get; set; }
        public List<String> listHours { get; set; }
        public List<String> listMinutes { get; set; }
        public Cartelera()
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
        }


        private void cleanButton_Click(object sender, RoutedEventArgs e)
        {
            genreBox.SelectedItem = null;
            langBox.SelectedItem = null;
            diaInBox.SelectedDate = null;
            hourBox.SelectedItem = null;
            minuteBox.SelectedItem = null;
        }

        private void filtButton_Click(object sender, RoutedEventArgs e)
        {
            var genre = genreBox.Text;
            var lang = langBox.Text;
            DateTime? diaIn = null;
            TimeSpan? hourIn = null;
            if (diaInBox.SelectedDate != null)
            {
                MessageBox.Show("Contraseña correcta, bienvenido de nuevo.", "Datos inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Information);
                diaIn = diaInBox.SelectedDate.Value;
            }
            if (hourBox.Text != "" && minuteBox.Text != "")
            {
                hourIn = TimeSpan.ParseExact(hourBox.Text + ":" + minuteBox.Text, "hh\\:mm", CultureInfo.InvariantCulture);
            }
            else if (hourBox.Text != "" && minuteBox.Text == "")
            {
                hourIn = TimeSpan.ParseExact(hourBox.Text + ":00", "hh\\:mm", CultureInfo.InvariantCulture);
            }
            else if (hourBox.Text == "" && minuteBox.Text != "")
            {
                hourIn = TimeSpan.ParseExact("00:" + minuteBox.Text, "hh\\:mm", CultureInfo.InvariantCulture);
            }
            //var diaFin = diaFinBox.SelectedDate.Value;
            CarteleraFiltrada carteleraFiltrada = new CarteleraFiltrada(this, logica, genre, lang, diaIn, hourIn);
            carteleraFiltrada.Show();
            this.Hide();
        }
    }
}