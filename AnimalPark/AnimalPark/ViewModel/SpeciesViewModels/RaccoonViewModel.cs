using System;
using AnimalPark.Common;
using AnimalPark.Model.Concretes;
using AnimalPark.Model.Interfaces;

namespace AnimalPark.ViewModel.SpeciesViewModels
{
    public class RaccoonViewModel : BindableBase, IMammal
    {
        private RaccoonType _type;

        public RaccoonType Type
        {
            get => _type;
            set => _type = value;
        }

        public event Action<bool> ChildDataErrorDelegate;
    }
}
