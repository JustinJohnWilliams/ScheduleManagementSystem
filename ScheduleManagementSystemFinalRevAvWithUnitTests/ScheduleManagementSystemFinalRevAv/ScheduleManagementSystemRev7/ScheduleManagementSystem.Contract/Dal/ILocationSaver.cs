using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Contract.Dal
{
    public interface ILocationSaver
    {

        /// <summary>
        /// Saves or updates a location.
        /// </summary>
        /// <param name="location"></param>
        void SaveLocation(ILocationMaster location);

        /// <summary>
        /// Removes a location.
        /// </summary>
        /// <param name="locationId"></param>
        void RemoveLocation(int locationId);
    }
}
