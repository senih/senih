<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sections.aspx.cs" Inherits="Administration_Sections" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" Runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
        <LoggedInTemplate>
            You must be admin!
        </LoggedInTemplate>
        <AnonymousTemplate>
            Unauthorized !!!
        </AnonymousTemplate>
        <RoleGroups>
            <asp:RoleGroup Roles="administrators">
                <ContentTemplate>
                    &nbsp;<br />
                    <table>
                        <tr>
                            <td colspan="2">
                                New Module Type Definition</td>
                        </tr>
                        <tr>
                            <td align="right">
                                Name:</td>
                            <td>
                                <asp:TextBox ID="ModuleNameTextBox" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right">
                                Module File:
                            </td>
                            <td>
                                <asp:TextBox ID="FileNameTextBox" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right">
                                Visible:</td>
                            <td>
                                <asp:CheckBox ID="VisibleCheckBox" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                </td>
                            <td align="right">
                                <asp:Button ID="AddNewModuleTypeButton" runat="server" Text="Add New Module" OnClick="AddNewModuleTypeButton_Click" /></td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
</asp:Content>

