using System;
using AnimalPark.Model.Enums;

namespace AnimalPark.Model.Bases 
{
    [Serializable]
    public abstract class Fish : Animal
    {
        private bool _isSaltwater;

        protected Fish(string name, int age, Gender gender, bool isSaltWater) : base(name, age, gender)
        {
            _isSaltwater = isSaltWater;
        }

        public override string ExtraInfo
        {

            get => base.ExtraInfo + $"{"\nCategory:", -40} {"Fish", -40}" +  $"{"\nLives in salt water?", -40} {_isSaltwater, -40}";
        }
    }
}
