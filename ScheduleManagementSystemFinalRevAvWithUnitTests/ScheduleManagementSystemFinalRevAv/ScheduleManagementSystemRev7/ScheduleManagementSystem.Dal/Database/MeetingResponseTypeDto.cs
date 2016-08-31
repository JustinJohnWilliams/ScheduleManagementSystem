using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Dal.Database
{
    [Table(Name = "dbo.MeetingResponseType")]
    internal class MeetingResponseTypeDto : IMeetingResponseType
    {
        private int _responseType;
        [Column(Storage = "_responseType")]
        public int ResponseType
        {
            get { return _responseType; }
            set { _responseType = value; }
        }

        private string _responseTypeDescription;
        [Column(Storage = "_responseTypeDescription")]
        public string ResponseTypeDescription
        {
            get { return _responseTypeDescription; }
            set { _responseTypeDescription = value; }
        }

        #region IMeetingResponseType Members

        int IMeetingResponseType.ResponseType
        {
            get { return _responseType; }
        }

        string IMeetingResponseType.ResponseTypeDescription
        {
            get { return _responseTypeDescription; }
        }

        #endregion
    }
}
