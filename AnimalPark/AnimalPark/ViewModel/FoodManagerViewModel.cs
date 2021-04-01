using System.Collections.Generic;
using AnimalPark.Common;
using AnimalPark.Model;

namespace AnimalPark.ViewModel
{
    public class FoodManagerViewModel : BindableBase
    {
        #region Private fields

        private List<FoodItem> _foodItems;

        private Dictionary<string, List<string>> _animalFoodItemsResolver;

        #endregion

        #region Setup

        public FoodManagerViewModel()
        {
            FoodItems = new List<FoodItem>()
            {
                new FoodItem() { Name = "FoodItem 1"},
                new FoodItem() { Name = "FoodItem 2"}
            };

            AnimalFoodItemsResolver = new Dictionary<string, List<string>>();
        }

        #endregion

        #region API

        /// <summary>
        /// Food items available for animals
        /// </summary>
        public List<FoodItem> FoodItems
        {
            get => _foodItems;
            set
            {
                if (value != null)
                {
                    _foodItems = value;
                    OnPropertyChanged(nameof(FoodItems));
                }
            }
        }

        public Dictionary<string, List<string>> AnimalFoodItemsResolver
        {
            get => _animalFoodItemsResolver;
            set
            {
                if (value != null)
                {
                    _animalFoodItemsResolver = value;
                }
            }
        }

        public void AddFoodItemToAnimal(string footItemName, string animalId)
        {

        } 

        #endregion
    }
}
