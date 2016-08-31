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
    public partial class _Default : System.Web.UI.Page, UserMeetingController.IView
    {
        private UserMeetingController _controller;
        private IUser _currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            _controller = new UserMeetingController(this);

            if (Request.QueryString.HasKeys())
            {
                int userId = Convert.ToInt32(Request.QueryString["UserId"].ToString());
                
                _currentUser = _controller.GetUser(userId);
                lblWelcome.Text = "Welcome, " + _currentUser.UserFirstName;

                _controller.GetMeetingsForUser(userId);
            }
            else
            {
                Response.Redirect("/LogIn.aspx");
            }
        }

        protected void lstVwMeeting_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                MeetingResult currentMeeting = ((ListViewDataItem)e.Item).DataItem as MeetingResult;
                ucMyMeetingDisplay currentMeetingDisplay = e.Item.FindControl("UCMeeting") as ucMyMeetingDisplay;
                (e.Item.FindControl("hdnFieldMeetingId") as HiddenField).Value = currentMeeting.MeetingId.ToString();
                (e.Item.FindControl("hdnFieldMeetingCalledBy") as HiddenField).Value = currentMeeting.MeetingCalledBy.ToString();
                currentMeetingDisplay.Initialize(currentMeeting);
            }

        }

        protected void lstVwMeeting_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int meetingId = Convert.ToInt32((e.Item.FindControl("hdnFieldMeetingId") as HiddenField).Value);
            ucMyMeetingDisplay objMeetingDisplay = e.Item.FindControl("UCMeeting") as ucMyMeetingDisplay;

            Response.Redirect("/MeetingDetail.aspx?UserId=" + _currentUser.UserId
                    + "&MeetingID=" + meetingId.ToString()
                    + "&ActualLocationText=" + (objMeetingDisplay.FindControl("lblMeetingLocation") as Label).Text
                    + "&MeetingTitle=" + (objMeetingDisplay.FindControl("lblMeetingTitle") as Label).Text
                    + "&MeetingDate=" + (objMeetingDisplay.FindControl("lblProjectedDate") as Label).Text
                    + "&MeetingScheduledByUserName=" + (objMeetingDisplay.FindControl("lblScheduledBy") as Label).Text
                    + "&MeetingScheduledByID=" + Convert.ToString((e.Item.FindControl("hdnFieldMeetingCalledBy") as HiddenField).Value));

            // Come back and implement this for same-page implementation
            // should do this now, but we'll try the easy way first...
            //_controller.RequestAdditionalInformation(meetingId);
        }

        protected void lnkButtonMyMeetings_OnClick(object sender, EventArgs e)
        {
            // do nothing
        }

        protected void lnkButtonViewFacilities_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/Facilities.aspx?UserId=" + _currentUser.UserId);
        }

        protected void lnkButtonViewMeetings_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/Meetings.aspx?UserId=" + _currentUser.UserId);
        }

        protected void lnkButtonMySettings_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/Settings.aspx?UserId=" + _currentUser.UserId);
        }

        protected void lnkButtonHelpSupport_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/HelpAndSupport.aspx?UserId=" + _currentUser.UserId);
        }



        #region IView Members

        void UserMeetingController.IView.NotifyError(string error)
        {
            lblErrorMessage.Text = error;
        }

        void UserMeetingController.IView.PopulateMeetings(List<MeetingResult> meetings, string userName)
        {
            lblWelcome.Text = "Welcome, " + userName + "!";

            if (meetings.Count == 0)
            {
                lblMeetingCount.Text = "No meetings currently scheduled.";
            }
            else
            {
                lblMeetingCount.Text = "Currently involved in: " + meetings.Count.ToString();
                lstVwMeeting.DataSource = meetings;
                lstVwMeeting.DataBind();
            }
        }

        void UserMeetingController.IView.PopulateAdditionalInformation(IMeetingMaster meeting)
        {
            // show additional information some how... modal popup? fields? ajax? grr...
        }

        #endregion
    }
}
