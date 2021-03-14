using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalPark.Common;
 
namespace AnimalPark.ViewModel.BaseSpeciesViewModels 
{
    public class FishViewModel : BindableBase, ICategory
    {
        private bool _isSaltWater;

        public bool IsSaltWater
        {
            get => _isSaltWater;

            set
            {
                _isSaltWater = value;
                OnPropertyChanged(nameof(IsSaltWater));
            }
        }

        public static FishViewModel GetContext(ICategory categoryContext)
        {
            return categoryContext as FishViewModel;
        }
    }
}