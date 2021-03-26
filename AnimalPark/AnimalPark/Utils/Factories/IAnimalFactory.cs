using AnimalPark.Common;
using AnimalPark.Model.Bases;
using AnimalPark.Model.Interfaces;

namespace AnimalPark.Utils.Factories
{
    public interface IAnimalFactory
    {
        Animal CreateAnimal(BindableBase mainContext, ICategory categoryContext); 
    }
}
  