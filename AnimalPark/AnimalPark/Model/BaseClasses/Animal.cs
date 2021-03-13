using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalPark.Model.BaseClasses
{
    public abstract class Animal
    {
        protected string _id;
        protected string _name;
        protected int _age;
        protected Gender _gender;
        protected double _waterNeed;

        protected Animal () {}
    }
}
