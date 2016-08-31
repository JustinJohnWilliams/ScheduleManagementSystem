<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMyMeetingDisplay.ascx.cs"
    Inherits="ScheduleManagementDashboard.UserControls.ucMyMeetingDisplay" %>
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
                <asp:LinkButton CssClass="btnInput" CommandName="EditMeeting" ID="btnEditMeeting" runat="server" Text="Edit Meeting" />
            </td>
            <td>
                <asp:LinkButton CssClass="btnInput" CommandName="RemoveMeeting" ID="btnRemoveMeeting" runat="server" Text="Remove Meeting" />
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
