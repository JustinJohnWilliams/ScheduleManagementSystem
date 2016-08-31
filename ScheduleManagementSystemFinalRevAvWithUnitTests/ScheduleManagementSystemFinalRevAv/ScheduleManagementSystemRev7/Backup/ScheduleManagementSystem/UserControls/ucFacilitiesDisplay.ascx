<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFacilitiesDisplay.ascx.cs"
    Inherits="ScheduleManagementSystem.UserControls.ucFacilitiesDisplay" %>
<table>
    <tr>
        <td>
            Location Name:
        </td>
        <td>
            <asp:Label ID="lblLocationName" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Location Building:
        </td>
        <td>
            <asp:Label ID="lblLocationBuilding" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Location Floor:
        </td>
        <td>
            <asp:Label ID="lblLocationFloor" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Location Capacity:
        </td>
        <td>
            <asp:Label ID="lblLocationCapacity" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:CheckBoxList ID="chkBoxListFeatures" runat="server" Enabled="false" RepeatDirection="Vertical">
                <asp:ListItem id="listItemAVAvailable" Text="AV Available" />
                <asp:ListItem id="listItemPhoneAvailable" Text="Phone Available" />
                <asp:ListItem id="listItemVideoAvailable" Text="Video Available" />
            </asp:CheckBoxList>
        </td>
    </tr>
</table>
