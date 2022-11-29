using System.Threading.Tasks;

namespace WiredBrainCoffe.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;
        private CustomersViewModel CustomersViewModel { get; }


        public MainViewModel(CustomersViewModel customersViewModel)
        {
            CustomersViewModel = customersViewModel;
            SelectedViewModel = CustomersViewModel;
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
