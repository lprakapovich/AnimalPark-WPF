using System;
using System.Collections.Generic;
using AnimalPark.Model.Enums;

namespace AnimalPark.Utils
{
    public class EnumHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="type"> enum type, e.g. Category </param>
        /// <returns> all enum values as a list of strings </returns>
        public static List<T> GetAllValuesAs<T>(Type type)
        {
            List<T> values = new List<T>();

            foreach (T value in Enum.GetValues(type))
            {
                values.Add(value);
            }

            return values;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns> list of species, if exists for specified category, or all species </returns>
        public static List<Species> GetSpeciesByCategory(Category category)
        {
            return GetCategorizedSpecies().ContainsKey(category) ? GetCategorizedSpecies()[category] : GetAllValuesAs<Species>(typeof(Species));
        }

        /// <summary>
        /// Groups enums into categorized clusters
        /// </summary>
        /// <returns> dictionary of categorized species, with a Category as a key </returns>
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

        /// <summary>
        /// Determines to which category a species belongs
        /// </summary>
        /// <param name="species"> Species enum </param>
        /// <returns> Category, if found, or default (Mammal) </returns>
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
