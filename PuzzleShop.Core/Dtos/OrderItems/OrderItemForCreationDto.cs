namespace PuzzleShop.Core.Dtos.OrderItems
{
    public class OrderItemForCreationDto
    {
        public decimal Cost { get; set; }
        public long PuzzleId { get; set; }
        public int TotalIdenticalItems { get; set; }
    }
}