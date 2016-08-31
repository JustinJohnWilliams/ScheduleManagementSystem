using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagementSystem.Contract.Dal;
using ScheduleManagementSystem.Contract.Model;
using ScheduleManagementSystem.Dal.Database;

namespace ScheduleManagementSystem.Dal
{
    public class UserRepository : IUserRetriever, IUserSaver
    {
        private string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region IUserSaver Members

        void IUserSaver.InsertUser(IUser user)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserRetriever Members

        IUser IUserRetriever.GetUserById(int userId)
        {
            using (ManagementSystemDataContext dataContext = new ManagementSystemDataContext(_connectionString))
            {
                return dataContext.UserDtos.SingleOrDefault(
                                        w => w.UserId == userId);
            }
        }

        List<IUser> IUserRetriever.GetAllUsers()
        {
            using (ManagementSystemDataContext dataContext = new ManagementSystemDataContext(_connectionString))
            {
                IEnumerable<UserDto> users = (from user in dataContext.UserDtos
                                              select user);
                return users.Cast<IUser>().ToList();
            }
        }

        List<IUser> IUserRetriever.GetUsersByMeeting(IMeetingMaster meeting)
        {
            throw new NotImplementedException();
        }

        bool IUserRetriever.IsUserValid(string userName, string password)
        {
            using (ManagementSystemDataContext dataContext = new ManagementSystemDataContext(_connectionString))
            {
                return dataContext.UserDtos.Any(
                                        w => w.UserName == userName
                                            && w.Password == password);
            }
        }

        int IUserRetriever.GetUserId(string userName, string password)
        {
            using (ManagementSystemDataContext dataContext = new ManagementSystemDataContext(_connectionString))
            {
                return dataContext.UserDtos.SingleOrDefault(
                                        w => w.UserName == userName 
                                            && w.Password == password).UserId;
            }
        }

        string IUserRetriever.GetUserFullNameByUserId(int userId)
        {
            using (ManagementSystemDataContext dataContext = new ManagementSystemDataContext(_connectionString))
            {
                string firstName = dataContext.UserDtos.SingleOrDefault(
                                                    u => u.UserId == userId).UserFirstName;
                string lastName = dataContext.UserDtos.SingleOrDefault(
                                                    u => u.UserId == userId).UserLastName;

                return string.Concat(firstName, " ", lastName);
            }
        }

        List<IUserSchedule> IUserRetriever.GetUserSchedules(List<int> userIds)
        {
            List<IUserSchedule> userSchedules = new List<IUserSchedule>();
            using (ManagementSystemDataContext dataContext = new ManagementSystemDataContext(_connectionString))
            {
                foreach(int id in userIds)
                {
                    UserScheduleDto userScheduleDto = dataContext.UserScheduleDtos.SingleOrDefault(
                                                        c => c.UserId == id);
                    userSchedules.Add(userScheduleDto);
                }
            }

            return userSchedules;
        }

        List<IUserSchedule> IUserRetriever.GetUserSchedule(int userId)
        {
            List<IUserSchedule> userSchedule = new List<IUserSchedule>();
            using (ManagementSystemDataContext dataContext = new ManagementSystemDataContext(_connectionString))
            {
                userSchedule = (from schedule in dataContext.UserScheduleDtos
                               where schedule.UserId == userId
                               select schedule).Cast<IUserSchedule>().ToList();
            }

            return userSchedule;
        }

        #endregion
    }
}
