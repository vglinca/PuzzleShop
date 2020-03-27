using PuzzleShop.Core.Dtos.Puzzles;

namespace PuzzleShop.Core.Dtos.OrderItems
{
    public class OrderItemDto
    {
        public long Id { get; set; }
        public decimal Cost { get; set; }
        public PuzzleDto Puzzle { get; set; }
    }
}