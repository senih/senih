<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" Runat="Server">
    <asp:ChangePassword ID="ChangePassword1" runat="server" ContinueDestinationPageUrl="~/Administration/LoginPage.aspx">
        <MailDefinition From="vladimir.senih@gmail.com" Subject="Success!">
        </MailDefinition>
    </asp:ChangePassword>
</asp:Content>

