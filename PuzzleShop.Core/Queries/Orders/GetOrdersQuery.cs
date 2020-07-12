using System.Collections.Generic;
using MediatR;
using PuzzleShop.Core.Dtos.Orders;

namespace PuzzleShop.Core.Queries.Orders
{
    public class GetOrdersQuery : IRequest<IEnumerable<OrderDto>>
    {
        public long UserId { get; set; }
    }
}