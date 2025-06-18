using BikeRepairShop.API.Contexts;
using BikeRepairShop.API.Helpers;
using BikeRepairShop.API.Models;
using BikeRepairShop.API.Models.Dtos;

namespace BikeRepairShop.API.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int id);
        Task AddBookingAsync(BookingCreateDto booking);
        Task UpdateBookingAsync(Booking booking);
        Task DeleteBookingAsync(int id);
    }

    public class BookingService : IBookingService
    {
        private readonly BookingHandler _bookingHandler;

        public BookingService(BookingHandler bookingHandler)
        {
            _bookingHandler = bookingHandler;
        }

        public Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return _bookingHandler.GetAllBookingsAsync();
        }

        public Task<Booking> GetBookingByIdAsync(int id)
        {
            return _bookingHandler.GetBookingAsync(id);
        }

        public Task AddBookingAsync(BookingCreateDto booking)
        {
            if (booking.RepairOrders == null || !booking.RepairOrders.Any())// Atleast there should be one order with service type
            {
                throw new ArgumentException("Atleast one order should be here");
            }

            if (booking.RepairOrders.Any(repairOrder => !Enum.IsDefined(typeof(ServiceType), repairOrder.ServiceType)))
            {
                throw new ArgumentException("Cannot offer this service");
            }

            return _bookingHandler.AddBookingAsync(booking);
        }

        public Task UpdateBookingAsync(Booking booking)
        {
            return _bookingHandler.UpdateBookingAsync(booking);
        }

        public Task DeleteBookingAsync(int id)
        {
            return _bookingHandler.DeleteBookingAsync(id);
        }
    }
}
