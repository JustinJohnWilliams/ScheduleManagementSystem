using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using ScheduleManagementSystem.Contract.Dal;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Dal.Database
{
    [Table(Name = "dbo.CustomSettings")]
    internal class CustomSettingDto : ICustomSetting
    {
        private int _id;
        [Column(Storage = "_id", IsPrimaryKey=true, IsDbGenerated=true)]
        public int Id
        {
            get { return _id; }
        }

        private int _workDayBegin;
        [Column(Storage = "_workDayBegin")]
        public int WorkDayBegin
        {
            get { return _workDayBegin; }
            set { _workDayBegin = value; }
        }

        private int _workDayEnd;
        [Column(Storage = "_workDayEnd")]
        public int WorkDayEnd
        {
            get { return _workDayEnd; }
            set { _workDayEnd = value; }
        }

        private int _viewDays;
        [Column(Storage = "_viewDays")]
        public int ViewDays
        {
            get { return _viewDays; }
            set { _viewDays = value; }
        }

        #region ICustomSetting Members

        int ICustomSetting.Id
        {
            get { return _id; }
        }

        int ICustomSetting.WorkDayBegin
        {
            get { return _workDayBegin; }
        }

        int ICustomSetting.WorkDayEnd
        {
            get { return _workDayEnd; }
        }

        int ICustomSetting.ViewDays
        {
            get { return _viewDays; }
        }

        #endregion
    }
}
