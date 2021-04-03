using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using AnimalPark.Common;
using AnimalPark.Model;

namespace AnimalPark.ViewModel
{
    public class FoodManagerViewModel : BindableCollection<FoodItem> 
    {
        #region Private fields

        private Dictionary<string, List<string>> _animalFoodItemsResolver;

        #endregion

        #region Setup

        public FoodManagerViewModel()
        {

            Collection = new ObservableCollection<FoodItem>()
            {
                new FoodItem() { Name = "FoodItem 1"},
                new FoodItem() { Name = "FoodItem 2"}
            };

            Collection.CollectionChanged += FoodItemsOnCollectionChanged;

            AnimalFoodItemsResolver = new Dictionary<string, List<string>>();

            FoodAdderViewModel = new FoodAdderViewModel();

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

        #endregion

        public void test()
        {
            MessageBox.Show("HI");
        }

        #region Commands 


        private RelayCommand _addFoodItemCommand;
        public RelayCommand AddFoodItemCommand => _addFoodItemCommand ??
                                                  (_addFoodItemCommand = new RelayCommand(ex =>
                                                  {
                                                     // FoodAdderViewModel = new FoodAdderViewModel();

                                                      AddFoodItemDialog?.Invoke(this, new EventArgs()); 
                                                  }));

        private RelayCommand _deleteFoodItem;
        public RelayCommand DeleteFoodItem => _deleteFoodItem ??
                                              (_deleteFoodItem = new RelayCommand(ex => Collection.Remove(SelectedFoodItem), canEx => SelectedFoodItem != null));

        private RelayCommand _cancelCommand;
        private RelayCommand CancelCommand => _cancelCommand ??
                                              (_cancelCommand = new RelayCommand(ex => CloseDialog?.Invoke(this, new EventArgs())));
        
        public FoodItem SelectedFoodItem { get; set; }

        public FoodAdderViewModel FoodAdderViewModel { get; set; }

        #endregion

        #region Events


        public event EventHandler AddFoodItemDialog;

        public event EventHandler CloseDialog;

        private void FoodItemsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    MessageBox.Show("add new food");
                    break;

                case NotifyCollectionChangedAction.Remove:
                    MessageBox.Show("remove a food");
                    break;

                case NotifyCollectionChangedAction.Replace:
                    break;

            }
        }

        #endregion
    }
}
