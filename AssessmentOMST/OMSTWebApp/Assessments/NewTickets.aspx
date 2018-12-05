<%@ Page Title="New Tickets" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewTickets.aspx.cs" Inherits="OMSTWebApp.Assessments.NewTickets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Tickets Add during Assessment</h1>
    <h3>These are tickets added by running your code.</h3>
    <asp:ListView ID="NewTicketList" runat="server" DataSourceID="NewTicketListODS">
        <AlternatingItemTemplate>
            <tr style="background-color: #FFF8DC;">
                <td>
                    <asp:Label Text='<%# Eval("TicketID") %>' runat="server" ID="TicketIDLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("ShowTimeID") %>' runat="server" ID="ShowTimeIDLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("TicketCategoryID") %>' runat="server" ID="TicketCategoryIDLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("TicketPrice") %>' runat="server" ID="TicketPriceLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("TicketPremium") %>' runat="server" ID="TicketPremiumLabel" /></td>
               
            </tr>
        </AlternatingItemTemplate>
      
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                <tr>
                    <td>No data was returned. No new tickets have been added by your assessment.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
      
        <ItemTemplate>
            <tr style="background-color: #DCDCDC; color: #000000;">
                <td>
                    <asp:Label Text='<%# Eval("TicketID") %>' runat="server" ID="TicketIDLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("ShowTimeID") %>' runat="server" ID="ShowTimeIDLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("TicketCategoryID") %>' runat="server" ID="TicketCategoryIDLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("TicketPrice") %>' runat="server" ID="TicketPriceLabel" /></td>
                <td>
                    <asp:Label Text='<%# Eval("TicketPremium") %>' runat="server" ID="TicketPremiumLabel" /></td>
              
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table runat="server" id="itemPlaceholderContainer" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                            <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                <th runat="server">TicketID</th>
                                <th runat="server">ShowTimeID</th>
                                <th runat="server">TicketCategoryID</th>
                                <th runat="server">TicketPrice</th>
                                <th runat="server">TicketPremium</th>
                            </tr>
                            <tr runat="server" id="itemPlaceholder"></tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                        <asp:DataPager runat="server" ID="DataPager1">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True"></asp:NextPreviousPagerField>
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
       
    </asp:ListView>
    <asp:ObjectDataSource ID="NewTicketListODS" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Tickets_NewlyAddedTickets" 
        TypeName="OMSTSystem.BLL.TicketsController">
    </asp:ObjectDataSource>
</asp:Content>
