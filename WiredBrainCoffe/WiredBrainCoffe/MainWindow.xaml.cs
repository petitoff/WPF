using System.Windows;
using WiredBrainCoffe.Data;
using WiredBrainCoffe.Model;
using WiredBrainCoffe.ViewModel;

namespace WiredBrainCoffe
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();

            _viewModel = mainViewModel;
            DataContext = _viewModel;
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }
    }
}
