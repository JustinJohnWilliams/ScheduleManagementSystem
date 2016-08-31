using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagementSystem.Contract.Model;
using ScheduleManagementSystem.Dal.Database;

namespace ScheduleManagementSystem.Dal
{
    public class CustomSettingRepository
    {
        private string _connectionString;

        public CustomSettingRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ICustomSetting GetCustomSettings()
        {
            using (ManagementSystemDataContext dataContext = new ManagementSystemDataContext(_connectionString))
            {
                return dataContext.CustomSettingDtos.First();
            }
        }

        public void SetCustomSettings(ICustomSetting customSetting)
        {
            using (ManagementSystemDataContext dataContext = new ManagementSystemDataContext(_connectionString))
            {
                CustomSettingDto customSettingDto = dataContext.CustomSettingDtos.First();
                customSettingDto.ViewDays = customSetting.ViewDays;
                customSettingDto.WorkDayBegin = customSetting.WorkDayBegin;
                customSettingDto.WorkDayEnd = customSetting.WorkDayEnd;

                dataContext.SubmitChanges();
            }
        }
    }
}
