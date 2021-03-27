
namespace AnimalPark.Model.Interfaces
{
    /// <summary>
    /// Third level hierarchy interface representing a group of species,
    /// all the mammals
    ///
    /// These nested interfaces are introduced to ensure
    /// that it is not possible to use e.g. Fish controls in the context of the Mammals
    /// </summary>
    public interface IMammal : ISpecies
    {
    }
}
