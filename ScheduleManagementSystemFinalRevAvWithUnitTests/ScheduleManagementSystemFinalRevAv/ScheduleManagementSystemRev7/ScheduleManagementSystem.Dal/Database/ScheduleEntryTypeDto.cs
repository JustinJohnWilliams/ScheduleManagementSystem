using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Dal.Database
{
    [Table(Name = "dbo.ScheduleEntryType")]
    internal class ScheduleEntryTypeDto : IScheduleEntryType
    {
        private int _scheduleEntryTypeId;
        [Column(Storage = "_secheduleEntryTypeId")]
        public int ScheduleEntryTypeId
        {
            get { return _scheduleEntryTypeId; }
            set { _scheduleEntryTypeId = value; }
        }

        private string _scheduleEntryTypeDescription;
        [Column(Storage = "_scheduleEntryTypeDescription")]
        public string ScheduleEntryTypeDescription
        {
            get { return _scheduleEntryTypeDescription; }
            set { _scheduleEntryTypeDescription = value; }
        }

        #region IScheduleEntryType Members

        int IScheduleEntryType.ScheduleEntryTypeId
        {
            get { return _scheduleEntryTypeId; }
        }

        string IScheduleEntryType.ScheduleEntryTypeDescription
        {
            get { return _scheduleEntryTypeDescription; }
        }

        #endregion
    }
}
