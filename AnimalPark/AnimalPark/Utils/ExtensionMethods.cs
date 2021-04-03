using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace AnimalPark.Utils
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Reflectively get the description of th enum
        /// </summary>
        /// <param name="enumValue"> enum </param>
        /// <returns> string value of the description if exists, otherwise an empty string </returns>
        public static string GetDescription(this Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DescriptionAttribute>()?.Description ?? string.Empty;
        }

        /// <summary>
        /// Reflectively get the enum value of a known enum type
        /// </summary>
        /// <typeparam name="T"> enum type </typeparam>
        /// <param name="description"> description based on which enum value is retrieved</param>
        /// <returns> enum if exists, or default </returns>
        public static T GetValueFromDescription<T>(this string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                    {
                        return (T) field.GetValue(null);
                    }
                    else
                    {
                        if (field.Name == description)
                        {
                            return (T) field.GetValue(null);
                        }
                    }
                }
            }

            return default(T);
        }

        public static bool IsEmpty<T>(this ObservableCollection<T> collection)
        {
            return collection.ToList().Count == 0;
        }
    }
}
