using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Dal.Database
{
    [Table(Name = "dbo.Task")]
    internal class TaskDto : ITask
    {
        private int _taskId;
        [Column(Storage = "_taskId")]
        public int TaskId
        {
            get { return _taskId; }
            set { _taskId = value; }
        }

        private string _taskDescription;
        [Column(Storage = "_taskDescription")]
        public string TaskDescription
        {
            get { return _taskDescription; }
            set { _taskDescription = value; }
        }

        #region ITask Members

        int ITask.TaskId
        {
            get { return _taskId; }
        }

        string ITask.TaskDescription
        {
            get { return _taskDescription; }
        }

        #endregion
    }
}
