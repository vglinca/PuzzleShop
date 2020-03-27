using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Core.Dtos.Orders
{
    public class OrderStatusDto
    {
        public OrderStatusId OrderStatusId { get; set; }
        public string Name { get; set; }
    }
}