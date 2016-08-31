using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleManagementSystem.Contract.Model
{
    public interface IvwMeetingResponse
    {
        int MeetingId { get; }
        int FKUserId { get; }
        String UserDisplayName { get; }
        DateTime InvitedOn { get; }
        DateTime RespondedOn { get; }
        int ResponseType { get; }
        String ResponseTypeDescription { get; }
    }
}
