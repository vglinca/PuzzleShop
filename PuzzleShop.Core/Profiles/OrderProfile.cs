using AutoMapper;
using PuzzleShop.Core.Dtos.Orders;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Core.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.OrderStatus,
                    opt => opt.MapFrom(
                        src => src.OrderStatus.OrderStatusId.ToString()));
            CreateMap<OrderStatus, OrderStatusDto>();
        }
    }
}