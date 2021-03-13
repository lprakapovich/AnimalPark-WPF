using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalPark.Model.BaseClasses;
 
namespace AnimalPark.Utils.Factories
{
    public interface IAnimalFactory
    {
        Animal CreateAnimal();
    }
}
 