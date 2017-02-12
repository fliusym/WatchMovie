using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottenTomatoDataService
{
    public static class RTServiceApiUri
    {
        public static string ROTTEN_TOMATOES_API_KEY = @"apikey=kx9yz2q9q64pyfsxm435ey3j";

        // API URI's for Movies and DVD's
        public static string ROTTEN_TOMATOES_API_MOVIES_BOXOFFICE = @"http://api.rottentomatoes.com/api/public/v1.0/lists/movies/box_office.json?limit=20&country=us&" + ROTTEN_TOMATOES_API_KEY;
        public static string ROTTEN_TOMATOES_API_MOVIES_INTHEATERS = @"http://api.rottentomatoes.com/api/public/v1.0/lists/movies/in_theaters.json?page_limit=20&page=1&country=us&" + ROTTEN_TOMATOES_API_KEY;
        public static string ROTTEN_TOMATOES_API_MOVIES_OPENING = @"http://api.rottentomatoes.com/api/public/v1.0/lists/movies/opening.json?limit=20&country=us&" + ROTTEN_TOMATOES_API_KEY;
        public static string ROTTEN_TOMATOES_API_MOVIES_UPCOMING = @"http://api.rottentomatoes.com/api/public/v1.0/lists/movies/upcoming.json?page_limit=20&page=1&country=us&" + ROTTEN_TOMATOES_API_KEY;
        public static string ROTTEN_TOMATOES_API_DVD_TOPRENTALS = @"http://api.rottentomatoes.com/api/public/v1.0/lists/dvds/top_rentals.json?limit=20&country=us&" + ROTTEN_TOMATOES_API_KEY;
        public static string ROTTEN_TOMATOES_API_DVD_CURRENTRELEASES = @"http://api.rottentomatoes.com/api/public/v1.0/lists/dvds/current_releases.json?page_limit=20&page=1&country=us&" + ROTTEN_TOMATOES_API_KEY;
        public static string ROTTEN_TOMATOES_API_DVD_NEWRELEASES = @"http://api.rottentomatoes.com/api/public/v1.0/lists/dvds/new_releases.json?page_limit=20&page=1&country=us&" + ROTTEN_TOMATOES_API_KEY;
        public static string ROTTEN_TOMATOES_API_DVD_UPCOMING = @"http://api.rottentomatoes.com/api/public/v1.0/lists/dvds/upcoming.json?page_limit=20&page=1&country=us&" + ROTTEN_TOMATOES_API_KEY;

        // API URI for Movie Search
        public static string ROTTEN_TOMATOES_API_SEARCH = @"http://api.rottentomatoes.com/api/public/v1.0/movies.json?" + ROTTEN_TOMATOES_API_KEY + @"&q=";
    }
}
