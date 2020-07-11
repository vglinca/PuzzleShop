using System;
using System.Collections.Generic;
using PuzzleShop.Core.Entities;
using PuzzleShop.Core.Entities.Auth;
// ReSharper disable All

namespace PuzzleShop.Core.Entities
{
    public class Order : BaseEntity
    {
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public string ContactEmail { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public int TotalItems { get; set; }
        public decimal TotalCost { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public string OrderStatusTitle { get; set; }
        public OrderStatusId OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
    }
}