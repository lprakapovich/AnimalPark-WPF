using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace AnimalPark.Utils
{
    public static class ExtensionMethods
    {
        public static string GetDescription(this Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DescriptionAttribute>()?.Description ?? string.Empty;
        }

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
    }
}
