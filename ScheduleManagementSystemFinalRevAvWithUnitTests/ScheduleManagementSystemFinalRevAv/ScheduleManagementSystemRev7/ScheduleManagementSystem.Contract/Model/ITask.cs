using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleManagementSystem.Contract.Model
{
    public interface ITask
    {
        int TaskId { get; }
        string TaskDescription { get; }
    }
}
