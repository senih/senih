<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" Runat="Server">
    <div style="width:300px; float:left"><asp:PlaceHolder ID="LeftArea" runat="server"></asp:PlaceHolder></div>
    <div style="width:600px; float:left">
        <asp:PlaceHolder ID="CenterArea" runat="server"></asp:PlaceHolder>
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
    </div>
    <div style="width:300px; float:left"><asp:PlaceHolder ID="RightArea" runat="server"></asp:PlaceHolder></div>
</asp:Content>

