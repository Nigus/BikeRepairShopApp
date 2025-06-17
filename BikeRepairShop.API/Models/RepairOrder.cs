using BikeRepairShop.API.Helpers;

namespace BikeRepairShop.API.Models
{
    public class RepairOrder
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }

        public int BikeBrandId { get; set; }
        public BikeBrand BikeBrand { get; set; }

        public ServiceType ServiceType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
