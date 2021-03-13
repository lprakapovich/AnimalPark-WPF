using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalPark.Model;
using static AnimalPark.Model.BaseSpecies;
using static AnimalPark.Model.Species;

namespace AnimalPark.ViewModel
{
    public class MainViewModel
    {
        #region Private Fields

        private string _name; 
        private int _age;
        private Gender _gender;
        private Species _speciesType;
        private BaseSpecies _category; 

        private Dictionary<BaseSpecies, List<Species>> _associatedSpecies;

        #endregion

        #region Setup

        public MainViewModel()
        {
            _associatedSpecies = new Dictionary<BaseSpecies, List<Species>>()
            {
                {
                    Mammal, new List<Species> {Donkey, Panda, Raccoon}
                },
                {
                    Fish, new List<Species>() {JellyFish, BlueTang}
                },
                {
                    Bird, new List<Species>() {Crow, Dove, Sparrow}
                }
            };
        }

        #endregion

        public BaseSpecies Category 
        {
            get => _category;
            set => _category = value;
        }
    }
}
