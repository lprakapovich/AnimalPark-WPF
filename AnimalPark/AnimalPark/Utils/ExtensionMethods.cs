using System;
using System.Collections.Generic;
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

        /// <summary>
        ///  Check if a collection has any elements
        /// </summary>
        /// <typeparam name="T">parameter </typeparam>
        /// <param name="collection"> checked collection </param>
        /// <returns> boolean value </returns>
        public static bool IsEmpty<T>(this ObservableCollection<T> collection)
        {
            return collection.ToList().Count == 0;
        }

        /// <summary>
        /// string representation of the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns> list elements concatenated in a string </returns>
        public static string GetListed<T>(this List<T> list)
        {
            string listedElements = null;

            foreach (var element in list)
            {
                listedElements += element.ToString();
            }

            return listedElements;
        }

        /// <summary>
        /// For each key in the collection, check if the corresponding value exists
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="value"></param>
        /// <returns> whether a value is present in the dictionary </returns>
        public static bool ContainsValueInList<T>(this Dictionary<T, List<T>> dictionary, T value)
        {
            foreach (var key in dictionary.Keys)
            {
                if (dictionary[key].Contains(value))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
