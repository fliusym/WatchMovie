using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMViewModel
{
    public class WMRTException : Exception
    {
        public WMRTException(string msg)
            : base(msg)
        {
        }
    }
}
