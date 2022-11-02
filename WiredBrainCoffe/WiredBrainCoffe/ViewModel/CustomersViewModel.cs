using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffe.Data;
using WiredBrainCoffe.Model;

namespace WiredBrainCoffe.ViewModel
{
    class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;
        private CustomerItemViewModel? _selectedCustomer;
        private int _navigationColumn;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
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

        public int NavigationColumn
        {
            get => _navigationColumn;
            private set
            {
                _navigationColumn = value;
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

        internal void Add()
        {
            var customer = new Customer { FirstName = "New" };
            var customerItem = new CustomerItemViewModel(customer);
            Customers.Add(customerItem);
            SelectedCustomer = customerItem;
        }

        internal void MoveNavigation()
        {
            NavigationColumn = NavigationColumn == 0 ? 2 : 0;
        }
    }
}
