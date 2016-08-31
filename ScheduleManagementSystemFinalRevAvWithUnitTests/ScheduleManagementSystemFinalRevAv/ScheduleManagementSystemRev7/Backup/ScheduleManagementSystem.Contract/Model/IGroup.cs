using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleManagementSystem.Contract.Model
{
    public interface IGroup
    {
        int GroupId { get;}
        string GroupDescription { get; }
    }
}
