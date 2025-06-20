using AutoMapper;
using BikeRepairShop.API.Models;
using BikeRepairShop.API.Models.Dtos;
namespace BikeRepairShop.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BikeRepairBooking, BikeRepairBookingDto>()
                .ForMember(book => book.RepairOrders, opt => opt.MapFrom(src => src.RepairOrders));

            CreateMap<BikeRepairBookingDto, BikeRepairBooking>()
                .ForMember(book => book.RepairOrders, opt => opt.Ignore());


            CreateMap<BikeRepairBookingCreateDto, BikeRepairBooking>()
                .ForMember(book => book.RepairOrders, opt => opt.MapFrom(src => src.RepairOrders));

            CreateMap<RepairOrderDto, RepairOrder>();

            CreateMap<RepairOrderCreateDto, RepairOrder>();
            CreateMap<RepairOrder, RepairOrderDto>();
            CreateMap<BikeBrandDto, BikeBrand>();
            CreateMap<BikeBrand, BikeBrandDto>();
            CreateMap<BikeBrandCreateDto, BikeBrand>();
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();
        }
    }
}
