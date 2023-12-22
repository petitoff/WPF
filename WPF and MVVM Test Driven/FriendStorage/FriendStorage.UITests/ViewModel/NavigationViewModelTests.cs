using System.Collections.Generic;
using System.Linq;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.ViewModel;
using Moq;
using Xunit;
using FriendStorage.Model;

namespace FriendStorage.UITests.ViewModel
{
    public class NavigationViewModelTests
    {
        private readonly NavigationViewModel _navigationViewModel;

        public NavigationViewModelTests()
        {
            var navigationDataProviderMock = new Mock<INavigationDataProvider>();
            navigationDataProviderMock.Setup(dp => dp.GetAllFriends()).Returns(
                new List<LookupItem>
                {
                    new LookupItem { Id = 1, DisplayMember = "Julia" },
                    new LookupItem { Id = 2, DisplayMember = "Thomas" }
                });


            _navigationViewModel = new NavigationViewModel(navigationDataProviderMock.Object);
            _navigationViewModel.Load();
        }

        [Fact]
        public void ShouldLoadFriends()
        {
            Assert.Equal(2, _navigationViewModel.Friends.Count);

            var friend1 = _navigationViewModel.Friends.SingleOrDefault(f => f.Id == 1);
            Assert.NotNull(friend1);
            Assert.Equal("Julia", friend1.DisplayMember);


            var friend2 = _navigationViewModel.Friends.SingleOrDefault(f => f.Id == 2);
            Assert.NotNull(friend2);
            Assert.Equal("Thomas", friend2.DisplayMember);
        }

        [Fact]
        public void ShouldLoadFriendsOnlyOnce()
        {
            _navigationViewModel.Load();
            _navigationViewModel.Load();

            Assert.Equal(2, _navigationViewModel.Friends.Count);
        }
    }
}