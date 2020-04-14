using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Core.Dtos.OrderItems
{
    public class OrderItemForCreationDto
    {
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public long PuzzleId { get; set; }
        public int TotalIdenticalItems { get; set; }
    }
}