using System.Collections.Generic;
using AnimalPark.Model.Bases;
using AnimalPark.Model.Enums;

namespace AnimalPark.Model.Concretes
{
    public class JellyFish : Fish
    {
        private JellyFishType _type;

        public JellyFish(string name, int age, Gender gender, bool isSaltwater, JellyFishType type) : base(name, age, gender, isSaltwater)
        {
            Type = type;
        }

        public JellyFishType Type
        {
            get => _type;
            set => _type = value;
        }

        public override string ToString()
        {
            return base.ToString() + "\n Type: " + _type;
        }

        public override FoodSchedule FoodSchedule { 

            get => new FoodSchedule()
            {
                EaterType = EaterType.Omnivorous,
                EatingHabitsDescription = new List<string>() { "Fish, crabs, and tiny plants" }
            };
        }

        public override string ExtraInfo { get => base.ExtraInfo + "Species: Jelly Fish" + $"{"Type:",-15} {Type,10}\n"; }

    }
}
