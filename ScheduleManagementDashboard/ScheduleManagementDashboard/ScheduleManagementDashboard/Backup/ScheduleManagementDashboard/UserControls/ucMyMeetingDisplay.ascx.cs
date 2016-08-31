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
using ScheduleManagementSystem.Contract.Model;
using ScheduleManagementSystem.Contract.Dal;
using ScheduleManagementSystem.Control;
using System.Collections.Generic;
using ScheduleManagementSystem.Model;

namespace ScheduleManagementDashboard.UserControls
{
    public partial class ucMyMeetingDisplay : UserControl
    {
        public void Initialize(MeetingResult meeting)
        {
            if (meeting != null)
            {
                lblMeetingLocation.Text = meeting.ActualLocation;
                lblMeetingTitle.Text = meeting.Title;
                lblProjectedDate.Text = meeting.Date;
                lblScheduledBy.Text = meeting.ScheduledBy;
            }
        }
    }
}