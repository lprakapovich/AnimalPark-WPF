using AnimalPark.Common;
using AnimalPark.Model;
using AnimalPark.Model.BaseClasses;
using AnimalPark.Model.Concretes;
using AnimalPark.ViewModel;
using AnimalPark.ViewModel.BaseSpeciesViewModels;
using AnimalPark.ViewModel.SpeciesViewModels;

namespace AnimalPark.Utils.Factories
{
    public class MammalFactory : IAnimalFactory
    {
        public Animal CreateAnimal(BindableBase mainContext, ICategory baseContext) 
        {
            MainViewModel context = (MainViewModel) mainContext;

            Animal animal = null;
            
            switch (context.SelectedSpecies)
            {
                case Species.Raccoon:
                    animal = new Raccoon(
                        context.Name,
                        context.Age,
                        context.Gender,
                        ((MammalViewModel)(baseContext)).IsDomesticated,
                        ((RaccoonViewModel) (baseContext.SelectedSpeciesControl)).Type);
                    break;
            }

            return animal;
        }
    }
}
