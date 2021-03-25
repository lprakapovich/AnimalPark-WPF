using AnimalPark.Common;
using AnimalPark.Model;
using AnimalPark.Model.Interfaces;
using AnimalPark.ViewModel.SpeciesViewModels;

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
                case Species.Raccoon:
                    SelectedSpeciesControl = new RaccoonViewModel();
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
