using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using AnimalPark.Model.Enums;

namespace AnimalPark.Utils.Converters
{
    class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Gender gender)
            {
                return gender.ToString();
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string gender) 
            {
                return Enum.Parse(typeof(Gender), gender);
            }

            return null;
        }

        public string[] GenderStrings => GetGenderStrings(); 

        private string[] GetGenderStrings()
        {
            List<string> genders = new List<string>();

            foreach (var gender in Enum.GetValues(typeof(Gender)))
            {
                genders.Add(gender.ToString());
            }

            return genders.ToArray();
        }
    }
}
