using AnimalPark.Model.BaseClasses;

namespace AnimalPark.Model.Concretes
{
    public class Raccoon : Mammal
    { 
        public Raccoon(string name, int age, Gender gender, bool isDomesticated, RaccoonType type)
            : base(name, age, gender, isDomesticated)
        {
            Type = type;
        }

        private RaccoonType _type;

        public RaccoonType Type
        {
            get => _type;
            set => _type = value;
        }
    }
}
