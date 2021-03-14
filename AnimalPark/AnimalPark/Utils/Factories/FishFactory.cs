using AnimalPark.Common;
using AnimalPark.Model;
using AnimalPark.Model.BaseClasses;
using AnimalPark.Model.Concretes;
using AnimalPark.ViewModel;
using AnimalPark.ViewModel.BaseSpeciesViewModels;
using AnimalPark.ViewModel.SpeciesViewModels;

namespace AnimalPark.Utils.Factories
{
    public class FishFactory : IAnimalFactory
    {
        public Animal CreateAnimal(BindableBase mainContext, ICategory baseContext, ISpecies speciesContext)
        {
            MainViewModel context = (MainViewModel) mainContext;

            Animal animal = null;

            switch (context.SpeciesType)
            {
                case Species.Prawn:
                    animal = new Prawn(context.Name, context.Age, context.Gender, 
                        ((FishViewModel) (baseContext)).IsSaltWater,
                        ((PrawnViewModel) (speciesContext)).CanBeEaten);
                    break;

                case Species.JellyFish:
                    animal = new JellyFish(context.Name, context.Age, context.Gender,
                        ((FishViewModel) (baseContext)).IsSaltWater,
                        ((JellyFishViewModel) (speciesContext)).Type);
                    break;
            }

            return animal;
        }
    }
}
