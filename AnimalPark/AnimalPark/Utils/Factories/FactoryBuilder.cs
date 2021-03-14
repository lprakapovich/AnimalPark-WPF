using AnimalPark.Model;

namespace AnimalPark.Utils.Factories
{
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
                    return new MammalFactory();
            }
        }
    }
}

