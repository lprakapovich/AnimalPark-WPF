using System;
using AnimalPark.Common;
using AnimalPark.Model.Interfaces;

namespace AnimalPark.ViewModel.SpeciesViewModels
{
    /// <summary>
    /// DataContext for the control with data specific for Prawn
    /// </summary>
    public class PrawnViewModel : BindableBase, IFish 
    {
        private bool _canBeEaten;
        public bool CanBeEaten
        {
            get => _canBeEaten;

            set
            {
                _canBeEaten = value;
           }
        }

        public PrawnViewModel()
        {
           // ChildDataErrorDelegate?.Invoke(true);
        }

        public event Action<bool> ChildDataErrorDelegate;

        public void Emit()
        {
            ChildDataErrorDelegate.Invoke(HasErrors);
        }
    }
}
