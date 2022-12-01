using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffe.Model;

namespace WiredBrainCoffe.Data
{
    public interface IProductDataProvider
    {
        Task<IEnumerable<Product>?> GetAllAsync();
    }
    
    public class ProductDataProvider : IProductDataProvider
    {
        public async Task<IEnumerable<Product>?> GetAllAsync()
        {
            await Task.Delay(100); // simulate server delay
            return new List<Product>
            {
                new() {Name = "Coffee", Description = "Black hot drink"},
                new() {Name = "Espresso", Description = "Very strong coffe without milk"},
                new() {Name = "Cappuccino", Description = "Espresso, hot milk and a steamed milk foam"}
            };
        }
    }
}
