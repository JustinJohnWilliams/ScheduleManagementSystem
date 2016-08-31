<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ScheduleManagementSystem.View._Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<%@ Register Src="~/UserControls/ucMyMeetingDisplay.ascx" TagPrefix="UserControl" TagName="ucMyMeetingDisplay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DMS: stress free meeting</title>
    <link href="style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <div id="header">  <span class="logo">DMS</span> </div>
    <div id="content">
        <form id="form1" runat="server">
        <div id="contentHead">
            <ul id="menuList">
                <li><asp:LinkButton ID="lnkButtonMyMeetings" runat="server" OnClick="lnkButtonMyMeetings_OnClick" Text="My Meetings" /></li>
                <li><asp:LinkButton ID="lnkButtonViewFacilities" runat="server" OnClick="lnkButtonViewFacilities_OnClick" Text="View Facilities" /></li>
                <li><asp:LinkButton ID="lnkButtonViewMeetings" runat="server" OnClick="lnkButtonViewMeetings_OnClick" Text="View Meetings" /></li>
                <li><asp:LinkButton ID="lnkButtonMySettings" runat="server" OnClick="lnkButtonMySettings_OnClick" Text="My Settings" /></li>
                <li><asp:LinkButton ID="lnkButtonHelpSupport" runat="server" OnClick="lnkButtonHelpSupport_OnClick" Text="Help & Support" /></li>
            </ul>
        </div>
        <div id="contentReal">
            <div>
                <asp:Label ID="lblErrorMessage" runat="server" Font-Bold="true" ForeColor="Red" />
                <h3><asp:Label ID="lblWelcome" runat="server" /></h3>
            </div>
            
            <div id="meetingResults" style="margin: 10px 0 0 0; padding: 0 0 0 0">
                <asp:ListView ID="lstVwMeeting" runat="server" OnItemCommand="lstVwMeeting_ItemCommand"
                    OnItemDataBound="lstVwMeeting_ItemDataBound" ItemPlaceholderID="itemContainer">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="itemContainer" runat="server" />
                    </LayoutTemplate>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnFieldMeetingId" runat="server" />
                        <asp:HiddenField ID="hdnFieldMeetingCalledBy" runat="server" />
                        <UserControl:ucMyMeetingDisplay ID="UCMeeting" runat="server" />
                    </ItemTemplate>            
                </asp:ListView>
            </div>
            <asp:Label ID="lblMeetingCount" runat="server" />
            
        </div>
        </form>
    </div>
</body>
</html>
