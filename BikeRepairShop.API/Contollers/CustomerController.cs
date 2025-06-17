using BikeRepairShop.API.Contexts;
using BikeRepairShop.API.Models;
using BikeRepairShop.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeRepairShop.API.Contollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomerService _customerService;
        public ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;   
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync()
        {
            try
            {
                var customers = await _customerService.GetAllCustomerAsync();
                return Ok(customers); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetCustomerById(int Id)
        {
            try
            {
                return Ok(await _customerService.GetCustomerById(Id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddCusomter([FromBody] Customer customer)
        {
            try
            {
                await _customerService.AddCustomer(customer);
                return Ok(customer);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);   
                return BadRequest(ex.Message);
            }
        }
    }
}
