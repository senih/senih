<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" Runat="Server">
<div align="center" class="admin">
    <asp:PasswordRecovery ID="PasswordRecovery" runat="server">
        <MailDefinition From="vladimir.senih@gmail.com" Subject="Success!!!">
        </MailDefinition>
    </asp:PasswordRecovery>
</div>
</asp:Content>

