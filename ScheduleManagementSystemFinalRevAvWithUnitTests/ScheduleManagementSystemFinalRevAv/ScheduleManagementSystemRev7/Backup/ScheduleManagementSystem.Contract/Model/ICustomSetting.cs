using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleManagementSystem.Contract.Model
{
    public interface ICustomSetting
    {
        int Id { get; }
        int WorkDayBegin { get; }
        int WorkDayEnd { get; }
        int ViewDays { get; }
    }
}
