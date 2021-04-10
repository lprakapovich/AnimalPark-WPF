using System;
using AnimalPark.Common;
using AnimalPark.Utils;
using AnimalPark.Utils.Factories;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AnimalPark.Model.Bases;
using AnimalPark.Model.Enums;
using AnimalPark.Model.Interfaces;
using AnimalPark.ViewModel.BaseSpeciesViewModels;
using static AnimalPark.Model.Enums.FileExtension;
using static AnimalPark.Model.Enums.Species;
using static AnimalPark.Utils.FileExtensionHelper;
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

            FoodManagerViewModel = new FoodManagerViewModel();

            AnimalListViewModel.AnimalFoodScheduleDelegate +=
                animal => animal != null ? FoodManagerViewModel.GetAnimalSchedule(animal) : null;
        }

        #endregion

        /// <summary>
        /// Public properties used mostly as bindings in GUI layer
        /// </summary>
        #region API

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

        public FoodManagerViewModel FoodManagerViewModel
        {
            get => _foodManagerViewModel;
            set
            {
                if (value != null)
                {
                    _foodManagerViewModel = value;
                }
            }
        }


        public void ResetApplication() 
        {
            AnimalListViewModel.ClearCollection();
            FoodManagerViewModel.ClearCollection(); 
            ResetControls();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Triggered each time a new category is selected
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
                OnPropertyChanged(nameof(SpeciesList));
                SelectedSpecies = Unknown;
            }
        }

        /// <summary>
        /// Triggered in "Collection all species" mode, therefore firstly determines
        /// to which category a species belongs, and then updates the control
        /// </summary>
        private void OnSpeciesSelected()
        {
            if (IsCheckedListAllAnimals)
            {
                Category = EnumHelper.FindCorrespondingCategory(SelectedSpecies);
            }

            CategoryControl?.OnSpeciesSelected(SelectedSpecies);
            RegisterEventHandler();
        }

        /// <summary>
        /// ChildViewModels send an event to the parent to inform it about the validation result
        /// on the user input, as a boolean value
        /// </summary>
        private void RegisterEventHandler()
        {
            if (CategoryControl?.SelectedSpeciesControl != null)
            {
                CategoryControl.SelectedSpeciesControl.ChildDataErrorDelegate += (isChildValid) =>
                {
                    ChildViewModelValid = isChildValid;
                    OnPropertyChanged(nameof(IsViewModelValid));
                };
            }
        }
        
        /// <summary>
        /// Animal creation with the use of AnimalFactory 
        /// </summary>
        private void CreateAnimal()
        {
            CategoryControl?.SelectedSpeciesControl?.NotifyParentAboutValidity();

            if (SelectedSpecies == Unknown)
            {
                MessageDelegate?.Invoke("Select a species type first.");
            }
            else if (!IsViewModelValid)
            {
                MessageDelegate?.Invoke("Some fields are empty or invalid!");
            }
            else
            {
                Animal = FactoryBuilder.GetAnimalFactory(Category)?.CreateAnimal(this, CategoryControl);
                AnimalListViewModel.Collection.Add(Animal);
            }
        }

        /// <summary>
        /// Reset application to the initial state
        /// </summary>
        private void ResetControls()
        {
            Name = null;
            Age = null;
            ResetSettings();
        }

        private void ResetSettings()
        {
            Category = Category.Mammal;
            SelectedSpecies = Unknown;
            ChildViewModelValid = false;
        }

        #endregion

        #region Events

        /// <summary>
        /// Display a message to the user
        /// </summary>
        public Action<string> MessageDelegate;

        /// <summary>
        /// Invoke when either a file or directory has been chosen by the user
        /// </summary>
        public Action<string> PathReceiver;  
         
        /// <summary>
        /// Select a directory where a file should be saved, with file extension specified
        /// </summary>
        public Action<FileExtensionMetaData> DirectorySelector;  
          
        /// <summary>
        /// Select a file that should be read
        /// </summary>
        public Action<FileExtensionMetaData> FileSelector;  

        /// <summary>
        /// Display dialog with option to save the app state 
        /// </summary>
        public Action AppReset;  

        /// <summary>
        /// Display dialog with option to exit the app 
        /// </summary>
        public Action AppExit;   

        #endregion

        #region Commands

        private RelayCommand _createAnimalCommand;

        public RelayCommand CreateAnimalCommand =>_createAnimalCommand ??
                   (_createAnimalCommand = new RelayCommand(ex => { CreateAnimal(); }));
        

        private RelayCommand _linkAnimalToFoodItemCommand;
        public RelayCommand LinkAnimalToFoodItemCommand => _linkAnimalToFoodItemCommand ??
                                                           (_linkAnimalToFoodItemCommand = new RelayCommand(ex => LinkAnimalToFoodItem()));

       
        private RelayCommand _saveAsBinaryCommand;
        public RelayCommand SaveAsBinaryCommand => _saveAsBinaryCommand ??
                                                   (_saveAsBinaryCommand = new RelayCommand(ex =>
                                                   {
                                                       if (AnimalListViewModel.Collection.IsEmpty())
                                                       {
                                                           MessageDelegate?.Invoke("Animal list is empty!");
                                                       }
                                                       else
                                                       {
                                                           PathReceiver = path => 
                                                               HandleSerializationAction(AnimalListViewModel.SerializeBinary, path);
                                                           DirectorySelector?.Invoke(ResolveFileExtension(Dat));
                                                       }
                                                   }));

        private RelayCommand _saveAsXmlCommand;
        public RelayCommand SaveAsXmlCommand => _saveAsXmlCommand ??
                                                (_saveAsXmlCommand = new RelayCommand(ex =>
                                                {
                                                    if (FoodManagerViewModel.Collection.IsEmpty())
                                                    {
                                                        MessageDelegate?.Invoke("Food item list is empty!");
                                                    }
                                                    else
                                                    {
                                                        PathReceiver = path => 
                                                            HandleSerializationAction(FoodManagerViewModel.SerializeXml, path);
                                                        DirectorySelector?.Invoke(ResolveFileExtension(Xml));
                                                    }
                                                }));

        private RelayCommand _readBinaryCommand;
        public RelayCommand ReadBinaryCommand => _readBinaryCommand ??
                                                 (_readBinaryCommand = new RelayCommand(ex =>
                                                 {
                                                     PathReceiver = s =>
                                                         HandleSerializationAction(AnimalListViewModel.DeserializeBinary, s);
                                                     FileSelector.Invoke(ResolveFileExtension(Dat));
                                                 }));


        private RelayCommand _readXmlCommand;
        public RelayCommand ReadXmlCommand => _readXmlCommand ??
                                              (_readXmlCommand = new RelayCommand(ex =>
                                              {
                                                  PathReceiver = s => 
                                                      HandleSerializationAction(FoodManagerViewModel.DeserializeXml, s);
                                                  FileSelector.Invoke(ResolveFileExtension(Xml));
                                              }));

        private RelayCommand _resetCommand;
        public RelayCommand ResetCommand => _resetCommand ??
                                            (_resetCommand = new RelayCommand(ex => AppReset?.Invoke()));

        private RelayCommand _exitCommand;
        public RelayCommand ExitCommand => _exitCommand ??
                                           (_exitCommand = new RelayCommand(ex => AppExit?.Invoke()));

        /// <summary>
        /// Handle possible exceptions coming from the SerializationUtils lib
        /// </summary>
        /// <param name="action"> serialization (deserialization) of (to) xml or binary  </param>
        /// <param name="path"> file or directory name </param>
        private void HandleSerializationAction(Action<string> action, string path)
        {
            SerializationHandler.HandleSerializationAction(action, path, MessageDelegate);
        }

        private void LinkAnimalToFoodItem()
        {
            if (AnimalListViewModel.SelectedAnimal == null || FoodManagerViewModel.SelectedFoodItem == null)
            {
                MessageDelegate?.Invoke("You must select an animal and a food item first!");
            }
            else
            {
                FoodManagerViewModel.LinkAnimalToFoodItem(AnimalListViewModel.SelectedAnimal);
                MessageDelegate?.Invoke($"Successfully added a {FoodManagerViewModel.SelectedFoodItem.Name} to {AnimalListViewModel.SelectedAnimal.Name}'s food schedule!");
                FoodManagerViewModel.Reset();
                AnimalListViewModel.Reset();
            }
        }

        #endregion

        #region Validation

        /// <summary>
        /// Invoked each time a certain property is set, to register possible errors
        /// </summary>
        /// <param name="property"> property name, e.g. Category </param>
        /// <param name="value"> property value, e.g. Mammal </param>
        /// <param name="validationType"> validation strategy </param>
        private void ValidateProperty(string property, object value, ValidationType validationType)
        {
            bool isValid = IsValid(validationType, property, value, out ICollection<string> errors);
             
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

        /// <summary>
        /// Validation result for any child controls, set each time a data in a corresponding view model changes
        /// </summary>
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
        private FoodManagerViewModel _foodManagerViewModel;

        private bool _isCheckedListAllAnimals;

        #endregion
    }
}
