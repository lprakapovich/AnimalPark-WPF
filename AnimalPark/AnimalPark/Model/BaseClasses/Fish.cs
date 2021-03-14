using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalPark.Model.BaseClasses
{
    public abstract class Fish : Animal
    {
        private bool _isSaltwater;

        protected Fish(string name, int age, Gender gender, bool isSaltWater) : base(name, age, gender)
        {
            _isSaltwater = isSaltWater;
        }
    }
}
