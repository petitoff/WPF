using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendStorage.Model;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.ViewModel;

namespace FriendStorage.UITests.ViewModel
{
    public class NavigationViewModelTests
    {
        [Fact]
        public void ShouldLoadFriends()
        {
            var navigationViewModel = new NavigationViewModel(new NavigationDataProviderMocks());
            navigationViewModel.Load();

            Assert.Equal(2, navigationViewModel.Friends.Count);

            var friend1 = navigationViewModel.Friends.SingleOrDefault(f => f.Id == 1);
            Assert.NotNull(friend1);
            Assert.Equal("Julia", friend1.DisplayMember);


            var friend2 = navigationViewModel.Friends.SingleOrDefault(f => f.Id == 2);
            Assert.NotNull(friend2);
            Assert.Equal("Thomas", friend2.DisplayMember);
        }

        [Fact]
        public void ShouldLoadFriendsOnlyOnce()
        {
            var navigationViewModel = new NavigationViewModel(new NavigationDataProviderMocks());
            navigationViewModel.Load();
            navigationViewModel.Load();

            Assert.Equal(2, navigationViewModel.Friends.Count);
        }
    }

    public class NavigationDataProviderMocks : INavigationDataProvider
    {
        public IEnumerable<LookUpItem> GetAllFriends()
        {
            yield return new LookUpItem { Id = 1, DisplayMember = "Julia"};
            yield return new LookUpItem { Id = 2, DisplayMember = "Thomas" };
        }
    }
}
