<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" Runat="Server">
    <asp:Login ID="Login1" runat="server" CreateUserText="Register" CreateUserUrl="~/Administration/Registration.aspx" DestinationPageUrl="~/Administration/Default.aspx" PasswordRecoveryText="Forgot your password?" PasswordRecoveryUrl="~/ForgotPassword.aspx">
    </asp:Login>
</asp:Content>

