using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Dal.Database
{
    [Table(Name = "dbo.Group")]
    internal class GroupDto : IGroup
    {
        private int _groupId;
        [Column(Storage = "_groupId")]
        public int GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        private string _groupDescription;
        [Column(Storage = "_groupDescription")]
        public string GroupDescription
        {
            get { return _groupDescription; }
            set { _groupDescription = value; }
        }

        #region IGroup Members

        int IGroup.GroupId
        {
            get { return _groupId; }
        }

        string IGroup.GroupDescription
        {
            get { return _groupDescription; }
        }

        #endregion
    }
}
