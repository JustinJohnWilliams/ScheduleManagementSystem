using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Dal.Database
{
    [Table(Name = "dbo.UserGroup")]
    internal class UserGroupDto : IUserGroup
    {
        private int _userId;
        [Column(Storage = "_userId")]
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private int _groupId;
        [Column(Storage = "_groupId")]
        public int GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        #region IUserGroup Members

        int IUserGroup.UserId
        {
            get { return _userId; }
        }

        int IUserGroup.GroupId
        {
            get { return _groupId; }
        }

        #endregion
    }
}
