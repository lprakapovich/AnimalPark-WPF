using System;
using AnimalPark.Model.Bases;
using AnimalPark.Model.Enums;

namespace AnimalPark.Utils.Comparators
{
    public class Comparer
    { 
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

        public static int CompareByAgeAscending(Animal animal, Animal compared)
        {
            return animal == null
                ? (compared == null ? 0 : -1)
                : (animal.Age == compared.Age ? 0 : animal.Age > compared.Age ? 1 : -1);
        }

        public static int CompareByAgeDescending(Animal animal, Animal compared)
        {
            return animal == null 
                ? (compared == null ? 0 : -1)
                : (animal.Age == compared.Age ? 0 : animal.Age < compared.Age ? 1 : -1);
        }
         
        public static int CompareByNameAscending(Animal animal, Animal compared)
        {
            return animal == null
                ? (compared == null ? 0 : -1)
                : (animal.Name.Equals(compared.Name) ? 0 : string.Compare(animal.Name, compared.Name, StringComparison.CurrentCulture));
        }
        
        public static int CompareByNameDescending(Animal animal, Animal compared)
        {
            return animal == null
                ? (compared == null ? 0 : -1)
                : (animal.Name.Equals(compared.Name) ? 0 : -string.Compare(animal.Name, compared.Name, StringComparison.CurrentCulture));
        }
    }
}
