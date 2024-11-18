using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Cine_sillas;
using Peliculas;
using Peliculas.Objetos;

namespace Peliculas
{
    public partial class CarteleraFiltrada : Window
    {
        public Logica logica;
        public Cartelera cartelera;

        public CarteleraFiltrada(Cartelera cartelera, Logica logica, String genre, String lang, DateTime? inDay, TimeSpan? hourIn)
        {
            InitializeComponent();
            this.cartelera = cartelera;
            this.logica = logica;
            logica.Filtrar(genre, lang, inDay, hourIn);
            filmsGrid.DataContext = logica;
            filmBox.DataContext = logica;
            diaLbl.Content = inDay?.ToString("dd/MM/yyyy");
        }

        private void butCancelar_Click(object sender, RoutedEventArgs e)
        {
            logica.filtFilms.Clear();
            this.Close();
            cartelera.Show();
        }

        private void butReservar_Click(object sender, RoutedEventArgs e)
        {
            if (filmBox.SelectedItem != null)
            {
                Pelicula pelicula = (Pelicula)filmBox.SelectedItem;
                SeatsWindow seatsWindow = new SeatsWindow(DateTime.ParseExact((String)diaLbl.Content, "dd/MM/yyyy", CultureInfo.InvariantCulture), pelicula.Hora, pelicula.Sala);
            }
            else
            {
                MessageBox.Show("Selecciona una pelicula para hacer la reserva", "Pelicula faltante", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
