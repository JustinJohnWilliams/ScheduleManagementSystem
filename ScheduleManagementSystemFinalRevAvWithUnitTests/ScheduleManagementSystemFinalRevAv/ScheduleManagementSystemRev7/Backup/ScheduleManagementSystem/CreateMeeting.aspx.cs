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
using System.Collections.Generic;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem
{
    public partial class CreateMeeting : System.Web.UI.Page, CreateMeetingController.IView
    {
        private CreateMeetingController _controller;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.HasKeys())
                {
                    _controller = new CreateMeetingController(this);
                    List<IUser> users = _controller.GetAllUsers();
                    chkBoxListUsers.DataSource = users;
                    chkBoxListUsers.DataTextField = "UserName";
                    chkBoxListUsers.DataValueField = "UserId";
                    chkBoxListUsers.DataBind();

                    List<ILocationMaster> locations = _controller.GetAllLocations();
                    ddlLocations.DataSource = locations;
                    ddlLocations.DataTextField = "LocationName";
                    ddlLocations.DataValueField = "LocationId";
                    ddlLocations.DataBind();

                }
                else
                {
                    Response.Redirect("/LogIn.aspx");
                }
            }
        }

        protected void btnCreateMeeting_Click(object sender, EventArgs e)
        {
            _controller = new CreateMeetingController(this);
            List<int> userIds = new List<int>();

            string title = txtBoxMeetingTitle.Text.Trim();
            bool avRequired = chckavRequired.Checked;
            bool phoneRequired = chckphoneRequired.Checked;
            bool videoRequired = chckvideoRequired.Checked;
            DateTime windowStart = Convert.ToDateTime(txtBoxStartDate.Text.Trim());
            DateTime windowEnd = Convert.ToDateTime(txtBoxEndDate.Text.Trim());
            int duration = Convert.ToInt32(txtBoxDuration.Text.Trim());
            int prefLocId = Convert.ToInt32(ddlLocations.SelectedValue);
            string PhoneBridge = txtBoxPhone.Text.Trim();
            string PhoneAccessCode = txtBoxPhoneAccess.Text.Trim();

            foreach (ListItem item in chkBoxListUsers.Items)
            {
                if (item.Selected == true)
                {
                    userIds.Add(Convert.ToInt32(item.Value));
                }
            }

            int priority = Convert.ToInt32(ddlPriority.SelectedValue);

            _controller.CreateMeeting(userIds, title, windowStart, windowEnd, duration
                    , avRequired, phoneRequired, videoRequired, prefLocId, priority
                    , Convert.ToInt32(Request.QueryString["UserId"])
                    , PhoneBridge, PhoneAccessCode);

        }

        protected void lnkButtonMyMeetings_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/default.aspx?userid=" + Request.QueryString["UserId"].ToString());
        }

        protected void lnkButtonViewFacilities_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/Facilities.aspx?userid=" + Request.QueryString["UserId"].ToString());
        }

        protected void lnkButtonViewMeetings_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/Meetings.aspx?UserId=" + Request.QueryString["UserId"].ToString());
        }

        protected void lnkButtonMySettings_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/Settings.aspx?userid=" + Request.QueryString["UserId"].ToString());
        }

        protected void lnkButtonHelpSupport_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/helpandsupport.aspx?userid=" + Request.QueryString["UserId"].ToString());
        }

        protected void lnkButtonCreateMeeting_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/CreateMeeting.aspx?userid=" + Request.QueryString["UserId"].ToString());
        }

        #region IView Members

        void CreateMeetingController.IView.NotifyError(string error)
        {
            lblErrorMessage.Text = error;
            lblErrorMessage.Visible = true;
        }

        void CreateMeetingController.IView.NotifySuccess(string success)
        {
            lblSuccess.Text = success;
            lblSuccess.Visible = true;

            txtBoxMeetingTitle.Text = string.Empty;
            chckavRequired.Checked = false;
            chckphoneRequired.Checked = false;
            chckvideoRequired.Checked = false;
            txtBoxStartDate.Text = string.Empty;
            txtBoxEndDate.Text = string.Empty;
            txtBoxDuration.Text = string.Empty;
            ddlLocations.SelectedIndex = 0;
            txtBoxPhone.Text = string.Empty;
            txtBoxPhoneAccess.Text = string.Empty;
            foreach (ListItem item in chkBoxListUsers.Items)
            {
                item.Selected = false;
            }
        }

        #endregion
    }
}
