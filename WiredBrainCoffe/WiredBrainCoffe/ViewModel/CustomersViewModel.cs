using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffe.Command;
using WiredBrainCoffe.Data;
using WiredBrainCoffe.Model;

namespace WiredBrainCoffe.ViewModel
{
    public class CustomersViewModel : ViewModelBase
    {
        public DelegateCommand AddCommand { get; }
        public DelegateCommand DeleteCommand { get; }
        public DelegateCommand MoveNavigationCommand { get; }
        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();

        private readonly ICustomerDataProvider _customerDataProvider;
        private CustomerItemViewModel? _selectedCustomer;
        private NavigationSide _navigationSide;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
            AddCommand = new DelegateCommand(Add);
            MoveNavigationCommand = new DelegateCommand(MoveNavigation);
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
        }

        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChange();
                DeleteCommand.OnCanExecuteChanged();
            }
        }

        public NavigationSide NavigationSide
        {
            get => _navigationSide;
            private set
            {
                _navigationSide = value;
                OnPropertyChange();
            }
        }

        public override async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }

            var customers = await _customerDataProvider.GetAllAsync();

            if (customers == null)
            {
                return;
            }

            foreach (var customer in customers)
            {
                Customers.Add(new CustomerItemViewModel(customer));
            }
        }

        private void Add(object? parameter)
        {
            var customer = new Customer { FirstName = "New" };
            var customerItem = new CustomerItemViewModel(customer);
            Customers.Add(customerItem);
            SelectedCustomer = customerItem;
        }

        private void MoveNavigation(object? parameter)
        {
            NavigationSide = NavigationSide == NavigationSide.Left ? NavigationSide.Right : NavigationSide.Left;
        }

        private void Delete(object? parameter)
        {
            if(SelectedCustomer != null)
            {
                Customers.Remove(SelectedCustomer);
                SelectedCustomer = null;
            }
        }

        private bool CanDelete(object? parameter)
        {
            return SelectedCustomer is not null;
        }
    }

    public enum NavigationSide
    {
        Left, Right
    }
}
