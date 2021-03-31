
using System;
using AnimalPark.Model.Enums;
using AnimalPark.Model.Interfaces;

namespace AnimalPark.Model.Bases 
{
    public abstract class Animal : IAnimal
    {
        private string _id;
        private string _name;
        private int _age;
        private Gender _gender;

        protected Animal(string name, int age, Gender gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Age
        {
            get => _age;
            set => _age = value;
        }

        public Gender Gender
        {
            get => _gender;
            set => _gender = value;
        }

        public virtual string ExtraInfo
        {
            get => $"{"Name:",-4} {Name,-40}" + $"{"\nAge:",-40} {Age,-40}" + $"{"\nGender:",-40} {Gender,-40}";
        }

        public abstract FoodSchedule FoodSchedule { get; }
    }
}
