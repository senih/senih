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
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Administration/Images/up_btn.gif" /></td>
    </tr>
    <tr>
        <td colspan="2" style="width: 234px">
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
