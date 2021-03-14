using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalPark.Model.BaseClasses
{
    public abstract class Mammal : Animal
    { 
        private bool _isDomesticated;

        protected Mammal(string name, int age, Gender gender, bool isDomesticated) : base(name, age, gender)
        {
            _isDomesticated = isDomesticated;
        }
    }
}
