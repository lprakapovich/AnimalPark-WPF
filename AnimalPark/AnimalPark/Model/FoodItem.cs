using System;
using System.Collections.Generic;
using AnimalPark.Utils;

namespace AnimalPark.Model
{
    [Serializable]
    public class FoodItem
    {
        private string _name;

        private List<string> _ingredients;

        public FoodItem()
        {
        }

        public FoodItem(string name, List<string> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
        }

        public string Name
        {
            get => _name;
            set
            {
                if (value != null)
                {
                    _name = value;
                }
            }
        }

        public List<string> Ingredients
        {
            get => _ingredients;
            set
            {
                if (value != null)
                {
                    _ingredients = value;
                }
            }
        }

        public override string ToString()
        {
            return Name + ", Ingredients - " + Ingredients.GetListed();
        }
    }
}
