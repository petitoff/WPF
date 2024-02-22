using FriendStorage.UI.Events;
using FriendStorage.UI.ViewModel;
using Moq;
using Prism.Events;
using Xunit;

namespace FriendStorage.UITests.ViewModel
{
    public class MainViewModelTests
    {
        private readonly Mock<IEventAggregator> _eventAggregatorMock;
        private readonly Mock<INavigationViewModel> _navigationViewModelMock;
        private readonly OpenFriendEditViewEvent _openFriendEditViewEvent;
        private readonly MainViewModel _viewModel;

        public MainViewModelTests()
        {
            _navigationViewModelMock = new Mock<INavigationViewModel>();

            _openFriendEditViewEvent = new OpenFriendEditViewEvent();
            _eventAggregatorMock = new Mock<IEventAggregator>();
            _eventAggregatorMock.Setup(ea => ea.GetEvent<OpenFriendEditViewEvent>())
                .Returns(_openFriendEditViewEvent);

            _viewModel = new MainViewModel(_navigationViewModelMock.Object,
                CreateFriendEditViewModel, _eventAggregatorMock.Object);
        }

        private IFriendEditViewModel CreateFriendEditViewModel()
        {
            return new Mock<IFriendEditViewModel>().Object;
        }

        [Fact]
        public void ShouldCallTheLoadMethodOfTheFriendEditViewModel()
        {
            _viewModel.Load();
            _navigationViewModelMock.Verify(vm => vm.Load(), Times.Once);
        }
    }
}