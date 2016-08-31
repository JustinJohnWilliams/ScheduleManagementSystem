using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleManagementSystem.Contract.Model
{
    public interface IUserGroup
    {
        int UserId { get; }
        int GroupId { get; }
    }
}
