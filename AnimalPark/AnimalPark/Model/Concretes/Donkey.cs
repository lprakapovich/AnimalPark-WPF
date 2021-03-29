using System.Collections.Generic;
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

        public override string ToString()
        {
            return base.ToString() + "\nStubbornness level: " + _stubbornness;
        }

        public override FoodSchedule FoodSchedule
        { 
            get => new FoodSchedule()
            { 
                EaterType = EaterType.Herbivore,
                EatingHabitsDescription = new List<string>() { "Straw, hay, and grass!"}
            };
        }

        public override string ExtraInfo { get => base.ExtraInfo + "Species: Donkey" + $"{"Stubbornness:",-15} {Stubbornness,10}\n"; }
    }
}
