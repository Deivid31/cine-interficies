using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
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

namespace Peliculas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = "./../../../usuarios.txt";
        public MainWindow()
        {
            InitializeComponent();
        }
        static async Task Esperar()
        {
            await Task.Delay(1000); 
        }
        public bool EsCorreoValido(string email)
        {
            try
            {
                var direccionCorreo = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void button_borrar_Click(object sender, RoutedEventArgs e)
        {
            txtBox_correo.Clear();
            PassBox.Clear();
        }
        private void AbrirNuevaVentana()
        {
            Window1 nuevaVentana = new Window1();
            
            nuevaVentana.ShowDialog();
        }
        int seguidas = 0;
        private async void button_confirmar_Click(object sender, RoutedEventArgs e)
        {
            List<string> correos = new List<string>();
            List<string> contraseñas = new List<string>();
            string[] lineas = File.ReadAllLines(path);

            foreach (string linea in lineas)
            {
                if (linea.Contains('|'))
                {
                    string[] separa = linea.Split('|');
                    correos.Add(separa[0]);
                    contraseñas.Add(separa[1]);
                }
            }
            if (seguidas != 3)
            {
                if (EsCorreoValido(txtBox_correo.Text) && PassBox.Password.Length >= 3)
                {

                    if (correos.Contains(txtBox_correo.Text))
                    {
                        int pos = 0;
                        for (int i = 0; i < correos.Count; i++)
                        {
                            if (correos[i] == txtBox_correo.Text)
                            {
                                pos = i; break;
                            }
                        }
                        if (contraseñas[pos].Equals(PassBox.Password))
                        {
                            MessageBox.Show("Contraseña correcta, bienvenido de nuevo.", "Datos inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Information);
                            seguidas = 0;
                            AbrirNuevaVentana();
                        }
                        else
                        {
                            MessageBox.Show("Contraseña incorrecta", "Error de inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Warning);
                            seguidas++;
                            if (seguidas == 3)
                            {
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        using (StreamWriter writer = new StreamWriter(path, append: true))
                        {
                            writer.WriteLine(txtBox_correo.Text + "|" + PassBox.Password);
                        }
                        MessageBox.Show("Los datos introducidos son válidos para un registro, bienvenido.", "Datos Registro", MessageBoxButton.OK, MessageBoxImage.Information);
                        seguidas = 0;
                        AbrirNuevaVentana();
                    }

                }
                else
                {
                    seguidas++;
                    MessageBox.Show("La contraseña debe ser mayor a 3 caracteres y el correo debe ser válido.", "Error Registro/Inicio sesión", MessageBoxButton.OK, MessageBoxImage.Warning);
                    if (seguidas == 3) { 
                        this.Close();
                    }

                }
            }
            
        }
    }
}
