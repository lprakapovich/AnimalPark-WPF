using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalPark.Model
{
    public class FoodItem
    {
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
