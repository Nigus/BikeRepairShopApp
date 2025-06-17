using BikeRepairShop.API.Data;
using BikeRepairShop.API.Models;

namespace BikeRepairShop.API.Contexts
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    public class BookingHandler
    {
        private readonly CustomDbContext _customDbContext;

        public BookingHandler(CustomDbContext customDbContext)
        {
            _customDbContext = customDbContext;
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

        public async Task AddBookingAsync(Booking booking)
        {
            _customDbContext.Bookings.Add(booking);
            await _customDbContext.SaveChangesAsync();
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            var _booking = _customDbContext.Bookings.FirstOrDefaultAsync(b => b.Id == booking.Id);
            if (_booking == null)
                throw new Exception(nameof(Booking));

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
