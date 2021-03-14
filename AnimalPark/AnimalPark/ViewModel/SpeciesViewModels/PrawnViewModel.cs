using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalPark.Common;

namespace AnimalPark.ViewModel.SpeciesViewModels
{
    public class PrawnViewModel : BindableBase, ISpecies
    {
        private bool _canBeEaten;
        public bool CanBeEaten
        {
            get => _canBeEaten;

            set
            {
                _canBeEaten = value;
                OnPropertyChanged(nameof(CanBeEaten));
            }
        }
    }
}
