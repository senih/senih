<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" Runat="Server">
<div class="wrapper">
<table>
<tr>
<td>
<div>
    <div class="leftsidebar">
        <asp:PlaceHolder ID="LeftArea" runat="server">
            <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
            <asp:Menu ID="Menu" runat="server" DataSourceID="SiteMapDataSource1">
            </asp:Menu>
        </asp:PlaceHolder>
    </div>
    <div class="center">
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
    <div class="rightsidebar"><asp:PlaceHolder ID="RightArea" runat="server"></asp:PlaceHolder></div>
</div>
</td>
</tr>
</table>
</div>
</asp:Content>

