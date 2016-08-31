<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateLocation.aspx.cs" 
Inherits="ScheduleManagementDashboard.View.CreateLocation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DMS: stress free meeting</title>
    <link href="style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <div id="header">  <span class="logo">DMS <span class="dash">Dashboard</span></span> </div>
    <div id="content">
        <form id="form1" runat="server">
        <div id="contentHead">
            <ul id="menuList">
                <li><asp:LinkButton ID="lnkButtonMyDashboard" runat="server" OnClick="lnkButtonMyDashboard_OnClick" Text="My Dashboard" /></li>
            </ul>
        </div>
        <div id="contentReal">
            <div>
                <asp:Label ID="lblErrorMessage" runat="server" Font-Bold="true" ForeColor="Red" />
            </div>
            
            <div id="locationResults" >
				<table>
					<tr>
						<td>
							<strong>Location Name:</strong>
						</td>
						<td>
							<asp:TextBox ID="lblLocationName" runat="server" />
						</td>
					</tr>
					<tr>
						<td>
							<strong>Location Building:</strong>
						</td>
						<td>
							<asp:TextBox ID="lblLocationBuilding" runat="server" />
						</td>
					</tr>
					<tr>
						<td>
							<strong>Location Room:</strong>
						</td>
						<td>
							<asp:TextBox ID="lblLocationRoom" runat="server" />
						</td>
					</tr>
					<tr>
						<td>
							<strong>Location Floor:</strong>
						</td>
						<td>
							<asp:TextBox ID="lblLocationFloor" runat="server" />
						</td>
					</tr>
					<tr>
						<td>
							<strong>Location Capacity:</strong>
						</td>
						<td>
							<asp:TextBox ID="lblLocationCapacity" runat="server" />
						</td>
					</tr>
					<tr>
						<td>
							<strong>Location Options:</strong>
						</td>
						<td>
							<asp:CheckBoxList ID="chkBoxListFeatures" runat="server" Enabled="True" RepeatDirection="Vertical">
								<asp:ListItem id="listItemAVAvailable" Text="AV Available" />
								<asp:ListItem id="listItemPhoneAvailable" Text="Phone Available" />
								<asp:ListItem id="listItemVideoAvailable" Text="Video Available" />
							</asp:CheckBoxList>
						</td>
					</tr>
					<tr>
						<td>
							<asp:Button ID="lnkButtonAddLocation" runat="server" CssClass="btnInput" Text="Save Location" OnClick="lnkButtonAddLocation_Click"/>
						</td>
					</tr>
				</table>
            </div>            
        </div>
        </form>
    </div>
</body>
</html>
