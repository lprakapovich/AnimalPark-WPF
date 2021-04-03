using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AnimalPark.Common;
using AnimalPark.Model;

namespace AnimalPark.ViewModel
{
    public class FoodAdderViewModel : BindableCollection<string>
    {
        #region Private fields

        private string _foodItemName;

        private string _selectedIngredient;

        #endregion

        #region Setup

        public FoodAdderViewModel()
        {
            Collection = new ObservableCollection<string>()
            {
                "ing 1",
                "ing 2"
            };
        }

        #endregion

        #region API

        public string FoodItemName
        {
            get => _foodItemName;
            set
            {
                _foodItemName = value;
                OnPropertyChanged(nameof(FoodItemName));
            }
        }

        public string SelectedIngredient
        {
            get => _selectedIngredient;
            set
            {
                _selectedIngredient = value;
                OnPropertyChanged(nameof(SelectedIngredient));
            }
        }

        #endregion

        #region Events

        public event EventHandler CloseWindow;

        public Action<FoodItem> CreateFoodItem;

        #endregion

        #region Commands

        private RelayCommand _addIngredientCommand;
        public RelayCommand AddIngredientCommand => _addIngredientCommand ??
                                                    (_addIngredientCommand =
                                                        new RelayCommand(ex => Collection.Add(FoodItemName)));

        private RelayCommand _deleteIngredientCommand;
        public RelayCommand DeleteIngredientCommand => _deleteIngredientCommand ??
                                                       (_deleteIngredientCommand = new RelayCommand(ex =>
                                                           Collection.Remove(SelectedIngredient), canEx => SelectedIngredient != null));

        private RelayCommand _closeWindowCommand;
        public RelayCommand CloseWindowCommand => _closeWindowCommand ?? (_closeWindowCommand = new RelayCommand(ex => CloseWindow?.Invoke(this, new EventArgs())));

        private RelayCommand _createFoodItemCommand;

        public RelayCommand CreateFoodItemCommand => _createFoodItemCommand ??
                                                     (_createFoodItemCommand = new RelayCommand(ex =>
                                                     {
                                                         CreateFoodItem?.Invoke(new FoodItem() { Name = FoodItemName, Ingredients = Collection.ToList()});
                                                         CloseWindow?.Invoke(this, new EventArgs());
                                                     }));

        #endregion
    }
}
 