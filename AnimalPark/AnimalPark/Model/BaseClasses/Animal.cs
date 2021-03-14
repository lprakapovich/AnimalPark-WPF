
namespace AnimalPark.Model.BaseClasses
{
    public abstract class Animal
    {
        private string _id;
        private string _name;
        private int _age;
        private Gender _gender;

        protected Animal(string name, int age, Gender gender)
        {
            _name = name;
            _age = age;
            _gender = gender;
        }
    }
}
