using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace ScheduleManagementSystem.Dal.Database
{
    internal class ManagementSystemDataContext : System.Data.Linq.DataContext
    {
        public ManagementSystemDataContext(string connectionString)
            : base(connectionString)
        { }

        internal Table<GroupDto> GroupDtos { get { return GetTable<GroupDto>(); } }
        internal Table<Location_MasterDto> Location_MasterDtos { get { return GetTable<Location_MasterDto>(); } }
        internal Table<Meeting_MasterDto> Meeting_MasterDtos { get { return GetTable<Meeting_MasterDto>(); } }
        internal Table<Meeting_ResponseDto> Meeting_ResponseDtos { get { return GetTable<Meeting_ResponseDto>(); } }
        internal Table<MeetingResponseTypeDto> MeetingResponseTypeDtos { get { return GetTable<MeetingResponseTypeDto>(); } }
        internal Table<ScheduleEntryTypeDto> ScheduleEntryTypeDtos { get { return GetTable<ScheduleEntryTypeDto>(); } }
        internal Table<TaskDto> TaskDtos { get { return GetTable<TaskDto>(); } }
        internal Table<TaskGroupDto> TaskGroupDtos { get { return GetTable<TaskGroupDto>(); } }
        internal Table<UserDto> UserDtos { get { return GetTable<UserDto>(); } }
        internal Table<UserGroupDto> UserGroupDtos { get { return GetTable<UserGroupDto>(); } }
        internal Table<UserScheduleDto> UserScheduleDtos { get { return GetTable<UserScheduleDto>(); } }
        internal Table<vw_MeetingResponseDto> vw_MeetingResponseDtos { get { return GetTable<vw_MeetingResponseDto>(); } }
        internal Table<CustomSettingDto> CustomSettingDtos { get { return GetTable<CustomSettingDto>(); } }
    }
}
