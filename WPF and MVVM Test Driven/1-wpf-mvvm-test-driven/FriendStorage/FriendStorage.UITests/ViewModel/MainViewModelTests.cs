using FriendStorage.UI.ViewModel;

namespace FriendStorage.UITests.ViewModel
{
    public class MainViewModelTests
    {
        [Fact]
        public void ShouldCallTheLoadMethodOfTheFriendEditViewModel()
        {
            var navigationViewModelMock = new NavigationViewModelMock();
            var viewModel = new MainViewModel(navigationViewModelMock);
            viewModel.Load();

            Assert.True(navigationViewModelMock.LoadWasCalled);
        }
    }

    public class NavigationViewModelMock : INavigationViewModel
    {
        public bool LoadWasCalled { get; set; }
        public void Load()
        {
            LoadWasCalled = true;
        }
    }
}
