using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleManagementSystem.Contract.Model
{
    public interface ITaskGroup
    {
        int GroupId { get; }
        int TaskId { get; }
    }
}
