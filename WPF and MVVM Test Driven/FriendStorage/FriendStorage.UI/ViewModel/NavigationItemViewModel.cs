using System;
using System.Windows.Input;
using FriendStorage.UI.Command;
using FriendStorage.UI.Events;
using Prism.Events;

namespace FriendStorage.UI.ViewModel
{
    public class NavigationItemViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        public NavigationItemViewModel(int id, string displayMember,
            IEventAggregator eventAggregator)
        {
            Id = id;
            DisplayMember = displayMember;
            OpenFriendEditViewCommand = new DelegateCommand(OnOpenFriendEditViewExecute);
            _eventAggregator = eventAggregator;
        }

        public string DisplayMember { get; set; }

        public int Id { get; set; }

        public ICommand OpenFriendEditViewCommand { get; set; }

        private void OnOpenFriendEditViewExecute(object obj)
        {
            _eventAggregator.GetEvent<OpenFriendEditViewEvent>()
                .Publish(Id);
        }
    }
}