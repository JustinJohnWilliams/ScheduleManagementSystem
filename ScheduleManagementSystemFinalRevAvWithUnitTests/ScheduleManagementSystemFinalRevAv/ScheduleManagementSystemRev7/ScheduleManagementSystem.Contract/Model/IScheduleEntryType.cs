using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleManagementSystem.Contract.Model
{
    public interface IScheduleEntryType
    {
        int ScheduleEntryTypeId { get; }
        string ScheduleEntryTypeDescription { get; }
    }
}
