using System;
using System.Collections.ObjectModel;
using System.Linq;
using AnimalPark.Common;
using AnimalPark.Model;
using AnimalPark.Utils;

namespace AnimalPark.ViewModel
{
    /// <summary>
    /// Data context for a view where creating a new food item and adding new ingredients occurs
    /// </summary>
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
        /// <summary>
        /// Delegate to close a window in case no changes must be made
        /// </summary>
        public event EventHandler CloseWindow;

        /// <summary>
        /// Delegate with a newly created food item passed as a parameter
        /// </summary>
        public Action<FoodItem> CreateFoodItem;

        /// <summary>
        /// Delegate to display a message to the user
        /// </summary>
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

        private RelayCommand _editIngredientCommand;
        public RelayCommand EditIngredientCommand => _editIngredientCommand ??
                                                     (_editIngredientCommand = new RelayCommand(ex =>
                                                     {
                                                         IngredientName = SelectedIngredient;
                                                         Collection.Remove(SelectedIngredient);
                                                     }, canEx => SelectedIngredient != null));

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
            Collection.Clear();
        }

        #endregion
    }
}
 