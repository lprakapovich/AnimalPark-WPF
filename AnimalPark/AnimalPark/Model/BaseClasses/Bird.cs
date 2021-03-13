using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AnimalPark.Model.BaseClasses
{
    public abstract class Bird : Animal
    {
        private double _flightSpeed; 
        protected Bird() : base()
        {
        }
    }
}
