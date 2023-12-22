using FriendStorage.DataAccess;
using FriendStorage.UI.DataProvider;

namespace FriendStorage.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(INavigationViewModel navigationViewModel)
        {
            NavigationViewModel = navigationViewModel;
        }

        public INavigationViewModel NavigationViewModel { get; set; }

        public void Load()
        {
            // NavigationViewModel.Load();
        }
    }
}
