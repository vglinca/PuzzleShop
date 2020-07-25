using MediatR;

namespace PuzzleShop.Core.Commands.UserOrders
{
    public class IncreaseOrderItemsCommand : IRequest<Unit>
    {
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public long PuzzleId { get; set; }
        public long UserId { get; set; }
    }
}