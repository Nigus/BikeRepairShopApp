using BikeRepairShop.API.Models.Dtos;
using BikeRepairShop.API.Models;

namespace BikeRepairShop.API.Services
{
    public interface IBikeRepairBookingService
    {
        Task<IEnumerable<BikeRepairBooking>> GetAllBookingsAsync();
        Task<BikeRepairBooking> GetBookingByIdAsync(int id);
        Task AddBookingAsync(BikeRepairBookingCreateDto booking);
        Task UpdateBookingAsync(BikeRepairBookingDto booking);
        Task DeleteBookingAsync(int id);
    }
}
