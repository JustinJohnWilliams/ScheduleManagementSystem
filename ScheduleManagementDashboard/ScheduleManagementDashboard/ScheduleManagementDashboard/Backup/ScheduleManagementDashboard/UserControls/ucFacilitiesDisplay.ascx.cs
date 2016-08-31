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

namespace ScheduleManagementDashboard.UserControls
{
    public partial class ucFacilitiesDisplay : UserControl
    {
        public void Initialize(ILocationMaster location)
        {
            if (location != null)
            {
            /*    lblLocationBuilding.Text = location.LocationBuilding.Trim();
                lblLocationCapacity.Text = location.LocationCapacity.ToString().Trim();
                lblLocationFloor.Text = location.LocationFloor.Trim(); */
                lblLocationName.Text = location.LocationName.Trim();

                /*listItemAVAvailable.Selected = location.IsAvAvailable;
                listItemPhoneAvailable.Selected = location.IsPhoneAvailable;
                listItemVideoAvailable.Selected = location.IsVideoConfAvailable;*/
            }
        }
    }
}