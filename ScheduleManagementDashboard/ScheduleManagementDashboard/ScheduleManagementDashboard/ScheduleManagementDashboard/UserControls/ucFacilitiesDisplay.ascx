<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFacilitiesDisplay.ascx.cs"
    Inherits="ScheduleManagementDashboard.UserControls.ucFacilitiesDisplay" %>
<table>
    <tr>
        <td>
            <strong>Location Name:</strong>
        </td>
        <td>
            <asp:Label ID="lblLocationName" runat="server" />
        </td>
    </tr>
    <!--<tr>
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
    </tr> -->
    <tr>
		<td>
			<asp:LinkButton Id="lnkButtonEditLocation" CommandName="EditLocation" CssClass="btnInput" runat="server" Text="Edit Location" />
		</td>
		<td>
			<asp:LinkButton ID="lnkButtonRemoveLocation" CommandName="RemoveLocation" CssClass="btnInput" runat="server" Text="Remove Location" />
		</td>
	</tr>
</table>
