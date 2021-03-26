using AnimalPark.Model.Bases;
using AnimalPark.Model.Enums;

namespace AnimalPark.Model.Concretes
{
    public class Donkey : Mammal
    {
        private int _stubbornness;
        public Donkey(string name, int age, Gender gender, bool isDomesticated, int stubbornness) : base(name, age, gender, isDomesticated)
        {
            Stubbornness = stubbornness;
        }
         
        public int Stubbornness
        {
            get => _stubbornness;
            set => _stubbornness = value;
        }
    }
}
