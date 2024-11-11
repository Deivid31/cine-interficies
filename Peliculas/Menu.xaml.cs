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

namespace Peliculas
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            
        }
        private void AbrirNuevaVentana()
        {
            Window1 nuevaVentana = new Window1();

            nuevaVentana.ShowDialog();
        }
        private void button_sobre_Click(object sender, RoutedEventArgs e)
        {
            AbrirNuevaVentana();
        }

        private void button_cerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_cargar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
