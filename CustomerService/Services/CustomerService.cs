using Microsoft.Extensions.Caching.Hybrid;
using System.Runtime.InteropServices.Marshalling;

namespace CustomerService.Services
{
    public class CustomerService(ILogger<CustomerService> logger,HybridCache cache)
    {
        public async Task<List<Customer>> GetAllCustomersAsync(CancellationToken ct)
        {
            var customers = await cache.GetOrCreateAsync("customers", async (ct) =>
            {
                logger.LogInformation("get all customers from the db");
                List<Customer> customers = new();
                customers.Add(new Customer(1, "abood",  23));
                customers.Add(new Customer(2, "hamood",  20));
                customers.Add(new Customer(3, "mutaz",  20));
                return customers;
            });
            return customers;
        }
        public async Task<Customer> GetCustomerByIdAsync(int Id, CancellationToken ct)
        {
            logger.LogInformation("get customer with the Id {Id} from the db", Id);
            string cacheKey = $"customer:{Id}";
            var customer = await cache.GetOrCreateAsync(cacheKey, async (ct) =>
            {
            
                return new Customer(Id, "new customer",25);
            });
            return customer;
        }
    }
}
