using AnimalPark.Common;
using AnimalPark.Model.Bases;
using AnimalPark.Model.Concretes;
using AnimalPark.Model.Enums;
using AnimalPark.Model.Interfaces;
using AnimalPark.ViewModel;
using AnimalPark.ViewModel.BaseSpeciesViewModels;
using AnimalPark.ViewModel.SpeciesViewModels;

namespace AnimalPark.Utils.Factories
{
    public class FishFactory : IAnimalFactory
    {
        public Animal CreateAnimal(BindableBase mainContext, ICategory categoryContext)
        {
            MainViewModel context = (MainViewModel) mainContext;

            Animal animal = null;

            switch (context.SelectedSpecies)
            {
                case Species.Prawn:
                    animal = new Prawn(context.Name, context.Age, context.Gender, 
                        ((FishViewModel) (categoryContext)).IsSaltWater,
                        ((PrawnViewModel) (categoryContext.SelectedSpeciesControl)).CanBeEaten);
                    break;

                case Species.JellyFish:
                    animal = new JellyFish(context.Name, context.Age, context.Gender,
                        ((FishViewModel) (categoryContext)).IsSaltWater,
                        ((JellyFishViewModel) (categoryContext.SelectedSpeciesControl)).Type);
                    break;
            }

            return animal;
        }
    }
}
