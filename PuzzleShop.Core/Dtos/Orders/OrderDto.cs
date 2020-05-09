using System;
using System.Collections;
using System.Collections.Generic;
using PuzzleShop.Core.Dtos.OrderItems;
using PuzzleShop.Core.Dtos.Users;
// ReSharper disable All

namespace PuzzleShop.Core.Dtos.Orders
{
    public class OrderDto : OrderBaseDto
    {
        public List<OrderItemDto> OrderItems { get; set; }

        public OrderDto()
        {
            OrderItems = new List<OrderItemDto>();
        }
    }
}