<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ModuleAdmin.ascx.cs" Inherits="Modules_ModuleAdmin" %>
<table >
    <tr>
        <td colspan="2">
            <asp:Label ID="ModuleNameLabel" runat="server"></asp:Label></td>
        <td>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="Button2" runat="server" Text="Delete Module" />
            <asp:Button ID="Button1" runat="server" Text="Edit Module" /></td>
        <td>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Administration/Images/up_btn.gif" /></td>
    </tr>
    <tr>
        <td colspan="2">
            Chose panel:<asp:DropDownList ID="PanelDropDownList" runat="server">
                <asp:ListItem Value="Left">Left Panel</asp:ListItem>
                <asp:ListItem Value="Center">Center Panel</asp:ListItem>
                <asp:ListItem Value="Right">Right Panel</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="PanelButton" runat="server" Text="Send" /></td>
        <td>
            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Administration/Images/down_btn.gif" /></td>
    </tr>
</table>
