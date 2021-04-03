﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using AnimalPark.Common;
using AnimalPark.Model.Bases;
using AnimalPark.Model.Enums;
using AnimalPark.Utils.Comparators;

namespace AnimalPark.ViewModel
{
    /// <summary>
    /// Class managing the list of animals, used instead of AnimalManager mentioned in the
    /// instructions to follow WPF naming conventions
    /// </summary>
    
    public class AnimalListViewModel : BindableCollection<Animal>
    {
        #region Private Fields

        private Animal _selectedAnimal;

        private SortingStrategy _sortingStrategy;

        #endregion

        #region Setup

        public AnimalListViewModel()
        {
            Collection = new ObservableCollection<Animal>();
            SelectedAnimal = null;
            Collection.CollectionChanged += AnimalsCollectionOnCollectionChanged;
        }

        #endregion

        #region API

        public Animal SelectedAnimal
        {
            get => _selectedAnimal;
            set
            { 
                _selectedAnimal = value;
                OnPropertyChanged(nameof(SelectedAnimal));
                OnPropertyChanged(nameof(IsAnimalSelected));
                OnPropertyChanged(nameof(SelectedAnimalDescription));
                OnPropertyChanged(nameof(SelectedAnimalEatingHabits));
            }
        }

        public SortingStrategy SortingStrategy
        {
            get => _sortingStrategy;
            set
            {
                _sortingStrategy = value;
                SortCollection();
                OnPropertyChanged(nameof(SortingStrategy));
            }
        }

        public string SelectedAnimalDescription => SelectedAnimal?.ExtraInfo;

        public List<string> SelectedAnimalEatingHabits => SelectedAnimal?.FoodSchedule.EatingHabitsDescription;

        public bool IsAnimalSelected => SelectedAnimal != null;

        #endregion

        #region Commands

        private RelayCommand _deleteAnimalCommand;

        public RelayCommand DeleteAnimalCommand =>
            _deleteAnimalCommand ??
            (_deleteAnimalCommand = new RelayCommand(e => Collection.Remove(SelectedAnimal), canEx => SelectedAnimal != null));

        #endregion

        #region Private methods

        /// <summary>
        /// Invoked each time the sorting option is changed, passes a resolved Comparer
        /// to the Sort() method and updates the observable collection with a sorted list
        /// </summary>
        /// 
        private void SortCollection()
        {
            List<Animal> sortedAnimals = Collection.ToList();
            sortedAnimals.Sort(Comparer.ResolveSortingStrategy(SortingStrategy));
            Collection = new ObservableCollection<Animal>(sortedAnimals);
            OnPropertyChanged(nameof(Collection));
        }

        #endregion

        #region Events
        private void AnimalsCollectionOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    MessageBox.Show("add new animal");
                    break;

                case NotifyCollectionChangedAction.Remove:
                    MessageBox.Show("remove an animal");
                    break;

                case NotifyCollectionChangedAction.Replace:
                    break;

            }
        }

        #endregion
    }
}
