using AnimalPark.Common;
using AnimalPark.Model.BaseClasses;
using AnimalPark.ViewModel;

namespace AnimalPark.Utils.Factories
{
    public interface IAnimalFactory
    {
        Animal CreateAnimal(BindableBase mainContext, ICategory baseContext, ISpecies speciesContext);
    }
}
 