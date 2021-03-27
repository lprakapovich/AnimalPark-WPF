using System;
using AnimalPark.Common;
using AnimalPark.Model.Interfaces;

namespace AnimalPark.ViewModel.SpeciesViewModels
{
    public class PrawnViewModel : BindableBase, IFish 
    {
        private bool _canBeEaten;
        public bool CanBeEaten
        {
            get => _canBeEaten;

            set
            {
                _canBeEaten = value;
                OnPropertyChanged(nameof(CanBeEaten));
            }
        }

        public event Action<bool> ChildDataErrorDelegate;
    }
}
