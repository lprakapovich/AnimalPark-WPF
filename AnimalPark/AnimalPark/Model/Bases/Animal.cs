
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

        public override string ToString()
        {
            return "Name: " + Name + "\nAge: " + Age + "\nGender: " + Gender;
        }

        public virtual string ExtraInfo
        {
            get
            {
                return null;
            }
        }

        public abstract FoodSchedule FoodSchedule { get; set; }
    }
}
