using AnimalPark.Common;
using AnimalPark.Model.Enums;
using AnimalPark.Model.Interfaces;
using AnimalPark.ViewModel.SpeciesViewModels;
 
namespace AnimalPark.ViewModel.BaseSpeciesViewModels  
{
    public class FishViewModel : BindableBase, ICategory
    {
        private bool _isSaltWater;

        private IFish _fishSpeciesViewModel;

        public bool IsSaltWater
        {
            get => _isSaltWater;

            set
            {
                _isSaltWater = value;
                OnPropertyChanged(nameof(IsSaltWater));
            }
        }

        public void OnSpeciesSelected(Species species)
        {
            switch (species)
            {
                case Species.JellyFish:
                    SelectedSpeciesControl = new JellyFishViewModel();
                    break;

                case Species.Prawn:
                    SelectedSpeciesControl = new PrawnViewModel();
                    break;

                default:
                    SelectedSpeciesControl = null;
                    break;
            }

            //SelectedSpeciesControl?.NotifyParentAboutValidity(); 
        }

        public ISpecies SelectedSpeciesControl
        {
            get => _fishSpeciesViewModel;
            set
            {
                _fishSpeciesViewModel = (IFish) value;
                OnPropertyChanged(nameof(SelectedSpeciesControl));
            }
        }
    }
}