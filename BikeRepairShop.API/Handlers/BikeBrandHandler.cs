using AutoMapper;
using BikeRepairShop.API.Data;
using BikeRepairShop.API.Models;
using BikeRepairShop.API.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BikeRepairShop.API.Contexts
{
    public class BikeBrandHandler
    {
        private readonly CustomDbContext _context;
        private readonly IMapper _mapper;
        public BikeBrandHandler(CustomDbContext context, IMapper mapper)
        {
           _context = context; 
            _mapper = mapper;
        }

        public async Task<List<BikeBrand>> BikeBrandsAsync()
        {
            return await _context.BikeBrand.ToListAsync();
        }
        public async Task AddBikeBrand(BikeBrandDto dto)
        {
            var brand = _mapper.Map<BikeBrand>(dto);

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
