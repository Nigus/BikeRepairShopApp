﻿using BikeRepairShop.API.Helpers;

namespace BikeRepairShop.API.Models.Dtos
{
    public class RepairOrderCreateDto
    {
        public int BikeBrandId { get; set; }
        public string BikeBrandName { get; set; } = string.Empty;
        public ServiceType ServiceType { get; set; }
    }
}
