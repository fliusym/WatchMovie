using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace WMViewModelCommon
{
    public abstract class WMMovieItemCommon : BindableBase,IWMMovieItem
    {

        private static readonly Uri _baseUri = new Uri("ms-appx:///");
        protected WMMovieItemCommon(string uniqueId, string title, string rating, int audienceScore, int criticsScore, string clips, string reviews, string cast, string imagePath, String description)
        {
            this._uniqueId = uniqueId;
            this._title = title;
            this._rating = rating;
            this._audienceScore = audienceScore;
            this._criticsScore = criticsScore;
            this._clips = clips;
            this._reviews = reviews;
            this._cast = cast;
            this._description = description;
            this._imagePath = imagePath;
        }
        private string _uniqueId = string.Empty;
        /// <summary>
        /// provide the movie item unique Id
        /// </summary>
        public string UniqueId
        {
            get { return _uniqueId; }
            set { SetProperty(ref _uniqueId, value); }
        }

        private string _title = string.Empty;
        /// <summary>
        /// provide the movie item title
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _rating = string.Empty;
        /// <summary>
        /// provide the movie item rating
        /// </summary>
        public string Rating
        {
            get { return _rating; }
            set { SetProperty(ref _rating, value); }
        }

        private int _audienceScore;
        /// <summary>
        /// provide the movie item audience score
        /// </summary>
        public int AudienceScore
        {
            get { return _audienceScore; }
            set { SetProperty(ref _audienceScore, value); }
        }
        private int _criticsScore;
        /// <summary>
        /// provide the movie item critics score
        /// </summary>
        public int CriticsScore
        {
            get { return _criticsScore; }
            set { this.SetProperty(ref this._criticsScore, value); }
        }

        private string _clips;
        /// <summary>
        /// provide the movie item clips
        /// </summary>
        public string Clips
        {
            get { return _clips; }
            set { this.SetProperty(ref this._clips, value); }
        }

        private string _reviews;
        /// <summary>
        /// provide the movie item reviews
        /// </summary>
        public string Reviews
        {
            get { return _reviews; }
            set { this.SetProperty(ref this._reviews, value); }
        }

        private string _cast;
        /// <summary>
        /// provide movie item cast
        /// </summary>
        public string Cast
        {
            get { return _cast; }
            set { this.SetProperty(ref this._cast, value); }
        }

        private string _description = string.Empty;
        /// <summary>
        /// provide movie item description
        /// </summary>
        public string Description
        {
            get { return this._description; }
            set { this.SetProperty(ref this._description, value); }
        }

        private ImageSource _image = null;
        private string _imagePath = null;
        /// <summary>
        /// provide the movie item image
        /// </summary>
        public ImageSource Image
        {
            get
            {
                if (this._image == null && this._imagePath != null)
                {
                    this._image = new BitmapImage(new Uri(WMMovieItemCommon._baseUri, this._imagePath));
                }
                return this._image;
            }

            set
            {
                this._imagePath = null;
                this.SetProperty(ref this._image, value);
            }
        }
        /// <summary>
        /// set the movie item image based on its image path
        /// </summary>
        /// <param name="path">the image path</param>
        public void SetImage(string path)
        {
            this._image = null;
            this._imagePath = path;
            this.OnPropertyChanged("Image");
        }
        /// <summary>
        /// override the ToString
        /// </summary>
        /// <returns>the title of the movie item</returns>
        public override string ToString()
        {
            return this.Title;
        }
    
    }
}
