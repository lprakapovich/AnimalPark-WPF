using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalPark.Model.BaseClasses
{
    public abstract class Animal
    {
        private string _id;
        private string _name;
        private int _age;
        private Gender _gender;
        private bool _isAdopted;

        protected Animal () {}
    }
}
