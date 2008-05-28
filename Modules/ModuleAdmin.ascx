<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ModuleAdmin.ascx.cs" Inherits="Modules_ModuleAdmin" %>
<table width="100%">
    <tr>
        <td colspan="2" style="width: 234px">
            <asp:Label ID="ModuleNameLabel" runat="server"></asp:Label></td>
        <td>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="width: 234px">
            <asp:Button ID="DeleteButton" runat="server" Text="Delete Module" OnClick="DeleteButton_Click" />
            <asp:Button ID="EditButton" runat="server" Text="Edit Module" OnClick="EditButton_Click" /></td>
        <td>
            <asp:ImageButton ID="ModuleUpButton" runat="server" ImageUrl="~/Administration/Images/up_btn.gif" OnClick="ModuleUpButton_Click" /></td>
    </tr>
    <tr>
        <td colspan="2" style="width: 234px">
            Chose panel:<asp:DropDownList ID="PanelDropDownList" runat="server">
                <asp:ListItem Value="LeftArea">Left Panel</asp:ListItem>
                <asp:ListItem Value="CenterArea">Center Panel</asp:ListItem>
                <asp:ListItem Value="RightArea">Right Panel</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="PanelButton" runat="server" Text="Send" OnClick="PanelButton_Click" /></td>
        <td>
            <asp:ImageButton ID="ModuleDownButton" runat="server" ImageUrl="~/Administration/Images/down_btn.gif" OnClick="ModuleDownButton_Click" /></td>
    </tr>
</table>
<hr />
