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
        private Customer? _selectedCustomer;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
        }

        public ObservableCollection<Customer> Customers { get; } = new();
        public Customer? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
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
                Customers.Add(customer);
            }
        }

        internal void Add()
        {
            var customer = new Customer { FirstName = "New" };
            Customers.Add(customer);
            SelectedCustomer = customer;
        }
    }
}
