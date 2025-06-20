using Microsoft.EntityFrameworkCore;

namespace BikeRepairShop.API.Models
{
    [Index(nameof(Email), IsUnique=true)]
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public ICollection<BikeRepairBooking> Bookings { get; set; } = new List<BikeRepairBooking>();
    }
}
