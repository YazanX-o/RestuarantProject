<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="restuarant.aspx.cs" Inherits="RestuarantProject.Account.restuarant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified" style="margin-right: 0px">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblOutput" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">Every Red star <span style="color: red">*</span> is ambortint to fill</td>
        </tr>
        <tr>
            <td style="width: 378px; height: 34px;">Restuarent Name <span style="color: red">*</span></td>
            <td style="width: 725px; height: 34px;">
                <asp:TextBox ID="TxtRestaurantName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 378px">Cell <span style="color: red">*</span></td>
            <td style="width: 725px">
                <asp:TextBox ID="txtCell" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 378px">Address <span style="color: red">*</span></td>
            <td style="width: 725px">
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 378px">City <span style="color: red">*</span></td>
            <td style="width: 725px">
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 378px">Country <span style="color: red">*</span></td>
            <td style="width: 725px">
                <asp:DropDownList ID="ddlCountry" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 378px; height: 34px;">How much did you spend per persion ?</td>
            <td style="width: 725px; height: 34px;">
                <asp:TextBox ID="txtPricePPerison" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">What&#39;s the food type that the restuarant provide <span style="color: red">*</span></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:CheckBoxList ID="cblFoodtype" runat="server">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td colspan="2">What services does provide ? <span style="color: red">*</span></td>
        </tr>
        <tr>
            <td style="width: 378px; height: 28px;">
                <asp:CheckBoxList ID="cblRestuarantServices" runat="server">
                </asp:CheckBoxList>
            </td>
            <td style="width: 725px; height: 28px;">
                <asp:CheckBoxList ID="cblFoodTime" runat="server">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <span style="color: red">*</span><asp:Repeater ID="repeaterRating" runat="server">
                <HeaderTemplate>
                    <table>
                        <th style="width:350px; background-color:lightgray; text-align:center">Restuarant Rating Criteria </th>
                        <th style="width:400px; background-color:lightgray; text-align:left"> Restuarant Rating</th>
                            </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table>
                        <td>
                            <%--<asp:Label ID="lblHotelRatingCriteriaId" runat="server" Text='<%#Eval("hotelRatingCriteriaId") %>'></asp:Label>:--%>
                            <asp:HiddenField  ID="hdnHotelRatingCriteriaId" runat="server" Value='<%#Eval("restuarantRatingCriteriaId") %>'/>
                        </td>
                        <td style="width:350px; background-color:lightgray; text-align:center">  
                          <asp:Label ID="lblHotelRatingCriteria"  runat="server" Text='<%#Eval("restuarantRatingCriteria") %>' />
                          
                        </td>
                        <td  style="width:400px; background-color:lightgray; text-align:center" >
                   <%--         <asp:RadioButtonList ID="rblRating" runat="server"></asp:RadioButtonList>--%>
                            <asp:RadioButtonList ID="rblHotelRatingCriteriaPoint" runat="server" RepeatDirection="Horizontal"
                                CellSpacing="2">
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                     </table>
                </ItemTemplate>
            </asp:Repeater>
            &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 378px">&nbsp;</td>
            <td style="width: 725px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 378px">Share more details about your experience ?</td>
            <td style="width: 725px">
                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" style="margin-right:200"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 378px">&nbsp;</td>
            <td style="width: 725px">
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                <asp:Button ID="btnShowOtherRatings" runat="server" OnClick="btnShowOtherRatings_Click" Text="Show other ratings" />
                <asp:Button ID="btnShowMyRatings" runat="server" Text="Show my ratings" />
            </td>
        </tr>
    </table>
</asp:Content>
