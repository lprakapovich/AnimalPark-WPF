using AnimalPark.Model.Bases;
using AnimalPark.Model.Enums;

namespace AnimalPark.Model.Concretes
{
    public class JellyFish : Fish
    {
        private JellyFishTYpe _type;

        public JellyFish(string name, int age, Gender gender, bool isSaltwater, JellyFishTYpe type) : base(name, age, gender, isSaltwater)
        {
            Type = type;
        }

        public JellyFishTYpe Type
        {
            get => _type;
            set => _type = value;
        }

        public override string ToString()
        {
            return base.ToString() + "\n Type: " + _type;
        }

        public override FoodSchedule FoodSchedule { get; set; }
    }
}
