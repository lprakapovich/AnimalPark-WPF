using System;
using System.Collections.Generic;
using AnimalPark.Model.Enums;

namespace AnimalPark.Utils
{
    public class EnumHelper
    {
        public static List<T> GetAllValuesAs<T>(Type type)
        {
            List<T> values = new List<T>();

            foreach (T value in Enum.GetValues(type))
            {
                values.Add(value);
            }

            return values;
        }
        
        public static List<Species> GetSpeciesByCategory(Category category)
        {
            return GetCategorizedSpecies().ContainsKey(category) ? GetCategorizedSpecies()[category] : GetAllValuesAs<Species>(typeof(Species));
        }

        private static Dictionary<Category, List<Species>> GetCategorizedSpecies()
        {
            return new Dictionary<Category, List<Species>>()
            {
                {
                    Category.Mammal, new List<Species>()
                    {
                        Species.Raccoon, Species.Donkey
                    }
                },
                {
                    Category.Fish, new List<Species>()
                    {
                        Species.JellyFish, Species.Prawn
                    }
                }
            };
        }

        public static Category FindCorrespondingCategory(Species species)
        {
            Category foundCategory = Category.Mammal; 

            foreach (Category category in GetCategorizedSpecies().Keys)
            {
                if (GetCategorizedSpecies()[category].Contains(species))
                {
                    foundCategory = category;
                }
            }

            return foundCategory;
        }
    }
}
