using System.Collections.Generic;
// ReSharper disable All

namespace PuzzleShop.Domain.Entities
{
    public class OrderStatus : BaseEntity
    {
        public string Title { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}