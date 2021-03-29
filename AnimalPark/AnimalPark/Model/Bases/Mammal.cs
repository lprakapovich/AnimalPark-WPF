using AnimalPark.Model.Enums;

namespace AnimalPark.Model.Bases 
{
    public abstract class Mammal : Animal
    { 
        private bool _isDomesticated;

        protected Mammal(string name, int age, Gender gender, bool isDomesticated) : base(name, age, gender)
        {
            _isDomesticated = isDomesticated;
        }

        public override string ToString()
        {
            return base.ToString() + "\nIs domesticated? " + _isDomesticated;
        }

        public override string ExtraInfo
        {
            get => base.ExtraInfo + $"{"Category:", -15} {"Mammal", 10}\n" + $"{"Is domesticated?:", -15} {_isDomesticated, 10}\n";
        }
    }
}
