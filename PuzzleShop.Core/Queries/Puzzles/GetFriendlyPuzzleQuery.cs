using MediatR;
using PuzzleShop.Core.Dtos.Puzzles;

namespace PuzzleShop.Core.Queries.Puzzles
{
    public class GetFriendlyPuzzleQuery : IRequest<PuzzleTableRowDto>
    {
        public long Id { get; set; }
    }
}