using BikeRepairShop.API.Data;
using BikeRepairShop.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeRepairShop.API.Contexts
{
    public class BikeBrandHandler
    {
        private readonly CustomDbContext _context;

        public BikeBrandHandler(CustomDbContext context)
        {
           _context = context; 
        }

        public async Task<List<BikeBrand>> BikeBrandsAsync()
        {
            return await _context.Brands.ToListAsync();
        }
        public async Task AddBikeBrand(BikeBrand bikeBrand)
        {
            _context.Brands.Add(bikeBrand);
            await _context.SaveChangesAsync();  
        }

        public async Task DeleteBikeBrand(BikeBrand bikeBrand)
        {
            //TODO write a code to check if the bike brand is allready in the database
            _context.Brands.Remove(bikeBrand);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<BikeBrand>> GetAllBikeBrand()
        {
            return await _context.Brands.ToListAsync();
        }
    }
}
