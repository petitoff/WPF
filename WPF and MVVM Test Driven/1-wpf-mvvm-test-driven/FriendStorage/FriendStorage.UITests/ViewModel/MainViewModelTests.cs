using FriendStorage.UI.ViewModel;
using Moq;

namespace FriendStorage.UITests.ViewModel;

public class MainViewModelTests
{
    [Fact]
    public void ShouldCallTheLoadMethodOfTheFriendEditViewModel()
    {
        var navigationViewModelMock = new Mock<INavigationViewModel>();
        var viewModel = new MainViewModel(navigationViewModelMock.Object);
        viewModel.Load();

        navigationViewModelMock.Verify(vm => vm.Load(), Times.Once);
        
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