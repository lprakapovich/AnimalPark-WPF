using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using AnimalPark.Model.Concretes;

namespace AnimalPark.Utils.Converters
{
    public class JellyFishTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is JellyFishType type)
            {
                return value.ToString();
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string jellyFishType)
            {
                return Enum.Parse(typeof(JellyFishType), jellyFishType); 
            }

            return null;
        }

        public string[] JellyFishTypes => GetRaccoonTypes();

        private string[] GetRaccoonTypes() 
        {
            List<string> jellyFishTypes = new List<string>();

            foreach (var jellyFish in Enum.GetValues(typeof(JellyFishType)))
            {
                jellyFishTypes.Add(jellyFish.ToString());
            }

            return jellyFishTypes.ToArray();
        }
    }
}
