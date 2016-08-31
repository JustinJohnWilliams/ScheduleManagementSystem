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
using ScheduleManagementSystem.Model;

namespace ScheduleManagementDashboard.View
{
    public partial class CreateLocation : System.Web.UI.Page, LocationController.IView
    {
        LocationController _controller;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.HasKeys())
                {
                    _controller = new LocationController(this);
                    //Get Location
                    int locId = Convert.ToInt16(Request.QueryString["LocationId"]);
                    if (locId >= 1)
                    {
                        ILocationMaster _currentLocation = _controller.GetLocationByLocationId(locId);
                        //Populate Page
                        lblLocationBuilding.Text = _currentLocation.LocationBuilding.Clone().ToString();
                        lblLocationCapacity.Text = _currentLocation.LocationCapacity.ToString();
                        lblLocationFloor.Text = _currentLocation.LocationFloor;
                        lblLocationName.Text = _currentLocation.LocationName.Clone().ToString();
                        lblLocationRoom.Text = _currentLocation.LocationRoom;

                        if (_currentLocation.IsAvAvailable) { chkBoxListFeatures.Items.FindByValue("AV Available").Selected = true; }
                        if (_currentLocation.IsPhoneAvailable) { chkBoxListFeatures.Items.FindByValue("Phone Available").Selected = true; }
                        if (_currentLocation.IsVideoConfAvailable) { chkBoxListFeatures.Items.FindByValue("Video Available").Selected = true; }
                    }
                }
                else
                {

                }
            }

        }

        protected void lnkButtonAddLocation_Click(object sender, EventArgs e)
        {
            _controller = new LocationController(this);
            LocationMaster loc = new LocationMaster();
            loc.LocationBuilding = lblLocationBuilding.Text.Trim();
            loc.LocationCapacity = Convert.ToInt16(lblLocationCapacity.Text.Trim());
            loc.LocationFloor = lblLocationFloor.Text.Trim();
            loc.LocationName = lblLocationName.Text.Trim();
            loc.LocationRoom = lblLocationRoom.Text.Trim();
            loc.IsAvAvailable = chkBoxListFeatures.Items.FindByText("AV Available").Selected;
            loc.IsPhoneAvailable = chkBoxListFeatures.Items.FindByText("Phone Available").Selected;
            loc.IsVideoConfAvailable = chkBoxListFeatures.Items.FindByText("Video Available").Selected;

            int locId = Convert.ToInt16(Request.QueryString["LocationId"]);
            if (locId >= 1)
            {
                loc.LocationId = locId;
            }
            _controller.InsertLocation(loc as ILocationMaster);

            Response.Redirect("/Default.aspx?UserId=" + Request.QueryString["UserId"]);
        }

        #region IView Members

        void LocationController.IView.NotifyError(string errorMessage)
        {
            //lbl/
        }

        #endregion

        #region Menu

        protected void lnkButtonMyDashboard_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx?UserId=" + Request.QueryString["UserId"]);
        }

        #endregion
    }
}
