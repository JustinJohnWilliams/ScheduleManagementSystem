﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4200
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ScheduleManagementSystem.Test.Dal.Utility
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="DMS")]
	public partial class DMSTestDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUserScheduleDto(UserScheduleDto instance);
    partial void UpdateUserScheduleDto(UserScheduleDto instance);
    partial void DeleteUserScheduleDto(UserScheduleDto instance);
    #endregion
		
		public DMSTestDataContext() : 
				base(global::ScheduleManagementSystem.Test.Properties.Settings.Default.DMSConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public DMSTestDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DMSTestDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DMSTestDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DMSTestDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<CustomSettingDto> CustomSettingDtos
		{
			get
			{
				return this.GetTable<CustomSettingDto>();
			}
		}
		
		public System.Data.Linq.Table<GroupDto> GroupDtos
		{
			get
			{
				return this.GetTable<GroupDto>();
			}
		}
		
		public System.Data.Linq.Table<Location_MasterDto> Location_MasterDtos
		{
			get
			{
				return this.GetTable<Location_MasterDto>();
			}
		}
		
		public System.Data.Linq.Table<Meeting_MasterDto> Meeting_MasterDtos
		{
			get
			{
				return this.GetTable<Meeting_MasterDto>();
			}
		}
		
		public System.Data.Linq.Table<Meeting_ResponseDto> Meeting_ResponseDtos
		{
			get
			{
				return this.GetTable<Meeting_ResponseDto>();
			}
		}
		
		public System.Data.Linq.Table<MeetingResponseTypeDto> MeetingResponseTypeDtos
		{
			get
			{
				return this.GetTable<MeetingResponseTypeDto>();
			}
		}
		
		public System.Data.Linq.Table<ScheduleEntryTypeDto> ScheduleEntryTypeDtos
		{
			get
			{
				return this.GetTable<ScheduleEntryTypeDto>();
			}
		}
		
		public System.Data.Linq.Table<TaskDto> TaskDtos
		{
			get
			{
				return this.GetTable<TaskDto>();
			}
		}
		
		public System.Data.Linq.Table<TaskGroupDto> TaskGroupDtos
		{
			get
			{
				return this.GetTable<TaskGroupDto>();
			}
		}
		
		public System.Data.Linq.Table<UserDto> UserDtos
		{
			get
			{
				return this.GetTable<UserDto>();
			}
		}
		
		public System.Data.Linq.Table<UserGroupDto> UserGroupDtos
		{
			get
			{
				return this.GetTable<UserGroupDto>();
			}
		}
		
		public System.Data.Linq.Table<UserScheduleDto> UserScheduleDtos
		{
			get
			{
				return this.GetTable<UserScheduleDto>();
			}
		}
	}
	
	[Table(Name="dbo.CustomSettings")]
	public partial class CustomSettingDto
	{
		
		private int _Id;
		
		private System.Nullable<int> _WorkDayBegin;
		
		private System.Nullable<int> _WorkDayEnd;
		
		private System.Nullable<int> _ViewDays;
		
		public CustomSettingDto()
		{
		}
		
		[Column(Storage="_Id", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this._Id = value;
				}
			}
		}
		
		[Column(Storage="_WorkDayBegin", DbType="Int")]
		public System.Nullable<int> WorkDayBegin
		{
			get
			{
				return this._WorkDayBegin;
			}
			set
			{
				if ((this._WorkDayBegin != value))
				{
					this._WorkDayBegin = value;
				}
			}
		}
		
		[Column(Storage="_WorkDayEnd", DbType="Int")]
		public System.Nullable<int> WorkDayEnd
		{
			get
			{
				return this._WorkDayEnd;
			}
			set
			{
				if ((this._WorkDayEnd != value))
				{
					this._WorkDayEnd = value;
				}
			}
		}
		
		[Column(Storage="_ViewDays", DbType="Int")]
		public System.Nullable<int> ViewDays
		{
			get
			{
				return this._ViewDays;
			}
			set
			{
				if ((this._ViewDays != value))
				{
					this._ViewDays = value;
				}
			}
		}
	}
	
	[Table(Name="dbo.[Group]")]
	public partial class GroupDto
	{
		
		private int _GroupId;
		
		private string _GroupDescription;
		
		public GroupDto()
		{
		}
		
		[Column(Storage="_GroupId", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int GroupId
		{
			get
			{
				return this._GroupId;
			}
			set
			{
				if ((this._GroupId != value))
				{
					this._GroupId = value;
				}
			}
		}
		
		[Column(Storage="_GroupDescription", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string GroupDescription
		{
			get
			{
				return this._GroupDescription;
			}
			set
			{
				if ((this._GroupDescription != value))
				{
					this._GroupDescription = value;
				}
			}
		}
	}
	
	[Table(Name="dbo.Location_Master")]
	public partial class Location_MasterDto
	{
		
		private int _LocationId;
		
		private string _LocationName;
		
		private string _LocationBuilding;
		
		private string _LocationFloor;
		
		private string _LocationRoom;
		
		private int _LocationCapacity;
		
		private System.Nullable<bool> _IsAVAvailable;
		
		private System.Nullable<bool> _IsPhoneAvailable;
		
		private System.Nullable<bool> _IsVideoConfAvailable;
		
		public Location_MasterDto()
		{
		}
		
		[Column(Storage="_LocationId", IsPrimaryKey=true, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int LocationId
		{
			get
			{
				return this._LocationId;
			}
			set
			{
				if ((this._LocationId != value))
				{
					this._LocationId = value;
				}
			}
		}
		
		[Column(Storage="_LocationName", DbType="VarChar(50)")]
		public string LocationName
		{
			get
			{
				return this._LocationName;
			}
			set
			{
				if ((this._LocationName != value))
				{
					this._LocationName = value;
				}
			}
		}
		
		[Column(Storage="_LocationBuilding", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string LocationBuilding
		{
			get
			{
				return this._LocationBuilding;
			}
			set
			{
				if ((this._LocationBuilding != value))
				{
					this._LocationBuilding = value;
				}
			}
		}
		
		[Column(Storage="_LocationFloor", DbType="VarChar(5) NOT NULL", CanBeNull=false)]
		public string LocationFloor
		{
			get
			{
				return this._LocationFloor;
			}
			set
			{
				if ((this._LocationFloor != value))
				{
					this._LocationFloor = value;
				}
			}
		}
		
		[Column(Storage="_LocationRoom", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string LocationRoom
		{
			get
			{
				return this._LocationRoom;
			}
			set
			{
				if ((this._LocationRoom != value))
				{
					this._LocationRoom = value;
				}
			}
		}
		
		[Column(Storage="_LocationCapacity", DbType="Int NOT NULL")]
		public int LocationCapacity
		{
			get
			{
				return this._LocationCapacity;
			}
			set
			{
				if ((this._LocationCapacity != value))
				{
					this._LocationCapacity = value;
				}
			}
		}
		
		[Column(Storage="_IsAVAvailable", DbType="Bit")]
		public System.Nullable<bool> IsAVAvailable
		{
			get
			{
				return this._IsAVAvailable;
			}
			set
			{
				if ((this._IsAVAvailable != value))
				{
					this._IsAVAvailable = value;
				}
			}
		}
		
		[Column(Storage="_IsPhoneAvailable", DbType="Bit")]
		public System.Nullable<bool> IsPhoneAvailable
		{
			get
			{
				return this._IsPhoneAvailable;
			}
			set
			{
				if ((this._IsPhoneAvailable != value))
				{
					this._IsPhoneAvailable = value;
				}
			}
		}
		
		[Column(Storage="_IsVideoConfAvailable", DbType="Bit")]
		public System.Nullable<bool> IsVideoConfAvailable
		{
			get
			{
				return this._IsVideoConfAvailable;
			}
			set
			{
				if ((this._IsVideoConfAvailable != value))
				{
					this._IsVideoConfAvailable = value;
				}
			}
		}
	}
	
	[Table(Name="dbo.Meeting_Master")]
	public partial class Meeting_MasterDto
	{
		
		private int _MeetingId;
		
		private string _MeetingDesc;
		
		private System.DateTime _MeetingStartTime;
		
		private System.DateTime _MeetingEndTime;
		
		private int _MeetingCalledBy;
		
		private int _MeetingPriority;
		
		private string _AgendaURL;
		
		private string _PhoneBridge;
		
		private string _PhoneBridgeAccessCode;
		
		private System.Nullable<int> _PreferredLocationId;
		
		private System.Nullable<int> _ActualLocationId;
		
		private string _MinutesURL;
		
		private bool _IsAVRequired;
		
		private bool _IsPhoneRequired;
		
		private bool _IsVideoConfRequired;
		
		private System.Nullable<System.DateTime> _MeetingWindowStart;
		
		private System.Nullable<System.DateTime> _MeetingWindowEnd;
		
		private System.Nullable<int> _MeetingDuration;
		
		public Meeting_MasterDto()
		{
		}
		
		[Column(Storage="_MeetingId", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int MeetingId
		{
			get
			{
				return this._MeetingId;
			}
			set
			{
				if ((this._MeetingId != value))
				{
					this._MeetingId = value;
				}
			}
		}
		
		[Column(Storage="_MeetingDesc", DbType="VarChar(50)")]
		public string MeetingDesc
		{
			get
			{
				return this._MeetingDesc;
			}
			set
			{
				if ((this._MeetingDesc != value))
				{
					this._MeetingDesc = value;
				}
			}
		}
		
		[Column(Storage="_MeetingStartTime", DbType="DateTime NOT NULL")]
		public System.DateTime MeetingStartTime
		{
			get
			{
				return this._MeetingStartTime;
			}
			set
			{
				if ((this._MeetingStartTime != value))
				{
					this._MeetingStartTime = value;
				}
			}
		}
		
		[Column(Storage="_MeetingEndTime", DbType="DateTime NOT NULL")]
		public System.DateTime MeetingEndTime
		{
			get
			{
				return this._MeetingEndTime;
			}
			set
			{
				if ((this._MeetingEndTime != value))
				{
					this._MeetingEndTime = value;
				}
			}
		}
		
		[Column(Storage="_MeetingCalledBy", DbType="Int NOT NULL")]
		public int MeetingCalledBy
		{
			get
			{
				return this._MeetingCalledBy;
			}
			set
			{
				if ((this._MeetingCalledBy != value))
				{
					this._MeetingCalledBy = value;
				}
			}
		}
		
		[Column(Storage="_MeetingPriority", DbType="Int NOT NULL")]
		public int MeetingPriority
		{
			get
			{
				return this._MeetingPriority;
			}
			set
			{
				if ((this._MeetingPriority != value))
				{
					this._MeetingPriority = value;
				}
			}
		}
		
		[Column(Storage="_AgendaURL", DbType="VarChar(255)")]
		public string AgendaURL
		{
			get
			{
				return this._AgendaURL;
			}
			set
			{
				if ((this._AgendaURL != value))
				{
					this._AgendaURL = value;
				}
			}
		}
		
		[Column(Storage="_PhoneBridge", DbType="VarChar(50)")]
		public string PhoneBridge
		{
			get
			{
				return this._PhoneBridge;
			}
			set
			{
				if ((this._PhoneBridge != value))
				{
					this._PhoneBridge = value;
				}
			}
		}
		
		[Column(Storage="_PhoneBridgeAccessCode", DbType="VarChar(15)")]
		public string PhoneBridgeAccessCode
		{
			get
			{
				return this._PhoneBridgeAccessCode;
			}
			set
			{
				if ((this._PhoneBridgeAccessCode != value))
				{
					this._PhoneBridgeAccessCode = value;
				}
			}
		}
		
		[Column(Storage="_PreferredLocationId", DbType="Int")]
		public System.Nullable<int> PreferredLocationId
		{
			get
			{
				return this._PreferredLocationId;
			}
			set
			{
				if ((this._PreferredLocationId != value))
				{
					this._PreferredLocationId = value;
				}
			}
		}
		
		[Column(Storage="_ActualLocationId", DbType="Int")]
		public System.Nullable<int> ActualLocationId
		{
			get
			{
				return this._ActualLocationId;
			}
			set
			{
				if ((this._ActualLocationId != value))
				{
					this._ActualLocationId = value;
				}
			}
		}
		
		[Column(Storage="_MinutesURL", DbType="VarChar(255)")]
		public string MinutesURL
		{
			get
			{
				return this._MinutesURL;
			}
			set
			{
				if ((this._MinutesURL != value))
				{
					this._MinutesURL = value;
				}
			}
		}
		
		[Column(Storage="_IsAVRequired", DbType="Bit NOT NULL")]
		public bool IsAVRequired
		{
			get
			{
				return this._IsAVRequired;
			}
			set
			{
				if ((this._IsAVRequired != value))
				{
					this._IsAVRequired = value;
				}
			}
		}
		
		[Column(Storage="_IsPhoneRequired", DbType="Bit NOT NULL")]
		public bool IsPhoneRequired
		{
			get
			{
				return this._IsPhoneRequired;
			}
			set
			{
				if ((this._IsPhoneRequired != value))
				{
					this._IsPhoneRequired = value;
				}
			}
		}
		
		[Column(Storage="_IsVideoConfRequired", DbType="Bit NOT NULL")]
		public bool IsVideoConfRequired
		{
			get
			{
				return this._IsVideoConfRequired;
			}
			set
			{
				if ((this._IsVideoConfRequired != value))
				{
					this._IsVideoConfRequired = value;
				}
			}
		}
		
		[Column(Storage="_MeetingWindowStart", DbType="DateTime")]
		public System.Nullable<System.DateTime> MeetingWindowStart
		{
			get
			{
				return this._MeetingWindowStart;
			}
			set
			{
				if ((this._MeetingWindowStart != value))
				{
					this._MeetingWindowStart = value;
				}
			}
		}
		
		[Column(Storage="_MeetingWindowEnd", DbType="DateTime")]
		public System.Nullable<System.DateTime> MeetingWindowEnd
		{
			get
			{
				return this._MeetingWindowEnd;
			}
			set
			{
				if ((this._MeetingWindowEnd != value))
				{
					this._MeetingWindowEnd = value;
				}
			}
		}
		
		[Column(Storage="_MeetingDuration", DbType="Int")]
		public System.Nullable<int> MeetingDuration
		{
			get
			{
				return this._MeetingDuration;
			}
			set
			{
				if ((this._MeetingDuration != value))
				{
					this._MeetingDuration = value;
				}
			}
		}
	}
	
	[Table(Name="dbo.Meeting_Response")]
	public partial class Meeting_ResponseDto
	{
		
		private int _MeetingId;
		
		private int _FKUserId;
		
		private System.DateTime _InvitedOn;
		
		private System.Nullable<System.DateTime> _RespondedOn;
		
		private System.Nullable<int> _ResponseType;
		
		private int _ResponseId;
		
		public Meeting_ResponseDto()
		{
		}
		
		[Column(Storage="_MeetingId", DbType="Int NOT NULL")]
		public int MeetingId
		{
			get
			{
				return this._MeetingId;
			}
			set
			{
				if ((this._MeetingId != value))
				{
					this._MeetingId = value;
				}
			}
		}
		
		[Column(Storage="_FKUserId", DbType="Int NOT NULL")]
		public int FKUserId
		{
			get
			{
				return this._FKUserId;
			}
			set
			{
				if ((this._FKUserId != value))
				{
					this._FKUserId = value;
				}
			}
		}
		
		[Column(Storage="_InvitedOn", DbType="DateTime NOT NULL")]
		public System.DateTime InvitedOn
		{
			get
			{
				return this._InvitedOn;
			}
			set
			{
				if ((this._InvitedOn != value))
				{
					this._InvitedOn = value;
				}
			}
		}
		
		[Column(Storage="_RespondedOn", DbType="DateTime")]
		public System.Nullable<System.DateTime> RespondedOn
		{
			get
			{
				return this._RespondedOn;
			}
			set
			{
				if ((this._RespondedOn != value))
				{
					this._RespondedOn = value;
				}
			}
		}
		
		[Column(Storage="_ResponseType", DbType="Int")]
		public System.Nullable<int> ResponseType
		{
			get
			{
				return this._ResponseType;
			}
			set
			{
				if ((this._ResponseType != value))
				{
					this._ResponseType = value;
				}
			}
		}
		
		[Column(Storage="_ResponseId", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int ResponseId
		{
			get
			{
				return this._ResponseId;
			}
			set
			{
				if ((this._ResponseId != value))
				{
					this._ResponseId = value;
				}
			}
		}
	}
	
	[Table(Name="dbo.MeetingResponseType")]
	public partial class MeetingResponseTypeDto
	{
		
		private int _ResponseType;
		
		private string _ResponseTypeDescription;
		
		public MeetingResponseTypeDto()
		{
		}
		
		[Column(Storage="_ResponseType", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int ResponseType
		{
			get
			{
				return this._ResponseType;
			}
			set
			{
				if ((this._ResponseType != value))
				{
					this._ResponseType = value;
				}
			}
		}
		
		[Column(Storage="_ResponseTypeDescription", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ResponseTypeDescription
		{
			get
			{
				return this._ResponseTypeDescription;
			}
			set
			{
				if ((this._ResponseTypeDescription != value))
				{
					this._ResponseTypeDescription = value;
				}
			}
		}
	}
	
	[Table(Name="dbo.ScheduleEntryType")]
	public partial class ScheduleEntryTypeDto
	{
		
		private int _ScheduleEntryTypeId;
		
		private string _ScheduleEntryTypeDescription;
		
		public ScheduleEntryTypeDto()
		{
		}
		
		[Column(Storage="_ScheduleEntryTypeId", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int ScheduleEntryTypeId
		{
			get
			{
				return this._ScheduleEntryTypeId;
			}
			set
			{
				if ((this._ScheduleEntryTypeId != value))
				{
					this._ScheduleEntryTypeId = value;
				}
			}
		}
		
		[Column(Storage="_ScheduleEntryTypeDescription", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ScheduleEntryTypeDescription
		{
			get
			{
				return this._ScheduleEntryTypeDescription;
			}
			set
			{
				if ((this._ScheduleEntryTypeDescription != value))
				{
					this._ScheduleEntryTypeDescription = value;
				}
			}
		}
	}
	
	[Table(Name="dbo.Task")]
	public partial class TaskDto
	{
		
		private int _TaskId;
		
		private string _TaskDescription;
		
		public TaskDto()
		{
		}
		
		[Column(Storage="_TaskId", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int TaskId
		{
			get
			{
				return this._TaskId;
			}
			set
			{
				if ((this._TaskId != value))
				{
					this._TaskId = value;
				}
			}
		}
		
		[Column(Storage="_TaskDescription", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string TaskDescription
		{
			get
			{
				return this._TaskDescription;
			}
			set
			{
				if ((this._TaskDescription != value))
				{
					this._TaskDescription = value;
				}
			}
		}
	}
	
	[Table(Name="dbo.TaskGroup")]
	public partial class TaskGroupDto
	{
		
		private int _GroupId;
		
		private int _TaskId;
		
		public TaskGroupDto()
		{
		}
		
		[Column(Storage="_GroupId", DbType="Int NOT NULL")]
		public int GroupId
		{
			get
			{
				return this._GroupId;
			}
			set
			{
				if ((this._GroupId != value))
				{
					this._GroupId = value;
				}
			}
		}
		
		[Column(Storage="_TaskId", DbType="Int NOT NULL")]
		public int TaskId
		{
			get
			{
				return this._TaskId;
			}
			set
			{
				if ((this._TaskId != value))
				{
					this._TaskId = value;
				}
			}
		}
	}
	
	[Table(Name="dbo.[User]")]
	public partial class UserDto
	{
		
		private int _UserId;
		
		private string _UserName;
		
		private string _UserFirstName;
		
		private string _UserLastName;
		
		private string _UserEmail;
		
		private string _Password;
		
		private System.DateTime _PasswordActiveDate;
		
		private bool _RequirePasswordReset;
		
		public UserDto()
		{
		}
		
		[Column(Storage="_UserId", IsPrimaryKey=true, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this._UserId = value;
				}
			}
		}
		
		[Column(Storage="_UserName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this._UserName = value;
				}
			}
		}
		
		[Column(Storage="_UserFirstName", DbType="VarChar(50)")]
		public string UserFirstName
		{
			get
			{
				return this._UserFirstName;
			}
			set
			{
				if ((this._UserFirstName != value))
				{
					this._UserFirstName = value;
				}
			}
		}
		
		[Column(Storage="_UserLastName", DbType="VarChar(50)")]
		public string UserLastName
		{
			get
			{
				return this._UserLastName;
			}
			set
			{
				if ((this._UserLastName != value))
				{
					this._UserLastName = value;
				}
			}
		}
		
		[Column(Storage="_UserEmail", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string UserEmail
		{
			get
			{
				return this._UserEmail;
			}
			set
			{
				if ((this._UserEmail != value))
				{
					this._UserEmail = value;
				}
			}
		}
		
		[Column(Storage="_Password", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this._Password = value;
				}
			}
		}
		
		[Column(Storage="_PasswordActiveDate", DbType="DateTime NOT NULL")]
		public System.DateTime PasswordActiveDate
		{
			get
			{
				return this._PasswordActiveDate;
			}
			set
			{
				if ((this._PasswordActiveDate != value))
				{
					this._PasswordActiveDate = value;
				}
			}
		}
		
		[Column(Storage="_RequirePasswordReset", DbType="Bit NOT NULL")]
		public bool RequirePasswordReset
		{
			get
			{
				return this._RequirePasswordReset;
			}
			set
			{
				if ((this._RequirePasswordReset != value))
				{
					this._RequirePasswordReset = value;
				}
			}
		}
	}
	
	[Table(Name="dbo.UserGroup")]
	public partial class UserGroupDto
	{
		
		private int _UserId;
		
		private int _GroupId;
		
		public UserGroupDto()
		{
		}
		
		[Column(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this._UserId = value;
				}
			}
		}
		
		[Column(Storage="_GroupId", DbType="Int NOT NULL")]
		public int GroupId
		{
			get
			{
				return this._GroupId;
			}
			set
			{
				if ((this._GroupId != value))
				{
					this._GroupId = value;
				}
			}
		}
	}
	
	[Table(Name="dbo.UserSchedule")]
	public partial class UserScheduleDto : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IndexId;
		
		private int _UserId;
		
		private System.DateTime _FromTime;
		
		private System.Nullable<System.DateTime> _ToTime;
		
		private string _ScheduleEntryDescription;
		
		private int _ScheduleEntryType;
		
		private int _MeetingId;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIndexIdChanging(int value);
    partial void OnIndexIdChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnFromTimeChanging(System.DateTime value);
    partial void OnFromTimeChanged();
    partial void OnToTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnToTimeChanged();
    partial void OnScheduleEntryDescriptionChanging(string value);
    partial void OnScheduleEntryDescriptionChanged();
    partial void OnScheduleEntryTypeChanging(int value);
    partial void OnScheduleEntryTypeChanged();
    partial void OnMeetingIdChanging(int value);
    partial void OnMeetingIdChanged();
    #endregion
		
		public UserScheduleDto()
		{
			OnCreated();
		}
		
		[Column(Storage="_IndexId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IndexId
		{
			get
			{
				return this._IndexId;
			}
			set
			{
				if ((this._IndexId != value))
				{
					this.OnIndexIdChanging(value);
					this.SendPropertyChanging();
					this._IndexId = value;
					this.SendPropertyChanged("IndexId");
					this.OnIndexIdChanged();
				}
			}
		}
		
		[Column(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[Column(Storage="_FromTime", DbType="DateTime NOT NULL")]
		public System.DateTime FromTime
		{
			get
			{
				return this._FromTime;
			}
			set
			{
				if ((this._FromTime != value))
				{
					this.OnFromTimeChanging(value);
					this.SendPropertyChanging();
					this._FromTime = value;
					this.SendPropertyChanged("FromTime");
					this.OnFromTimeChanged();
				}
			}
		}
		
		[Column(Storage="_ToTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> ToTime
		{
			get
			{
				return this._ToTime;
			}
			set
			{
				if ((this._ToTime != value))
				{
					this.OnToTimeChanging(value);
					this.SendPropertyChanging();
					this._ToTime = value;
					this.SendPropertyChanged("ToTime");
					this.OnToTimeChanged();
				}
			}
		}
		
		[Column(Storage="_ScheduleEntryDescription", DbType="VarChar(50)")]
		public string ScheduleEntryDescription
		{
			get
			{
				return this._ScheduleEntryDescription;
			}
			set
			{
				if ((this._ScheduleEntryDescription != value))
				{
					this.OnScheduleEntryDescriptionChanging(value);
					this.SendPropertyChanging();
					this._ScheduleEntryDescription = value;
					this.SendPropertyChanged("ScheduleEntryDescription");
					this.OnScheduleEntryDescriptionChanged();
				}
			}
		}
		
		[Column(Storage="_ScheduleEntryType", DbType="Int NOT NULL")]
		public int ScheduleEntryType
		{
			get
			{
				return this._ScheduleEntryType;
			}
			set
			{
				if ((this._ScheduleEntryType != value))
				{
					this.OnScheduleEntryTypeChanging(value);
					this.SendPropertyChanging();
					this._ScheduleEntryType = value;
					this.SendPropertyChanged("ScheduleEntryType");
					this.OnScheduleEntryTypeChanged();
				}
			}
		}
		
		[Column(Storage="_MeetingId", DbType="Int NOT NULL")]
		public int MeetingId
		{
			get
			{
				return this._MeetingId;
			}
			set
			{
				if ((this._MeetingId != value))
				{
					this.OnMeetingIdChanging(value);
					this.SendPropertyChanging();
					this._MeetingId = value;
					this.SendPropertyChanged("MeetingId");
					this.OnMeetingIdChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
