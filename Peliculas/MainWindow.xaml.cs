﻿using Peliculas.Objetos;
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
        DBMachine db = new DBMachine();
        int seguidas = 0;

        public MainWindow()
        {
            InitializeComponent();
        }
        public bool EsCorreoValido(string email)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    var direccionCorreo = new MailAddress(email);
                    return true;
                }
                return false;
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
        private void AbrirNuevaVentana(Boolean admin)
        {
            Menu nuevaVentana = new Menu(admin);

            MainWindow1.Hide();
            nuevaVentana.ShowDialog();
        }
        
        private async void button_confirmar_Click(object sender, RoutedEventArgs e)
        {
            if (seguidas != 3)
            {
                if (EsCorreoValido(txtBox_correo.Text) && PassBox.Password.Length >= 3)
                {

                    if (db.userExist(txtBox_correo.Text))
                    {
                        if (db.checkUser(txtBox_correo.Text, PassBox.Password))
                        {
                            MessageBox.Show("Contraseña correcta, bienvenido de nuevo.", "Datos inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Information);
                            seguidas = 0;
                            if (db.isAdmin(txtBox_correo.Text))
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
                        db.addUser(txtBox_correo.Text, PassBox.Password);
                        MessageBox.Show("Los datos introducidos son válidos para un registro, bienvenido.", "Datos Registro", MessageBoxButton.OK, MessageBoxImage.Information);
                        seguidas = 0;
                        AbrirNuevaVentana(false);
                    }

                }
                else
                {
                    seguidas++;
                    txtBox_correo.Clear();
                    PassBox.Clear();
                    MessageBox.Show("La contraseña debe ser mayor a 3 caracteres y el correo debe ser válido.", "Error Registro/Inicio sesión", MessageBoxButton.OK, MessageBoxImage.Warning);
                    if (seguidas == 3) { 
                        this.Close();
                    }

                }
            }
            
        }
    }
}
