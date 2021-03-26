using AnimalPark.Common;
using AnimalPark.Utils;
using AnimalPark.Utils.Factories;
using AnimalPark.ViewModel.BaseSpeciesViewModels;
using System.Collections.Generic;
using AnimalPark.Model.Bases;
using AnimalPark.Model.Enums;
using AnimalPark.Model.Interfaces;
using static AnimalPark.Model.Enums.Species;

namespace AnimalPark.ViewModel
{
    /// <summary>
    /// Main class handling animal creation
    /// </summary>
    public class MainViewModel : BindableBase
    {
        #region Setup

        public MainViewModel()
        {
            Category = Category.Mammal;
            AnimalListViewModel = new AnimalListViewModel();
        }

        #endregion

        public Category Category
        {
            get => _category;
            set
            {
                _category = value;
                UpdateCategoryControl();
                OnPropertyChanged(nameof(Category));
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

        public List<Species> SpeciesTypes
        {
            get => IsCheckedListAllAnimals
                ? EnumHelper.GetAllValuesAs<Species>(typeof(Species))
                : EnumHelper.GetSpeciesByCategory(Category);
        }

        public Species SelectedSpecies
        {
            get => _selectedSpecies;
            set
            {
                _selectedSpecies = value;
                OnSpeciesSelected();
                OnPropertyChanged(nameof(SelectedSpecies));
            }
        }

        public AnimalListViewModel AnimalListViewModel
        {
            get => _animalListViewModel;
            set
            {
                if (value != null)
                {
                    _animalListViewModel = value;
                    OnPropertyChanged(nameof(AnimalListViewModel));
                }
            }
        }

        public bool CategoryListEnabled
        {
            get => !IsCheckedListAllAnimals;
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

            if (IsCheckedListAllAnimals)
            {
                CategoryControl.OnSpeciesSelected(SelectedSpecies);
            }
            else
            {
                OnPropertyChanged(nameof(SpeciesTypes));
                SelectedSpecies = Unknown;
            }
        }

        private void OnSpeciesSelected()
        {
            if (IsCheckedListAllAnimals)
            {
                Category = EnumHelper.FindCorrespondingCategory(SelectedSpecies);
            }

            CategoryControl.OnSpeciesSelected(SelectedSpecies);
        }

        private void CreateAnimal()
        {
            Animal = FactoryBuilder.GetAnimalFactory(Category)?.CreateAnimal(this, CategoryControl);
            AnimalListViewModel.AddAnimal(Animal);
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
                OnPropertyChanged(nameof(CategoryListEnabled));
                OnPropertyChanged(nameof(SpeciesTypes));
            }
        }

        #region Commands

        private RelayCommand _createAnimalCommand;

        public RelayCommand CreateAnimalCommand
        {
            get => _createAnimalCommand ??
                   (_createAnimalCommand = new RelayCommand(ex => { CreateAnimal(); }, canEx => AllDataFilled));
        }

        public bool AllDataFilled => AnimalDataFilled && CategoryDataFilled;

        private bool CategoryDataFilled { get; set; }

        private bool AnimalDataFilled => !string.IsNullOrEmpty(Name) || Age <= 0;

        #endregion

        #region Private Fields

        private string _name;
        private int _age;
        private Gender _gender;
        private Category _category;

        private ICategory _categoryControl;
        private Species _selectedSpecies;

        private Animal _animal;
        private AnimalListViewModel _animalListViewModel;

        #endregion
    }
}
