using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMViewModelCommon
{
    /// <summary>
    /// The highest level of the data model
    /// </summary>
    public interface IWMEntity
    {
        string UniqueId { get; set; }
    }
}
