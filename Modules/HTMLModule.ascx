<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HTMLModule.ascx.cs" Inherits="Modules_HTMLModule" %>
<%@ Register Src="ModuleAdmin.ascx" TagName="ModuleAdmin" TagPrefix="uc1" %>
<%@ Register Assembly="WYSIWYGEditor" Namespace="InnovaStudio" TagPrefix="editor" %>

<uc1:ModuleAdmin ID="ModuleAdmin" OnDeleteModule="ModuleAdmin_DeleteModule" OnEdit="ModuleAdmin_Edit" runat="server" />
<asp:MultiView ID="ControlMultiView" runat="server">
    <asp:View ID="EditView" runat="server">
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="TitleTextBox" runat="server"></asp:TextBox>
                    <editor:wysiwygeditor id="TextEditor" runat="server" EditMode="XHTMLBody" ></editor:wysiwygeditor>                    
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="CancelButton" runat="server" Text="Cancel" OnClick="CancelButton_Click" />
                    <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click" />                    
                </td>
            </tr>       
        </table>
    </asp:View>
    <asp:View ID="ReadView" runat="server">
        <asp:Literal ID="TitleLiteral" runat="server"></asp:Literal><br />
        <asp:Literal ID="HtmlContent" runat="server"></asp:Literal><br />
        <asp:Literal ID="DateLiteral" runat="server"></asp:Literal><br />
    </asp:View>
</asp:MultiView>
