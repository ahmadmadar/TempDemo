using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using OMSTSystem.DAL;
using OMST.Data.Entities;
using System.ComponentModel;
using OMST.Data.POCOs;
#endregion

namespace OMSTSystem.BLL
{
    public class MovieController
    {
        public decimal Movies_GetTicketPrices(int movieid)
        {
            using (var context = new OMSTContext())
            {
                var premiuminfo = (from x in context.Movies
                                   where x.MovieID == movieid
                                   select x.ScreenType).FirstOrDefault();
                decimal premiumticket = 0.00m;
                if (premiuminfo == null)
                {
                    throw new Exception("Movie screentype info missing");
                }
                if (premiuminfo.Premium)
                {
                    if (premiuminfo.ScreenTypeID == 2)
                    {
                        premiumticket = 3.00m;
                    }
                    else
                    {
                        premiumticket = 5.00m;
                    }
                }
                return premiumticket;
            }
        }
    }
}
