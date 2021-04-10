using System;
using AnimalPark.Model.Bases;
using AnimalPark.Model.Enums;

namespace AnimalPark.Model.Concretes
{
    [Serializable]
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

        public override string ExtraInfo { get => base.ExtraInfo + $"{"\nSpecies: ", -40} {"Jelly Fish", -40}" + $"{"\nType:", -40} {Type, -40}"; }
    }
}
