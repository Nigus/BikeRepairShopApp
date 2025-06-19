using AutoMapper;
using BikeRepairShop.API.Data;
using BikeRepairShop.API.Models;
using BikeRepairShop.API.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BikeRepairShop.API.Contexts
{
    public class CustomerHandler
    {
        private readonly CustomDbContext _customDbContext;
        private readonly IMapper _mapper;
        public CustomerHandler(CustomDbContext customDbContext, IMapper mapper)
        {
            _customDbContext = customDbContext;
            _mapper = mapper;
        }

       public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
       {
            return await _customDbContext.Customers.ToListAsync();
       }

        public async Task AddCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
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
