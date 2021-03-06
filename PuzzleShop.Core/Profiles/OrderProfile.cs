﻿using AutoMapper;
using PuzzleShop.Core.Dtos.Customers;
using PuzzleShop.Core.Dtos.Orders;
using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Core.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.OrderStatusId,
                    opt => opt.MapFrom(
                        src => (long) src.OrderStatusId));
            CreateMap<Order, OrderTableRowDto>()
                .ForMember(dest => dest.OrderStatusId,
                    opt => opt.MapFrom(
                        src => (long) src.OrderStatusId));
            CreateMap<OrderStatus, OrderStatusDto>();
            CreateMap<CustomerInfoForOrderDto, Order>();
        }
    }
}