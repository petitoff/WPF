using System.Windows;
using FriendStorage.UI.ViewModel;

namespace FriendStorage.UI.View
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;

            _viewModel = mainViewModel;
            DataContext = _viewModel;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.Load();
        }
    }
}
