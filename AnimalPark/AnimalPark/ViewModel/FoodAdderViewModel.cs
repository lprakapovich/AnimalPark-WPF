using System;
using System.Collections.ObjectModel;
using System.Linq;
using AnimalPark.Common;
using AnimalPark.Model;
using AnimalPark.Utils;

namespace AnimalPark.ViewModel
{
    public class FoodAdderViewModel : BindableCollection<string>
    {
        #region Private fields

        private string _foodItemName;

        private string _ingredientName;

        private string _selectedIngredient;

        #endregion

        #region Setup

        public FoodAdderViewModel()
        {
            Collection = new ObservableCollection<string>();
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

        public string IngredientName 
        {
            get => _ingredientName;
            set
            {
                _ingredientName = value;
                OnPropertyChanged(nameof(IngredientName));
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

        public Action<string> MessageDelegate;

        #endregion

        #region Commands

        private RelayCommand _addIngredientCommand;
        public RelayCommand AddIngredientCommand => _addIngredientCommand ??
                                                    (_addIngredientCommand =
                                                        new RelayCommand(ex =>
                                                            {
                                                                Collection.Add(IngredientName);
                                                                IngredientName = null;
                                                            },
                                                            canExecute => !(string.IsNullOrEmpty(IngredientName) && string.IsNullOrWhiteSpace(IngredientName))));

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
                                                         if (InvalidInput)
                                                         {
                                                             MessageDelegate?.Invoke("Specify the name and add at least one ingredient!");
                                                         }
                                                         else
                                                         {
                                                             CreateFoodItem?.Invoke(new FoodItem(FoodItemName, Collection.ToList()));
                                                             Reset();
                                                             CloseWindow?.Invoke(this, new EventArgs());
                                                         }
                                                     }));

        public bool InvalidInput => string.IsNullOrEmpty(FoodItemName) || string.IsNullOrWhiteSpace(FoodItemName) || Collection.IsEmpty();

        #endregion

        #region Private methods

        private void Reset()
        {
            FoodItemName = null;
            IngredientName = null;
            SelectedIngredient = null;
        }

        #endregion
    }
}
 