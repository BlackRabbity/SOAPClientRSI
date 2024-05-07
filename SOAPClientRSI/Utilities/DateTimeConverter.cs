using System;
using System.Globalization;
using System.Windows.Data;

namespace SOAPClientRSI.Utilities
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "";

            string input = value.ToString();
            DateTime dateTime;
            if (DateTime.TryParse(input, out dateTime))
            {
                if (parameter.ToString() == "Date")
                    return dateTime.ToString("yyyy-MM-dd");
                else if (parameter.ToString() == "Time")
                    return dateTime.ToString("HH:mm");
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
