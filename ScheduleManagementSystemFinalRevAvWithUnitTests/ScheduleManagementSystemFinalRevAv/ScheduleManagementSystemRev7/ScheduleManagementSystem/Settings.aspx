<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="ScheduleManagementSystem.Settings" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>
<%@ Register TagPrefix="CustomControl" Namespace="ScheduleManagementSystem.Controls"
    Assembly="ScheduleManagementSystem" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DMS: stress free meeting</title>
    <link href="style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <div id="header">
        <span class="logo">DMS</span>
    </div>
    <div id="content">
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="contentHead">
            <ul id="menuList">
                <li>
                    <asp:LinkButton ID="lnkButtonMyMeetings" runat="server" OnClick="lnkButtonMyMeetings_OnClick"
                        Text="My Meetings" /></li>
                <li>
                    <asp:LinkButton ID="lnkButtonViewFacilities" runat="server" OnClick="lnkButtonViewFacilities_OnClick"
                        Text="View Facilities" /></li>
                <li>
                    <asp:LinkButton ID="lnkButtonViewMeetings" runat="server" OnClick="lnkButtonViewMeetings_OnClick"
                        Text="View Meetings" /></li>
                <li>
                    <asp:LinkButton ID="lnkButtonMySettings" runat="server" OnClick="lnkButtonMySettings_OnClick"
                        Text="My Settings" /></li>
                <li>
                    <asp:LinkButton ID="lnkButtonHelpSupport" runat="server" OnClick="lnkButtonHelpSupport_OnClick"
                        Text="Help & Support" /></li>
            </ul>
        </div>
        <div id="contentReal">
            <div>
                <asp:Label ID="lblErrorMessage" runat="server" Font-Bold="true" ForeColor="Red" />
            </div>
            <br />
            <br />
            <DayPilot:DayPilotCalendar ID="DailyCalendar" runat="server" BusinessBeginsHour="8"
                Days="7" EventClickHandling="PostBack" FreetimeClickHandling="PostBack" OnEventClick="DailyCalendar_EventClick"
                OnFreeTimeClick="DailyCalendar_FreeTimeClick" HourHeight="50" />
            <br />
            <br />
            <div>
            </div>
            <table id="tableAddEntry" runat="server" visible="false">
                <tr>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text="Description: " />
                    </td>
                    <td>
                        <asp:TextBox ID="txtBoxDescription" runat="server" />
                        <asp:RequiredFieldValidator ID="rqdTxtBoxDescription" runat="server" ControlToValidate="txtBoxDescription"
                            ErrorMessage="* Required" ForeColor="Red" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblStartTime" runat="server" Text="Entry Start Time: " />
                    </td>
                    <td>
                        <asp:Label ID="lblStartTimeData" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblEndTime" runat="server" Text="Entry End Time: " />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEndTimeHour" runat="server">
                            <asp:ListItem Text="[Select Hour]" Value="" Selected="True" />
                            <asp:ListItem Text="12" Value="12" />
                            <asp:ListItem Text="1" Value="1" />
                            <asp:ListItem Text="2" Value="2" />
                            <asp:ListItem Text="3" Value="3" />
                            <asp:ListItem Text="4" Value="4" />
                            <asp:ListItem Text="5" Value="5" />
                            <asp:ListItem Text="6" Value="6" />
                            <asp:ListItem Text="7" Value="7" />
                            <asp:ListItem Text="8" Value="8" />
                            <asp:ListItem Text="9" Value="9" />
                            <asp:ListItem Text="10" Value="10" />
                            <asp:ListItem Text="11" Value="11" />
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlEndTimeMinute" runat="server">
                            <asp:ListItem Text="00" Value="0" />
                            <asp:ListItem Text="15" Value="15" />
                            <asp:ListItem Text="30" Value="30" />
                            <asp:ListItem Text="45" Value="45" />
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlEndTimeAMPM" runat="server">
                            <asp:ListItem Text="AM" Value="AM" />
                            <asp:ListItem Text="PM" Value="PM" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnScheduleBusyTime" runat="server" Text="Save" OnClick="btnScheduleBusyTime_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <CustomControl:ModalPopupBox ID="mdlPopupResult" runat="server" Title="Details" ShowClose="true"
            Width="600px" Height="450px" BehaviorId="mpbResults" CssClass="modalpopup">
            <div class="modal">
                <table>
                    <tr>
                        <td>
                            Meeting Title:
                        </td>
                        <td>
                            <asp:TextBox ID="txtBoxMeetingTitle" runat="server" Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            From Time:
                        </td>
                        <td>
                            <asp:TextBox ID="txtBoxFromTime" runat="server" Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            To Time:
                        </td>
                        <td>
                            <asp:TextBox ID="txtBoxToTime" runat="server" Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMeetingCalledBy" runat="server" Text="Meeting Called By: " />
                        </td>
                        <td>
                            <asp:TextBox ID="txtBoxMeetingCalledBy" runat="server" Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMEetingPriority" runat="server" Text="Priority: " />
                        </td>
                        <td>
                            <asp:TextBox ID="txtBoxMeetingPriority" runat="server" Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblAgendaUrl" runat="server" Text="Agenda URL: " />
                        </td>
                        <td>
                            <asp:TextBox ID="txtBoxAgendaUrl" runat="server" Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPhoneBridge" runat="server" Text="Phone Bridge: " />
                        </td>
                        <td>
                            <asp:TextBox ID="txtBoxPhoneBridge" runat="server" Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPhoneBridgeAccessCode" runat="server" Text="Phone Bridge Access Code: " />
                        </td>
                        <td>
                            <asp:TextBox ID="txtBoxPhoneBridgeAccessCode" runat="server" Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblLocation" runat="server" Text="Location" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtBoxLocation" runat="server" Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMinutesUrl" runat="server" Text="Minutes URL: " />
                        </td>
                        <td>
                            <asp:TextBox ID="txtBoxMinutesUrl" runat="server" Enabled="false" />
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hiddenMeetingId" runat="server" />
            </div>
            <asp:Button ID="btnOk" runat="server" Text="Exit" OnClick="btnOk_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" Visible="false" />
        </CustomControl:ModalPopupBox>
        <asp:Button ID="btnPopup" runat="server" Style="display: none" />
        <Ajax:ModalPopupExtender ID="pop" runat="server" PopupControlID="mdlPopupResult"
            TargetControlID="btnPopup" BehaviorID="mpbResults" BackgroundCssClass="modalbg2" />
        </form>
    </div>
</body>
</html>
