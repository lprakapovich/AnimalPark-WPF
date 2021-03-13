using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalPark.Model.BaseClasses;

namespace AnimalPark.Utils
{
    public interface IAnimalFactory
    {
        Animal CreateAnimal();
    }
}
