﻿using System;
using AnimalPark.Model.Bases;
using AnimalPark.Model.Enums;

namespace AnimalPark.Utils.Comparators
{
    public static class Comparer
    { 
        /// <summary>
        /// Factory method of sorting strategies
        /// </summary>
        /// <param name="strategy"> Strategy to sort animal list </param>
        /// <returns> Comparison delegate that is then passes to Sort() as a parameter</returns>
        public static Comparison<Animal> ResolveSortingStrategy(SortingStrategy strategy)
        {
            switch (strategy)
            {
                case SortingStrategy.ByAgeAsc:
                    return CompareByAgeAscending;

                case SortingStrategy.ByAgeDesc:
                    return CompareByAgeDescending; 

                case SortingStrategy.ByNameAsc:
                    return CompareByNameAscending;

                case SortingStrategy.ByNameDesc:
                    return CompareByNameDescending;

                default:
                    return CompareByAgeAscending;
            }
        }

        /// <summary>
        /// Compare animals by age in ascending manner 
        /// </summary>
        /// <returns></returns>
        public static int CompareByAgeAscending(Animal animal, Animal compared)
        {
            return animal == null
                ? (compared == null ? 0 : -1)
                : (animal.Age == compared.Age ? 0 : animal.Age > compared.Age ? 1 : -1);
        }

        /// <summary>
        /// Compare animals by age in descending manner 
        /// </summary>
        /// <returns></returns>
        public static int CompareByAgeDescending(Animal animal, Animal compared)
        {
            return animal == null 
                ? (compared == null ? 0 : -1)
                : (animal.Age == compared.Age ? 0 : animal.Age < compared.Age ? 1 : -1);
        }

        /// <summary>
        /// Compare animals by name in ascending manner 
        /// </summary>
        /// <returns></returns>
        public static int CompareByNameAscending(Animal animal, Animal compared)
        {
            return animal == null
                ? (compared == null ? 0 : -1)
                : (animal.Name.Equals(compared.Name) ? 0 : string.Compare(animal.Name, compared.Name, StringComparison.CurrentCulture));
        }

        /// <summary>
        /// Compare animals by name in descending manner 
        /// </summary>
        /// <returns></returns>
        public static int CompareByNameDescending(Animal animal, Animal compared)
        {
            return animal == null
                ? (compared == null ? 0 : -1)
                : (animal.Name.Equals(compared.Name) ? 0 : -string.Compare(animal.Name, compared.Name, StringComparison.CurrentCulture));
        }
    }
}
