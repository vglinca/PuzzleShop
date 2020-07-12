using MediatR;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.Commands.Orders
{
    public class ChangeOrderStatusCommand : IRequest<Unit>
    {
        public long OrderId { get; set; }
        public OrderStatusId OrderStatusId { get; set; }
    }
}