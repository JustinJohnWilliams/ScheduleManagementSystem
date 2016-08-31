using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ScheduleManagementSystem.Control;

namespace ScheduleManagementDashboard
{
    public partial class LogIn : System.Web.UI.Page, LoginController.IView
    {
        private LoginController _controller;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            _controller = new LoginController(this);
            string userName = txtBoxUserName.Text.Trim();
            string password = txtBoxPassword.Text.Trim();
            bool isValid = _controller.IsUserValid(userName, password);

            if (isValid)
            {
                int userId = _controller.GetUserId(userName, password);
                Response.Redirect("/Default.aspx?UserId=" + userId);
            }
            else
            {
                lblErrorMessage.Text = "Error - Incorrect Username/Password";
            }
        }

        #region IView Members

        void LoginController.IView.NotifyError(string error)
        {
            lblErrorMessage.Text = error;
        }

        #endregion
    }
}
