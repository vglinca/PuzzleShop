using System;
// ReSharper disable All

namespace PuzzleShop.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public long OrderId { get; set; }
        public virtual Order Order { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public long PuzzleId { get; set; }
        public virtual Puzzle Puzzle { get; set; }
    }
}