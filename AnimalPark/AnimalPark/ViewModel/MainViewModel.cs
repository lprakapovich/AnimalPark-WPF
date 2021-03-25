using AnimalPark.Common;
using AnimalPark.Model;
using AnimalPark.Model.BaseClasses;
using AnimalPark.Utils;
using AnimalPark.Utils.Factories;
using AnimalPark.ViewModel.BaseSpeciesViewModels;
using System.Collections.Generic;
using static AnimalPark.Model.Species;

namespace AnimalPark.ViewModel
{
    public class MainViewModel : BindableBase
    {
        #region Setup

        public MainViewModel()
        {
            Category = Category.Mammal;
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

        /// <summary>
        /// If ListAllSpecies is checked,
        /// category control gets informed about
        /// and updates GUI accordingly
        /// </summary>
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

        public bool CategoryListEnabled
        {
            get => !IsCheckedListAllAnimals;
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
            Animal = FactoryBuilder.GetAnimalFactory(Category).CreateAnimal(this, CategoryControl);
        }


        //public Species SpeciesType
        //{
        //    get => SpeciesTypes[SelectedSpeciesTypeIndex == -1 ? 0 : SelectedSpeciesTypeIndex];
        //    set => OnPropertyChanged(nameof(SpeciesType));
        //}

        //public int SelectedSpeciesTypeIndex
        //{
        //    get => _selectedSpeciesTypeIndex;
        //    set
        //    {
        //        _selectedSpeciesTypeIndex = value;
        //        //UpdateSpeciesControl();
        //        OnPropertyChanged(nameof(SelectedSpeciesTypeIndex));
        //        OnPropertyChanged(nameof(SpeciesType));
        //    }
        //}


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

        public bool AllDataFilled => AnimalDataFilled && CategoryDataFilled && SpeciesDataFilled;

        private bool SpeciesDataFilled { get; set; }

        private bool CategoryDataFilled { get; set; }

        private bool AnimalDataFilled => !string.IsNullOrEmpty(Name) || Age <= 0;

        #endregion

        #region Private Fields

        /// <summary>
        /// Main View model handles input for
        /// all the common fields from the Animal class
        /// </summary>
        private string _name;
        private int _age;
        private Gender _gender;
        private Category _category;

        /// <summary>
        /// Created animal
        /// </summary>
        private Animal _animal;

        /// <summary>
        /// Selected animal category, e.g. Mammal
        /// </summary>
        private ICategory _categoryControl;

        private Species _selectedSpecies;

        #endregion
    }
}
