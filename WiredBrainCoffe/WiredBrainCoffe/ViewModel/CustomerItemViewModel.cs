using WiredBrainCoffe.Model;

namespace WiredBrainCoffe.ViewModel
{
    public class CustomerItemViewModel : ViewModelBase
    {
        private readonly Customer _customer;

        public CustomerItemViewModel(Customer customer)
        {
            _customer = customer;
        }

        public int Id => _customer.Id;

        public string? FirstName
        {
            get => _customer.FirstName;
            set
            {
                _customer.FirstName = value;
                OnPropertyChange();
            }
        }

        public string? LastName
        {
            get => _customer.LastName;
            set
            {
                _customer.LastName = value;
                OnPropertyChange();
            }
        }

        public bool IsDeveloper
        {
            get => _customer.IsDeveloper;
            set
            {
                _customer.IsDeveloper = value;
                OnPropertyChange();
            }
        }
    }
}
