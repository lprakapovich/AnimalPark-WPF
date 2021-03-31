using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalPark.Model.Interfaces
{
    public interface IChildValidator
    {
        /// <summary>
        /// Delegate used to inform MainViewModel about validation results in the child view models
        /// </summary>
        event Action<bool> ChildDataErrorDelegate;

        /// <summary>
        /// Send event to parent so that it knew about the current
        /// validity state of the child
        /// </summary>
        void NotifyParentAboutValidity();
    }
}
