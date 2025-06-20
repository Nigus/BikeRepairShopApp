namespace BikeRepairShop.API.Models.Dtos
{
    public class BikeRepairBookingCreateDto
    {
        public int CustomerId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime ExpectedDueDate { get; set; }
        public string? Notes { get; set; }
        public List<RepairOrderDto> RepairOrders { get; set; } = new();
    }
}
