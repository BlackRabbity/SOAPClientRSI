using Microsoft.Win32;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using ServiceReference;
using SOAPClientRSI.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Xps.Packaging;
using System.Xml.Linq;

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

        private async void ReservationToPDF(object sender, RoutedEventArgs e)
        {
            CinemaImplClient client = ClientProvider.Client;
            string macAddress = MACAddressProvider.GetMACAddress();
            try
            {
                List<showing> showings = (await client.GetReservedSeatsAsync(macAddress)).@return.ToList();

                // Create a SaveFileDialog
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                // Set properties for the SaveFileDialog
                saveFileDialog.Title = "Save File";
                saveFileDialog.Filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";

                // Show the SaveFileDialog
                if (saveFileDialog.ShowDialog() == true)
                {
                    // Get the selected file path from the SaveFileDialog
                    string filePath = saveFileDialog.FileName;

                    // Implement your logic to save the file with the given file path
                    // For example, you can use File.WriteAllText to save a text file
                    // Create a new PDF document
                    PdfDocument document = new PdfDocument();

                    // Add a page to the document
                    PdfPage page = document.AddPage();

                    // Get an XGraphics object for drawing on the page
                    XGraphics gfx = XGraphics.FromPdfPage(page);

                    // Draw text on the page
                    XFont font = new XFont("Arial", 12);
                    XBrush brush = XBrushes.Black;

                    List<string> lines = new List<string>();

                    foreach (var showing in showings)
                    {
                        lines.Add($"Reservation for showing:");
                        lines.Add($"Film title: {showing.film.title}");
                        lines.Add($"Date of play: {showing.date.Replace('T', ' ')}");

                        foreach (var seat in showing.room.seats)
                        {
                            if (seat != null)
                            {
                                lines.Add(@$"Seat Number: {seat.seatNumber} (row: {seat.row} column: {seat.column})");
                            }
                        }
                        lines.Add(@$"");
                    }
                    double yPos = 50; // Starting Y position
                    foreach (string line in lines)
                    {
                        gfx.DrawString(line, font, brush, 50, yPos);
                        yPos += 20; // Increment Y position for the next line
                    }
                    //gfx.DrawString(fileText, font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

                    // Save the document to a file
                    document.Save(filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
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
