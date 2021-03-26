using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using AnimalPark.Model.Enums;

namespace AnimalPark.Utils.Converters
{
    public class SpeciesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Species speciesType)
            {
                return speciesType.ToString();
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string speciesType)
            {
                return Enum.Parse(typeof(Species), speciesType);
            }

            return null;
        }

        public static string[] SpeciesStrings => GetSpeciesStrings();

        private static string[] GetSpeciesStrings() 
        {
            List<string> species = new List<string>();

            foreach (Species speciesType in Enum.GetValues(typeof(Species)))
            {
                if (speciesType != Species.Unknown)
                {
                    species.Add(speciesType.ToString());
                }
            }

            return species.ToArray();
        }
    }
}
