using System.Collections.Generic;
using System.Threading.Tasks;
using WiredBrainCoffe.Model;

namespace WiredBrainCoffe.Data
{
    interface ICustomerDataProvider
    {
        Task<IEnumerable<Customer>?> GetAllAsync();
    }
}