using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMViewModelCommon;

namespace WMMoviesViewModel
{
    public class RTInTheaterMovie : WMMovieItemCommon
    {
        public RTInTheaterMovie(string uniqueId, string title, string rating, int audienceScore, int criticsScore, string clips, 
            string reviews, string cast, string imagePath, string description,RTInTheaterMoviesGroup movieGroup)
            : base(uniqueId, title, rating, audienceScore, criticsScore, clips, reviews, cast, imagePath, description)
        {
            this._movieGroup = movieGroup;
        }

        private RTInTheaterMoviesGroup _movieGroup;
        /// <summary>
        /// provide the group this movie is in
        /// </summary>
        public RTInTheaterMoviesGroup MovieGroup
        {
            get { return _movieGroup; }
            set { SetProperty(ref _movieGroup, value); }
        }
            
    }
}
