using System.Threading.Tasks;
using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace shopapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        /// <summary>
        /// Get details of the current request customer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("details")]
        public async Task<IActionResult> Get()
        {
            var customerDetails = await _customerService.GetCustomerDetails();
            return Ok(customerDetails);
        }

        /// <summary>
        /// Registers a customer
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(CustomerRegistrationRequest request)
        {
            await _customerService.RegisterCustomer(request);
            return NoContent();
        }
    }
}
