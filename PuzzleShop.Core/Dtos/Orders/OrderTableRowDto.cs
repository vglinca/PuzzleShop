using PuzzleShop.Core.Dtos.OrderItems;
using PuzzleShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleShop.Core.Dtos.Orders
{
	public class OrderTableRowDto
	{
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public int TotalItems { get; set; }
        public decimal TotalCost { get; set; }
        public string OrderStatus { get; set; }
    }
}
