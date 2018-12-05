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
    [DataObject]
    public class TheatreController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<Theatre> Theatres_List()
        {
            using (var context = new OMSTContext())
            {
                return context.Theatres.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Theatre Theatres_Get(int theatreid)
        {
            using (var context = new OMSTContext())
            {
                return context.Theatres.Find(theatreid);
            }
        }

      
    }
}
