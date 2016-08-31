using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleManagementSystem.Contract.Model
{
    public interface ILocationMaster
    {
        int LocationId { get; }
        string LocationName { get; }
        string LocationBuilding { get; }
        string LocationFloor { get; }
        string LocationRoom { get; }
        int LocationCapacity { get; }
        bool IsAvAvailable { get; }
        bool IsPhoneAvailable { get; }
        bool IsVideoConfAvailable { get; }
    }
}
