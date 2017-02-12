using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace WMDataServiceApi
{
    /// <summary>
    /// represents the class to parse the response from REST api
    /// </summary>
    public static class DataServiceApiLoader
    {
        public static T DeserializeObject<T>(string objString)
        {
            var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            return (T)JsonConvert.DeserializeObject<T>(objString);
        }

        async public static Task<T> LoadObject<T>(string apiName)
        {
            var ws = new HttpClient();
            var apiCall = new Uri(apiName);
            string response = await ws.GetStringAsync(apiCall);
            return (T)DeserializeObject<T>(response);
        }
    }

}
