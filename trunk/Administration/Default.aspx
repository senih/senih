<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Administration_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" Runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            You are not authorized to view this content! Please <a href="Login.aspx">Log In</a>
        </AnonymousTemplate>
        <RoleGroups>
            <asp:RoleGroup Roles="administrators">
                <ContentTemplate>
                    Administrator panel! 
                    <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutAction="Redirect" LogoutPageUrl="~/Administration/Login.aspx" /><br />
                    <a href="Users.aspx">User Managment</a>
                    <a href="WebSite.aspx">CMS Setup</a>
                    <a href="Navigation.aspx">Navigation</a>                    
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
        <LoggedInTemplate>
            <a href="Users.aspx">Edit your account</a>
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>

