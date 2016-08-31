using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Dal.Database
{
    [Table(Name = "dbo.Meeting_Response")]
    internal class Meeting_ResponseDto : IMeetingResponse
    {
        private int _responseId;
        [Column(Storage = "_responseId", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ResponseId
        {
            get { return _responseId; }
            set { _responseId = value; }
        }

        private int _meetingId;
        [Column(Storage = "_meetingId")]
        public int MeetingId
        {
            get { return _meetingId; }
            set { _meetingId = value; }
        }

        private int _fkUserId;
        [Column(Storage = "_fkUserId")]
        public int FKUserId
        {
            get { return _fkUserId; }
            set { _fkUserId = value; }
        }

        private DateTime _invitedOn;
        [Column(Storage = "_invitedOn")]
        public DateTime InvitedOn
        {
            get { return _invitedOn; }
            set { _invitedOn = value; }
        }

        private Nullable<DateTime> _respondedOn;
        [Column(Storage = "_respondedOn")]
        public Nullable<DateTime> RespondedOn
        {
            get { return _respondedOn; }
            set { _respondedOn = value; }
        }

        private int _responseType;
        [Column(Storage = "_responseType")]
        public int ResponseType
        {
            get { return _responseType; }
            set { _responseType = value; }
        }

        #region IMeetingResponse Members

        int IMeetingResponse.MeetingId
        {
            get { return _meetingId; }
        }

        int IMeetingResponse.FKUserId
        {
            get { return _fkUserId; }
        }

        DateTime IMeetingResponse.InvitedOn
        {
            get { return _invitedOn; }
        }

        Nullable<DateTime> IMeetingResponse.RespondedOn
        {
            get { return _respondedOn; }
        }

        int IMeetingResponse.ResponseType
        {
            get { return _responseType; }
        }

        #endregion
    }
}
