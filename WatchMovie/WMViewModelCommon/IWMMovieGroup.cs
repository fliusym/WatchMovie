using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using System.Collections.ObjectModel;

namespace WMViewModelCommon
{
    public interface IWMMovieGroup : IWMGroup
    {
        ImageSource Image { get; set; }
        MovieWatchGroupIndex Index { get; set; }
        ObservableCollection<IWMMovieItem> Items { get; }

    }

    public enum MovieWatchGroupIndex
    {
        MovieWatchGroupInTheaters = 0,
        MovieWatchGroupUpcoming,
        MovieWatchGroupFavoriteTheaters
    }
}
