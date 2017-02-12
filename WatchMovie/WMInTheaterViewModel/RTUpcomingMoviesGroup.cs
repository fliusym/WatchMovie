using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMViewModelCommon;
using RottenTomatoDataService;

namespace WMMoviesViewModel
{
    public class RTUpcomingMoviesGroup : WMMovieGroupCommon<RTUpcomingMovie>
    {
        public RTUpcomingMoviesGroup(string uniqueId, string title, string imagePath)
            : base(uniqueId, title, imagePath)
        {
        }

        protected override void AddItemInternal<U>(U response)
        {
            RTMovies movies = response as RTMovies;
            if (movies != null)
            {
                try
                {
                    Items.Clear();

                    foreach (var mi in movies.Movies.Select(t => new RTUpcomingMovie(
                        t.Id,
                        t.Title,
                        t.MPAARating,
                        t.Ratings.AudienceScore,
                        t.Ratings.CriticsScore,
                        t.Links.Clips,
                        t.Links.Reviews,
                        t.Links.Cast,
                        t.Posters.Original,
                        t.Synopsis,
                        this)))
                    {
                        Items.Add(mi);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            base.AddItemInternal<U>(response);
        }
    }
}
