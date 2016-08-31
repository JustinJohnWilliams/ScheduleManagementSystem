<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateMeeting.aspx.cs"
    Inherits="ScheduleManagementSystem.CreateMeeting" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DMS: stress free meeting</title>
    <LINK href="style.css" rel="stylesheet" type="text/css">
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
            </div>
            <div>
                <table>
                    <tr>
                        <td class="style2">
                            Meeting Title:
                        </td>
                        <td class="style1">
                            <asp:TextBox ID="txtBoxMeetingTitle" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Invite:
                        </td>
                        <td class="style1">
                            <asp:CheckBoxList ID="chkBoxListUsers" runat="server" RepeatColumns="3">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Importance:
                        </td>
                        <td class="style1">
                            <asp:DropDownList ID="ddlPriority" runat="server">
                                <asp:ListItem Value="0" Text="Low" />
                                <asp:ListItem Value="1" Text="Medium" />
                                <asp:ListItem Value="2" Text="High" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:CheckBox ID="chckavRequired" runat="server" Text="Projecter Required" />
                        </td>
                        <td class="style1">
                            <asp:CheckBox ID="chckphoneRequired" runat="server" Text="Phone Required" />
                        </td>
                        <td class="style3">
                            <asp:CheckBox ID="chckvideoRequired" runat="server" Text="Video Conference Required" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Meeting Window Start: 
                        </td>
                        <td class="style1">
                            <asp:TextBox ID="txtBoxStartDate" runat="server" />
                        </td>
                        <td class="style3">
                            Meeting Window End: 
                        </td>
                        <td>
                            <asp:TextBox ID="txtBoxEndDate" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Meeting Duration (minutes):
                        </td>
                        <td class="style1">
                            <asp:TextBox ID="txtBoxDuration" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Phone Bridge :
                        </td>
                        <td class="style1">
                            <asp:TextBox ID="txtBoxPhone" runat="server" />
                        </td>
                        <td class="style2">
                            Phone Access Code :
                        </td>
                        <td class="style1">
                            <asp:TextBox ID="txtBoxPhoneAccess" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Preferred Location : 
                        </td>
                        <td class="style1">
                            <asp:DropDownList ID="ddlLocations" runat="server" />
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <asp:Button ID="btnCreateMeeting" runat="server" Text="Create Meeting" 
                    onclick="btnCreateMeeting_Click" />
                <asp:Label ID="lblSuccess" runat="server" Visible="false" ForeColor="Blue" />
            </div>
        </div>
    </form>
    </div>
</body>
</html>
