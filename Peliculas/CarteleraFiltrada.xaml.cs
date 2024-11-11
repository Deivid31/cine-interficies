using System;
using System.Collections.Generic;
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
using Peliculas;

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
        }

        private void butCancelar_Click(object sender, RoutedEventArgs e)
        {
            logica.filtFilms.Clear();
            this.Close();
            cartelera.Show();
        }

        private void butReservar_Click(object sender, RoutedEventArgs e)
        {
            //Reserva, ns
        }
    }
}
