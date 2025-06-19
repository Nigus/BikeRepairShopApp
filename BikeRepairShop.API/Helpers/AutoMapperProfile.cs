using AutoMapper;
using BikeRepairShop.API.Models;
using BikeRepairShop.API.Models.Dtos;
namespace BikeRepairShop.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Booking, BookingDto>()
                .ForMember(book => book.RepairOrders, opt => opt.MapFrom(src => src.RepairOrders));

            CreateMap<BookingDto, Booking>()
                .ForMember(book => book.RepairOrders, opt => opt.Ignore());


            CreateMap<BookingCreateDto, Booking>()
                .ForMember(book => book.RepairOrders, opt => opt.MapFrom(src => src.RepairOrders));

            CreateMap<RepairOrderDto, RepairOrder>();

            CreateMap<RepairOrderCreateDto, RepairOrder>();

        }
    }
}
