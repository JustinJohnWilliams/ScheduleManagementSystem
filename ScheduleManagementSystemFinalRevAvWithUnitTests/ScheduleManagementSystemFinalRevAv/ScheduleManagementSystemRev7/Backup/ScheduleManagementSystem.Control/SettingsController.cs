using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagementSystem.Contract.Dal;
using ScheduleManagementSystem.Contract.Model;
using ScheduleManagementSystem.Model;
using ScheduleManagementSystem.Dal;

namespace ScheduleManagementSystem.Control
{
    public class SettingsController
    {
        private IView _view;
        private IUserRetriever _userRetriever = DependancyInjection.Instance.Resolve<IUserRetriever>();
        private IMeetingRetriever _meetingRetriever = DependancyInjection.Instance.Resolve<IMeetingRetriever>();
        private ILocationRetriever _locationRetriever = DependancyInjection.Instance.Resolve<ILocationRetriever>();
        private IMeetingScheduler _meetingScheduler = DependancyInjection.Instance.Resolve<IMeetingScheduler>();
        private CustomSettingRepository _customSettingRepository = DependancyInjection.Instance.Resolve<CustomSettingRepository>();

        public SettingsController(IView view)
        {
            _view = view;        
        }


        public interface IView
        {
            /// <summary>
            /// Notifies user of error.
            /// </summary>
            /// <param name="errorMessage"></param>
            void NotifyError(string errorMessage);
        }



        public IUser GetCurrerntUserById(int userId)
        {
            return _userRetriever.GetUserById(userId);
        }

        public List<IUserSchedule> GetUserScheduleById(int userId)
        {
            return _userRetriever.GetUserSchedule(userId);
        }

        public void ScheduleBusyTime(string description, DateTime beginTime, DateTime endTime, int userId)
        {
            if (endTime.CompareTo(beginTime) <= 0)
                _view.NotifyError("Select a valid end time.");

            _meetingScheduler.ScheduleUserBusyTime(description, beginTime, endTime, userId);
        }

        public MeetingResult GetEventInformationById(int scheduleEntryId)
        {
            MeetingResult meetingResult = new MeetingResult();
            IUserSchedule userSchedule = _meetingRetriever.GetUserBusyTime(scheduleEntryId);
            
            if (userSchedule.MeetingId == 0)
            {
                meetingResult.UserScheduleIndexId = userSchedule.IndexId;
                meetingResult.Title = userSchedule.ScheduleEntryDescription;
                meetingResult.MeetingStartTime = userSchedule.FromTime;
                meetingResult.MeetingEndTime = userSchedule.ToTime;
                meetingResult.MeetingId = userSchedule.MeetingId;
            }
            else
            {
                IMeetingMaster result = _meetingRetriever.GetMeetingByMeetingId(userSchedule.MeetingId);
                
                meetingResult.AgendaURL = result.AgendaURL;
                meetingResult.IsAVRequired = result.IsAVRequired;
                meetingResult.IsPhoneRequired = result.IsPhoneRequired;
                meetingResult.IsVideoConfRequired = result.IsVideoConfRequired;
                meetingResult.PreferredLocation = _locationRetriever.GetLocationByLocationId(result.PreferredLocationId).LocationName;
                meetingResult.ActualLocation = _locationRetriever.GetLocationByLocationId(result.ActualLocationId).LocationName;
                meetingResult.MeetingDesc = result.MeetingDesc;
                meetingResult.MeetingEndTime = result.MeetingEndTime;
                meetingResult.MeetingPriority = result.MeetingPriority;//todo
                meetingResult.MeetingStartTime = result.MeetingStartTime;
                meetingResult.MinutesURL = result.MinutesURL;
                meetingResult.PhoneBridge = result.PhoneBridge;
                meetingResult.PhoneBridgeAccessCode = result.PhoneBridgeAccessCode;
                meetingResult.ScheduledBy = _userRetriever.GetUserFullNameByUserId(result.MeetingCalledBy);
                meetingResult.Title = result.MeetingDesc;
                meetingResult.MeetingId = userSchedule.MeetingId;
            }

            return meetingResult;
        }

        public ICustomSetting GetCustomSettings()
        {
            return _customSettingRepository.GetCustomSettings();
        }

        public void RemoveBusyTime(int userScheduleIndexId)
        {
            _meetingScheduler.RemoveUserBusyTime(userScheduleIndexId);
        }

        public void SetCustomSettings(int dayBegin, int dayEnd, int viewDays)
        {
            CustomSetting customSetting = new CustomSetting
                                                {
                                                    ViewDays = viewDays,
                                                    WorkDayBegin = dayBegin,
                                                    WorkDayEnd = dayEnd
                                                };
            _customSettingRepository.SetCustomSettings(customSetting);
        }
    }
}
