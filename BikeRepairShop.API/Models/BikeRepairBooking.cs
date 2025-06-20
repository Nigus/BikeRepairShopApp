using BikeRepairShop.API.Helpers;
using System.Text.Json.Serialization;

namespace BikeRepairShop.API.Models
{
    public class BikeRepairBooking
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime BookingDate { get; set; }
        public DateTime ExpectedDueDate { get; set; }
        public string? Notes { get; set; }
        [JsonIgnore]
        public ICollection<RepairOrder> RepairOrders { get; set; } = new List<RepairOrder>();
    }
}
