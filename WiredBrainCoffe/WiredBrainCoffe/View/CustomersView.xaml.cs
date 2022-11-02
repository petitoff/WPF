using System.Windows;
using System.Windows.Controls;
using WiredBrainCoffe.Data;
using WiredBrainCoffe.ViewModel;

namespace WiredBrainCoffe.View
{
    public partial class CustomersView : UserControl
    {
        private CustomersViewModel _viewModel;

        public CustomersView()
        {
            InitializeComponent();

            _viewModel = new CustomersViewModel(new CustomerDataProvider());
            DataContext = _viewModel;
            Loaded += CustomersView_Loaded;
        }

        private async void CustomersView_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }
    }
}
