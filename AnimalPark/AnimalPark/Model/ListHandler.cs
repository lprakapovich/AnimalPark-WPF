using System.Collections.Generic;
using AnimalPark.Model.Interfaces;

namespace AnimalPark.Model
{
    public class ListHandler<T> : IListHandler<T>
    {
        public List<T> List { get; set; }

        public void RemoveAt(int position)
        {
            if (List.Count > position && position >= 0)
            {
                List.RemoveAt(position);
            }
        }

        public void ReplaceAt(int position, T t)
        {
            if (List.Count > position && position >= 0)
            {
                List[position] = t;
            }
        }

        public T Get(int position)
        {
            return List.Count > position && position >= 0 ? List[position] : default;
        }
    }
}
