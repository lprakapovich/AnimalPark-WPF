
using System.Collections.Generic;
using AnimalPark.Model.Enums;

namespace AnimalPark.Model
{
    public class FoodSchedule
    {
        private EaterType _eaterType;
        private List<string> _eatingHabitsDescription;

        public EaterType EaterType
        {
            get => _eaterType;
            set => _eaterType = value;
        }

        public List<string> EatingHabitsDescription
        {
            get => _eatingHabitsDescription;
            set
            {
                if (value != null)
                {
                    _eatingHabitsDescription = value;
                }
            }
        }
    }
}
