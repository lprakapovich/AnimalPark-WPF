using System.ComponentModel;

namespace AnimalPark.Model.Enums
{
    public enum SortingStrategy
    {
        [Description("By age, ascending")]
        ByAgeAsc,
        [Description("By age, descending")]
        ByAgeDesc,
        [Description("By name, ascending")]
        ByNameAsc,
        [Description("By name, descending")]
        ByNameDesc
    }
}
