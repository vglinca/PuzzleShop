using AutoMapper;
using PuzzleShop.Core.Dtos.OrderItems;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.Profiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItemForCreationDto, OrderItem>();
            CreateMap<OrderItem, OrderItemDto>();
        }   
    }
}