using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Model
{
    public class CustomSetting : ICustomSetting
    {
        public int Id { get; set; }
        public int WorkDayBegin { get; set; }
        public int WorkDayEnd { get; set; }
        public int ViewDays { get; set; }
    }
}
