using System.Collections.ObjectModel;
using AnimalPark.Model.Bases;

namespace AnimalPark.Utils
{
    /// <summary>
    /// Responsible for keeping a list of all animals
    /// </summary>
    public class AnimalManager
    {
        #region Private Fields

        private ObservableCollection<Animal> _animals;
        private Animal _selectedAnimal;

        #endregion

        public ObservableCollection<Animal> Animals
        {
            get => _animals;
            set
            {
                if (value != null)
                {
                    _animals = value;
                }
            }
        }

        public Animal SelectedAnimal
        {
            get => _selectedAnimal;
            set => _selectedAnimal = value;
        }
    }
}
