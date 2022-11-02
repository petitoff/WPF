using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffe.Command;
using WiredBrainCoffe.Data;
using WiredBrainCoffe.Model;

namespace WiredBrainCoffe.ViewModel
{
    class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;


        private CustomerItemViewModel? _selectedCustomer;
        private NavigationSide _navigationSide;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
            AddCommand = new DelegateCommand(Add);
            MoveNavigationCommand = new DelegateCommand(MoveNavigation);
        }

        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();
        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChange();
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

        public async Task LoadAsync()
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

        public DelegateCommand AddCommand { get; }
        public DelegateCommand MoveNavigationCommand { get; }


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
    }

    public enum NavigationSide
    {
        Left, Right
    }
}
