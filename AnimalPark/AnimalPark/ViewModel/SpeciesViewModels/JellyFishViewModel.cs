using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalPark.Common;
using AnimalPark.Model.Concretes;

namespace AnimalPark.ViewModel.SpeciesViewModels
{
    public class JellyFishViewModel : BindableBase, ISpecies
    {
        private JellyFishTYpe _type;

        public JellyFishTYpe Type
        {
            get => _type;
            set => _type = value;
        }
    }
}
