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
    /// Interaction logic for MultiSeatsReservationPopupWindow.xaml
    /// </summary>
    public partial class MultiSeatsReservationPopupWindow : Window
    {
        public int showingId;
        public MultiSeatsReservationPopupWindow(int showingId)
        {
            this.showingId = showingId;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void MultiReservation(object sender, RoutedEventArgs e)
        {
            CinemaImplClient client = ClientProvider.Client;
            string macAddress = MACAddressProvider.GetMACAddress();
            try
            {
                string seatsText = MultiSeats.Text;
                string[] seatStrings = seatsText.Split(',');
                int[] seatsIds = seatStrings.Select(int.Parse).ToArray();
                seatsIds = seatsIds.Select(x => x - 1).ToArray();
                var result = await client.reserveMultipleSeatsAsync(seatsIds, showingId, macAddress);
                MessageBoxResult messageBox = MessageBox.Show(result.@return, "Confirmation", MessageBoxButton.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
