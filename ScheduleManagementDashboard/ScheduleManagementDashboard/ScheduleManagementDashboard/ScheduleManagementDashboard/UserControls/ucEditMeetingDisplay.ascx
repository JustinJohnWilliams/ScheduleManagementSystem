<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucEditMeetingDisplay.ascx.cs" 
    Inherits="ScheduleManagementDashboard.UserControls.ucEditMeetingDisplay" %>

<div id="divMeetingTable" visible="false">
    <table width="100%">
        <tr>
            <td>
                Title: 
            </td>
            <td>
                <asp:Label ID="lblMeetingTitle" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Scheduled By:
            </td>
            <td>
                <asp:Label ID="lblScheduledBy" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Preferred Location:
            </td>
            <td>
                <asp:Label ID="lblPreferredLocation" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Actual Location:
            </td>
            <td>
                <asp:Label ID="lblActualLocation" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Meeting Start Time:
            </td>
            <td>
                <asp:Label ID="lblStartTime" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Meeting End Time:
            </td>
            <td>
                <asp:Label ID="lblEndTime" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Meeting Priority:
            </td>
            <td>
                <asp:Label ID="lblPriority" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Minutes URL:
            </td>
            <td>
                <asp:Label ID="lblMinutesUrl" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Agenda URL:
            </td>
            <td>
                <asp:Label ID="lblAgendaUrl" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Phone Bridge:
            </td>
            <td>
                <asp:Label ID="lblPhoneBridge" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Bridge Access Code:
            </td>
            <td>
                <asp:Label ID="lblAccessCode" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBoxList ID="chkBoxListFeatures" runat="server" Enabled="false" RepeatDirection="Vertical">
                    <asp:ListItem id="listItemAVRequired" Text="AV Required" />
                    <asp:ListItem id="listItemPhoneRequired" Text="Phone Required" />
                    <asp:ListItem id="listItemVideoRequired" Text="Video Required" />
                </asp:CheckBoxList>
            </td>
        </tr>
    </table>
</div>
