using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using AnimalPark.Common;
using AnimalPark.Model;
using AnimalPark.Model.Bases;
using AnimalPark.Utils;

namespace AnimalPark.ViewModel
{
    public class FoodManagerViewModel : BindableCollection<FoodItem> 
    {
        #region Private fields

        private Dictionary<string, List<string>> _animalFoodItemsResolver;

        private FoodItem _selectedFoodItem;
        #endregion

        #region Setup

        public FoodManagerViewModel()
        {
            Collection = new ObservableCollection<FoodItem>(); 
            FoodAdderViewModel = new FoodAdderViewModel();
            AnimalFoodItemsResolver = new Dictionary<string, List<string>>();

            Collection.CollectionChanged += FoodItemsOnCollectionChanged;
            FoodAdderViewModel.CreateFoodItem += item => Collection.Add(item);
        }

        #endregion
         
        #region API

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

        public FoodItem SelectedFoodItem
        {
            get => _selectedFoodItem;
            set
            {
                _selectedFoodItem = value;
                OnPropertyChanged(nameof(SelectedFoodItem));
            }
        }


        public void LinkAnimalToFoodItem(Animal animal)
        {
            if (AnimalFoodItemsResolver.ContainsKey(animal.Id))
            {
                if (AnimalFoodItemsResolver[animal.Id].Contains(SelectedFoodItem.Name))
                {
                    MessageDelegate?.Invoke($"{animal.Name} already has {SelectedFoodItem.Name} in its food schedule!");
                }
                else
                {
                    AnimalFoodItemsResolver[animal.Id].Add(SelectedFoodItem.Name);
                }
            }
            else
            {
                AnimalFoodItemsResolver.Add(animal.Id, new List<string>() { SelectedFoodItem.Name });
            }
        }

        public List<string> GetAnimalSchedule(string animalId)
        {
            return AnimalFoodItemsResolver.ContainsKey(animalId) ? PrepareFoodItemsForDisplay(AnimalFoodItemsResolver[animalId]) : null;
        }

        private List<string> PrepareFoodItemsForDisplay(List<string> foodItemNames)
        {
            List<string> foodItemDescriptions = new List<string>();

            foreach (var name in foodItemNames)
            {
                foodItemDescriptions.Add(Collection.FirstOrDefault(i => i.Name.Equals(name))?.ToString());
            }
            
            return foodItemDescriptions;
        }

        #endregion

        #region Commands 


        private RelayCommand _addFoodItemCommand;
        public RelayCommand AddFoodItemCommand => _addFoodItemCommand ??
                                                  (_addFoodItemCommand = new RelayCommand(ex => AddFoodItemDialog?.Invoke(this, new EventArgs())));

        private RelayCommand _deleteFoodItem;
        public RelayCommand DeleteFoodItem => _deleteFoodItem ??
                                              (_deleteFoodItem = new RelayCommand(ex =>
                                              {
                                                  if (!AnimalFoodItemsResolver.ContainsValueInList(SelectedFoodItem.Name))
                                                  {
                                                      Collection.Remove(SelectedFoodItem);
                                                  }
                                                  else
                                                  {
                                                      MessageDelegate?.Invoke("Can't remove food item since some animals have it in their food schedule!");
                                                  }
                                              }, canEx => SelectedFoodItem != null));

        private RelayCommand _cancelCommand;
        private RelayCommand CancelCommand => _cancelCommand ??
                                              (_cancelCommand = new RelayCommand(ex => CloseDialog?.Invoke(this, new EventArgs())));

        public FoodAdderViewModel FoodAdderViewModel { get; set; }

        #endregion

        #region Events

        public Action<string> MessageDelegate;

        public event EventHandler AddFoodItemDialog;

        public event EventHandler CloseDialog;

        private void FoodItemsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    MessageBox.Show("New food item added!");
                    break;

                case NotifyCollectionChangedAction.Remove:
                    MessageBox.Show("Food item deleted!");
                    break;
            }
        }

        #endregion

        public void Reset()
        {
            SelectedFoodItem = null;
        }
    }
}
