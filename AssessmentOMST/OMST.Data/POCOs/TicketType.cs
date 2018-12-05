using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMST.Data.POCOs
{
    public class TicketType
    {
        public string CategoryDescription { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public TicketType()
        {

        }
        public TicketType(string description, int qty, decimal price)
        {
            CategoryDescription = description;
            Quantity = qty;
            Price = price;
        }
    }
}
