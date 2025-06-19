using BikeRepairShop.API.Helpers;

namespace BikeRepairShop.API.Models.Dtos
{
    public class RepairOrderDto
    {
        public int Id { get; set; }
        public int BikeBrandId { get; set; }
        public int BikeBrandName {  get; set; }
        public ServiceType ServiceType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
