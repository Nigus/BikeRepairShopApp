using BikeRepairShop.API.Data;
using BikeRepairShop.API.Models;

namespace BikeRepairShop.API.Contexts
{
    using AutoMapper;
    using BikeRepairShop.API.Models.Dtos;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    public class BookingHandler
    {
        private readonly CustomDbContext _customDbContext;
        private readonly IMapper _mapper;

        public BookingHandler(CustomDbContext customDbContext, IMapper mapper)
        {
            _customDbContext = customDbContext;
            _mapper = mapper;
        }
        public async Task<Booking> GetBookingAsync(int id)
        {
            var booking = await _customDbContext.Bookings.FirstOrDefaultAsync(b => b.Id == id);
            if (booking == null)
                throw new Exception($"Booking with id {id} not found");

            return booking;
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _customDbContext.Bookings.ToListAsync(); 
        }

        public async Task AddBookingAsync(BookingCreateDto bookingDto)
        {
            if (bookingDto.RepairOrders == null || !bookingDto.RepairOrders.Any())
            {
                throw new Exception("At least one repair order is required.");
            }
          
            var booking = _mapper.Map<Booking>(bookingDto);

            foreach(var order in bookingDto.RepairOrders)
            {
                order.CreatedDate = DateTime.Now;
            }

            _customDbContext.Bookings.Add(booking);
            await _customDbContext.SaveChangesAsync();
        }

        public async Task UpdateBookingAsync(BookingDto bookingDto)
        {
            var _booking = _customDbContext.Bookings.FirstOrDefaultAsync(b => b.Id == bookingDto.Id);
            if (_booking == null)
                throw new Exception(nameof(Booking));
            
            var booking = _mapper.Map<Booking>(bookingDto);

            _customDbContext.Bookings.Update(booking);
            await _customDbContext.SaveChangesAsync();
        }

        public async Task DeleteBookingAsync(int bookingId)
        {
            var booking = await _customDbContext.Bookings.FirstOrDefaultAsync(b => b.Id == bookingId);
            if (booking == null)
                throw new Exception($"Booking with id {bookingId} not found");

            _customDbContext.Bookings.Remove(booking);
            await _customDbContext.SaveChangesAsync();
        }
    }
}
