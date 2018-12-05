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
    public class LocationController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Location> Locations_List()
        {
            using (var context = new OMSTContext())
            {
                return context.Locations.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Location Locations_Get(int locationid)
        {
            using (var context = new OMSTContext())
            {
                return context.Locations.Find(locationid);
            }
        }
    }
}
