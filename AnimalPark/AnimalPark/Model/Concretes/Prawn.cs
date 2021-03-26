using AnimalPark.Model.Bases;
using AnimalPark.Model.Enums;

namespace AnimalPark.Model.Concretes
{
    public class Prawn : Fish
    {
        private bool _canBeEaten;

        public Prawn(string name, int age, Gender gender, bool isSaltwater, bool canBeEaten)
            : base(name, age, gender, isSaltwater)
        {
            _canBeEaten = canBeEaten;
        }
    }
}
