using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using OMST.Data.POCOs;
#endregion

namespace OMST.Data.DTOs
{
    public class TicketRequest
    {
        public int ShowTimeID { get; set; }
        public decimal PremiumPrice { get; set; }
        public List<TicketType> RequireTickets { get; set; }
    }
}
