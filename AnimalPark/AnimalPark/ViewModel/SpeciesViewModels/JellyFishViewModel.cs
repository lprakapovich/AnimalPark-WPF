using AnimalPark.Common;
using AnimalPark.Model.Concretes;
using AnimalPark.Model.Interfaces;

namespace AnimalPark.ViewModel.SpeciesViewModels
{
    public class JellyFishViewModel : BindableBase, IFish
    {
        private JellyFishTYpe _type;

        public JellyFishTYpe Type
        {
            get => _type;
            set => _type = value;
        }
    }
}
