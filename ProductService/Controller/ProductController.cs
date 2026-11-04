using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controller
{
    [ApiController]
    [Route("products")]
    public class ProductController(global::ProductService.Services.ProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProducts(CancellationToken ct)
        {
            var products = await productService.GetAllProductsAsync(ct);
            return Ok(products);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetProductById(int id,CancellationToken ct)
        {
            var product =await productService.GetProductByIdAsync(id, ct);
            return Ok(product);
        }
    }
}
