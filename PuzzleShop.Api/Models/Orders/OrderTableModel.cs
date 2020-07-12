using System;

namespace PuzzleShop.Api.Models.Orders
{
    public class OrderTableModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
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
        public string OrderStatusTitle { get; set; }
        public long OrderStatusId { get; set; }
    }
}