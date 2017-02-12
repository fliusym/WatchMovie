using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMViewModelCommon
{
    /// <summary>
    /// represents the group
    /// </summary>
    public interface IWMGroup : IWMEntity
    {
        string Title { get; set; }
        void AddItem<T>(T response);
    }
}
