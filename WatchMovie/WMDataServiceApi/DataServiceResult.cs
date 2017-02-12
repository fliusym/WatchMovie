using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMDataServiceApi
{
    public class DataServiceResult
    {
        public DataServiceApiStatus Status { get; set; }
        public string ApiName { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}
