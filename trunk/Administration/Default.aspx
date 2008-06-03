<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Administration_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" Runat="Server">
<div align="center" class="admin">
    <asp:LoginView ID="LoginView1" runat="server">
        <RoleGroups>
            <asp:RoleGroup Roles="administrators">
                <ContentTemplate>
                    <asp:Label ID="TitleLabe" SkinID="TitleLabel" runat="server" Text="Administrator panel"></asp:Label><br /><br />
                    <div>
                        <a href="Users.aspx">User Managment</a>
                        <a href="WebSite.aspx">CMS Setup</a>
                        <a href="Navigation.aspx">Navigation</a>
                    </div>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
</div>
</asp:Content>

