using BikeRepairShop.API.Contexts;
using BikeRepairShop.API.Models;
using BikeRepairShop.API.Models.Dtos;

namespace BikeRepairShop.API.Services
{
    public interface ICustomerService
    {
        Task AddCustomer(CustomerCreateDto customer);
        Task<IEnumerable<Customer>> GetAllCustomerAsync();
        Task<Customer> GetCustomerById(int customerId);
    }
    public class CustomerService : ICustomerService
    {
        private readonly CustomerHandler _customerHandler;
        public CustomerService(CustomerHandler customerHandler)
        {
            _customerHandler = customerHandler;
        }

        public Task AddCustomer(CustomerCreateDto customerDto)
        {
            return _customerHandler.AddCustomer(customerDto);
        }

        public Task<IEnumerable<Customer>> GetAllCustomerAsync()
        {
            return _customerHandler.GetAllCustomerAsync();
        }

        public Task<Customer> GetCustomerById(int customerId)
        {
            return _customerHandler.GetCustomerById(customerId);
        }
    }
}
