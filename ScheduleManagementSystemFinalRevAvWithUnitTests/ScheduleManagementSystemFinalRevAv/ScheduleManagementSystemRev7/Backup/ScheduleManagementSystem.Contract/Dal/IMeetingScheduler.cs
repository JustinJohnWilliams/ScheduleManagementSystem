using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagementSystem.Contract.Model;
using System.Data;

namespace ScheduleManagementSystem.Contract.Dal
{
    public interface IMeetingScheduler
    {
        /// <summary>
        /// Finds time the meeting should be scheduled at.
        /// </summary>
        /// <param name="Duration"></param>
        /// <param name="fromTime"></param>
        /// <param name="toTime"></param>
        /// <param name="invitees"></param>
        /// <param name="isAvRequired"></param>
        /// <param name="isPhoneRequired"></param>
        /// <param name="isVideoConfRequired"></param>
        /// <param name="PrefLocationID"></param>
        /// <param name="Priority"></param>
        /// <returns></returns>
        DataSet ScheduleMeeting(int Duration, DateTime fromTime, DateTime toTime, List<int> invitees, bool isAvRequired, bool isPhoneRequired, bool isVideoConfRequired, int PrefLocationID, int Priority);

        /// <summary>
        /// Responsible for creating meeting.
        /// </summary>
        /// <param name="Desc"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="priority"></param>
        /// <param name="userIds"></param>
        /// <param name="avRequired"></param>
        /// <param name="phoneRequired"></param>
        /// <param name="videoRequired"></param>
        /// <param name="prefLocation"></param>
        /// <param name="calledByUser"></param>
        /// <param name="myPhoneBridge"></param>
        /// <param name="myPhoneAccess"></param>
        /// <param name="WindowStart"></param>
        /// <param name="WindowEnd"></param>
        /// <param name="Duration"></param>
        void CreateMeeting(String Desc, DateTime StartTime, DateTime EndTime, int priority
                , List<int> userIds, bool avRequired, bool phoneRequired
                , bool videoRequired, int prefLocation, int calledByUser
                , string myPhoneBridge, string myPhoneAccess
                , DateTime WindowStart, DateTime WindowEnd, int Duration);

        /// <summary>
        /// Schedules a users busy time that is not a meeeting.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="userId"></param>
        void ScheduleUserBusyTime(string description, DateTime beginTime, DateTime endTime, int userId);

        /// <summary>
        /// Removes User Schedule entry based on index id.
        /// </summary>
        /// <param name="userScheduleIndexId"></param>
        void RemoveUserBusyTime(int userScheduleIndexId);
    }
}
