using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalPark.Model
{
    public class FoodManager
    {
        public List<FoodItem> FoodItems { get; set; }

        /// <summary>
        /// Key - an id of the food item
        /// Value - ids of all the animals consuming the food item
        /// </summary>
        public Dictionary<string, List<string>> AnimalFoodItemMapper { get; set; }
    }
}
