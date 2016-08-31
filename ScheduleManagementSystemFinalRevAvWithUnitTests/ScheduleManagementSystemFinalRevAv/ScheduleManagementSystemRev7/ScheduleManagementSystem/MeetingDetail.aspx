<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeetingDetail.aspx.cs"
    Inherits="ScheduleManagementSystem.View._MeetingDetail" %>

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
           <div id="divMeetingDetails" style="margin: 10px 0 0 0; padding: 0 0 0 0">
            <table id="tblMeetingDetails" align="center">
                <tr>
                    <td>
                        <table id="Table1" align="center" runat="server">
                            <tr>
                                <td align="center">Meeting Location: </td>
                                <td align="center">Meeting Description: </td>
                                <td align="center">Meeting Date: </td>
                                <td align="center">Meeting Facilitator: </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ReadOnly="True" ID="txtMeetingLocation" runat="server"
                                        TextMode="SingleLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMeetingTitle" ReadOnly="True" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMeetingDate" runat="server" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMeetingScheduledBy" runat="server" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gvMeetingResponses" runat="server" AllowPaging="True" AllowSorting="True"
                BorderStyle="Solid" AutoGenerateColumns="False">
                <FooterStyle Font-Size="X-Small" Font-Names="Arial" Font-Bold="True" ForeColor="White" VerticalAlign="Middle"
				    BackColor="Silver"></FooterStyle>
			    <AlternatingRowStyle HorizontalAlign="Left" VerticalAlign="Middle" BackColor="Gainsboro"></AlternatingRowStyle>
			    <RowStyle VerticalAlign="Middle" BackColor="White"></RowStyle>
			    <HeaderStyle Font-Size="X-Small" Font-Names="Arial" Font-Bold="True" 
                    ForeColor="Black" VerticalAlign="Middle"
				    BackColor="White"></HeaderStyle>
			    <Columns>
			        <asp:BoundField DataField="MeetingId" ReadOnly="true" Visible="false" HeaderText="MeetingId" />
			        <asp:BoundField DataField="FKUserID" ReadOnly="true" Visible="false" HeaderText="FKUserID" />
			        <asp:BoundField DataField="UserDisplayName" ReadOnly="true" Visible="true" HeaderText="Invitee Name" />
			        <asp:BoundField DataField="InvitedOn" ReadOnly="true" Visible="true" HeaderText="Invited On" />
			        <asp:BoundField DataField="RespondedOn" ReadOnly="true" Visible="true" HeaderText="Responded On" />
			        <asp:BoundField DataField="ResponseType" ReadOnly="true" Visible="false" HeaderText="ResponseType" />
			        <asp:BoundField DataField="ResponseTypeDescription" ReadOnly="true" Visible="true" HeaderText="Response"/>
			    </Columns>
                
            </asp:GridView>
        </div>
        <asp:Button ID="btnEditMeeting" runat="server" Visible="false" 
            onclick="btnEditMeeting_Click" />
        </div>
    </form>
    </div>
</body>
</html>
