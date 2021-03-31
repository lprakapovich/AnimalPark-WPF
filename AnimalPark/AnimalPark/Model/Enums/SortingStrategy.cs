using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
