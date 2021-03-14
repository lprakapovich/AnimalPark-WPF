using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalPark.Common;

namespace AnimalPark.ViewModel.BaseSpeciesViewModels 
{
    public class MammalViewModel : BindableBase, ICategory
    {
        private bool _isDomesticated;

        public bool IsDomesticated
        {
            get => _isDomesticated;
            set => _isDomesticated = value; 
        }
    }
}
