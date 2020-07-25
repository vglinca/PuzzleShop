using System.Collections.Generic;
using MediatR;
using PuzzleShop.Core.Dtos.Orders;

namespace PuzzleShop.Core.Queries.UserOrders
{
    public class GetUserOrdersQuery : IRequest<IEnumerable<OrderDto>>
    {
        public long UserId { get; set; }
    }
}