using BikeRepairShop.API.Data;
using BikeRepairShop.API.Models;
using BikeRepairShop.API.Models.Dtos;
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
            return await _context.BikeBrand.ToListAsync();
        }
        public async Task AddBikeBrand(BikeBrandDto dto)
        {
            var brand = new BikeBrand
            {
                BikeName = dto.BikeName,
                BikeDescription = dto.BikeDescription,
                Model = dto.Model,
                BikeType = dto.BikeType,
            };

            _context.BikeBrand.Add(brand);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBikeBrand(BikeBrand bikeBrand)
        {
            //TODO write a code to check if the bike brand is allready in the database
            _context.BikeBrand.Remove(bikeBrand);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<BikeBrand>> GetAllBikeBrand()
        {
            return await _context.BikeBrand.ToListAsync();
        }
    }
}
