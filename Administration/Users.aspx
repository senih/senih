<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Administration_Users" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" Runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
        <RoleGroups>
            <asp:RoleGroup Roles="administrators">
                <ContentTemplate>
                    <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutAction="Redirect" LogoutPageUrl="~/Administration/Login.aspx" />
                    <br />
                    <asp:GridView ID="UsersGridView" runat="server" AutoGenerateColumns="false" AllowSorting="true" AllowPaging="true" DataKeyNames="UserName" OnSelectedIndexChanged="UsersGridView_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="UserName" HeaderText="User Name" />
                            <asp:BoundField DataField="Email" HeaderText="E-mail" />
                            <asp:CheckBoxField DataField="IsApproved" HeaderText="Approved" />
                            <asp:CheckBoxField DataField="IsLockedOut" HeaderText="Locked" />
                            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView><br />
                    <table ID="UserManage" runat="server" visible="false">
                        <tr>
                            <td>
                                User name:</td>
                            <td >
                                <asp:Label ID="UserNameLabel" runat="server"></asp:Label></td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                E-mail:</td>
                            <td >
                                <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="EmailTextBox"
                                    Display="Dynamic" ErrorMessage="Required Field!">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter valid email address" ControlToValidate="EmailTextBox" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Approved user:</td>
                            <td  >
                                <asp:CheckBox ID="ApprovedCheckBox" runat="server" /></td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Role:</td>
                            <td  >
                                <asp:DropDownList ID="RolesDropDown" runat="server">
                                </asp:DropDownList></td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="DeleteButton" runat="server" OnClick="DeleteButton_Click" Text="Delete user" /></td>
                            <td >
                                <asp:Button ID="UpdateButton" runat="server" Text="Update user" OnClick="UpdateButton_Click" /></td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
        <AnonymousTemplate>
            Unauthorized!
        </AnonymousTemplate>
        <LoggedInTemplate>
            <asp:LoginStatus ID="LoginStatus2" runat="server" LogoutAction="Redirect" LogoutPageUrl="~/Default.aspx" />
            <br />
                    <table id="UserTable" runat="server">
                        <tr>
                            <td >User Name:
                            </td>
                            <td  >
                                &nbsp;<asp:Label ID="UserLabel" runat="server"></asp:Label></td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td >E-mail:
                            </td>
                            <td >
                                <asp:TextBox ID="UserEmailTextBox" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserEmailTextBox"
                                    Display="Dynamic" ErrorMessage="Required Field"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                        ID="RegularExpressionValidator1" runat="server" ControlToValidate="UserEmailTextBox"
                                        Display="Dynamic" ErrorMessage="Enter valid mail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                        </tr>
                        <tr>
                            <td>
                                Old password:</td>
                            <td>
                                <asp:TextBox ID="OldPasswordTextBox" runat="server"></asp:TextBox></td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td >Password:
                            </td>
                            <td style="width: 158px" >
                                <asp:TextBox ID="UserPasswordTextBox" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="MinPasswordLengthLabel" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td >
                                Confirm password:</td>
                            <td >
                                <asp:TextBox ID="ConfirmPasswordTextBox" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ControlToCompare="UserPasswordTextBox" ControlToValidate="ConfirmPasswordTextBox">Password filds must match</asp:CompareValidator></td>
                        </tr>
                        <tr>
                            <td >
                                </td>
                            <td >
                                <asp:Button ID="UpdateUserButton" runat="server" Text="Update account" OnClick="UpdateUserButton_Click" /></td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                            </td>
                        </tr>
                    </table>
            <asp:Label ID="UserStatusLabel" runat="server"></asp:Label>
        </LoggedInTemplate>
     </asp:LoginView>
</asp:Content>

