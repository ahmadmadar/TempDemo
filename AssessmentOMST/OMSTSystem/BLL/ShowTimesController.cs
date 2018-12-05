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
    public class ShowTimesController
    {
        public List<MovieListPOCO> ShowTimes_MoviesByLocations(int locationid)
        {
            DateTime fakeDate = DateTime.Parse("2017-12-28");
            using (var context = new OMSTContext())
            {
                var results = (from x in context.ShowTimes
                               where x.StartDate.Year == 2017
                                  && x.StartDate.Month == 12
                                  && x.StartDate.Day == 28
                                  && x.Theatre.LocationID == locationid
                               select new MovieListPOCO
                               {
                                   MovieID = x.MovieID,
                                   Title =x.Movie.Title
                               }).Distinct().OrderBy(x => x.Title);
                return results.ToList();
            }
        }
        public List<MovieShowTimes> ShowTimes_ShowTimesByMoviesByLocations(int locationid, int movieid)
        {
            DateTime fakeDate = DateTime.Parse("2017-12-28");
            using (var context = new OMSTContext())
            {
                var results = (from x in context.ShowTimes
                               where x.StartDate.Year == 2017
                                  && x.StartDate.Month == 12
                                  && x.StartDate.Day == 28
                                  && x.Theatre.LocationID == locationid
                                  && x.MovieID == movieid
                               select new MovieShowTimes
                               {
                                   TheatreNumber = x.Theatre.TheatreNumber,
                                   ShowTimeID = x.ShowTimeID,
                                   Times = x.StartDate
                               }).Distinct().OrderBy(x => x.Times);
                return results.ToList();
            }
        }

       
    }
}
