using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AnimalPark.Utils
{
    public static class ObservableCollectionHelper 
    {
        public static void Sort<T>(this ObservableCollection<T> collection, Comparison<T> comparison)
        {
            var sortableList = new List<T>(collection);

            sortableList.Sort(comparison);

            collection = new ObservableCollection<T>(sortableList);
        }
    }
}
