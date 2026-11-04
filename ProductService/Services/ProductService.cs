using Microsoft.Extensions.Caching.Hybrid;

namespace ProductService.Services
{
    public class ProductService(ILogger<ProductService>logger,HybridCache cache)
    {
        public async Task<List<Product>> GetAllProductsAsync(CancellationToken ct)
        {
            
            var products=await cache.GetOrCreateAsync("products", async (ct) =>
            {
                logger.LogInformation("get all products from the db");
                List<Product> products = new();
                products.Add(new Product(1, "soda", 2.99m, 10));
                products.Add(new Product(2, "cake", 3.99m, 11));
                products.Add(new Product(3, "chocolate", 4.99m, 12));
                products.Add(new Product(4, "cheese", 5.99m, 13));
                return products;
            });
            return products;
        }
        public async Task<Product> GetProductByIdAsync(int Id, CancellationToken ct)
        {
            logger.LogInformation("get product with the Id {Id} from the db", Id);
            string cacheKey = $"product:{Id}";
            var product = await cache.GetOrCreateAsync(cacheKey, async (ct) =>
            {

                return new Product(Id, "orange juice", 1.99m, 100);
            });
            return product;
        }
    }
}
