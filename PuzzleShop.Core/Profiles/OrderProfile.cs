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
                        src => src.OrderStatus.OrderStatusId.ToString()))
                .ForMember(dest => dest.OrderStatusId,
                    opt => opt.MapFrom(
                        src => (long) src.OrderStatusId));
            CreateMap<Order, OrderTableRowDto>()
                .ForMember(dest => dest.OrderStatus,
                    opt => opt.MapFrom(
                        src => src.OrderStatus.OrderStatusId.ToString()))
                .ForMember(dest => dest.OrderStatusId,
                    opt => opt.MapFrom(
                        src => (long) src.OrderStatusId));
            CreateMap<OrderStatus, OrderStatusDto>();
        }
    }
}