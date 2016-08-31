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
using ScheduleManagementSystem.UserControls;
using System.Collections.Generic;

namespace ScheduleManagementSystem
{
    public partial class Facilities : System.Web.UI.Page, LocationController.IView
    {
        private LocationController _controller;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.HasKeys())
            {
                _controller = new LocationController(this);
                List<ILocationMaster> locations = _controller.GetAllLocations();
                lstVwLocation.DataSource = locations;
                lstVwLocation.DataBind();
            }
            else
            {
                Response.Redirect("/LogIn.aspx");
            }
            
        }

        protected void lstVwLocation_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ILocationMaster currentLocation = ((ListViewDataItem)e.Item).DataItem as ILocationMaster;
                ucFacilitiesDisplay currentLocationDisplay = e.Item.FindControl("UCLocation") as ucFacilitiesDisplay;
                currentLocationDisplay.Initialize(currentLocation);
            }
        }

        protected void lnkButtonMyMeetings_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx?UserId=" + Request.QueryString["UserId"].ToString());
        }

        protected void lnkButtonViewFacilities_OnClick(object sender, EventArgs e)
        {
            // do nothing.
        }

        protected void lnkButtonViewMeetings_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/Meetings.aspx?UserId=" + Request.QueryString["UserId"].ToString());
        }

        protected void lnkButtonMySettings_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/Settings.aspx?UserId=" + Request.QueryString["UserId"].ToString());
        }

        protected void lnkButtonHelpSupport_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/HelpAndSupport.aspx?UserId=" + Request.QueryString["UserId"].ToString());
        }

        #region IView Members

        void LocationController.IView.NotifyError(string errorMessage)
        {
            lblErrorMessage.Text = errorMessage;
        }

        #endregion
    }
}
