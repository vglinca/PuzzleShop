using System;
using System.Collections;
using System.Collections.Generic;
using PuzzleShop.Core.Dtos.OrderItems;
using PuzzleShop.Core.Dtos.Users;
// ReSharper disable All

namespace PuzzleShop.Core.Dtos.Orders
{
    public class OrderDto
    {
        public long Id { get; set; }
        public UserDto User { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public int TotalItems { get; set; }
        public decimal TotalCost { get; set; }
        public string OrderStatus { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }

        public OrderDto()
        {
            OrderItems = new List<OrderItemDto>();
        }
    }
}