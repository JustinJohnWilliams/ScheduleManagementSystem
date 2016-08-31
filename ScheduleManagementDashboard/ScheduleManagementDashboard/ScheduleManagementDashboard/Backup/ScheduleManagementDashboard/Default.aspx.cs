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
using ScheduleManagementSystem.Model;
using ScheduleManagementSystem.Contract.Model;
using ScheduleManagementDashboard.UserControls;
using System.Collections.Generic;

namespace ScheduleManagementDashboard.View
{
    public partial class _Default : System.Web.UI.Page, LocationController.IView, SettingsController.IView
    {
        private LocationController _lController;
        private SettingsController _sController;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _lController = new LocationController(this);
                _sController = new SettingsController(this);

                if (Request.QueryString.HasKeys())
                {
                    lblWelcome.Text = "Welcome Admin.";

                    _lController.GetAllLocations();
                    lnkButtonAddLocation.Visible = true;
                    List<ILocationMaster> locations = _lController.GetAllLocations();
                    if (locations.Count > 0)
                    {
                        lblLocationInfo.Text = "There are currently " + locations.Count.ToString() + " locations available.";
                        lstVwLocation.DataSource = locations;
                        lstVwLocation.DataBind();
                    }

                }
                else
                {
                    Response.Redirect("/LogIn.aspx");
                }
            }
        }


        protected void lstVwLocation_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ILocationMaster currentLocation = ((ListViewDataItem)e.Item).DataItem as ILocationMaster;
                ucFacilitiesDisplay currentLocationDisplay = e.Item.FindControl("UCLocation") as ucFacilitiesDisplay;
                (e.Item.FindControl("ucLocationId") as HiddenField).Value = currentLocation.LocationId.ToString();
                currentLocationDisplay.Initialize(currentLocation);
            }
        }

        protected void lstVwLocation_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            _lController = new LocationController(this);
            int locationId = Convert.ToInt16((e.Item.FindControl("ucLocationId") as HiddenField).Value);
            if (String.Equals(e.CommandName, "RemoveLocation"))
            {
                _lController.RemoveLocation(locationId);
                Response.Redirect("/Default.aspx?UserId=" + Request.QueryString["UserId"]);
            }
            else if (String.Equals(e.CommandName, "EditLocation"))
            {
                Response.Redirect("/CreateLocation.aspx?UserId=" + Request.QueryString["UserId"] + "&LocationId=" + locationId);
            }
        }

        protected void lnkButtonAddLocation_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/CreateLocation.aspx?UserId=" + Request.QueryString["UserId"]);
        }

        protected void lnkButtonUpdateCalendar_Click(object sender, EventArgs e)
        {
            _sController = new SettingsController(this);

            int dayEnd = Convert.ToInt16(txtBoxDayEnd.Text);
            int dayBegin = Convert.ToInt16(txtBoxDayBegin.Text);
            int numDays = Convert.ToInt16(txtBoxDayDisplay.Text);
            String errorMessage = "";
            if ((dayEnd < 1) || (dayEnd > 24))
            {
                errorMessage += "Day End Hour must be between 1 and 24. <br/>";
            }

            if ((dayBegin < 1) || (dayBegin > 24))
            {
                errorMessage += "Day Begin Hours must be between 1 and 24.<br/>";
            }

            if (numDays < 1)
            {
                errorMessage += "Number of Days to display must be greater than 1.<br/>";
            }

            if (errorMessage.Length > 0)
            {
                lblErrorMessage.Text = errorMessage;
            }
            else
            {
                _sController.SetCustomSettings(dayBegin, dayEnd, numDays);
            }
        }

        #region IView Members


        void LocationController.IView.NotifyError(string errorMessage)
        {
            lblErrorMessage.Text = errorMessage;
        }

        #endregion

        #region Menu

        protected void lnkButtonMyDashboard_OnClick(object sender, EventArgs e)
        {
            // Response.Redirect("/Default.aspx?UserId=" + _currentUser.UserId);
        }

        #endregion

        #region IView Members

        void SettingsController.IView.NotifyError(string errorMessage)
        {
            lblErrorMessage.Text = errorMessage;
        }

        #endregion
    }


}
