using MediatR;
using PuzzleShop.Core.Dtos.Orders;
using PuzzleShop.Core.PaginationModels;

namespace PuzzleShop.Core.Queries.Orders
{
    public class GetPagedOrdersQuery : IRequest<PagedResponse<OrderTableRowDto>>
    {
        public PagedRequest PagedRequest { get; set; }
    }
}