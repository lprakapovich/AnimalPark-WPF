using System.Collections.ObjectModel;
using System.Collections.Specialized;
using AnimalPark.Common;
using AnimalPark.Model.Bases;

namespace AnimalPark.ViewModel
{
    /// <summary>
    /// Class managing the list of animals, used instead of AnimalManager mentioned in the
    /// instructions to follow WPF naming conventions
    /// </summary>
    public class AnimalListViewModel : BindableBase
    {
        #region Private Fields

        private ObservableCollection<Animal> _animals;
        private Animal _selectedAnimal;

        #endregion

        public AnimalListViewModel()
        {
            Animals = new ObservableCollection<Animal>();
            Animals.CollectionChanged += AnimalsOnCollectionChanged;
            SelectedAnimal = null;
        }

        #region API
        public ObservableCollection<Animal> Animals
        {
            get => _animals;
            set
            {
                if (value != null)
                {
                    _animals = value;
                    OnPropertyChanged(nameof(Animals));
                }
            }
        }

        public Animal SelectedAnimal
        {
            get => _selectedAnimal;
            set
            { 
                _selectedAnimal = value;
                OnPropertyChanged(nameof(SelectedAnimal));
                OnPropertyChanged(nameof(IsAnimalSelected));
                OnPropertyChanged(nameof(SelectedAnimalDescription));
            }
        }

        public string SelectedAnimalDescription => SelectedAnimal?.ToString();

        public bool IsAnimalSelected => SelectedAnimal != null;

        public void AddAnimal(Animal animal)
        {
            if (animal != null)
            {
                Animals.Add(animal);
            }
        }

        #endregion

        #region Commands

        private RelayCommand _deleteAnimalCommand;

        public RelayCommand DeleteAnimalCommand =>
            _deleteAnimalCommand ??
            (_deleteAnimalCommand = new RelayCommand(e => DeleteAnimal(), canEx => SelectedAnimal != null));

        #endregion

        #region Private methods

        private void DeleteAnimal()
        {
            Animals.Remove(SelectedAnimal);
        }

        private void AnimalsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    break;

                case NotifyCollectionChangedAction.Remove:
                    break;

                case NotifyCollectionChangedAction.Replace:
                    break;
            }
        }

        #endregion
    }
}
