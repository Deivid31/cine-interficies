using Peliculas.Objetos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
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

namespace Cine_sillas
{
    public partial class SeatsWindow : Window
    {
        private List<String> seats_selected = new List<String>();
        private List<String> used_seats = new List<String>();
        DBMachine db = new DBMachine();

        DateTime date;
        TimeSpan time;
        int room;

        public SeatsWindow(DateTime date2, TimeSpan time2, int room2)
        {
            date = date2;
            time = time2;
            room = room2;

            InitializeComponent();
            ReadSeats();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button.IsCancel == false)
            {
                if (!used_seats.Contains(button.Name))
                {
                    button.Background = new SolidColorBrush(Colors.DarkGray);
                    button.IsCancel = true;
                    seats_selected.Add(button.Name);
                }
            }
            else
            {
                if (!used_seats.Contains(button.Name))
                {
                    button.Background = new SolidColorBrush(Colors.LightGray);
                    button.IsCancel = false;
                    seats_selected.Remove(button.Name);
                }
            }
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (seats_selected.Count != 0)
            {
                db.addSeats(seats_selected, time.ToString("hh\\:mm"), date.ToString("yyyy-MM-dd"), room);
                MessageBox.Show("Las entradas se han registrado con éxito", "Gracias por su compra", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Debes seleccionar al menos una butaca", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void ReadSeats()
        {
            List<String> seats = db.take_seats(time.ToString("hh\\:mm"), date.ToString("yyyy-MM-dd"), room);

            foreach (string seat in seats)
            {
                Button button = (Button)this.FindName(seat);
                if (button != null)
                {
                    used_seats.Add(button.Name);
                    button.Background = new SolidColorBrush(Colors.DarkRed);
                    button.IsEnabled = false;
                }

            }
        }
    }
}
