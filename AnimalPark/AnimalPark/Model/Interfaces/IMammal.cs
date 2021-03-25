
namespace AnimalPark.Model.Interfaces
{
    /// <summary>
    /// Third level hierarchy
    /// Interface specific for all the mammals view models
    ///
    /// These nested interfaces are introduced to ensure
    /// that it is not possible to use e.g. Fish controls in the context of the Mammals
    /// </summary>
    public interface IMammal : ISpecies
    {
    }
}
