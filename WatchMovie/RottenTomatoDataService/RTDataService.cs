using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMDataServiceApi;

namespace RottenTomatoDataService
{
    public class RTDataService
    {
        private readonly DataServiceApi _rtApi = new DataServiceApi();

        async public Task<DataServiceResult> GetRTInTheaterDataAsync()
        {
            var apiName = RTServiceApiUri.ROTTEN_TOMATOES_API_MOVIES_INTHEATERS;
            return await _rtApi.Invoke<RTMovies>(apiName);
        }

        async public Task<DataServiceResult> GetRTUpcomingDataAsync()
        {
            var apiName = RTServiceApiUri.ROTTEN_TOMATOES_API_MOVIES_UPCOMING;
            return await _rtApi.Invoke<RTMovies>(apiName);
        }
    }
}
