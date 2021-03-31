using System;
using AnimalPark.Common;
using AnimalPark.Utils;
using AnimalPark.Utils.Factories;
using System.Collections.Generic;
using System.Linq;
using AnimalPark.Model.Bases;
using AnimalPark.Model.Enums;
using AnimalPark.Model.Interfaces;
using AnimalPark.Utils.Validators;
using AnimalPark.ViewModel.BaseSpeciesViewModels;
using static AnimalPark.Model.Enums.Species;
using static AnimalPark.Utils.Validators.ValidationService;
using static AnimalPark.Utils.Validators.ValidationService.ValidationType;

namespace AnimalPark.ViewModel
{
    /// <summary>
    /// Main class handling animal creation, and dynamic creation of the controls
    /// containing properties specific for each animal category / species type
    /// </summary>
    public class MainViewModel : BindableBase
    {
        #region Setup

        public MainViewModel()
        {
            ResetSettings(); 
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

        public List<Species> SpeciesList
        {
            get => IsCheckedListAllAnimals
                ? EnumHelper.GetAllValuesAs<Species>(typeof(Species)).Where(s => s != Unknown).ToList()
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
                OnPropertyChanged(nameof(SpeciesList));
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
            RegisterEventHandler();
        }

        private void RegisterEventHandler()
        {
            if (CategoryControl.SelectedSpeciesControl != null)
            {
                CategoryControl.SelectedSpeciesControl.ChildDataErrorDelegate += (isChildValid) =>
                {
                    ChildViewModelValid = isChildValid;
                    OnPropertyChanged(nameof(IsViewModelValid));
                };
            }
        }

        private void CreateAnimal()
        {
            if (SelectedSpecies == Unknown)
            {
                ErrorMessageDelegate?.Invoke("Select a species type first.");
            }
            else if (!IsViewModelValid)
            {
                ErrorMessageDelegate?.Invoke("Some fields are empty or invalid!");
            }
            else
            {
                Animal = FactoryBuilder.GetAnimalFactory(Category)?.CreateAnimal(this, CategoryControl);
                AnimalListViewModel.AddAnimal(Animal);
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                ValidateProperty(nameof(Name), value, StringValidation);
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(IsViewModelValid));
            }
        }

        public string Age 
        {
            get => _age;
            set
            {
                _age = value;
                ValidateProperty(nameof(Age), value, NumberValidation);
                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(IsViewModelValid));
            }
        }

        public Gender Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        public Animal Animal
        {
            get => _animal;
            set
            {
                _animal = value;
                OnPropertyChanged(nameof(Animal));
            }
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
                OnPropertyChanged(nameof(SpeciesList));
            }
        }

        #region Events

        public Action<string> ErrorMessageDelegate;

        #endregion

        #region Commands

        private RelayCommand _createAnimalCommand;

        public RelayCommand CreateAnimalCommand
        {
            get => _createAnimalCommand ??
                   (_createAnimalCommand = new RelayCommand(ex => { CreateAnimal(); }));
        }

        #endregion

        #region Validation

        private void ValidateProperty(string property, object value, ValidationType validationType)
        {
            bool isValid = ValidationService.IsValid(validationType, property, value, out ICollection<string> errors);
             
            if (!isValid)
            {
                Errors[property] = errors;
                RaiseErrorsChanged(property);
            } 
            else if (Errors.ContainsKey(property))
            {
                Errors.Remove(property);
                RaiseErrorsChanged(property);
            }

            OnPropertyChanged(nameof(IsViewModelValid));
        }

        private bool IsViewModelValid
        {
            get => !HasErrors && SelectedSpecies != Unknown && !string.IsNullOrWhiteSpace(Name) && int.Parse(Age) > 0 && ChildViewModelValid;
        }

        private void ResetSettings()
        {
            Category = Category.Mammal;
            SelectedSpecies = Unknown;
            ChildViewModelValid = false;
        }

        private bool ChildViewModelValid { get; set; }
        #endregion

        #region Private Fields

        private string _name;
        private string _age;
        private Gender _gender;
        private Category _category;

        private ICategory _categoryControl;
        private Species _selectedSpecies;

        private Animal _animal;
        private AnimalListViewModel _animalListViewModel;

        #endregion
    }
}
