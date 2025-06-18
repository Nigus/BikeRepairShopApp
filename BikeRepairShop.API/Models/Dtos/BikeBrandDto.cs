using BikeRepairShop.API.Helpers;

namespace BikeRepairShop.API.Models.Dtos
{
    public class BikeBrandDto
    {
        public int Id { get; set; }
        public string BikeName { get; set; }
        public string Model { get; set; }
        public string BikeDescription { get; set; } = string.Empty;
        public BikeType BikeType { get; set; }
    }
}
