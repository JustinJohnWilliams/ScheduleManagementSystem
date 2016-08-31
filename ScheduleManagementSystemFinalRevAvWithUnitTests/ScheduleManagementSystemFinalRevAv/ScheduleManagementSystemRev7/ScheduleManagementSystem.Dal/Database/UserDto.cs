using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Dal.Database
{
    [Table(Name = "dbo.User")]
    internal class UserDto : IUser
    {
        private int _userId;
        [Column(Storage = "_userId")]
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private string _userName;
        [Column(Storage = "_userName")]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _userFirstName;
        [Column(Storage = "_userFirstName")]
        public string UserFirstName
        {
            get { return _userFirstName; }
            set { _userFirstName = value; }
        }

        private string _userLastName;
        [Column(Storage = "_userLastName")]
        public string UserLastName
        {
            get { return _userLastName; }
            set { _userLastName = value; }
        }

        private string _userEmail;
        [Column(Storage = "_userEmail")]
        public string UserEmail
        {
            get { return _userEmail; }
            set { _userEmail = value; }
        }

        private string _password;
        [Column(Storage = "_password")]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private DateTime _passwordActiveDate;
        [Column(Storage = "_passwordActiveDate")]
        public DateTime PasswordActiveDate
        {
            get { return _passwordActiveDate; }
            set { _passwordActiveDate = value; }
        }

        private bool _requirePasswordReset;
        [Column(Storage = "_requirePasswordReset")]
        public bool RequirePasswordReset
        {
            get { return _requirePasswordReset; }
            set { _requirePasswordReset = value; }
        }



        #region IUser Members

        int IUser.UserId
        {
            get { return _userId; }
        }

        string IUser.UserName
        {
            get { return _userName; }
        }

        string IUser.UserFirstName
        {
            get { return _userFirstName; }
        }

        string IUser.UserLastName
        {
            get { return _userLastName; }
        }

        string IUser.UserEmail
        {
            get { return _userEmail; }
        }

        string IUser.Password
        {
            get { return _password; }
        }

        DateTime IUser.PasswordActivateDate
        {
            get { return _passwordActiveDate; }
        }

        bool IUser.RequirePasswordReset
        {
            get { return _requirePasswordReset; }
        }

        #endregion
    }
}
