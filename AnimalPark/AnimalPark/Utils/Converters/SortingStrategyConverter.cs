using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using AnimalPark.Model.Enums;

namespace AnimalPark.Utils.Converters
{
    public class SortingStrategyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SortingStrategy strategy)
            {
                return ((Enum) value).GetDescription();
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                return stringValue.GetValueFromDescription<SortingStrategy>();
            }

            return null;
        }
        public string[] EnumDescriptions => GetEnumDescriptions();

        private string[] GetEnumDescriptions()
        { 
            List<string> strategies = new List<string>();

            foreach (var strategy in Enum.GetValues(typeof(SortingStrategy)))
            {
                strategies.Add(((Enum) strategy).GetDescription());
            }

            return strategies.ToArray();
        }
    }
}
