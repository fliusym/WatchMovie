using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace WMViewModelCommon
{
    [Windows.Foundation.Metadata.WebHostHidden]
    public abstract class WMMovieGroupCommon<T> : BindableBase, IWMMovieGroup where T : IWMMovieItem
    {
        private static readonly Uri _baseUri = new Uri("ms-appx:///");

        public WMMovieGroupCommon(string uniqueId, string title, string imagePath)
        {
            _uniqueId = uniqueId;
            _title = title;
            _imagePath = imagePath;
            Items.CollectionChanged += Items_CollectionChanged;
        }
        /// <summary>
        /// when the items in the movie group has changed
        /// </summary>
        /// <param name="sender">the sender of the event</param>
        /// <param name="e">the event args</param>
        void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Provides a subset of the full items collection to bind to from a GroupedItemsPage
            // for two reasons: GridView will not virtualize large items collections, and it
            // improves the user experience when browsing through groups with large numbers of
            // items.
            //
            // A maximum of 12 items are displayed because it results in filled grid columns
            // whether there are 1, 2, 3, 4, or 6 rows displayed

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewStartingIndex < 12)
                    {
                        TopItems.Insert(e.NewStartingIndex, Items[e.NewStartingIndex]);
                        if (TopItems.Count > 12)
                        {
                            TopItems.RemoveAt(12);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                    if (e.OldStartingIndex < 12 && e.NewStartingIndex < 12)
                    {
                        TopItems.Move(e.OldStartingIndex, e.NewStartingIndex);
                    }
                    else if (e.OldStartingIndex < 12)
                    {
                        TopItems.RemoveAt(e.OldStartingIndex);
                        TopItems.Add(Items[11]);
                    }
                    else if (e.NewStartingIndex < 12)
                    {
                        TopItems.Insert(e.NewStartingIndex, Items[e.NewStartingIndex]);
                        TopItems.RemoveAt(12);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldStartingIndex < 12)
                    {
                        TopItems.RemoveAt(e.OldStartingIndex);
                        if (Items.Count >= 12)
                        {
                            TopItems.Add(Items[11]);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    if (e.OldStartingIndex < 12)
                    {
                        TopItems[e.OldStartingIndex] = Items[e.OldStartingIndex];
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    TopItems.Clear();
                    while (TopItems.Count < Items.Count && TopItems.Count < 12)
                    {
                        TopItems.Add(Items[TopItems.Count]);
                    }
                    break;
            }
        }

        private string _title = string.Empty;
        /// <summary>
        /// provide the movie group title
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                SetProperty(ref _title, value);
            }
        }

        private ImageSource _image = null;
        private string _imagePath = null;
        /// <summary>
        /// provide the movie group image
        /// </summary>
        public ImageSource Image
        {
            get
            {
                if (this._image == null && _imagePath != null)
                {
                    _image = new BitmapImage(new Uri(WMMovieGroupCommon<T>._baseUri, _imagePath));
                }
                return _image;
            }
            set
            {
                _imagePath = null;
                SetProperty(ref _image, value);
            }
        }
        /// <summary>
        /// movie watch group index
        /// </summary>
        public MovieWatchGroupIndex Index { get; set; }
        /// <summary>
        /// provide the items for the group
        /// </summary>
        private ObservableCollection<IWMMovieItem> _items = new ObservableCollection<IWMMovieItem>();
        public ObservableCollection<IWMMovieItem> Items
        {
            get { return _items; }
        }

        private ObservableCollection<IWMMovieItem> _topItems = new ObservableCollection<IWMMovieItem>();
        /// <summary>
        /// provide the top items for the group
        /// </summary>
        public ObservableCollection<IWMMovieItem> TopItems
        {
            get { return _topItems; }
        }
        private string _uniqueId = string.Empty;
        /// <summary>
        /// provide movie group unique id
        /// </summary>
        public string UniqueId
        {
            get
            {
                return _uniqueId;
            }
            set
            {
                SetProperty(ref _uniqueId, value);
            }
        }

        /// <summary>
        /// Add item from the response of REST api
        /// </summary>
        /// <typeparam name="U">The response type</typeparam>
        /// <param name="response">Response content</param>
        public void AddItem<U>(U response)
        {
            AddItemInternal<U>(response);
        }
        /// <summary>
        /// Add item internal function, derived function should override this
        /// </summary>
        /// <typeparam name="U">the response type</typeparam>
        /// <param name="response">response content</param>
        protected virtual void AddItemInternal<U>(U response)
        {

        }
    }
}
