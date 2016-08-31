using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Dal.Database
{
    [Table(Name = "dbo.TaskGroup")]
    internal class TaskGroupDto : ITaskGroup
    {
        private int _groupId;
        [Column(Storage = "_groupId")]
        public int GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        private int _taskId;
        [Column(Storage = "_taskId")]
        public int TaskId
        {
            get { return _taskId; }
            set { _taskId = value; }
        }

        #region ITaskGroup Members

        int ITaskGroup.GroupId
        {
            get { return _groupId; }
        }

        int ITaskGroup.TaskId
        {
            get { return _taskId; }
        }

        #endregion
    }
}
