<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs"
 Inherits="ScheduleManagementDashboard.View._Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Src="~/UserControls/ucMyMeetingDisplay.ascx" TagPrefix="UserControl" TagName="ucMyMeetingDisplay" %>
<%@ Register Src="~/UserControls/ucFacilitiesDisplay.ascx" TagPrefix="UserControl" TagName="ucFacilitiesDisplay" %>

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
                <h3><asp:Label ID="lblWelcome" runat="server" /></h3>
            </div>
            
            
            <div id="locationResults" >
				<strong><asp:Label ID="lblLocationInfo" runat="server" /></strong><br/><br/>
				<table>
					<tr>
						<td>
							<asp:ListView ID="lstVwLocation" runat="server" OnItemDataBound="lstVwLocation_ItemDataBound"
								ItemPlaceholderID="itemContainer" OnItemCommand="lstVwLocation_ItemCommand">
								<LayoutTemplate>
									<asp:PlaceHolder ID="itemContainer" runat="server" />
								</LayoutTemplate>
								<ItemTemplate>
									<asp:HiddenField ID="ucLocationId" runat="server" />
									<UserControl:ucFacilitiesDisplay ID="UCLocation" runat="server" />
								</ItemTemplate>
								
							</asp:ListView>
						</td>
					</tr>
					<tr><td></td></tr>
					<tr>
						<td align=center>
							<asp:LinkButton ID="lnkButtonAddLocation" OnClick="lnkButtonAddLocation_OnClick" CssClass="btnInput" runat="server" Text="Add New Location" Visible="true"/>
						</td>
					</tr>
				</table>
            </div>
            
            <div id="calendarSettings" style="float:left; margin:10px;">
				<strong>Calendar display Preferences</strong><br/><br/>
				
				<table>
					<tr>
						<td><strong>Hour Worday Begins (1-24)</strong></td>
						<td><asp:TextBox ID="txtBoxDayBegin" runat="server" /></td>
					</tr>
					<tr>
						<td><strong>Hour Workday Ends (1-24)</strong></td>
						<td><asp:TextBox ID="txtBoxDayEnd" runat="server" /></td>
					</tr>
					<tr>
						<td><strong>Number of Days to Display (1-*)</strong></td>
						<td><asp:TextBox ID="txtBoxDayDisplay" runat="server" /></td>
					</tr>
					<tr>
						<td><asp:LinkButton ID="lnkButtonUpdateCalendar" runat="server" OnClick="lnkButtonUpdateCalendar_Click" CssClass="btnInput" text="Save Calendar Settings"/></td>
					</tr>
				</table>
			</div>
					
            
            </div>
            
            
        </div>
        </form>
    </div>
</body>
</html>
