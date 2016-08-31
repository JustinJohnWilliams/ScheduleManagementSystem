using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Dal.Database
{
    [Table(Name = "dbo.Meeting_Master")]
    internal class Meeting_MasterDto : IMeetingMaster
    {
        private int _meetingId;
        [Column(Storage = "_meetingId", IsPrimaryKey=true, IsDbGenerated=true)]
        public int MeetingId
        {
            get { return _meetingId; }
            set { _meetingId = value; }
        }

        private string _meetingDesc;
        [Column(Storage = "_meetingDesc")]
        public string MeetingDesc
        {
            get { return _meetingDesc; }
            set { _meetingDesc = value; }
        }

        private DateTime _meetingStartTime;
        [Column(Storage = "_meetingStartTime")]
        public DateTime MeetingStartTime
        {
            get { return _meetingStartTime; }
            set { _meetingStartTime = value; }
        }

        private DateTime _meetingEndTime;
        [Column(Storage = "_meetingEndTime")]
        public DateTime MeetingEndTime
        {
            get { return _meetingEndTime; }
            set { _meetingEndTime = value; }
        }

        private DateTime _meetingWindowStart;
        [Column(Storage = "_meetingWindowStart")]
        public DateTime MeetingWindowStart
        {
            get { return _meetingWindowStart; }
            set { _meetingWindowStart = value; }
        }

        private DateTime _meetingWindowEnd;
        [Column(Storage = "_meetingWindowEnd")]
        public DateTime MeetingWindowEnd
        {
            get { return _meetingWindowEnd; }
            set { _meetingWindowEnd = value; }
        }

        private int _meetingDuration;
        [Column(Storage = "_meetingDuration")]
        public int MeetingDuration
        {
            get { return _meetingDuration; }
            set { _meetingDuration = value; }
        }

        private int _meetingCalledBy;
        [Column(Storage = "_meetingCalledBy")]
        public int MeetingCalledBy
        {
            get { return _meetingCalledBy; }
            set { _meetingCalledBy = value; }
        }

        private int _meetingPriority;
        [Column(Storage = "_meetingPriority")]
        public int MeetingPriority
        {
            get { return _meetingPriority; }
            set { _meetingPriority = value; }
        }

        private string _agendaUrl;
        [Column(Storage = "_agendaUrl")]
        public string AgendaURL
        {
            get { return _agendaUrl; }
            set { _agendaUrl = value; }
        }

        private string _phoneBridge;
        [Column(Storage = "_phoneBridge")]
        public string PhoneBridge
        {
            get { return _phoneBridge; }
            set { _phoneBridge = value; }
        }

        private string _phoneBridgeAccessCode;
        [Column(Storage = "_phoneBridgeAccessCode")]
        public string PhoneBridgeAccessCode
        {
            get { return _phoneBridgeAccessCode; }
            set { _phoneBridgeAccessCode = value; }
        }

        private int _preferredLocationId;
        [Column(Storage = "_preferredLocationId")]
        public int PreferredLocationId
        {
            get { return _preferredLocationId; }
            set { _preferredLocationId = value; }
        }

        private int _actualLocationId;
        [Column(Storage = "_actualLocationId")]
        public int ActualLocationId
        {
            get { return _actualLocationId; }
            set { _actualLocationId = value; }
        }

        private string _minutesUrl;
        [Column(Storage = "_minutesUrl")]
        public string MinutesURL
        {
            get { return _minutesUrl; }
            set { _minutesUrl = value; }
        }

        private bool _isAVRequired;
        [Column(Storage = "_isAVRequired")]
        public bool IsAVRequired
        {
            get { return _isAVRequired; }
            set { _isAVRequired = value; }
        }

        private bool _isPhoneRequired;
        [Column(Storage = "_isPhoneRequired")]
        public bool IsPhoneRequired
        {
            get { return _isPhoneRequired; }
            set { _isPhoneRequired = value; }
        }

        private bool _isVideoConfRequired;
        [Column(Storage = "_isVideoConfRequired")]
        public bool IsVideoConfRequired
        {
            get { return _isVideoConfRequired; }
            set { _isVideoConfRequired = value; }
        }

        #region IMeetingMaster Members

        int IMeetingMaster.MeetingId
        {
            get { return _meetingId; }
        }

        string IMeetingMaster.MeetingDesc
        {
            get { return _meetingDesc; }
        }

        DateTime IMeetingMaster.MeetingStartTime
        {
            get { return _meetingStartTime; }
        }

        DateTime IMeetingMaster.MeetingEndTime
        {
            get { return _meetingEndTime; }
        }

        DateTime IMeetingMaster.MeetingWindowStart
        {
            get { return _meetingWindowStart; }
        }

        DateTime IMeetingMaster.MeetingWindowEnd
        {
            get { return _meetingWindowEnd; }
        }

        int IMeetingMaster.MeetingDuration
        {
            get { return _meetingDuration; }
        }

        int IMeetingMaster.MeetingCalledBy
        {
            get { return _meetingCalledBy; }
        }

        int IMeetingMaster.MeetingPriority
        {
            get { return _meetingPriority; }
        }

        string IMeetingMaster.AgendaURL
        {
            get { return _agendaUrl; }
        }

        string IMeetingMaster.PhoneBridge
        {
            get { return _phoneBridge; }
        }

        string IMeetingMaster.PhoneBridgeAccessCode
        {
            get { return _phoneBridgeAccessCode; }
        }

        int IMeetingMaster.PreferredLocationId
        {
            get { return _preferredLocationId; }
        }

        int IMeetingMaster.ActualLocationId
        {
            get { return _actualLocationId; }
        }

        string IMeetingMaster.MinutesURL
        {
            get { return _minutesUrl; }
        }

        bool IMeetingMaster.IsAVRequired
        {
            get { return _isAVRequired; }
        }

        bool IMeetingMaster.IsPhoneRequired
        {
            get { return _isPhoneRequired; }
        }

        bool IMeetingMaster.IsVideoConfRequired
        {
            get { return _isVideoConfRequired; }
        }

        #endregion
    }
}
