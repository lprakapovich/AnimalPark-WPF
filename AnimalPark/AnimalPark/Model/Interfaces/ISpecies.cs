
using System;

namespace AnimalPark.Model.Interfaces
{
    /// <summary>
    /// Second level interface for view models related to Species,
    /// e.g. PrawnViewModel or RaccoonViewModel
    /// </summary>

    public interface ISpecies
    {
        /// <summary>
        /// Delegate used to inform MainViewModel about validation results in the child view models
        /// </summary>
        event Action<bool> ChildDataErrorDelegate;

        void Emit(); 
    }
}
 