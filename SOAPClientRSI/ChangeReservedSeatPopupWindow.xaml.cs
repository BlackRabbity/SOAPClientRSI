using ServiceReference;
using SOAPClientRSI.Utilities;
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

namespace SOAPClientRSI
{
    /// <summary>
    /// Interaction logic for ChangeReservedSeatPopupWindow.xaml
    /// </summary>
    public partial class ChangeReservedSeatPopupWindow : Window
    {
        public int seatId;
        public int showingId;
        public ChangeReservedSeatPopupWindow(int seatId, int showingId)
        {
            this.seatId = seatId;
            this.showingId = showingId;
            InitializeComponent();
        }

        private async void ChangeReservation(object sender, RoutedEventArgs e)
        {
            CinemaImplClient client = ClientProvider.Client;
            string macAddress = MACAddressProvider.GetMACAddress();
            try
            {
                string seatsText = NewSeat.Text;
                int newSeatId = int.Parse(seatsText)-1;
                var result = await client.changeReservedSeatAsync(seatId, newSeatId, showingId, macAddress);
                MessageBoxResult messageBox = MessageBox.Show(result.@return, "Confirmation", MessageBoxButton.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
