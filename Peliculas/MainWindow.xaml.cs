using Peliculas.Objetos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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
    public partial class MainWindow : Window
    {
        DBMachine db = new DBMachine();
        int seguidas = 0;
        public User userBinding;
        int numErrors = 0;

        public MainWindow()
        {
            InitializeComponent();
            RefreshUsrAndContent();
        }
        

        private void RefreshUsrAndContent() {
            userBinding = new User();
            txtBox_correo.DataContext = userBinding;
            txtBox_contra.DataContext = userBinding;
        }

        private void button_borrar_Click(object sender, RoutedEventArgs e)
        {
            txtBox_correo.Clear();
            txtBox_contra.Clear();
            RefreshUsrAndContent();
        }
        private void AbrirNuevaVentana(Boolean admin)
        {
            Menu nuevaVentana = new Menu(admin);

            MainWindow1.Hide();
            nuevaVentana.ShowDialog();
        }

        public void FunctionValidationError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                numErrors++;
            }
            else
            {
                numErrors--;
            }

            if (numErrors == 0)
            {
                button_confirmar.IsEnabled = true;
            }
            else
            {
                button_confirmar.IsEnabled = false;
            }
        }


        private async void button_confirmar_Click(object sender, RoutedEventArgs e)
        {
            if (seguidas != 3)
            {
                if (db.userExist(userBinding))
                {
                    if (db.checkUser(userBinding))
                    {
                        seguidas = 0;
                        if (db.isAdmin(userBinding))
                        {
                            AbrirNuevaVentana(true);
                        }
                        AbrirNuevaVentana(false);
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
                        
                    db.addUser(userBinding);
                    MessageBox.Show("Los datos introducidos son válidos para un registro, bienvenido.", "Datos Registro", MessageBoxButton.OK, MessageBoxImage.Information);
                    seguidas = 0;
                    AbrirNuevaVentana(false);
                }
            }
        }

        private void controlar_aste(object sender, TextChangedEventArgs e)
        {
            txtBox_contra_aste.Text = new string('*', txtBox_contra.Text.Length);
        }
    }
}
