using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamEssentials.Converters
{
    public class ConnectivityColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int connectivity = (int)value;

            switch (connectivity)
            {
                case 1:
                    return Color.LightGreen;
                case 2:
                    return Color.Red;
                default:
                    return Color.Gray;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
