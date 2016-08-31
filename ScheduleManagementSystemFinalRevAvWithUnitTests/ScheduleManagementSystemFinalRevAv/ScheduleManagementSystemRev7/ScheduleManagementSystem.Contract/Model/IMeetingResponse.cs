using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleManagementSystem.Contract.Model
{
    public interface IMeetingResponse
    {
        int ResponseId { get; }
        int MeetingId { get; }
        int FKUserId { get; }
        DateTime InvitedOn { get; }
        Nullable<DateTime> RespondedOn { get; }
        int ResponseType { get; }
    }
}
