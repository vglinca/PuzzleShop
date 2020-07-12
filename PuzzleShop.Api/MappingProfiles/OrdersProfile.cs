using AutoMapper;
using PuzzleShop.Api.Models.Orders;
using PuzzleShop.Core.Dtos.Orders;

namespace PuzzleShop.Api.MappingProfiles
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<OrderTableRowDto, OrderTableModel>();
            CreateMap<OrderDto, OrderModel>();
        }
    }
}