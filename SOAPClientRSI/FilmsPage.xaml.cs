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
    public class Film
    {
        public string Title { get; set; }
        public DateTime DayOfPlay { get; set; }
        public string Hour { get; set; }
        public Film(string title, DateTime dayOfPlay, string hour)
        {
            this.Title = title;
            this.DayOfPlay = dayOfPlay;
            this.Hour = hour;
        }
    }

    public partial class FilmsPage : Page
    {
        public List<Film> Films { get; set; }
        public FilmsPage()
        {
            InitializeComponent();

            Films = new List<Film>()
            {
                new Film("Film 1", new DateTime(2020, 8, 9), "10:00"),
                new Film("Film 2", new DateTime(2020, 8, 9), "12:00"),
                new Film("Film 3", new DateTime(2020, 8, 9), "14:00"),
            };
            Films_ListBox.DataContext = Films;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
