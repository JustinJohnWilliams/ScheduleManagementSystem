using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Contract.Dal
{
    public interface IUserSaver
    {
        /// <summary>
        /// inserts a new user.
        /// </summary>
        /// <param name="user"></param>
        void InsertUser(IUser user);
    }
}
