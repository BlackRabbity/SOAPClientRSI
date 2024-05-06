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
using ServiceReference;

namespace SOAPClientRSI
{
    public partial class FilmsPage : Page
    {
        private CinemaImplClient client;

        public FilmsPage()
        {
            InitializeComponent();
            client = new CinemaImplClient();
            InitializeAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
        private async void InitializeAsync()
        {
            try
            {
                var result = await client.getShowingsAsync();
                List<showing> showings = result.@return.ToList();
                Films_ListBox.DataContext = showings;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
