using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagementSystem.Contract.Dal;
using ScheduleManagementSystem.Model;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Control
{
    public class MeetingController
    {
        private IMeetingRetriever _meetingRetriever = DependancyInjection.Instance.Resolve<IMeetingRetriever>();
        private ILocationRetriever _locationRetriever = DependancyInjection.Instance.Resolve<ILocationRetriever>();
        private IUserRetriever _userRetriever = DependancyInjection.Instance.Resolve<IUserRetriever>();

        private IView _view;

        public interface IView
        {
            /// <summary>
            /// notifies user of error
            /// </summary>
            /// <param name="errorMessage"></param>
            void NotifyError(string errorMessage);
        }

        public MeetingController(IView view)
        {
            _view = view;
        }

        public List<MeetingResult> GetAllMeetings()
        {
            List<IMeetingMaster> results = _meetingRetriever.GetAllMeetings();
            List<MeetingResult> meetings = new List<MeetingResult>();

            foreach (IMeetingMaster result in results)
            {
                MeetingResult meeting = new MeetingResult();

                meeting.AgendaURL = result.AgendaURL;
                meeting.IsAVRequired = result.IsAVRequired;
                meeting.IsPhoneRequired = result.IsPhoneRequired;
                meeting.IsVideoConfRequired = result.IsVideoConfRequired;
                meeting.PreferredLocation = _locationRetriever.GetLocationByLocationId(result.PreferredLocationId).LocationName;
                meeting.ActualLocation = _locationRetriever.GetLocationByLocationId(result.ActualLocationId).LocationName;
                meeting.MeetingDesc = result.MeetingDesc;
                meeting.MeetingEndTime = result.MeetingEndTime;
                meeting.MeetingPriority = result.MeetingPriority;//todo
                meeting.MeetingStartTime = result.MeetingStartTime;
                meeting.MinutesURL = result.MinutesURL;
                meeting.PhoneBridge = result.PhoneBridge;
                meeting.PhoneBridgeAccessCode = result.PhoneBridgeAccessCode;
                meeting.ScheduledBy = _userRetriever.GetUserFullNameByUserId(result.MeetingCalledBy);
                meeting.Title = result.MeetingDesc;

                meetings.Add(meeting);
            }

            return meetings;
        }

        public MeetingResult GetMeetingById(int meetingId)
        {
            IMeetingMaster result = _meetingRetriever.GetMeetingByMeetingId(meetingId);

            MeetingResult meeting = new MeetingResult();
            
            meeting.AgendaURL = result.AgendaURL;
            meeting.IsAVRequired = result.IsAVRequired;
            meeting.IsPhoneRequired = result.IsPhoneRequired;
            meeting.IsVideoConfRequired = result.IsVideoConfRequired;
            meeting.PreferredLocation = _locationRetriever.GetLocationByLocationId(result.PreferredLocationId).LocationName;
            meeting.ActualLocation = _locationRetriever.GetLocationByLocationId(result.ActualLocationId).LocationName;
            meeting.MeetingDesc = result.MeetingDesc;
            meeting.MeetingEndTime = result.MeetingEndTime;
            meeting.MeetingPriority = result.MeetingPriority;//todo
            meeting.MeetingStartTime = result.MeetingStartTime;
            meeting.MinutesURL = result.MinutesURL;
            meeting.PhoneBridge = result.PhoneBridge;
            meeting.PhoneBridgeAccessCode = result.PhoneBridgeAccessCode;
            meeting.ScheduledBy = _userRetriever.GetUserFullNameByUserId(result.MeetingCalledBy);
            meeting.Title = result.MeetingDesc;
            meeting.MeetingDuration = result.MeetingDuration;

            return meeting;
        }
    }
}
