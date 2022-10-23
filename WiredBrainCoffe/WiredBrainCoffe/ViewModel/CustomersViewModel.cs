using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WiredBrainCoffe.Data;
using WiredBrainCoffe.Model;

namespace WiredBrainCoffe.ViewModel
{
    class CustomersViewModel
    {
        public ObservableCollection<Customer> Customers { get; } = new();
        private readonly ICustomerDataProvider _customerDataProvider;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
        }

        public Customer? SelectedCustomer { get; set; }

        public async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }

            var customers = await _customerDataProvider.GetAllAsync();

            if(customers == null)
            {
                return;
            }

            foreach (var customer in customers)
            {
                Customers.Add(customer);
            }
        }
    }
}
