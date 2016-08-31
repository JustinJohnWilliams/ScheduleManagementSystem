using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Model
{
    public class MeetingResult : IMeetingMaster
    {
        public int UserScheduleIndexId { get; set; }
        public string PreferredLocation { get; set; }
        public string ActualLocation { get; set; }
        public string ScheduledBy { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }

        #region IMeetingMaster Members

        public int MeetingId { get; set; }
        public string MeetingDesc { get; set; }
        public DateTime MeetingStartTime { get; set; }
        public DateTime MeetingEndTime { get; set; }
        public DateTime MeetingWindowStart { get; set; }
        public DateTime MeetingWindowEnd { get; set; }
        public int MeetingDuration { get; set; }
        public int MeetingCalledBy { get; set; }
        public int MeetingPriority { get; set; }
        public string AgendaURL { get; set; }
        public string PhoneBridge { get; set; }
        public string PhoneBridgeAccessCode { get; set; }
        public int PreferredLocationId { get; set; }
        public int ActualLocationId { get; set; }
        public string MinutesURL { get; set; }
        public bool IsAVRequired { get; set; }
        public bool IsPhoneRequired { get; set; }
        public bool IsVideoConfRequired { get; set; }


        #endregion
    }
}
