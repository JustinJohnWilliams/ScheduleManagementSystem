using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagementSystem.Contract.Model;
using ScheduleManagementSystem.Contract.Dal;
using ScheduleManagementSystem.Model;
using System.Data;

namespace ScheduleManagementSystem.Control
{
    public class CreateMeetingController
    {
        private IView _view;
        private IUserRetriever _userRetriever = DependancyInjection.Instance.Resolve<IUserRetriever>();
        private IMeetingScheduler _meetingScheduler = DependancyInjection.Instance.Resolve<IMeetingScheduler>();
        private ILocationRetriever _locationRetriever = DependancyInjection.Instance.Resolve<ILocationRetriever>();

        public CreateMeetingController(IView view)
        {
            _view = view;
        }

        public interface IView
        {
            /// <summary>
            /// Alerts view know of error
            /// </summary>
            /// <param name="error"></param>
            void NotifyError(string error);

            /// <summary>
            /// Notifies user of success
            /// </summary>
            /// <param name="success"></param>
            void NotifySuccess(string success);
        }


        public void CreateMeeting(List<int> userIds, string title, DateTime windowStart, DateTime windowEnd, int duration, bool avRequired, bool phoneRequired, bool videoRequired, int prefLocation, int priority, int calledByUser, string PhoneBridge, string PhoneAccess)
        {
            if (userIds.Count() == 0)
                _view.NotifyError("Must select at least 1 user to invite");

            DataSet MeetingTimes = _meetingScheduler.ScheduleMeeting(duration, windowStart, windowEnd, userIds, avRequired, phoneRequired, videoRequired, prefLocation, priority);

            if (MeetingTimes.Tables[0].Rows[0].Field<DateTime>("MeetingStartTime").Equals(null))
            {
                _view.NotifyError("No Meeting Time could be found");
            }
            else
            {
                _meetingScheduler.CreateMeeting(title, MeetingTimes.Tables[0].Rows[0].Field<DateTime>("MeetingStartTime"), MeetingTimes.Tables[0].Rows[0].Field<DateTime>("MeetingEndTime"), priority, userIds, avRequired, phoneRequired, videoRequired, prefLocation, calledByUser, PhoneBridge, PhoneAccess, windowStart, windowEnd, duration);
                _view.NotifySuccess("Meeting created Successfully!");
            }
        }

        public List<IUser> GetAllUsers()
        {
            List<IUser> users = _userRetriever.GetAllUsers();
            users.Remove(users.SingleOrDefault(c => c.UserName == "admin"));
            return users;
        }

        public List<ILocationMaster> GetAllLocations()
        {
            return _locationRetriever.GetAllLocations();
        }
    }
}
