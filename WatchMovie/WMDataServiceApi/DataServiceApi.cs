using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMDataServiceApi
{
    public class DataServiceApi
    {
        /// <summary>
        /// Invoke the REST api 
        /// </summary>
        /// <typeparam name="T">The type of response from the REST api</typeparam>
        /// <param name="apiName">The API name used to call REST service </param>
        /// <returns></returns>
        async public Task<DataServiceResult> Invoke<T>(string apiName)
        {
            DataServiceResult result = new DataServiceResult();
            try
            {
                var response = await DataServiceApiLoader.LoadObject<T>(apiName);
                result.Message = string.Empty;
                result.Result = response;
                result.ApiName = apiName;
                result.Status = DataServiceApiStatus.DATASERVICE_SUCCESS;
            }
            catch (Exception e)
            {
                result.Status = DataServiceApiStatus.DATASERVICE_FAILURE;
                result.ApiName = apiName;
                result.Message = e.Message;
                result.Result = null;
            }
            return result;
        }
    }
}
