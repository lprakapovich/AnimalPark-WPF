using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalPark.Model.BaseClasses;

namespace AnimalPark.Model.Concretes
{
    public class Prawn : Fish
    {
        private bool _canBeEaten;

        public Prawn(string name, int age, Gender gender, bool isSaltwater, bool canBeEaten)
            : base(name, age, gender, isSaltwater)
        {
            _canBeEaten = canBeEaten;
        }
    }
}
