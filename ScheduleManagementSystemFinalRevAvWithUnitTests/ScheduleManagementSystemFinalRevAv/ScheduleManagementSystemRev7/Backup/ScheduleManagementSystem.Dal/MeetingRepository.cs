using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagementSystem.Contract.Dal;
using ScheduleManagementSystem.Contract.Model;
using ScheduleManagementSystem.Dal.Database;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace ScheduleManagementSystem.Dal
{
    public class MeetingRepository : IMeetingRetriever, IMeetingScheduler, ILocationRetriever, ILocationSaver, IMeetingResponseTypeRetriever
    {
        private string _connectionString;

        public MeetingRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        //TODO: Implement interface methods.

        #region IMeetingRetriever Members

        List<IMeetingMaster> IMeetingRetriever.GetAllMeetingsByUser(IUser user)
        {
            using (ManagementSystemDataContext dataContext = new ManagementSystemDataContext(_connectionString))
            {
                List<IMeetingMaster> meetings = new List<IMeetingMaster>();

                List<int> meetingIds = (from schedules in dataContext.Meeting_ResponseDtos
                                        where schedules.FKUserId == user.UserId
                                            && schedules.MeetingId != 0
                                        select schedules.MeetingId).ToList();

                if (meetingIds.Count != 0)
                {
                    foreach (int id in meetingIds)
                    {
                        meetings.Add(dataContext.Meeting_MasterDtos.Single(c => c.MeetingId == id));
                    }

                    return meetings;
                }
                else
                {
                    return new List<IMeetingMaster>();
                }
            }


        }

        List<IMeetingMaster> IMeetingRetriever.GetMeetingsByLocation(ILocationMaster location)
        {
            using (ManagementSystemDataContext dataContext = new ManagementSystemDataContext(_connectionString))
            {
                IEnumerable<Meeting_MasterDto> results = (from meeting in dataContext.Meeting_MasterDtos
                                                          where meeting.ActualLocationId == location.LocationId
                                                          select meeting);

                return results.Cast<IMeetingMaster>().ToList();
            }
        }

        IMeetingMaster IMeetingRetriever.GetMeetingByMeetingId(int meetingId)
        {
            using (ManagementSystemDataContext dataContext = new ManagementSystemDataContext(_connectionString))
            {
                return dataContext.Meeting_MasterDtos.SingleOrDefault(
                                                    c => c.MeetingId == meetingId);
            }
        }

        List<IMeetingMaster> IMeetingRetriever.GetAllMeetings()
        {
            using (ManagementSystemDataContext dataContext = new ManagementSystemDataContext(_connectionString))
            {
                IEnumerable<Meeting_MasterDto> meetings = (from meeting in dataContext.Meeting_MasterDtos
                                                           select meeting);
                return meetings.Cast<IMeetingMaster>().ToList();
            }
        }

        List<IvwMeetingResponse> IMeetingRetriever.GetMeetingResponsesByMeetingId(int meetingId)
        {
            using (ManagementSystemDataContext dataContext = new ManagementSystemDataContext(_connectionString))
            {
                IEnumerable<vw_MeetingResponseDto> responses = (from response in dataContext.vw_MeetingResponseDtos
                                                                where meetingId == response.MeetingId
                                                                select response);
                return responses.Cast<IvwMeetingResponse>().ToList();
            }
        }

        List<IMeetingResponseType> IMeetingRetriever.GetResponseTypeByID(int responseTypeId)
        {
            throw new NotImplementedException();
        }

        IUserSchedule IMeetingRetriever.GetUserBusyTime(int entryId)
        {
            using (ManagementSystemDataContext dataContext = new ManagementSystemDataContext(_connectionString))
            {
                return dataContext.UserScheduleDtos.Single(c => c.IndexId == entryId);
            }
        }


        #endregion

        #region IMeetingScheduler Members

        DataSet IMeetingScheduler.ScheduleMeeting(int Duration, DateTime fromTime, DateTime toTime, List<int> invitees, bool isAvRequired, bool isPhoneRequired, bool isVideoConfRequired, int PrefLocationID, int Priority)
        {
            //Lets get the start time of the meeting if it is possible to schedule a "preffered" meeting
            SqlConnection cn = new SqlConnection(_connectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GenerateMeetingTime";

            cmd.Parameters.Add(new SqlParameter("@Duration", Duration));
            cmd.Parameters.Add(new SqlParameter("@FromDate", fromTime));
            cmd.Parameters.Add(new SqlParameter("@ToDate", toTime));
            String invitedUsers = "";
            foreach (int usr in invitees)
            {
                invitedUsers += usr.ToString() + ",";
            }
            //trim the last stray ","
            invitedUsers = invitedUsers.Substring(0, invitedUsers.Length - 1);

            cmd.Parameters.Add(new SqlParameter("@Users", invitedUsers));

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            string lol = ds.Tables[0].Rows[0].Field<string>("MeetingStartTime") ?? string.Empty;

            if (lol.Equals(string.Empty))
            {
                //This means no preferred time is available. We need to try again with any free time.

                cn = new SqlConnection(_connectionString);
                cn.Open();

                cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_CreateMeetingScheduleAvailability";

                cmd.Parameters.Add(new SqlParameter("@Duration", Duration));
                cmd.Parameters.Add(new SqlParameter("@FromDate", fromTime));
                cmd.Parameters.Add(new SqlParameter("@ToDate", toTime));
                cmd.Parameters.Add(new SqlParameter("@Users", invitedUsers));

                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }

            return ds;
        }

        void IMeetingScheduler.CreateMeeting(String Desc, DateTime StartTime, DateTime EndTime, int priority
                , List<int> userIds, bool avRequired, bool phoneRequired
                , bool videoRequired, int prefLocation, int calledByUser
                , string myPhoneBridge, string myPhoneAccess
                , DateTime WindowStart, DateTime WindowEnd, int Duration)
        {
            int currentid;

            using (ManagementSystemDataContext dataContext = new ManagementSystemDataContext(_connectionString))
            {
                Meeting_MasterDto meetingMasterDto = new Meeting_MasterDto
                {
                    MeetingDesc = Desc,
                    MeetingStartTime = StartTime,
                    MeetingEndTime = EndTime,
                    MeetingPriority = priority,
                    IsAVRequired = avRequired,
                    IsPhoneRequired = phoneRequired,
                    IsVideoConfRequired = videoRequired,
                    PreferredLocationId = prefLocation,
                    ActualLocationId = prefLocation,
                    MeetingCalledBy = calledByUser,
                    PhoneBridge = myPhoneBridge,
                    PhoneBridgeAccessCode = myPhoneAccess,
                    MeetingWindowStart = WindowStart,
                    MeetingWindowEnd = WindowEnd,
                    MeetingDuration = Duration
                };

                dataContext.Meeting_MasterDtos.InsertOnSubmit(meetingMasterDto);
                dataContext.SubmitChanges();

                currentid = meetingMasterDto.MeetingId;
                List<Meeting_ResponseDto> meetingResponses = new List<Meeting_ResponseDto>();
                foreach (int usr in userIds)
                {
                    Meeting_ResponseDto meetingResponseDto = new Meeting_ResponseDto
                    {
                        MeetingId = currentid,
                        FKUserId = usr,
                        InvitedOn = DateTime.Now,
                        RespondedOn = null
                    };

                    meetingResponses.Add(meetingResponseDto);
                }


                dataContext.Meeting_ResponseDtos.InsertAllOnSubmit<Meeting_ResponseDto>(meetingResponses);
                dataContext.SubmitChanges();
            }
        }

        void IMeetingScheduler.ScheduleUserBusyTime(string description, DateTime beginTime, DateTime endTime, int userId)
        {
            using (ManagementSystemDataContext dataContext = new ManagementSystemDataContext(_connectionString))
            {
                UserScheduleDto userScheduleDto = new UserScheduleDto
                {
                    FromTime = beginTime,
                    ToTime = endTime,
                    UserId = userId,
                    ScheduleEntryDescription = description,
                    ScheduleEntryType = 1
                };

                dataContext.UserScheduleDtos.InsertOnSubmit(userScheduleDto);
                dataContext.SubmitChanges();
            }
        }

        void IMeetingScheduler.RemoveUserBusyTime(int userScheduleIndexId)
        {
            using (ManagementSystemDataContext dataContext = new ManagementSystemDataContext(_connectionString))
            {
                dataContext.UserScheduleDtos.DeleteAllOnSubmit(dataContext.UserScheduleDtos.Where(c => c.IndexId == userScheduleIndexId));
                dataContext.SubmitChanges();
            }
        }

        #endregion

        #region ILocationRetriever Members

        ILocationMaster ILocationRetriever.GetLocationByLocationId(int locationId)
        {
            using (ManagementSystemDataContext dataContext = new ManagementSystemDataContext(_connectionString))
            {
                return dataContext.Location_MasterDtos.SingleOrDefault(
                                            c => c.LocationId == locationId);
            }
        }

        List<ILocationMaster> ILocationRetriever.GetAllLocations()
        {
            using (ManagementSystemDataContext dataContext = new ManagementSystemDataContext(_connectionString))
            {
                IEnumerable<Location_MasterDto> results = (from location in dataContext.Location_MasterDtos
                                                           select location);

                return results.Cast<ILocationMaster>().ToList();
            }
        }

        List<ILocationMaster> ILocationRetriever.GetLocationsFromSearchCriteria(IUser user, bool isAvRequired, bool isPhoneRequired, bool isVideoConfRequired, int capacity)
        {
            using (ManagementSystemDataContext dataContext = new ManagementSystemDataContext(_connectionString))
            {
                IEnumerable<Location_MasterDto> results = (from location in dataContext.Location_MasterDtos
                                                           where isAvRequired == location.IsAVAvailable
                                                                && isPhoneRequired == location.IsPhoneAvailable
                                                                && isVideoConfRequired == location.IsVideoConfAvailable
                                                                && capacity <= location.LocationCapacity
                                                           select location);
                return results.Cast<ILocationMaster>().ToList();
            }
        }

        #endregion

        #region IMeetingResponseTypeRetriever Members

        List<IMeetingResponseType> IMeetingResponseTypeRetriever.GetResponseTypes()
        {
            using (ManagementSystemDataContext dataContext = new ManagementSystemDataContext(_connectionString))
            {
                IEnumerable<MeetingResponseTypeDto> meetingResponseTypes = (from types in dataContext.MeetingResponseTypeDtos
                                                                            select types);
                return meetingResponseTypes.Cast<IMeetingResponseType>().ToList();
            }
        }

        #endregion

        #region ILocationSaver Members

        void ILocationSaver.SaveLocation(ILocationMaster location)
        {
            using (ManagementSystemDataContext datacontext = new ManagementSystemDataContext(_connectionString))
            {
                if (datacontext.Location_MasterDtos.Any(c => c.LocationId == location.LocationId))
                {
                    Location_MasterDto lcm = datacontext.Location_MasterDtos.Single(c => c.LocationId == location.LocationId);
                    lcm.IsAVAvailable = location.IsAvAvailable;
                    lcm.IsPhoneAvailable = location.IsPhoneAvailable;
                    lcm.IsVideoConfAvailable = location.IsVideoConfAvailable;
                    lcm.LocationBuilding = location.LocationBuilding;
                    lcm.LocationCapacity = location.LocationCapacity;
                    lcm.LocationFloor = location.LocationFloor;
                    lcm.LocationName = location.LocationName;
                    lcm.LocationRoom = location.LocationRoom;
                }
                else
                {
                    Location_MasterDto lcm = new Location_MasterDto
                    {
                        IsAVAvailable = location.IsAvAvailable,
                        IsPhoneAvailable = location.IsPhoneAvailable,
                        IsVideoConfAvailable = location.IsVideoConfAvailable,
                        LocationBuilding = location.LocationBuilding,
                        LocationCapacity = location.LocationCapacity,
                        LocationFloor = location.LocationFloor,
                        LocationName = location.LocationName,
                        LocationRoom = location.LocationRoom
                    };

                    datacontext.Location_MasterDtos.InsertOnSubmit(lcm);
                }

                datacontext.SubmitChanges();


            }
        }

        void ILocationSaver.RemoveLocation(int locationId)
        {
            using (ManagementSystemDataContext datacontext = new ManagementSystemDataContext(_connectionString))
            {
                datacontext.Location_MasterDtos.DeleteAllOnSubmit(datacontext.Location_MasterDtos.Where(c => c.LocationId == locationId));
                datacontext.SubmitChanges();
            }
        }

        #endregion
    }
}
