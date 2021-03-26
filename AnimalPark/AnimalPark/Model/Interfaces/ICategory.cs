
using AnimalPark.Model.Enums;

namespace AnimalPark.Model.Interfaces
{
    /// <summary>
    /// Top-hierarchy
    /// Interface for view models related to category, e.g. FishViewModel or MammalViewModel
    /// </summary>
    public interface ICategory
    {
        void OnSpeciesSelected(Species species);

        /// <summary>
        /// Interface property, to access a selected species' control 
        /// </summary>
        ISpecies SelectedSpeciesControl
        {
            get;
            set;
        }
    }
}
  