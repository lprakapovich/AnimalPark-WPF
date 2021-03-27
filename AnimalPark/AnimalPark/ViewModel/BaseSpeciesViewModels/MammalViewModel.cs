using AnimalPark.Common;
using AnimalPark.Model.Enums;
using AnimalPark.Model.Interfaces;
using AnimalPark.ViewModel.SpeciesViewModels;
using static AnimalPark.Model.Enums.Species;

namespace AnimalPark.ViewModel.BaseSpeciesViewModels   
{
    public class MammalViewModel : BindableBase, ICategory
    {
        private bool _isDomesticated;

        private IMammal _mammalSpeciesViewModel;

        public bool IsDomesticated
        {
            get => _isDomesticated;
            set
            {
                _isDomesticated = value;
                OnPropertyChanged(nameof(IsDomesticated));
            } 
        }

        public void OnSpeciesSelected(Species species)
        {
            switch (species)
            {
                case Raccoon:
                    SelectedSpeciesControl = new RaccoonViewModel();
                    break;

                case Donkey:
                    SelectedSpeciesControl = new DonkeyViewModel();
                    break;

                default:
                    SelectedSpeciesControl = null;
                    break;
            }
        }

        public ISpecies SelectedSpeciesControl
        {
            get => _mammalSpeciesViewModel;
            set
            {
                _mammalSpeciesViewModel = (IMammal) value;
                OnPropertyChanged(nameof(SelectedSpeciesControl));
            }
        }
    }
}
