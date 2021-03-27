using System;
using System.Collections.Generic;
using System.Windows;
using AnimalPark.Common;
using AnimalPark.Model.Interfaces;
using AnimalPark.Utils.Validators;
using static AnimalPark.Utils.Validators.ValidationService;
using static AnimalPark.Utils.Validators.ValidationService.ValidationType;

namespace AnimalPark.ViewModel.SpeciesViewModels
{
    public class DonkeyViewModel : BindableBase, IMammal
    {
        private string _stubbornness;
        public string Stubbornness
        {
            get => _stubbornness;
            set
            {
                _stubbornness = value;
                ValidateProperty(nameof(Stubbornness), value, NumberValidation); 
                OnPropertyChanged(nameof(Stubbornness));
            }
        }

        private void ValidateProperty(string property, object value, ValidationType type)
        {
            bool isValid = ValidationService.IsValid(NumberValidation, property, value, out ICollection<string> errors);

            if (!isValid)
            {
                Errors[property] = errors;
            }
            else if (Errors.ContainsKey(property))
            {
                Errors.Remove(property);
            }

            ChildDataErrorDelegate?.Invoke(isValid);
        }

        public event Action<bool> ChildDataErrorDelegate;
    }
}
