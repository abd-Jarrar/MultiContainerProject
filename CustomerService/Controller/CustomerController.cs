using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controller
{
    [ApiController]
    [Route("customers")]
    public class CustomerController(global::CustomerService.Services.CustomerService customerService):ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers(CancellationToken ct)
        {
            var customers = await customerService.GetAllCustomersAsync(ct);
            return Ok(customers);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCustomerById(int id, CancellationToken ct)
        {
            var customer = await customerService.GetCustomerByIdAsync(id, ct);
            return Ok(customer);
        }
    }
}
