using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using AnimalPark.Model;

namespace AnimalPark.Utils.Converters
{
    public class BaseSpeciesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is BaseSpecies baseSpecies)
            {
                return baseSpecies.ToString();
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string species)
            {
                return Enum.Parse(typeof(BaseSpecies), species);
            }

            return null;
        }

        public string[] BaseSpeciesStrings => GetBaseSpeciesStrings();

        private string[] GetBaseSpeciesStrings()
        {
            List<string> baseSpecies = new List<string>();

            foreach (var species in Enum.GetValues(typeof(BaseSpecies))) 
            {
                baseSpecies.Add(species.ToString());
            }

            return baseSpecies.ToArray();
        }
    }
}
