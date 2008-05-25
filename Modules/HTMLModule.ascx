<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HTMLModule.ascx.cs" Inherits="Modules_HTMLModule" %>
<%@ Register Assembly="WYSIWYGEditor" Namespace="InnovaStudio" TagPrefix="editor" %>

<asp:MultiView ID="ControlMultiView" runat="server">
    <asp:View ID="EditView" runat="server">
        <table>
            <tr>
                <td>                    
                    <editor:wysiwygeditor id="TextEditor" runat="server" EditMode="HTML" onSave="SaveButton_Click()"></editor:wysiwygeditor>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="CancelButton" runat="server" Text="Cancel" OnClick="CancelButton_Click" />
                    <asp:Button ID="SaveButton" runat="server" style="display:none" Text="Save" OnClick="SaveButton_Click" />                    
                </td>
            </tr>       
        </table>
    </asp:View>
    <asp:View ID="ReadView" runat="server">
        <asp:Literal ID="HtmlContent" runat="server"></asp:Literal></asp:View>
</asp:MultiView>
