using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagementSystem.Contract.Dal;
using ScheduleManagementSystem.Contract.Model;
using ScheduleManagementSystem.Model;

namespace ScheduleManagementSystem.Control
{
    public class UserMeetingController
    {
        private IMeetingScheduler _meetingScheduler = DependancyInjection.Instance.Resolve<IMeetingScheduler>();
        private IMeetingRetriever _meetingRetriever = DependancyInjection.Instance.Resolve<IMeetingRetriever>();
        private IUserSaver _userSaver = DependancyInjection.Instance.Resolve<IUserSaver>();
        private IUserRetriever _userRetriever = DependancyInjection.Instance.Resolve<IUserRetriever>();
        private ILocationRetriever _locationRetriever = DependancyInjection.Instance.Resolve<ILocationRetriever>();

        private IView _view;


        public interface IView
        {
            /// <summary>
            /// notifies user of error
            /// </summary>
            /// <param name="error"></param>
            void NotifyError(string error);

            /// <summary>
            /// Populates meetings for users, displays name
            /// </summary>
            /// <param name="meetings"></param>
            /// <param name="userName"></param>
            void PopulateMeetings(List<MeetingResult> meetings, string userName);

            /// <summary>
            /// Populates additional information for meeting
            /// </summary>
            /// <param name="meeting"></param>
            void PopulateAdditionalInformation(IMeetingMaster meeting);
        }

        public UserMeetingController(IView view)
        {
            _view = view;
        }

        public IUser GetUser(int userId)
        {
            return _userRetriever.GetUserById(userId);
        }

        public void GetMeetingsForUser(int userId)
        {
            IUser user = _userRetriever.GetUserById(userId);
            string userFullName = _userRetriever.GetUserFullNameByUserId(userId);
            List<MeetingResult> meetings = new List<MeetingResult>();
            List<IMeetingMaster> meetingMasters = _meetingRetriever.GetAllMeetingsByUser(user);

            foreach (IMeetingMaster meeting in meetingMasters)
            {
                MeetingResult meetingResult = new MeetingResult();

                meetingResult.MeetingId = meeting.MeetingId;
                meetingResult.ActualLocationId = meeting.ActualLocationId;
                meetingResult.Date = meeting.MeetingStartTime.ToString();
                meetingResult.ActualLocation = _locationRetriever.GetLocationByLocationId(meeting.ActualLocationId).LocationName;
                meetingResult.ScheduledBy = _userRetriever.GetUserFullNameByUserId(meeting.MeetingCalledBy);
                meetingResult.Title = meeting.MeetingDesc;

                meetings.Add(meetingResult);
            }
            _view.PopulateMeetings(meetings, userFullName);
        }

        public void RequestAdditionalInformation(int meetingId)
        {
            IMeetingMaster meeting = _meetingRetriever.GetMeetingByMeetingId(meetingId);

            _view.PopulateAdditionalInformation(meeting);
        }
    }
}
