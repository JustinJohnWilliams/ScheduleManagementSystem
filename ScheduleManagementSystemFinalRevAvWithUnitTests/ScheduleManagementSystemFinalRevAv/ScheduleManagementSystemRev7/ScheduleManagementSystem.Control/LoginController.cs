using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScheduleManagementSystem.Contract.Dal;
using ScheduleManagementSystem.Dal;

namespace ScheduleManagementSystem.Control
{
    public class LoginController
    {
        private IView _view;
        private IUserRetriever _userRetriever = DependancyInjection.Instance.Resolve<IUserRetriever>();

        public LoginController(IView view)
        {
            _view = view;
        }

        public interface IView
        {
            /// <summary>
            /// Notifies user of error
            /// </summary>
            /// <param name="error"></param>
            void NotifyError(string error);
        }

        public bool IsUserValid(string userName, string password)
        {
            return _userRetriever.IsUserValid(userName, password);
        }

        public int GetUserId(string userName, string password)
        {
            return _userRetriever.GetUserId(userName, password);
        }
    }
}
