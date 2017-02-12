using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace WMViewModelCommon
{
    /// <summary>
    /// movie item 
    /// </summary>
    public interface IWMMovieItem : IWMItem
    {
        string Rating { get; set; }
        int AudienceScore { get; set; }
        int CriticsScore { get; set; }
        string Clips { get; set; }
        string Reviews { get; set; }
        string Cast { get; set; }
        string Description { get; set; }
        ImageSource Image { get; set; }

    }
}
