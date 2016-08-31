using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleManagementSystem.Contract.Model
{
    public interface IUser
    {
        int UserId { get; }
        string UserName { get; }
        string UserFirstName { get; }
        string UserLastName { get; }
        string UserEmail { get; }
        string Password { get; }
        DateTime PasswordActivateDate { get; }
        bool RequirePasswordReset { get; }
    }
}
