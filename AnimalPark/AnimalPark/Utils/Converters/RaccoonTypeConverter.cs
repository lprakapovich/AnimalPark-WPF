using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using AnimalPark.Model.Concretes;

namespace AnimalPark.Utils.Converters
{
    public class RaccoonTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is RaccoonType type)
            {
                return value.ToString();
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string raccoonType)
            {
                return Enum.Parse(typeof(RaccoonType), raccoonType);
            }

            return null;
        }

        public string[] RaccoonTypes => GetRaccoonTypes();

        private string[] GetRaccoonTypes()
        {
            List<string> raccoonTypes = new List<string>();

            foreach (var raccoon in Enum.GetValues(typeof(RaccoonType)))
            {
                raccoonTypes.Add(raccoon.ToString());
            }

            return raccoonTypes.ToArray();
        }
    }
}
