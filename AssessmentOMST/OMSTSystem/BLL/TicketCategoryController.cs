using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using OMSTSystem.DAL;
using OMST.Data.Entities;
using System.ComponentModel;
#endregion


namespace OMSTSystem.BLL
{
    public class TicketCategoryController
    {
        public List<TicketCategory> TicketCategory_List()
        {
            using (var context = new OMSTContext())
            {
                return context.TicketCategories.ToList();
            }
        }
    }
}
