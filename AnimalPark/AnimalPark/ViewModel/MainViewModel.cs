using System;
using System.Collections.Generic;
using System.Linq;
using AnimalPark.Common;
using AnimalPark.Model;
using AnimalPark.Model.BaseClasses;
using AnimalPark.Utils.Converters;
using AnimalPark.Utils.Factories;
using AnimalPark.ViewModel.BaseSpeciesViewModels;
using AnimalPark.ViewModel.SpeciesViewModels;

namespace AnimalPark.ViewModel
{
    public class MainViewModel : BindableBase
    {
        #region Private Fields

        private string _name; 
        private int _age;
        private Gender _gender;
        private Species _speciesType;
        private Category _category;

        private Animal _animal;

        private Dictionary<Category, List<Species>> _associatedSpecies;

        private ICategory _categoryControl;
        private ISpecies _speciesControl; 

        #endregion

        #region Setup

        public MainViewModel()
        {
            CategoryControl = new MammalViewModel();

            _associatedSpecies = new Dictionary<Category, List<Species>>()
            {
                {
                    Model.Category.Mammal, new List<Species> {Species.Raccoon}
                },
                {
                    Model.Category.Fish, new List<Species>() {Species.JellyFish, Species.Prawn}
                }
            };
        }

        #endregion

        public Category Category 
        {
            get => _category;
            set
            {
                _category = value;

                SelectedSpeciesTypeIndex = 0;

                UpdateCategoryControl();
                OnPropertyChanged(nameof(Category));
                OnPropertyChanged(nameof(SpeciesTypes)); 
            }
        }

        private void UpdateCategoryControl()
        {
            switch (Category)
            {
                case Category.Mammal: 
                    CategoryControl = new MammalViewModel();
                    break;
                case Category.Fish:
                    CategoryControl = new FishViewModel();
                    break;
                default:
                    CategoryControl = new MammalViewModel();
                    break;
            }

            SpeciesControl = null;
        }

        private void UpdateSpeciesControl()
        {
            switch (SpeciesType) 
            {
                case Species.JellyFish:
                    SpeciesControl = new JellyFishViewModel();
                    break;
                case Species.Prawn:
                    SpeciesControl = new PrawnViewModel();
                    break;
                case Species.Raccoon:
                    SpeciesControl = new RaccoonViewModel();
                    break;
                default: 
                    SpeciesControl = new JellyFishViewModel();
                    break;
            }
        }

        private void CreateAnimal()
        {
            Animal = FactoryBuilder.GetAnimalFactory(Category).CreateAnimal(this, CategoryControl, SpeciesControl);
        }

        public List<Species> SpeciesTypes
        {
            get => IsCheckedListAllAnimals ? GetAllSpecies() : _associatedSpecies?[Category];
        }

        public Species SpeciesType
        {
            get => SpeciesTypes[SelectedSpeciesTypeIndex == -1 ? 0 : SelectedSpeciesTypeIndex];
            set
            {
                _speciesType = value;
                OnPropertyChanged(nameof(SpeciesType));
            }
        }


        private int _selectedSpeciesTypeIndex;
        public int SelectedSpeciesTypeIndex
        {
            get => _selectedSpeciesTypeIndex;
            set
            {
                _selectedSpeciesTypeIndex = value;

                UpdateSpeciesControl();
                OnPropertyChanged(nameof(SelectedSpeciesTypeIndex));
                OnPropertyChanged(nameof(SpeciesType));
            }
        }


        public ICategory CategoryControl 
        {
            get => _categoryControl;
            set
            {
                _categoryControl = value;
                OnPropertyChanged(nameof(CategoryControl));
            }
        }

        public ISpecies SpeciesControl
        {
            get => _speciesControl;
            set
            {
                _speciesControl = value;
                OnPropertyChanged(nameof(SpeciesControl));
            }
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Age
        {
            get => _age;
            set => _age = value;
        }

        public Gender Gender
        {
            get => _gender;
            set => _gender = value;
        }

        public Animal Animal
        {
            get => _animal;
            set => _animal = value;
        }

        private bool _isCheckedListAllAnimals;
        public bool IsCheckedListAllAnimals
        {
            get => _isCheckedListAllAnimals;
            set
            {
                _isCheckedListAllAnimals = value;
                OnPropertyChanged(nameof(IsCheckedListAllAnimals));
                OnPropertyChanged(nameof(SpeciesTypes));
            }
        }

        #region Commands

        private RelayCommand _createAnimalCommand;

        public RelayCommand CreateAnimalCommand
        {
            get => _createAnimalCommand ?? 
                   (_createAnimalCommand = new RelayCommand(ex => CreateAnimal()));
        }

        #endregion

        #region Private Fields

        private List<Species> GetAllSpecies()
        { 
            List<Species> _species = new List<Species>();

            foreach (Species value in Enum.GetValues(typeof(Species)))
            {
                _species.Add(value);
            }

            return _species;
        } 

        #endregion
    }
}
