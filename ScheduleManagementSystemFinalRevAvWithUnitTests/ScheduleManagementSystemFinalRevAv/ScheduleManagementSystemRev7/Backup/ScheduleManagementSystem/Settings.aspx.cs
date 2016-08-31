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
using DayPilot.Web.Ui;
using System.Collections.Generic;
using ScheduleManagementSystem.Model;

namespace ScheduleManagementSystem
{
    public partial class Settings : System.Web.UI.Page, SettingsController.IView
    {
        SettingsController _controller;

        IUser _currentUser;
        int _currentYear;
        int _currentMonth;
        int _currentDay;

        protected void Page_Load(object sender, EventArgs e)
        {
            tableAddEntry.Visible = false;

            SetDailyCalendarSettings();

            if (Request.QueryString.HasKeys())
            {
                _controller = new SettingsController(this);

                int userId = Convert.ToInt32(Request.QueryString["UserId"].ToString());

                _currentUser = _controller.GetCurrerntUserById(userId);
                List<IUserSchedule> userSchedule = _controller.GetUserScheduleById(userId);

                PopulateCalendar(userSchedule);
            }
            else
            {
                Response.Redirect("/LogIn.aspx");
            }

        }

        private void SetDailyCalendarSettings()
        {
            _controller = new SettingsController(this);

            ICustomSetting customSetting = _controller.GetCustomSettings();
            DailyCalendar.Days = customSetting.ViewDays;
            DailyCalendar.BusinessBeginsHour = customSetting.WorkDayBegin;
            DailyCalendar.BusinessEndsHour = customSetting.WorkDayEnd;
            
        }

        private void PopulateCalendar(List<IUserSchedule> userSchedule)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("start", typeof(DateTime));
            dataTable.Columns.Add("end", typeof(DateTime));
            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("name", typeof(string));

            foreach (IUserSchedule entry in userSchedule)
            {
                DataRow row = dataTable.NewRow();
                row["start"] = entry.FromTime;
                row["end"] = entry.ToTime;
                row["id"] = entry.IndexId;
                row["name"] = entry.ScheduleEntryDescription;

                dataTable.Rows.Add(row);
                
            }

            DailyCalendar.DataStartField = "start";
            DailyCalendar.DataEndField = "end";
            DailyCalendar.DataTextField = "name";
            DailyCalendar.DataValueField = "id";

            DailyCalendar.DataSource = dataTable;
            DailyCalendar.DataBind();
        }

        protected void btnScheduleBusyTime_Click(object sender, EventArgs e)
        {
            string description = txtBoxDescription.Text.Trim();
            int userId = _currentUser.UserId;
            DateTime beginTime = Convert.ToDateTime(lblStartTimeData.Text);
            int endMinute = Convert.ToInt32(ddlEndTimeMinute.SelectedValue);
            int endHour = Convert.ToInt32(ddlEndTimeHour.SelectedValue);
            if (ddlEndTimeAMPM.SelectedValue == "PM")
                endHour += 12;

            _currentYear = Convert.ToInt32(Session["Year"].ToString());
            _currentMonth = Convert.ToInt32(Session["Month"].ToString());
            _currentDay = Convert.ToInt32(Session["Day"].ToString());

            DateTime endTime = new DateTime(_currentYear, _currentMonth, _currentDay, endHour, endMinute, 0);

            
            _controller.ScheduleBusyTime(description, beginTime, endTime, userId);

            Response.Redirect("/Settings.aspx?UserId=" + userId);
        }
        
        protected void DailyCalendar_EventClick(object sender, EventClickEventArgs e)
        {
            int scheduleEntryId = Convert.ToInt32(e.Value);

            MeetingResult meetingResult = _controller.GetEventInformationById(scheduleEntryId);

            if (meetingResult.MeetingId == 0)
            {
                txtBoxMeetingTitle.Text = meetingResult.Title;
                txtBoxMeetingTitle.Enabled = true;
                txtBoxFromTime.Text = meetingResult.MeetingStartTime.ToString();
                txtBoxFromTime.Enabled = true;
                txtBoxToTime.Text = meetingResult.MeetingEndTime.ToString();
                txtBoxToTime.Enabled = true;
                lblMeetingCalledBy.Visible = false;
                txtBoxMeetingCalledBy.Visible = false;
                lblMEetingPriority.Visible = false;
                txtBoxMeetingPriority.Visible = false;
                lblAgendaUrl.Visible = false;
                txtBoxAgendaUrl.Visible = false;
                lblPhoneBridge.Visible = false;
                txtBoxPhoneBridge.Visible = false;
                lblPhoneBridgeAccessCode.Visible = false;
                txtBoxPhoneBridgeAccessCode.Visible = false;
                lblLocation.Visible = false;
                txtBoxLocation.Visible = false;
                lblMinutesUrl.Visible = false;
                txtBoxMinutesUrl.Visible = false;

                
                btnDelete.Visible = true;

                hiddenMeetingId.Value = meetingResult.UserScheduleIndexId.ToString();
            }
            else
            {
                txtBoxMeetingTitle.Text = meetingResult.Title;
                txtBoxFromTime.Text = meetingResult.MeetingStartTime.ToString();
                txtBoxToTime.Text = meetingResult.MeetingEndTime.ToString();
                txtBoxMeetingCalledBy.Text = meetingResult.ScheduledBy;
                txtBoxMeetingPriority.Text = meetingResult.MeetingPriority.ToString();
                txtBoxAgendaUrl.Text = meetingResult.AgendaURL;
                txtBoxPhoneBridge.Text = meetingResult.PhoneBridge;
                txtBoxPhoneBridgeAccessCode.Text = meetingResult.PhoneBridgeAccessCode;
                txtBoxLocation.Text = meetingResult.ActualLocation;
                txtBoxMinutesUrl.Text = meetingResult.MinutesURL;
                
            }

            pop.Show();
        }

        protected void DailyCalendar_FreeTimeClick(object sender, FreeClickEventArgs e)
        {
            _currentYear = e.Start.Year;
            _currentMonth = e.Start.Month;
            _currentDay = e.Start.Day;

            Session["Year"] = _currentYear;
            Session["Month"] = _currentMonth;
            Session["Day"] = _currentDay;

            lblStartTimeData.Text = new DateTime(_currentYear, _currentMonth, _currentDay, e.Start.Hour, e.Start.Minute, 0).ToString();

            tableAddEntry.Visible = true;
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            _controller = new SettingsController(this);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            _controller = new SettingsController(this);

            _controller.RemoveBusyTime(Convert.ToInt32(hiddenMeetingId.Value));
            Response.Redirect("/Settings.aspx?UserId=" + _currentUser.UserId);
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
            Response.Redirect("/Meetings.aspx?userid=" + Request.QueryString["UserId"].ToString());
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
            //do nothing
        }

        #region IView Members

        void SettingsController.IView.NotifyError(string errorMessage)
        {
            lblErrorMessage.Visible = true;
            lblErrorMessage.Text = errorMessage;
        }

        #endregion
    }
}
