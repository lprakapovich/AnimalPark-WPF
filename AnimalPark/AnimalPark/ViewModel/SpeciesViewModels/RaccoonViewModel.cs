using AnimalPark.Common;
using AnimalPark.Model.Concretes;

namespace AnimalPark.ViewModel.SpeciesViewModels
{
    public class RaccoonViewModel : BindableBase, ISpecies
    {
        private RaccoonType _type;

        public RaccoonType Type
        {
            get => _type;
            set => _type = value;
        }
    }
}
