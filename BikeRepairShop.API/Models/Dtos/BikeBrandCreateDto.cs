using BikeRepairShop.API.Helpers;

namespace BikeRepairShop.API.Models.Dtos
{
    public class BikeBrandCreateDto
    {
        public string BikeName { get; set; }
        public string Model { get; set; }
        public string BikeDescription { get; set; } = string.Empty;
        public BikeType BikeType { get; set; }
    }
}
