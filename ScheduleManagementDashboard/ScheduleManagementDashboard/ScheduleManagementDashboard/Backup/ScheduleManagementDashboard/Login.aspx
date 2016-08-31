<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="ScheduleManagementDashboard.LogIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <title>DMS: stress free meeting</title>
    <LINK href="style.css" rel="stylesheet" type="text/css">
</head>
<body>
    <div id="header">  <span class="logo">DMS <span class="dash">Dashboard</span></span> </div>
    <div id="content">
        <form id="form1" runat="server">
        <div id="contentHead">
           
        </div>
        <div id="contentReal">
        
            <h3>MyDMS Dashboard</h3>
            You are not logged in yet.<br /><br />
           
            <div>
                User Name: <br /> <asp:TextBox ID="txtBoxUserName" CssClass="txtBox" runat="server" />
                <br />
                Password:  <br /> <asp:TextBox ID="txtBoxPassword" CssClass="txtBox" runat="server" TextMode="Password" />
                <br /><br />
                <asp:Button ID="btnLogIn" runat="server" CssClass="btnInput" OnClick="btnLogIn_Click" Text="Log In" />
                &nbsp;&nbsp;&nbsp;<asp:Label ID="lblErrorMessage" runat="server" BackColor="Red" />
            </div>
        </div>
        </form>
    </div>
</body>
</html>
