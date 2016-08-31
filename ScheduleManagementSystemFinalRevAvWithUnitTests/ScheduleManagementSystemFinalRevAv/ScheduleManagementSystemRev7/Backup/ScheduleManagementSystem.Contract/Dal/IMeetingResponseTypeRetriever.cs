using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Contract.Dal
{
    public interface IMeetingResponseTypeRetriever
    {
        /// <summary>
        /// Get All of the Meeting Response Types
        /// </summary>
        /// <returns></returns>
        List<IMeetingResponseType> GetResponseTypes();
    }
}
