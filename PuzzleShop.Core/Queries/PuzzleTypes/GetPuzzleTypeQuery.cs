using MediatR;
using PuzzleShop.Core.Dtos.PuzzleTypes;

namespace PuzzleShop.Core.Queries.PuzzleTypes
{
    public class GetPuzzleTypeQuery : IRequest<PuzzleTypeDto>
    {
        public long Id { get; set; }
    }
}