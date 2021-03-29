using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalPark.Model.Bases;

namespace AnimalPark.Utils.Comparators
{
    public class Comparer
    {
        public static int CompareByAgeAscending(Animal animal, Animal compared)
        {
            if (animal == null)
            {
                if (compared == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return animal.Age.CompareTo(compared.Age);
            }
        }
    }
}
