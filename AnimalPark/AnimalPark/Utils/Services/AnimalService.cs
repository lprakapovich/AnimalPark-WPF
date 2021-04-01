using AnimalPark.Model;
using AnimalPark.Model.Bases;
using AnimalPark.Model.Enums;

namespace AnimalPark.Utils.Services
{
    /// <summary>
    /// A service that could play a role of intermediate communicator between the Presentation Layer
    /// and e.g. a database there all the data is stored. Introduced as an alternative to AnimalManager
    /// mentioned in the instructions
    /// </summary>
    public class AnimalService : ListHandler<Animal>
    {
        public void RegisterAnimal(Animal animal)
        {

        }

        private string GenerateIdBasedOnCategory(Category category)
        {
            return null;
        }
    }
}
