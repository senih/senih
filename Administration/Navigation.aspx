<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Navigation.aspx.cs" Inherits="Administration_Navigation" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" Runat="Server">
<div align="center" class="admin">
    <asp:LoginView ID="LoginView1" runat="server">
        <RoleGroups>
            <asp:RoleGroup Roles="administrators">
                <ContentTemplate>
                    <asp:Label ID="TitleLabel" runat="server" SkinID="TitleLabel" Text="Page Navigation Setup"></asp:Label>
                <div align=left>
                    <asp:TreeView ID="PagesTreeView" runat="server" AutoGenerateDataBindings="False"
                        OnSelectedNodeChanged="PagesTreeView_SelectedNodeChanged">                        
                        <DataBindings>
                            <asp:TreeNodeBinding DataMember="SiteMapNode" TextField="Title" ValueField="Url" />
                        </DataBindings>
                    </asp:TreeView>
                    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
                    <br />
                    <asp:Button ID="NewPageBtn" runat="server" Text="New Page" OnClick="NewPageBtn_Click" UseSubmitBehavior="false" /><br />
                    <br />
                    <asp:Label ID="WarningLabel" runat="server" ></asp:Label>
                    <table ID="PageDetails" runat="server" visible="false">
                        <tr>
                            <td>
                                <table >
                                    <tr>
                                        <td>
                                        </td>
                                        <td >
                                            <asp:ImageButton ID="MoveUpBtn" runat="server" ImageUrl="~/Administration/Images/up_btn.gif" OnClick="MoveUpBtn_Click" /></td>
                                        <td style="width: 35px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 14px">
                                            <asp:ImageButton ID="MoveLevelUpBtn" runat="server" ImageUrl="~/Administration/Images/left_btn.gif" OnClick="MoveLevelUpBtn_Click" /></td>
                                        <td style="height: 14px" >
                                        </td>
                                        <td style="width: 35px; height: 14px">
                                            <asp:ImageButton ID="MoveLevelDownBtn" runat="server" ImageUrl="~/Administration/Images/right_btn.gif"
                                                OnClick="MoveLevelDownBtn_Click" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td >
                                            <asp:ImageButton ID="MoveDownBtn" runat="server" ImageUrl="~/Administration/Images/down_btn.gif"
                                                OnClick="MoveDownBtn_Click" /></td>
                                        <td style="width: 35px">
                                        </td>
                                    </tr>
                                </table>
                                </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="PageTitleLabel" runat="server" Text="Page Title:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TitleTextBox" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="NavigationNameLabel" runat="server" Text="Navigation Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="NavigationTextBox" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NavigationTextBox"
                                    ErrorMessage="Required Field"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="VirtualPathLabel" runat="server" Text="Virtual Path:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="VirtualPathTextBox" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="AccessRolesLabel" runat="server" Text="Access Roles:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="AccessRolesDropDownList" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="EditRolesLabel" runat="server" Text="Edit Roles:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="EditRolesDropDownList" runat="server">
                                </asp:DropDownList></td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="VisibleLabel" runat="server" Text="Visible:"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="VisibleCheckBox" runat="server" Text="Visible" />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="UpdatePageBtn" runat="server" Text="Update Page" OnClick="UpdatePageBtn_Click" />
                            </td>
                            <td>                                
                    <asp:Button ID="DeletePageBtn" runat="server" OnClick="DeletePageBtn_Click" Text="Delete Page" /></td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
        <AnonymousTemplate>
            <asp:Label ID="Label1" runat="server" Text="Unauthorized!"></asp:Label>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <asp:Label ID="Label2" runat="server" Text="You must be admin to see this page!"></asp:Label>
        </LoggedInTemplate>
    </asp:LoginView>
</div>
</asp:Content>

