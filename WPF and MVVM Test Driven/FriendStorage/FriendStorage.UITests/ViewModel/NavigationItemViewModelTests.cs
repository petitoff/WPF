using FriendStorage.UI.Events;
using FriendStorage.UI.ViewModel;
using Moq;
using Prism.Events;
using Xunit;

namespace FriendStorage.UITests.ViewModel
{
    public class NavigationItemViewModelTests
    {
        [Fact]
        public void ShouldPublishOpenFriendEditViewEvent()
        {
            const int friendId = 7;
            var eventMock = new Mock<OpenFriendEditViewEvent>();
            var eventAggregatorMock = new Mock<IEventAggregator>();
            eventAggregatorMock.Setup(ea => ea.GetEvent<OpenFriendEditViewEvent>())
                .Returns(eventMock.Object);
            
            var viewModel = new NavigationItemViewModel(friendId, "Thomas", eventAggregatorMock.Object);
            viewModel.OpenFriendEditViewCommand.Execute(null);
        }
    }
}