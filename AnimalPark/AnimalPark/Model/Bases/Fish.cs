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

        public override string ToString()
        {
            return base.ToString() + "\nLives in a salt water? " + _isSaltwater;
        }

        public override string ExtraInfo { get => base.ExtraInfo + $"{"Category:", -15} {"Fish", 10}\n" +  $"{"Lives in salt water? ", -15} {_isSaltwater, 10}\n"; }
    }
}
