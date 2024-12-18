﻿using System;
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
        Boolean x;
        public Menu(Boolean admin)
        {
            InitializeComponent();
            if (!admin)
            {
                button_cargar.Content = "Comprar entradas";
            }
            x = admin;
        }
        private void AbrirNuevaVentana(int num)
        {
            if (num == 0) {
                AboutUs nuevaVentana = new AboutUs();

                nuevaVentana.ShowDialog();
            }
            else if (num == 1)
            {
                Cargar_Peliculas cargar = new Cargar_Peliculas();
                this.Close();
                cargar.ShowDialog();
            }
            else if (num == 3)
            {
                MainWindow mainw = new MainWindow();
                this.Close();
                mainw.ShowDialog();
            }
            else
            {
                Cartelera cartelera = new Cartelera();
                cartelera.ShowDialog();
            }
            
        }
        private void button_sobre_Click(object sender, RoutedEventArgs e)
        {
            AbrirNuevaVentana(0);
        }

        private void button_cerrar_Click(object sender, RoutedEventArgs e)
        {
            AbrirNuevaVentana(3);
        }

        private void button_cargar_Click(object sender, RoutedEventArgs e)
        {
            if (x == true)
            {
                AbrirNuevaVentana(1);
            }
            else
            {
                AbrirNuevaVentana(2);
            }
        }
    }
}
