<%@ Page Title="Ticket Sales - OMST" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseTickets.aspx.cs" Inherits="OMSTWebsite.Assessments.PurchaseTickets" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="row" style="background-color:gold">
        <h1>OMST Ticket Sales</h1>
    </div>
    <div class="row">
        <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
    </div>
    <div class="row">
        <blockquote class="alert alert-info">
            <ol>
                <li>Select Location (shows Movies)</li>
                <li>Select Movie (shows Show times and ticket selection)</li>
                <li>Select Show time and enter number of tickets for each category)</li>
                <li>Press Buy to purchase tickets</li>
            </ol>
        </blockquote>
    </div>
    <div class="row">
        <div class="col-md-offset-5 col-md-2">
            <asp:Button ID="Clear" runat="server" Text="Clear"
                class="btn btn-primary" Width="200px" OnClick="Clear_Click" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-offset-2 col-md-2">
            <asp:Panel ID="LocationPanel" runat="server">
                <h4>Locations</h4>
                <asp:RadioButtonList ID="LocationList" runat="server" 
                    DataSourceID="LocationListODS" 
                    DataTextField="Description" 
                    DataValueField="LocationID" 
                     AutoPostBack="true" OnSelectedIndexChanged="LocationList_SelectedIndexChanged">
                </asp:RadioButtonList>
                <asp:ObjectDataSource ID="LocationListODS" runat="server" 
                    OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="Locations_List" 
                    TypeName="OMSTSystem.BLL.LocationController"
                     OnSelected="CheckForException">
                </asp:ObjectDataSource>
            </asp:Panel>
        </div>
         <div class="col-md-2">
            <asp:Panel ID="MoviePanel" runat="server" Visible="false">
                <h4>Movies</h4>
                <asp:RadioButtonList ID="MovieList" runat="server" OnSelectedIndexChanged="MovieList_SelectedIndexChanged" 
                   AutoPostBack="true" >
                </asp:RadioButtonList>
            </asp:Panel>
        </div>
         <div class="col-md-4">
            <asp:Panel ID="ShowTimesTicketsPanel" runat="server" Visible="false">
                <table>
                    <tr>
                        <td>
                            <h4>ShowTimes&nbsp;&nbsp;</h4>
                        </td>
                         <td>
                            <h4>Tickets</h4>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                             <asp:RadioButtonList ID="ShowTimeList" runat="server" AutoPostBack="true" 
                                 OnSelectedIndexChanged="ShowTimeList_SelectedIndexChanged">
                             </asp:RadioButtonList>
                        </td>
                         <td>
                             <asp:Label ID="Infant" runat="server" Text="Infant:" Width="100px"></asp:Label>&nbsp;&nbsp;
                             <asp:DropDownList ID="InfantTickets" runat="server" AutoPostBack="true"
                                 OnSelectedIndexChanged="InfantTickets_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;
                             <asp:Label ID="InfantPrice" runat="server" ></asp:Label><br />
                             <asp:Label ID="Child" runat="server" Text="Child:" Width="100px"></asp:Label>&nbsp;&nbsp;
                             <asp:DropDownList ID="ChildTickets" runat="server" AutoPostBack="true"
                                 OnSelectedIndexChanged="ChildTickets_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;
                             <asp:Label ID="ChildPrice" runat="server" ></asp:Label><br />
                             <asp:Label ID="Teen" runat="server" Text="Teen:" Width="100px"></asp:Label>&nbsp;&nbsp;
                             <asp:DropDownList ID="TeenTickets" runat="server" AutoPostBack="true"
                                 OnSelectedIndexChanged="TeenTickets_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;
                             <asp:Label ID="TeenPrice" runat="server" ></asp:Label><br />
                             <asp:Label ID="Adult" runat="server" Text="Adult:" Width="100px"></asp:Label>&nbsp;&nbsp;
                             <asp:DropDownList ID="AdultTickets" runat="server" AutoPostBack="true"
                                 OnSelectedIndexChanged="AdultTickets_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;
                             <asp:Label ID="AdultPrice" runat="server" ></asp:Label><br />
                             <asp:Label ID="Senior" runat="server" Text="Senior:" Width="100px"></asp:Label>&nbsp;&nbsp;
                             <asp:DropDownList ID="SeniorTickets" runat="server" AutoPostBack="true"
                                 OnSelectedIndexChanged="SeniorTickets_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;
                             <asp:Label ID="SeniorPrice" runat="server" ></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            
                        </td>
                         <td>
                             <asp:Label ID="Label1" runat="server" Text="Premium:"></asp:Label>&nbsp;&nbsp;
                             <asp:Label ID="TicketPremium" runat="server" ></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            
                        </td>
                         <td>
                             <asp:Label ID="Total" runat="server" Text="Total:"></asp:Label>&nbsp;&nbsp;
                             <asp:Label ID="TotalPrice" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            
                        </td>
                         <td>
                             <asp:Button ID="Buy" runat="server" Text="Buy" class="btn"  Enabled="false" OnClick="Buy_Click"/>
                        </td>
                    </tr>
                </table>
               
                <br />
                
            </asp:Panel>
        </div>
    </div>
</asp:Content>
