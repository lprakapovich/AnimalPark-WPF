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
    }
}
