using BikeRepairShop.API.Contexts;
using BikeRepairShop.API.Models;

namespace BikeRepairShop.API.Services
{
    public interface ICustomerService
    {
        Task AddCustomer(Customer customer);
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

        public Task AddCustomer(Customer customer)
        {
            return _customerHandler.AddCustomer(customer);
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
