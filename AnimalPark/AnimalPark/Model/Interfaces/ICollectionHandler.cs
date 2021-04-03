using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AnimalPark.Model.Interfaces
{
    public interface ICollectionHandler<T> 
    {
        /// <summary>
        /// A list of objects handler by the implementing ListHandler
        /// </summary>
        ObservableCollection<T> Collection { get; set; } 

        /// <summary>
        /// Add new element to the collection
        /// </summary>
        /// <param name="t"> New element, not null </param>
        void Add(T t);

        /// <summary>
        /// Remove element at a given position, if exists
        /// </summary>
        /// <param name="position"> Index in the list </param>
        void RemoveAt(int position);

        /// <summary>
        /// Replace element with a new one at a given position, if exists
        /// </summary>
        /// <param name="position"> Index in the list </param>
        /// <param name="t"> A newly added element </param>
        void ReplaceAt(int position, T t);

        /// <summary>
        /// Get element at the given position, if exists
        /// </summary>
        /// <param name="position"> Index in the list </param>
        /// <returns> Instance of type T, or default </returns>
        T Get(int position);

        /// <summary>
        /// Calls a chained ToString() on each element in the collection
        /// </summary>
        /// <returns> Array of object descriptions </returns>
        string[] GetElementsDescription();
    }
}
