using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AnimalPark.Common;
using AnimalPark.Model.Bases;
using AnimalPark.Model.Concretes;
using AnimalPark.Model.Enums;
using AnimalPark.Utils.Comparators;

namespace AnimalPark.ViewModel
{
    /// <summary>
    /// Class managing the list of animals, used instead of AnimalManager mentioned in the
    /// instructions to follow WPF naming conventions
    /// </summary>
    public class AnimalListViewModel : BindableBase
    {
        #region Private Fields

        private ObservableCollection<Animal> _animals;
        private Animal _selectedAnimal;

        private SortingStrategy _sortingStrategy;

        #endregion

        public AnimalListViewModel()
        {
            Animals = new ObservableCollection<Animal>()
            {
                new JellyFish("vl", 10, Gender.Female, true, JellyFishType.BlackSeaNettle),
                new JellyFish("axl", 1, Gender.Female, true, JellyFishType.BlackSeaNettle),
                new JellyFish("abl", 1, Gender.Female, true, JellyFishType.BlackSeaNettle),
                new JellyFish("bl", 15, Gender.Female, true, JellyFishType.BlackSeaNettle),
                new JellyFish("al", 15, Gender.Female, true, JellyFishType.BlackSeaNettle)
            };

            SelectedAnimal = null;
        }

        #region API
        public ObservableCollection<Animal> Animals
        {
            get => _animals;
            set
            {
                if (value != null)
                {
                    _animals = value;
                    OnPropertyChanged(nameof(Animals));
                }
            }
        }

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
                SortAnimalList();
                OnPropertyChanged(nameof(SortingStrategy));
            }
        }

        public string SelectedAnimalDescription => SelectedAnimal?.ExtraInfo;

        public List<string> SelectedAnimalEatingHabits => SelectedAnimal?.FoodSchedule.EatingHabitsDescription;

        public bool IsAnimalSelected => SelectedAnimal != null;

        public void AddAnimal(Animal animal)
        {
            if (animal != null)
            {
                Animals.Add(animal);
            }
        }

        #endregion

        #region Commands

        private RelayCommand _deleteAnimalCommand;

        public RelayCommand DeleteAnimalCommand =>
            _deleteAnimalCommand ??
            (_deleteAnimalCommand = new RelayCommand(e => DeleteAnimal(), canEx => SelectedAnimal != null));

        #endregion

        #region Private methods

        private void DeleteAnimal()
        {
            Animals.Remove(SelectedAnimal);
        }
        
        /// <summary>
        /// Invoked each time the sorting option is changed, passes a resolved Comparer
        /// to the Sort() method and updates the observable collection with a sorted list
        /// </summary>
        private void SortAnimalList()
        {
            List<Animal> sortedAnimals = Animals.ToList();
            sortedAnimals.Sort(Comparer.ResolveSortingStrategy(SortingStrategy));
            Animals = new ObservableCollection<Animal>(sortedAnimals);
            OnPropertyChanged(nameof(Animals));
        }

        #endregion

    }
}
