using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Contract.Dal
{
    public interface IUserRetriever
    {
        /// <summary>
        /// returns user
        /// </summary>
        /// <returns></returns>
        IUser GetUserById(int userId); //todo: search criteria

        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns></returns>
        List<IUser> GetAllUsers();

        /// <summary>
        /// Returns all users in particular meeting
        /// </summary>
        /// <param name="meeting"></param>
        /// <returns></returns>
        List<IUser> GetUsersByMeeting(IMeetingMaster meeting);


        /// <summary>
        /// Returns true if user exists given username and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool IsUserValid(string userName, string password);


        /// <summary>
        /// Returns user id with given username and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        int GetUserId(string userName, string password);

        /// <summary>
        /// Returns first name and last name concatanated for user, given the userid
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        string GetUserFullNameByUserId(int userId);

        /// <summary>
        /// Returns list of UserSchedules by userIds
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        List<IUserSchedule> GetUserSchedules(List<int> userIds);

        /// <summary>
        /// Returns a list of UserSchedules for user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<IUserSchedule> GetUserSchedule(int userId);
    }
}
