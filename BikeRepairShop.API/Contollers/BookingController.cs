using BikeRepairShop.API.Contexts;
using BikeRepairShop.API.Models;
using BikeRepairShop.API.Models.Dtos;
using BikeRepairShop.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeRepairShop.API.Contollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly ILogger<BookingController> _logger;

        public BookingController(IBookingService bookingService, ILogger<BookingController> logger)
        {
            _bookingService = bookingService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            try
            {
                await _bookingService.GetBookingByIdAsync(id);
                return Ok(new { bookingId = id });
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            try
            {
                var bookings = await _bookingService.GetAllBookingsAsync();
                return Ok(bookings);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking([FromBody] BookingCreateDto bookingDto)
        {
            try
            {
                await _bookingService.AddBookingAsync(bookingDto);
                return Ok(nameof(Booking));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBooking([FromBody] Booking booking)
        {
            try
            {
                await _bookingService.UpdateBookingAsync(booking);
                return Ok(nameof(Booking));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            try
            {
                await _bookingService.DeleteBookingAsync(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
