using MediatR;
using PuzzleShop.Core.Dtos.Orders;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.Queries.UserOrders
{
    public class GetUserOrderByStatusQuery : IRequest<OrderDto>
    {
        public long UserId { get; set; }
        public OrderStatusId OrderStatusId { get; set; }
    }
}