using System.Collections.ObjectModel;
using FriendStorage.DataAccess;
using FriendStorage.Model;
using FriendStorage.UI.DataProvider;

namespace FriendStorage.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase
    {
        private readonly INavigationDataProvider _dataProvider;

        public NavigationViewModel(INavigationDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            Friends = new ObservableCollection<LookUpItem>();
        }

        public ObservableCollection<LookUpItem> Friends { get; set; }

        public void Load()
        {
            Friends.Clear();
            foreach (var friend in _dataProvider.GetAllFriends())
            {
                Friends.Add(friend);   
            }
        }
    }
}
