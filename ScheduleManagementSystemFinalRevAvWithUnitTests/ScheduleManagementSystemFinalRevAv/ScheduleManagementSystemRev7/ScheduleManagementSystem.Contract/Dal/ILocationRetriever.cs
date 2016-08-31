using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Contract.Dal
{
    public interface ILocationRetriever
    {
        /// <summary>
        /// returns the location from the given location id.
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        ILocationMaster GetLocationByLocationId(int locationId);

        /// <summary>
        /// returns all locations
        /// </summary>
        /// <returns></returns>
        List<ILocationMaster> GetAllLocations();

        /// <summary>
        /// Returns possible locations
        /// </summary>
        /// <param name="user"></param>
        /// <param name="isAvRequired"></param>
        /// <param name="isPhoneRequired"></param>
        /// <param name="isVideoConfRequired"></param>
        /// <returns></returns>
        List<ILocationMaster> GetLocationsFromSearchCriteria(IUser user, bool isAvRequired, bool isPhoneRequired, bool isVideoConfRequired, int capacity);
    }
}
