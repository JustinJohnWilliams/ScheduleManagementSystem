using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleManagementSystem.Contract.Model
{
    public interface IMeetingResponseType
    {
        int ResponseType { get; }
        string ResponseTypeDescription { get; }
    }
}
