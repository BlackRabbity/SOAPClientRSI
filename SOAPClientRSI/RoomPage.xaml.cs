using ServiceReference;
using SOAPClientRSI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for RoomPage.xaml
    /// </summary>
    public partial class RoomPage : Page
    {
        public int showingId;
        public int Columns { get; set; }
        public RoomPage(showing showing, int showingId)
        {
            InitializeComponent();
            this.showingId = showingId;
            Columns = showing.room.seats.Count() / 2;
            Seats_ListBox.DataContext = showing.room.seats.OrderBy(s => s.row).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            FilmsPage filmsPage = new FilmsPage();
            mainWindow.MainFrame.NavigationService.Navigate(filmsPage);
        }

        private async void Reserve_Seat(object sender, MouseButtonEventArgs e)
        {
            CinemaImplClient client = ClientProvider.Client;
            string macAddress = MACAddressProvider.GetMACAddress();
            try
            {
                int seatId = Seats_ListBox.SelectedIndex;
                var reservationMessage = await client.checkReservationAsync(seatId, showingId, macAddress);
                MessageBoxResult messageBox = MessageBox.Show(reservationMessage.@return, "Confirmation", MessageBoxButton.OK);
                await client.reserveSeatAsync(seatId, ",", showingId, ",", macAddress);
                var result = await client.getShowingsAsync();
                List<showing> showings = result.@return.ToList();
                Seats_ListBox.DataContext = showings[showingId].room.seats.OrderBy(s => s.row).ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MultiReservation(object sender, RoutedEventArgs e)
        {
            MultiSeatsReservationPopupWindow popup = new MultiSeatsReservationPopupWindow(showingId);
            popup.Closed += Popup_Closed;
            popup.ShowDialog();
        }
        private async void Popup_Closed(object? sender, EventArgs e)
        {
            CinemaImplClient client = ClientProvider.Client;
            try
            {
                var result = await client.getShowingsAsync();
                List<showing> showings = result.@return.ToList();
                Seats_ListBox.DataContext = showings[showingId].room.seats.OrderBy(s => s.row).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
