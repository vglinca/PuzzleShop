using AutoMapper;
using PuzzleShop.Core.Dtos.Orders;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Core.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderStatus, OrderStatusDto>();
        }
    }
}