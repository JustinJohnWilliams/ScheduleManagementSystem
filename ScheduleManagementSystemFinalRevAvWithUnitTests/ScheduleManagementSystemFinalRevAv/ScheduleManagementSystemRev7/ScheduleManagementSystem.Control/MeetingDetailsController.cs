using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagementSystem.Contract.Dal;
using ScheduleManagementSystem.Contract.Model;
using ScheduleManagementSystem.Model;

namespace ScheduleManagementSystem.Control
{

    public class MeetingDetailsController
    {
        private IMeetingRetriever _meetingRetriever = DependancyInjection.Instance.Resolve<IMeetingRetriever>();

        private IView _view;

        public interface IView
        {
            /// <summary>
            /// notifies user of error
            /// </summary>
            /// <param name="errorMessage"></param>
            void NotifyError(string errorMessage);

            /// <summary>
            /// Populates the responses for the meeting
            /// </summary>
            /// <param name="responses"></param>
            void PopulateResponses(List<IvwMeetingResponse> responses);
        }

        public MeetingDetailsController(IView view)
        {
            _view = view;
        }

        public void GetMeetingResponses(int MeetingId)
        {
            List<IvwMeetingResponse> responses = _meetingRetriever.GetMeetingResponsesByMeetingId(MeetingId);
            _view.PopulateResponses(responses);
        }

    }
}
