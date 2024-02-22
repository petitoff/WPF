using System;
using System.Collections.ObjectModel;
using Prism.Events;

namespace FriendStorage.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly Func<IFriendEditViewModel> _friendEditVmCreator;
        private readonly IEventAggregator _eventAggregator;

        public MainViewModel(INavigationViewModel navigationViewModel, Func<IFriendEditViewModel> friendEditVmCreator,
            IEventAggregator eventAggregator)
        {
            NavigationViewModel = navigationViewModel;
            FriendEditViewModels = new ObservableCollection<IFriendEditViewModel>();
            _friendEditVmCreator = friendEditVmCreator;
            _eventAggregator = eventAggregator;
        }

        public INavigationViewModel NavigationViewModel { get; }

        public ObservableCollection<IFriendEditViewModel> FriendEditViewModels { get; set; }

        public IFriendEditViewModel SelectedFriendEditViewModel { get; set; }

        public void Load()
        {
            NavigationViewModel.Load();
        }
    }
}