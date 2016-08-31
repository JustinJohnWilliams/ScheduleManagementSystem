using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Dal.Database
{
    [Table(Name = "dbo.UserSchedule")]
    internal class UserScheduleDto : IUserSchedule
    {
        private int _indexId;
        [Column(Storage = "_indexId", IsPrimaryKey = true, IsDbGenerated = true)]
        public int IndexId
        {
            get { return _indexId; }
        }
        private int _userId;
        [Column(Storage = "_userId")]
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private DateTime _fromTime;
        [Column(Storage = "_fromTime")]
        public DateTime FromTime
        {
            get { return _fromTime; }
            set { _fromTime = value; }
        }

        private DateTime _toTime;
        [Column(Storage = "_toTime")]
        public DateTime ToTime
        {
            get { return _toTime; }
            set { _toTime = value; }
        }

        private string _scheduleEntryDescription;
        [Column(Storage = "_scheduleEntryDescription")]
        public string ScheduleEntryDescription
        {
            get { return _scheduleEntryDescription; }
            set { _scheduleEntryDescription = value; }
        }

        private int _scheduleEntryType;
        [Column(Storage = "_scheduleEntryType")]
        public int ScheduleEntryType
        {
            get { return _scheduleEntryType; }
            set { _scheduleEntryType = value; }
        }

        private int _meetingId;
        [Column(Storage = "_meetingId")]
        public int MeetingId
        {
            get { return _meetingId; }
            set { _meetingId = value; }
        }

        #region IUserSchedule Members

        int IUserSchedule.IndexId
        {
            get { return _indexId; }
        }
        int IUserSchedule.UserId
        {
            get { return _userId; }
        }

        DateTime IUserSchedule.FromTime
        {
            get { return _fromTime; }
        }

        DateTime IUserSchedule.ToTime
        {
            get { return _toTime; }
        }

        string IUserSchedule.ScheduleEntryDescription
        {
            get { return _scheduleEntryDescription; }
        }

        int IUserSchedule.ScheduleEntryType
        {
            get { return _scheduleEntryType; }
        }

        int IUserSchedule.MeetingId
        {
            get { return _meetingId; }
        }

        #endregion
    }
}
