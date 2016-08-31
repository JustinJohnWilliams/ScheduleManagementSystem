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
using ScheduleManagementSystem.Contract.Model;
using System.Collections.Generic;
using ScheduleManagementSystem.UserControls;
using ScheduleManagementSystem.Model;

namespace ScheduleManagementSystem.View
{
    public partial class _MeetingDetails : System.Web.UI.Page, MeetingDetailsController.IView
    {
        private MeetingDetailsController _controller;
        int userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            _controller = new MeetingDetailsController(this);

            if (Request.QueryString.HasKeys())
            {
                userId = Convert.ToInt32(Request.QueryString["UserId"].ToString());
                int meetingId = Convert.ToInt32(Request.QueryString["MeetingID"]);
                txtMeetingLocation.Text = Request.QueryString["ActualLocationText"];
                txtMeetingTitle.Text = Request.QueryString["MeetingTitle"];
                txtMeetingDate.Text = Request.QueryString["MeetingDate"];
                txtMeetingScheduledBy.Text = Request.QueryString["MeetingScheduledByUserName"];
                int facilitatorId = Convert.ToInt32(Request.QueryString["MeetingScheduledByID"]);

                //If this is the user that created the meeting, give the option
                //  of editing the meeting
                if(userId == facilitatorId)
                    btnEditMeeting.Visible = true;

                _controller.GetMeetingResponses(meetingId);
            }
            else
            {
                Response.Redirect("/LogIn.aspx");
            }
        }

        void MeetingDetailsController.IView.NotifyError(string errorMessage)
        {
            lblErrorMessage.Text = errorMessage;
        }

        void MeetingDetailsController.IView.PopulateResponses(List<IvwMeetingResponse> responses)
        {
            gvMeetingResponses.DataSource = responses;
            gvMeetingResponses.DataBind();
        }

        protected void btnEditMeeting_Click(object sender, EventArgs e)
        {
            //TODO
            // Send to the "Create Meeting" page
            // with the data pre-loaded from this meeting
            // is there a better way to do that??
        }

        #region Menu Links
        protected void lnkButtonMyMeetings_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx?UserId=" + userId.ToString());
        }

        protected void lnkButtonViewFacilities_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/Facilities.aspx?UserId=" + userId.ToString());
        }

        protected void lnkButtonViewMeetings_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/Meetings.aspx?UserId=" + userId.ToString());
        }

        protected void lnkButtonMyPreferences_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/Preferences.aspx?UserId=" + userId.ToString());
        }

        protected void lnkButtonHelpSupport_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/HelpAndSupport.aspx?UserId=" + userId.ToString());
        }

        #endregion
    }
}
