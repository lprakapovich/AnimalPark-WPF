using AnimalPark.Model.Enums;

namespace AnimalPark.Model.Bases 
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
