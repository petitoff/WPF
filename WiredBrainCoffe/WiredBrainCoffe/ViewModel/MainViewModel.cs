using System.Threading.Tasks;
using WiredBrainCoffe.Command;

namespace WiredBrainCoffe.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private ViewModelBase? _selectedViewModel;


        public MainViewModel(CustomersViewModel customersViewModel, ProductsViewModel productsViewModel)
        {
            CustomersViewModel = customersViewModel;
            ProductsViewModel = productsViewModel;
            SelectedViewModel = CustomersViewModel;
            SelectViewModelCommand = new DelegateCommand(SelectViewModel);
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
        public CustomersViewModel CustomersViewModel { get; }
        public ProductsViewModel ProductsViewModel { get; }
        public DelegateCommand SelectViewModelCommand { get; }


        public override async Task LoadAsync()
        {
            if (SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }

        private async void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }
    }
}
