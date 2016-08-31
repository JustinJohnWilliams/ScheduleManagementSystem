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
using ScheduleManagementSystem.Model;

namespace ScheduleManagementDashboard.UserControls
{
    public partial class ucEditMeetingDisplay : System.Web.UI.UserControl
    {
        public void Initialize(MeetingResult meeting)
        {
            if (meeting != null)
            {
                lblMeetingTitle.Text = meeting.Title;
                lblAccessCode.Text = meeting.PhoneBridgeAccessCode;
                lblActualLocation.Text = meeting.ActualLocation;
                lblAgendaUrl.Text = meeting.AgendaURL;
                lblEndTime.Text = meeting.MeetingEndTime.ToString();
                lblStartTime.Text = meeting.MeetingStartTime.ToString();
                lblPreferredLocation.Text = meeting.PreferredLocation;
                lblMinutesUrl.Text = meeting.MinutesURL;
                lblPhoneBridge.Text = meeting.PhoneBridge;
                lblPriority.Text = meeting.MeetingPriority.ToString();

                lblScheduledBy.Text = meeting.ScheduledBy;

                listItemAVRequired.Selected = meeting.IsAVRequired;
                listItemPhoneRequired.Selected = meeting.IsPhoneRequired;
                listItemVideoRequired.Selected = meeting.IsVideoConfRequired;
            }
        }
    }
}