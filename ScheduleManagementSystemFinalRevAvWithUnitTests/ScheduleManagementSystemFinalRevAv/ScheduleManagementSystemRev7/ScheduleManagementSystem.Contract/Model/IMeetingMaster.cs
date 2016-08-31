using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleManagementSystem.Contract.Model
{
    public interface IMeetingMaster
    {
        int MeetingId { get; }
        string MeetingDesc { get; }
        DateTime MeetingStartTime { get; }
        DateTime MeetingEndTime { get; }
        DateTime MeetingWindowStart { get; }
        DateTime MeetingWindowEnd { get; }
        int MeetingDuration { get; }
        int MeetingCalledBy { get; }
        int MeetingPriority { get; }
        string AgendaURL { get; }
        string PhoneBridge { get; }
        string PhoneBridgeAccessCode { get; }
        int PreferredLocationId { get; }
        int ActualLocationId { get; }
        string MinutesURL { get; }
        bool IsAVRequired { get; }
        bool IsPhoneRequired { get; }
        bool IsVideoConfRequired { get; }
    }
}
