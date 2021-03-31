using System;
using AnimalPark.Common;
using AnimalPark.Model.Concretes;
using AnimalPark.Model.Interfaces;

namespace AnimalPark.ViewModel.SpeciesViewModels
{
    /// <summary>
    /// DataContext for the control with data specific for JellyFish
    /// </summary>
    public class JellyFishViewModel : BindableBase, IFish
    {
        private JellyFishType _type;

        public JellyFishType Type
        {
            get => _type;
            set
            {
                _type = value;
            }
        }

        public JellyFishViewModel()
        {
            // no parent
        //    ChildDataErrorDelegate.Invoke(true);
        }

        public event Action<bool> ChildDataErrorDelegate;
        public void Emit()
        {
            ChildDataErrorDelegate.Invoke(HasErrors);
        }
    }
}
