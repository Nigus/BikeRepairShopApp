using BikeRepairShop.API.Helpers;

namespace BikeRepairShop.API.Models
{
    public class BikeBrand
    {
        public int Id { get; set; }
        public string BikeName { get; set; }
        public string Model { get; set; }
        public string BikeDescription { get; set; } = string.Empty;
        public BikeType BikeType { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
