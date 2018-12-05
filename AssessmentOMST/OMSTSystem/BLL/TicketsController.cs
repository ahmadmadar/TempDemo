using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using OMSTSystem.DAL;
using OMST.Data.Entities;
using OMST.Data.DTOs;
using System.ComponentModel;
#endregion

namespace OMSTSystem.BLL
{
    [DataObject]
    public class TicketsController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<Ticket> Tickets_NewlyAddedTickets()
        {
            using (var context = new OMSTContext())
            {
                return context.Tickets
                    .Where(x => x.TicketID > (context.Tickets.Max(y => y.TicketID) - 25))
                    .Select(x => x)
                    .OrderByDescending(x => x.TicketID)
                    .ToList();
            }
        }

        public void Tickets_BuyTickets(TicketRequest request)
        {
            // TODO: Place your code here for processing the TicketRequest transaction
            //this method will do the following
            //  a) validate there is sufficient seats left for the show
            //  b) create a record for each requested ticket
            //  c) this must be done as a transaction

            if (request == null)
                throw new ArgumentNullException("Purchase details are missing");

            using (var context = new OMSTContext())
            {
                var show = context.ShowTimes.Find(request.ShowTimeID);
                if (show == null)
                    throw new ArgumentException("The supplied showtime does not exist");
                var totalSeats = show.Theatre.SeatingSize;
                var soldSeats = show.Tickets.Count();
                var availableSeats = totalSeats - soldSeats;
                var requestedSeats = request.RequireTickets.Sum(x => x.Quantity);
                if (requestedSeats > availableSeats)
                    throw new Exception("Insuffiecint number of seats available");

                foreach(var item in request.RequireTickets)
                {
                    for(int count = 1; count <= item.Quantity; count++)
                    {
                        decimal price = 0, premiumPrice = 0;
                        if (request.PremiumPrice > 0)
                            premiumPrice = request.PremiumPrice + item.Price;
                        else
                            price = item.Price;
                        var ticket = new Ticket
                        {
                            ShowTimeID = request.ShowTimeID,
                            TicketCategoryID = context.TicketCategories.Single(x => x.Description == item.CategoryDescription).TicketCategoryID,

                        };
                        context.Tickets.Add(ticket);
                    }
                }

                // Single transaction
                context.SaveChanges();
            }
           
        }
    }
}
