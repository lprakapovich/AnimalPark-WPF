using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AnimalPark.Utils.Converters
{
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolVal = (bool) value;
            return boolVal ? Visibility.Visible : (parameter ?? Visibility.Hidden);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((Visibility) value == Visibility.Visible);
        }
    }
}
