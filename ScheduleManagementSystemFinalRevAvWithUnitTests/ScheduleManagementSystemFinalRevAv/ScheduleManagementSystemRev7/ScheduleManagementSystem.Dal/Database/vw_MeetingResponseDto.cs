using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Dal.Database
{
    [Table(Name = "dbo.vw_MeetingResponse")]
    class vw_MeetingResponseDto : IvwMeetingResponse
    {
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

        private String _UserDisplayName;
        [Column(Storage = "_UserDisplayName")]
        public String UserDisplayName
        {
            get { return _UserDisplayName; }
            set { _UserDisplayName = value; }
        }

        private DateTime _invitedOn;
        [Column(Storage = "_invitedOn")]
        public DateTime InvitedOn
        {
            get { return _invitedOn; }
            set { _invitedOn = value; }
        }

        private DateTime _respondedOn;
        [Column(Storage = "_respondedOn")]
        public DateTime RespondedOn
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

        private String _ResponseTypeDescription;
        [Column(Storage = "_ResponseTypeDescription")]
        public String ResponseTypeDescription
        {
            get { return _ResponseTypeDescription; }
            set { _ResponseTypeDescription = value; }
        }

        #region IvwMeetingResponse Members

        int IvwMeetingResponse.MeetingId
        {
            get { return _meetingId; }
        }

        int IvwMeetingResponse.FKUserId
        {
            get { return _fkUserId; }
        }

        String IvwMeetingResponse.UserDisplayName
        {
            get { return _UserDisplayName; }
        }

        DateTime IvwMeetingResponse.InvitedOn
        {
            get { return _invitedOn; }
        }

        DateTime IvwMeetingResponse.RespondedOn
        {
            get { return _respondedOn; }
        }

        int IvwMeetingResponse.ResponseType
        {
            get { return _responseType; }
        }

        String IvwMeetingResponse.ResponseTypeDescription
        {
            get { return _ResponseTypeDescription; }
        }

        #endregion
    }
}
