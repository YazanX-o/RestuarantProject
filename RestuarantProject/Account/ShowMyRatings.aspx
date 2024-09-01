<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowMyRatings.aspx.cs" Inherits="RestuarantProject.Account.ShowMyRatings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <table class="nav-justified">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblOutput" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvShowAllRatings" runat="server" OnSelectedIndexChanged="gvShowAllRatings_SelectedIndexChanged">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td>
                <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
                <asp:Button ID="btndelete" runat="server" Text="Delete" />
            </td>
        </tr>
    </table>
</asp:Content>
