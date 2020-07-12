using MediatR;
using PuzzleShop.Core.Dtos.Puzzles;

namespace PuzzleShop.Core.Queries.Puzzles
{
    public class GetPuzzleQuery : IRequest<PuzzleDto>
    {
        public long Id { get; set; }
    }
}