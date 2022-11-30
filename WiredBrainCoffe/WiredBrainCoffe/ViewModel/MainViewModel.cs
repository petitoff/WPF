using System.Threading.Tasks;

namespace WiredBrainCoffe.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;
        private CustomersViewModel _customersViewModel;
        private ProductsViewModel _productsViewModel;


        public MainViewModel(CustomersViewModel customersViewModel, ProductsViewModel productsViewModel)
        {
            _customersViewModel = customersViewModel;
            _productsViewModel = productsViewModel;
            SelectedViewModel = _customersViewModel;
        }

        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                OnPropertyChange();
            }
        }

        public override async Task LoadAsync()
        {
            if (SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }
    }
}
