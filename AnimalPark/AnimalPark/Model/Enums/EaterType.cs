using System.ComponentModel;

namespace AnimalPark.Model.Enums
{
    public enum EaterType
    {
        [Description("Meat eater")]
        Carnivore,
        [Description("Plant eater")]
        Herbivore,
        [Description("All eater")]
        Omnivorous
    } 
}
