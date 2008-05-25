<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" Runat="Server">
    <asp:PlaceHolder ID="LeftArea" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="CentreArea" runat="server">

    </asp:PlaceHolder>
    <asp:PlaceHolder ID="RightArea" runat="server"></asp:PlaceHolder>
            <asp:Panel ID="AddModulePanel" runat="server">
        <table>
            <tr>
                <td>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" SelectCommand="SELECT * FROM [ModuleDefinition]"></asp:SqlDataSource>
                    <asp:DropDownList ID="ModuleDropDownList" runat="server" DataSourceID="SqlDataSource1" DataTextField="ModuleDefinitionName" DataValueField="ModuleDefinitionId">
                    </asp:DropDownList>
                    <asp:Button ID="AddModuleButton" runat="server" Text="Add Module" OnClick="AddModuleButton_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

