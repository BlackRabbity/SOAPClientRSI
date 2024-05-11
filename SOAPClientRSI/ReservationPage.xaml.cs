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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SOAPClientRSI
{
    /// <summary>
    /// Interaction logic for ReservationPage.xaml
    /// </summary>
    public partial class ReservationPage : Page
    {
        public ReservationPage()
        {
            InitializeComponent();
            LoadReservationAsync();
        }

        private async void LoadReservationAsync()
        {
            CinemaImplClient client = ClientProvider.Client;
            string macAddress = MACAddressProvider.GetMACAddress();
            try
            {
                var result = await client.GetReservedSeatsAsync(macAddress);
                ReservedSeats_ListBox.DataContext = result.@return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void ReservationToPDF(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeReservedSeat(object sender, RoutedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            object selectedItem = listBox.SelectedItem;
            seat selectedSeat = selectedItem as seat;
            int seatId = selectedSeat.seatNumber - 1;
            showing _showing = (showing)(sender as FrameworkElement).DataContext;
            int showingId = _showing.id;
            ChangeReservedSeatPopupWindow popup = new ChangeReservedSeatPopupWindow(seatId, showingId);
            popup.Closed += Popup_Closed;
            popup.ShowDialog();
        }

        private void Popup_Closed(object? sender, EventArgs e)
        {
            LoadReservationAsync();
        }
    }
}
