using MediatR;
using PuzzleShop.Core.Dtos.Orders;

namespace PuzzleShop.Core.Queries.Orders
{
    public class GetOrderQuery : IRequest<OrderDto>
    {
        public long OrderId { get; set; }
    }
}