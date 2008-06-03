<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WebSite.aspx.cs" Inherits="Administration_WebSite" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" Runat="Server">
<div align="center" class="admin">
    <asp:LoginView ID="LoginView1" runat="server">
        <RoleGroups>
            <asp:RoleGroup Roles="administrators">
                <ContentTemplate>
                    <asp:Label ID="TitleLabel" SkinID="TitleLabel" runat="server" Text="Content Managment System Setup"></asp:Label><br /><br /><br />
                    <table>
                        <tr>
                            <td >
                                <asp:Label ID="lblWebSiteTitle" runat="server" Text="Title"></asp:Label></td>
                            <td >
                                <asp:TextBox ID="WebSiteTitleTextBox" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label ID="lblLanguage" runat="server" Text="Language"></asp:Label></td>
                            <td >
                                <asp:DropDownList ID="LanguageDropDownList" runat="server">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label ID="lblSenderMail" runat="server" Text="Mail Sender Address"></asp:Label></td>
                            <td >
                                <asp:TextBox ID="MailSenderAddressTextBox" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label ID="lblSmtpServer" runat="server" Text="SMTP Server"></asp:Label></td>
                            <td >
                                <asp:TextBox ID="SmtpServerTextBox" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label ID="lblSmtpUser" runat="server" Text="SMTP User"></asp:Label></td>
                            <td >
                                <asp:TextBox ID="SmtpUserTextBox" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label ID="lblSmtpPassword" runat="server" Text="SMTP Password"></asp:Label></td>
                            <td >
                                <asp:TextBox ID="SmtpPasswordTextBox" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="height: 40px" >
                                <asp:Label ID="lblSmtpDomain" runat="server" Text="SMTP Domain"></asp:Label></td>
                            <td style="height: 40px" >
                                <asp:TextBox ID="SmtpDomainTextBox" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label ID="lblFooter" runat="server" Text="Footer"></asp:Label></td>
                            <td >
                                <asp:TextBox ID="FooterTextBox" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label ID="lblDescription" runat="server" Text="Website Description"></asp:Label></td>
                            <td >
                                <asp:TextBox ID="DescriptionTextBox" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label ID="lblKeywords" runat="server" Text="Website Keywords"></asp:Label></td>
                            <td >
                                <asp:TextBox ID="KeywordsTextBox" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label ID="lblTheme" runat="server" Text="Theme"></asp:Label>
                            </td>
                            <td >
                                <asp:DropDownList ID="ThemeDropDownList" runat="server">
                                    <asp:ListItem Value="Default" Text="Default Theme">
                                    </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td >
                            </td>
                            <td >
                                <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click" /></td>
                        </tr>
                        <tr>
                            <td >
                            </td>
                            <td >
                                <asp:Button ID="ResetButton" runat="server" Text="RESET Website" OnClick="ResetButton_Click" /></td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
        <LoggedInTemplate>
            <asp:Label ID="Label1" runat="server" Text="You must be admin to see this page!"></asp:Label>
        </LoggedInTemplate>
        <AnonymousTemplate>
            <asp:Label ID="Label2" runat="server" Text="Unauthorized!"></asp:Label>
        </AnonymousTemplate>
    </asp:LoginView>
</div>
</asp:Content>

