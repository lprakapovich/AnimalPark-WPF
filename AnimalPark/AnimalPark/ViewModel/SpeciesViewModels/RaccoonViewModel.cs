using System;
using AnimalPark.Common;
using AnimalPark.Model.Concretes;
using AnimalPark.Model.Interfaces;

namespace AnimalPark.ViewModel.SpeciesViewModels
{
    /// <summary>
    /// DataContext for the control with data specific for Raccoon
    /// </summary>
    public class RaccoonViewModel : BindableBase, IMammal
    {
        private RaccoonType _type;

        public RaccoonType Type
        {
            get => _type;
            set
            {
                _type = value;
            }
        }

        public RaccoonViewModel()
        {
            //ChildDataErrorDelegate?.Invoke(true);
        }

        public event Action<bool> ChildDataErrorDelegate;

        public void Emit()
        {
            ChildDataErrorDelegate.Invoke(HasErrors);
        }
    }
}
