using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleManagementSystem.Contract.Model
{
    public interface IUserSchedule
    {
        int IndexId { get; }
        int UserId { get; }
        DateTime FromTime { get; }
        DateTime ToTime { get; }
        string ScheduleEntryDescription { get; }
        int ScheduleEntryType { get; }
        int MeetingId { get; }
    }
}
