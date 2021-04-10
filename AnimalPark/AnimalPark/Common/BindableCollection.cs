using System.Collections.Generic;
using System.Collections.ObjectModel;
using AnimalPark.Model.Interfaces;
using SerializerUtility;

namespace AnimalPark.Common
{
    /// <summary>
    /// Generic abstract class encapsulating the logic required
    /// to manipulate on collections
    /// </summary>
    /// <typeparam name="T"> type parameter </typeparam>
    public abstract class BindableCollection<T> : AbstractNotifier, ICollectionHandler<T>, ISerializable<ICollection<T>> 
    {
        public ObservableCollection<T> Collection { get; set; }

        public void Add(T t)
        {
            if (t != null)
            {
                Collection.Add(t);
            }
        }

        public void RemoveAt(int position)
        {
            if (Collection.Count > position && position >= 0)
            {
                Collection.RemoveAt(position);
            }
        }

        public void ReplaceAt(int position, T t)
        {
            if (Collection.Count > position && position >= 0)
            {
                Collection[position] = t;
            }
        }

        public T Get(int position)
        {
            return Collection.Count > position && position >= 0 ? Collection[position] : default;
        }

        public void SerializeBinary(string filename)
        {
           SerializationUtils.SerializeDataToBinary(filename, Collection);
        }

        public void SerializeXml(string filename)
        {
            SerializationUtils.SerializeToXml(filename, Collection);
        }

        public void DeserializeBinary(string filename) 
        {
            Collection = SerializationUtils.DeserializeFromBinary<ObservableCollection<T>>(filename);
            OnPropertyChanged(nameof(Collection));
        }

        public void DeserializeXml(string filename)
        {
            Collection = SerializationUtils.DeserializeFromXml<ObservableCollection<T>>(filename);
            OnPropertyChanged(nameof(Collection));
        }

        public void ClearCollection()
        {
            Collection.Clear();
        }
    }
}
