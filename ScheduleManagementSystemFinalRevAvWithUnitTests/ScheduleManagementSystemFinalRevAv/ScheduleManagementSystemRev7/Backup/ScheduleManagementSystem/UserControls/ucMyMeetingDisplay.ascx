<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMyMeetingDisplay.ascx.cs"
    Inherits="ScheduleManagementSystem.UserControls.ucMyMeetingDisplay" %>
<div id="divMeetingTable" visible="false">
    <table>
        <tr>
            <td>
                <strong>Title:</strong>
            </td>
            <td>
                <asp:Label ID="lblMeetingTitle" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <strong>Scheduled By:</strong>
            </td>
            <td>
                <asp:Label ID="lblScheduledBy" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <strong>Projected Date:</strong>
            </td>
            <td>
                <asp:Label ID="lblProjectedDate" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <strong>Location:</strong>
            </td>
            <td>
                <asp:Label ID="lblMeetingLocation" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="lnkBtnViewDetails" runat="server" Text="View Meeting Details" />
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
        </tr>
        
    </table>
</div>
<div>
    <table>
        <tr>
            <td>
                <asp:Label ID="lblMeetingCount" runat="server" />
            </td>
        </tr>
    </table>
</div>
