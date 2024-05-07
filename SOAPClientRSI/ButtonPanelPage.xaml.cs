using ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
    /// Interaction logic for ButtonPanelPage.xaml
    /// </summary>
    public partial class ButtonPanelPage : Page
    {
        public ButtonPanelPage()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            FilmsPage filmsPage = new FilmsPage();
            mainWindow.MainFrame.NavigationService.Navigate(filmsPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            PriceListPage priceListPage = new PriceListPage();
            mainWindow.MainFrame.NavigationService.Navigate(priceListPage);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            ReservationPage reservationPage = new ReservationPage();
            mainWindow.MainFrame.NavigationService.Navigate(reservationPage);
        }
    }
}
