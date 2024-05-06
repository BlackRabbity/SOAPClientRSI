using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CinemaImplClient client;
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new ButtonPanelPage();

            // MTOM
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.MessageEncoding = WSMessageEncoding.Mtom;
            EndpointAddress endpointAddress = new EndpointAddress("http://localhost:9999/ws/CinemaImpl");
            client = new CinemaImplClient(binding, endpointAddress);

            //Load image with MTOM
            LoadLogoAsync();
        }

        private async void LoadLogoAsync()
        {

            try
            {
                var result = await client.getLogoAsync();
                byte[] logoBytes = result.@return;
                BitmapImage bitmapLogo = ByteArrayToBitmapImage(logoBytes);
                LogoImage.Source = bitmapLogo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private BitmapImage ByteArrayToBitmapImage(byte[] byteArray)
        {
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
                return image;
            }
        }
    }

}
