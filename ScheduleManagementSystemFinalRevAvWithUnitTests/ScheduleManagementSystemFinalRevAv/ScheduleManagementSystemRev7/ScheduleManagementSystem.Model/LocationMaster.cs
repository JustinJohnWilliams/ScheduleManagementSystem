using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Model
{
    public class LocationMaster : ILocationMaster
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationBuilding { get; set; }
        public string LocationFloor { get; set; }
        public string LocationRoom { get; set; }
        public int LocationCapacity { get; set; }
        public bool IsAvAvailable { get; set; }
        public bool IsPhoneAvailable { get; set; }
        public bool IsVideoConfAvailable { get; set; }
    }
}
