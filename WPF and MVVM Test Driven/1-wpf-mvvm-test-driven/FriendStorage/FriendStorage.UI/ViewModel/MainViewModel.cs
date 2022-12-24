using FriendStorage.DataAccess;
using FriendStorage.UI.DataProvider;

namespace FriendStorage.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel()
        {
            NavigationViewModel = new NavigationViewModel(new NavigationDataProvider(() => new FileDataService()));
        }

        public NavigationViewModel NavigationViewModel { get; set; }

        public void Load()
        {
            NavigationViewModel.Load();
        }
    }
}
