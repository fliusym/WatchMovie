using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WMViewModelCommon;
using RottenTomatoDataService;
using WMDataServiceApi;
using WMMoviesViewModel;

namespace WMViewModel
{
    public class WMViewModel
    {
        private static readonly WMViewModel _viewModel = new WMViewModel();

        private ObservableCollection<IWMGroup> _allGroups = new ObservableCollection<IWMGroup>();

        private readonly RTDataService _rtDataService = new RTDataService();

        private static bool _loaded = false;

        /// <summary>
        /// Init movie groups 
        /// </summary>
        /// <returns>nothing</returns>
        async private static Task InitMovieGroupsAsync()
        {
            try
            {
                if (!_loaded)
                {
                    _loaded = true;
                    Task<DataServiceResult>[] rtTasks = { _viewModel._rtDataService.GetRTInTheaterDataAsync(), _viewModel._rtDataService.GetRTUpcomingDataAsync() };
                    await Task.WhenAll<DataServiceResult>(rtTasks);
                    DataServiceResult inTheaterResult = rtTasks[0].Result;
                    _viewModel.AddNewMovieGroup(inTheaterResult, MovieGroupsCategory.InTheater);
                    DataServiceResult upcomingResult = rtTasks[1].Result;
                    _viewModel.AddNewMovieGroup(upcomingResult, MovieGroupsCategory.Upcoming);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// provide the AllGroups 
        /// </summary>
        public ObservableCollection<IWMGroup> AllGroups
        {
            get { return _allGroups; }
        }
        /// <summary>
        /// Get the group by its unique Id
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public static IWMGroup GetGroupById(string uniqueId)
        {
            var matches = _viewModel.AllGroups.Where((group) => group.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1)
            {
                return matches.First();
            }
            return null;
        }
        /// <summary>
        /// Get all groups
        /// </summary>
        /// <param name="identifier">The identifier of this method</param>
        /// <returns>list of groups</returns>
        async public static Task<IEnumerable<IWMGroup>> GetAllGroups(string identifier)
        {
            if (identifier != "AllGroups")
            {
                throw new ArgumentException("The identifier has to be AllGroups");
            }
            await InitMovieGroupsAsync();
            return _viewModel.AllGroups;
        }
        /// <summary>
        /// get the group by the group title
        /// </summary>
        /// <param name="title">the group title</param>
        /// <returns>the group has the same title</returns>
        public static IWMGroup GetGroupByTitle(string title)
        {
            var matches = _viewModel.AllGroups.Where(group => group.Title.Equals(title));
            if (matches.Count() == 1)
            {
                return matches.First();
            }
            return null;
        }
        /// <summary>
        /// add new movie group
        /// </summary>
        /// <param name="result">the result from the REST api</param>
        /// <param name="category">the movie group category, InTheater or Upcoming</param>
        private void AddNewMovieGroup(DataServiceResult result, MovieGroupsCategory category)
        {
            IWMGroup newGroup = null;
            if (result != null)
            {
                if (result.Status == DataServiceApiStatus.DATASERVICE_SUCCESS)
                {
                    var response = result.Result as RTMovies;
                    if (response != null)
                    {
                        string groupId = new System.Guid().ToString();
                        switch (category)
                        {
                            case MovieGroupsCategory.InTheater:
                                {
                                    newGroup = new RTInTheaterMoviesGroup(
                                        groupId, "InTheater", response.Movies[0].Posters.Original);
                                    break;
                                }
                            case MovieGroupsCategory.Upcoming:
                                {
                                    newGroup = new RTUpcomingMoviesGroup(
                                        groupId, "Upcoming", response.Movies[0].Posters.Original);
                                    break;
                                }
                        }
                    }
                    if (newGroup != null)
                    {
                        _viewModel.AllGroups.Add(newGroup);
                    }
                }
                else
                {
                    throw new WMRTException(result.Message);
                }
            }
        }


        private enum MovieGroupsCategory
        {
            InTheater,
            Upcoming
        }
     
    }
}
