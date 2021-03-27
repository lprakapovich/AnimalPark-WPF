using AnimalPark.Model;
using AnimalPark.Model.Enums;

namespace AnimalPark.Utils.Factories
{
    /// <summary>
    /// Factory helping to separate object creation depending on the category
    /// </summary>
    public static class FactoryBuilder
    {
        public static IAnimalFactory GetAnimalFactory(Category category)
        {
            switch (category)
            {
                case Category.Mammal:
                    return new MammalFactory();

                case Category.Fish:
                    return new FishFactory();

                default:
                    return null;
            }
        }
    }
}

