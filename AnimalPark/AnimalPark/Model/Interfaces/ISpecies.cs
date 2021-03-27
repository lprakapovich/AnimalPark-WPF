
using System;

namespace AnimalPark.Model.Interfaces
{
    /// <summary>
    /// Second level hierarchy
    /// Interface for view models related to Species, e.g. PrawnViewModel or PandaViewModel
    /// </summary>

    public interface ISpecies
    {
        event Action<bool> ChildDataErrorDelegate;
    }
}
 