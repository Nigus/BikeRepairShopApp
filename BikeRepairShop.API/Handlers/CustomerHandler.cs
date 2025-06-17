using BikeRepairShop.API.Data;
using BikeRepairShop.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeRepairShop.API.Contexts
{
    public class CustomerHandler
    {
        private readonly CustomDbContext _customDbContext;
        public CustomerHandler(CustomDbContext customDbContext)
        {
            _customDbContext = customDbContext;
        }

       public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
       {
            return await _customDbContext.Customers.ToListAsync();
       }

        public async Task AddCustomer(Customer customer)
        {
            _customDbContext.Add(customer);
            await _customDbContext.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            var customer = await _customDbContext.Customers.FirstOrDefaultAsync(b => b.Id == customerId);
            if (customer == null)
                throw new Exception($"Customer not found with Id {customerId}");
            return customer;
        }
    }
}
