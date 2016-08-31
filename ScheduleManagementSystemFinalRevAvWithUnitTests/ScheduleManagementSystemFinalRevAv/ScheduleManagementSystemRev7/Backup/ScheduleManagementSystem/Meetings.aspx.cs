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
using ScheduleManagementSystem.Model;
using ScheduleManagementSystem.UserControls;

namespace ScheduleManagementSystem
{
    public partial class Meetings : System.Web.UI.Page, MeetingController.IView
    {
        private MeetingController _controller;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.HasKeys())
            {
                _controller = new MeetingController(this);
                List<MeetingResult> meetings = _controller.GetAllMeetings();
                lstVwMeeting.DataSource = meetings;
                lstVwMeeting.DataBind();
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
                ucMeetingDisplay currentMeetingDisplay = e.Item.FindControl("UCMeeting") as ucMeetingDisplay;
                currentMeetingDisplay.Initialize(currentMeeting);
            }
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
            // do nothing.
        }

        protected void lnkButtonMySettings_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/settings.aspx?userid=" + Request.QueryString["UserId"].ToString());
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

        void MeetingController.IView.NotifyError(string errorMessage)
        {
            lblErrorMessage.Text = errorMessage;
        }

        #endregion
    }
}
