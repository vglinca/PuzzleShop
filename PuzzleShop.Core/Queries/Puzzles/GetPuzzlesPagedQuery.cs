using MediatR;
using PuzzleShop.Core.Dtos.Puzzles;
using PuzzleShop.Core.PaginationModels;

namespace PuzzleShop.Core.Queries.Puzzles
{
    public class GetPuzzlesPagedQuery : IRequest<PagedResponse<PuzzleTableRowDto>>
    {
        public PagedRequest PagedRequest { get; set; }
    }
}