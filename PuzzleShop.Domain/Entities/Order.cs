using System;
using System.Collections.Generic;

// ReSharper disable All

namespace PuzzleShop.Domain.Entities
{
    public class Order : BaseEntity
    {
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public int TotalItems { get; set; }
        public decimal TotalCost { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}