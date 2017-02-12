using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMViewModelCommon;

namespace WMMoviesViewModel
{
    public class RTUpcomingMovie : WMMovieItemCommon
    {
        public RTUpcomingMovie(string uniqueId, string title, string rating, int audienceScore, int criticsScore, string clips, string reviews, string cast, string imagePath, string description, RTUpcomingMoviesGroup movieGroup)
            : base(uniqueId, title, rating, audienceScore, criticsScore, clips, reviews, cast, imagePath, description)
        {
            this._movieGroup = movieGroup;
        }
        private RTUpcomingMoviesGroup _movieGroup;
        /// <summary>
        /// provide the movie group
        /// </summary>
        public RTUpcomingMoviesGroup MovieGroup
        {
            get { return _movieGroup; }
            set { SetProperty(ref _movieGroup, value); }
        }
    }
}
