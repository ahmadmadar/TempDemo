using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using OMSTSystem.BLL;
using OMST.Data.POCOs;
using OMST.Data.Entities;
using OMST.Data.DTOs;
#endregion

namespace OMSTWebsite.Assessments
{
    public partial class PurchaseTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadTicketCounts();
            }
        }

        protected void LoadTicketCounts()
        {
            
            for (int x = 0; x < 100; x++)
            {
                InfantTickets.Items.Insert(x, x.ToString());
                ChildTickets.Items.Insert(x, x.ToString());
                TeenTickets.Items.Insert(x, x.ToString());
                AdultTickets.Items.Insert(x, x.ToString());
                SeniorTickets.Items.Insert(x, x.ToString());
            }
        }

        protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
        {
            MessageUserControl.HandleDataBoundException(e);
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
           
            ClearShowTimeTicketsPanel();
            MoviePanel.Visible = false;
            MovieList.DataSource = null;
            MovieList.DataBind();
            LocationList.SelectedIndex = -1;
        }
      
        protected void ClearShowTimeTicketsPanel()
        {
            ShowTimesTicketsPanel.Visible = false;
            InfantTickets.SelectedIndex = 0;
            ChildTickets.SelectedIndex = 0;
            TeenTickets.SelectedIndex = 0;
            AdultTickets.SelectedIndex = 0;
            SeniorTickets.SelectedIndex = 0;
            TotalPrice.Text = "0.00";
            TicketPremium.Text = "0.00";
            Buy.Enabled = false;
        }

        protected void LocationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearShowTimeTicketsPanel();
            string locationid = LocationList.SelectedValue;
            List<MovieListPOCO> movies = null;
            MessageUserControl.TryRun(() =>
            {
                ShowTimesController sysmgr = new ShowTimesController();
                movies = sysmgr.ShowTimes_MoviesByLocations(int.Parse(locationid));
                if (movies == null)
                {
                    throw new Exception("No movies schedule at this location at this date.");
                }
                else
                {
                    MovieList.DataSource = movies;
                    MovieList.DataTextField = "Title";
                    MovieList.DataValueField = "MovieID";
                    MovieList.DataBind();
                    MoviePanel.Visible = true;
                }
            });
        }

        protected void MovieList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearShowTimeTicketsPanel();
            string locationid = LocationList.SelectedValue;
            string movieid = MovieList.SelectedValue;
            List<MovieShowTimes> showtimes = null;
            MessageUserControl.TryRun(() =>
            {
                MovieController msysmger = new MovieController();
                TicketCategoryController tcsysmgr = new TicketCategoryController();
                ShowTimesController stsysmgr = new ShowTimesController();
                showtimes = stsysmgr.ShowTimes_ShowTimesByMoviesByLocations(int.Parse(locationid), 
                                                                        int.Parse(movieid));
                if (showtimes == null)
                {
                    throw new Exception("Movies schedule at this location have changed, select location again.");
                }
                else
                {
                    decimal ticketpremium = msysmger.Movies_GetTicketPrices(int.Parse(movieid));
                    TicketPremium.Text = string.Format("{0:0.00}", ticketpremium);

                    ShowTimeList.DataSource = showtimes;
                    ShowTimeList.DataTextField = "ScheduleTime";
                    ShowTimeList.DataValueField = "ShowTimeID";
                    ShowTimeList.DataBind();

                    List<TicketCategory> ticketcategories = tcsysmgr.TicketCategory_List();
                    foreach(var item in ticketcategories)
                    {
                        switch(item.Description)
                        {
                            case "Infant":
                                {
                                    InfantPrice.Text = string.Format("{0:0.00}", item.TicketPrice);
                                    break;
                                }
                            case "Child":
                                {
                                    ChildPrice.Text = string.Format("{0:0.00}", item.TicketPrice);
                                    break;
                                }
                            case "Teen":
                                {
                                    TeenPrice.Text = string.Format("{0:0.00}", item.TicketPrice);
                                    break;
                                }
                            case "Adult":
                                {
                                    AdultPrice.Text = string.Format("{0:0.00}", item.TicketPrice);
                                    break;
                                }
                            case "Senior":
                                {
                                    SeniorPrice.Text = string.Format("{0:0.00}", item.TicketPrice);
                                    break;
                                }
                            
                        }
                    }
                    TotalPrice.Text = "0.00";
                    ShowTimesTicketsPanel.Visible = true;
                }
            });
        }

        protected void ShowTimeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buy.Enabled = true;
        }

        protected void InfantTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTicketTotal();
        }

        protected void ChildTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTicketTotal();
        }

        protected void TeenTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTicketTotal();
        }

        protected void AdultTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTicketTotal();
        }

        protected void SeniorTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTicketTotal();
        }

        protected void CalculateTicketTotal()
        {
            int infant = int.Parse(InfantTickets.SelectedValue);
            int child = int.Parse(ChildTickets.SelectedValue);
            int teen = int.Parse(TeenTickets.SelectedValue);
            int adult = int.Parse(AdultTickets.SelectedValue);
            int senior = int.Parse(SeniorTickets.SelectedValue);
            decimal totalprice = (infant * decimal.Parse(InfantPrice.Text) + decimal.Parse(TicketPremium.Text)) +
                (child * decimal.Parse(ChildPrice.Text) + decimal.Parse(TicketPremium.Text)) +
                (teen * decimal.Parse(TeenPrice.Text) + decimal.Parse(TicketPremium.Text)) +
                (adult * decimal.Parse(AdultPrice.Text) + decimal.Parse(TicketPremium.Text)) +
                (senior * decimal.Parse(SeniorPrice.Text) + decimal.Parse(TicketPremium.Text));
            TotalPrice.Text = string.Format("{0:0.00}", totalprice);
        }

        protected void Buy_Click(object sender, EventArgs e)
        {
            // TODO: Enter your code here for the Buy_Click() behaviour
            //your code must 
            // a) check at least one ticket is purchased by Teen, Adult or Senior
            //       (Theatre rule: NO unattended children or infants)
            
            // b) collect the following data ShowTimeID, Premium Ticket price, and for each
            //       ticket category (the category and number of tickets) using the DTO TicketRequest
            
            // c) pass the data for processing to Tickets_BuyTickets() under control of the
            //       user control error handler.
            // d) display a success message if ticket buying was completed.

            MessageUserControl.TryRun(() =>
            {
                // Get data from the form 
                int showtimeId = int.Parse(ShowTimeList.SelectedValue);
                int premiumPrice = int.Parse(TicketPremium.Text);
                var infantChoice = int.Parse(InfantTickets.SelectedValue);
                var childChoice = int.Parse(ChildTickets.SelectedValue);
                var teenChoice = int.Parse(TeenTickets.SelectedValue);
                var adultChoice = int.Parse(AdultTickets.SelectedValue);
                var seniorChoice = int.Parse(SeniorTickets.SelectedValue);
                var price = decimal.Parse(TotalPrice.Text);
                

                if (teenChoice == 0  && adultChoice == 0 && seniorChoice == 0)
                    throw new Exception("Theatre rule: NO unattended children or infants!");



                TicketRequest data = new TicketRequest();
                data.ShowTimeID = showtimeId;
                data.PremiumPrice = price;
                List<TicketType> tickets = new List<TicketType>();
                tickets.Add(new TicketType
                {
                    CategoryDescription = "Infant",
                    Price = decimal.Parse(InfantPrice.Text),
                    Quantity = infantChoice
                });

                tickets.Add(new TicketType
                {
                CategoryDescription = "Child",
                Price = decimal.Parse(ChildPrice.Text),
                Quantity = childChoice
                });

                tickets.Add(new TicketType
                {
                    CategoryDescription = "Teen",
                    Price = decimal.Parse(TeenPrice.Text),
                    Quantity = teenChoice
                });
                tickets.Add(new TicketType
                {
                CategoryDescription = "Adult",
                Price = decimal.Parse(AdultPrice.Text),
                Quantity = adultChoice
                });
                tickets.Add(new TicketType
                {
                    CategoryDescription = "Senior",
                    Price = decimal.Parse(SeniorPrice.Text),
                    Quantity = seniorChoice
                });


            // Pass in data to the BLL for processing
             data.RequireTickets = tickets;
             new TicketsController().Tickets_BuyTickets(data);
  
            },"Ticket Purchased", "Ticket is ready for pickup by customer");

        }
    }
}