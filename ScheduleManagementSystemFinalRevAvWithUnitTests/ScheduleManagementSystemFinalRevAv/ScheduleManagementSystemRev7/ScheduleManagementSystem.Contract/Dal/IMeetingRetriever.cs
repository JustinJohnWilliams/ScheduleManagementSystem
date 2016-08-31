using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Contract.Dal
{
    public interface IMeetingRetriever
    {
        /// <summary>
        /// Returns list of meetings with given user in attendance
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<IMeetingMaster> GetAllMeetingsByUser(IUser user);

        /// <summary>
        /// Returns all meetings for given location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        List<IMeetingMaster> GetMeetingsByLocation(ILocationMaster location);

        /// <summary>
        /// Returns meeting from given meetingId
        /// </summary>
        /// <param name="meetingId"></param>
        /// <returns></returns>
        IMeetingMaster GetMeetingByMeetingId(int meetingId);

        /// <summary>
        /// Returns a list of all meetings
        /// </summary>
        /// <returns></returns>
        List<IMeetingMaster> GetAllMeetings();

        /// <summary>
        /// Returns responses for meeting from given meetingId using the view
        /// </summary>
        /// <param name="meetingId"></param>
        /// <returns></returns>
        List<IvwMeetingResponse> GetMeetingResponsesByMeetingId(int meetingId);

        /// <summary>
        /// Get the Meeting Response Display text for an ID number
        /// </summary>
        /// <param name="responseTypeId"></param>
        /// <returns></returns>
        List<IMeetingResponseType> GetResponseTypeByID(int responseTypeId);

        /// <summary>
        /// Retruns a user schedule based off of the schedule entry type id
        /// </summary>
        /// <param name="scheduleEntryId"></param>
        /// <returns></returns>
        IUserSchedule GetUserBusyTime(int scheduleEntryId);
    }
}
