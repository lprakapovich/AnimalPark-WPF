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

        public override string ExtraInfo
        {
            get => base.ExtraInfo + $"{"\nCategory:", -40} {"Mammal", -40}" + $"{"\nIs domesticated?:", -40} {_isDomesticated, -40}";
        }
    }
}
