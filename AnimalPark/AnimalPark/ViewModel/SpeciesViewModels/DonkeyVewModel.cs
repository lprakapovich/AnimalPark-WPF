using AnimalPark.Common;
using AnimalPark.Model.Interfaces;

namespace AnimalPark.ViewModel.SpeciesViewModels
{
    public class DonkeyVewModel : BindableBase, IMammal
    {
        private int _stubbornness;
        public int Stubbornness
        {
            get => _stubbornness;
            set
            {
                if (value >= 0)
                {
                    _stubbornness = value;
                    OnPropertyChanged(nameof(Stubbornness));
                }
            }
        }
    }
}
