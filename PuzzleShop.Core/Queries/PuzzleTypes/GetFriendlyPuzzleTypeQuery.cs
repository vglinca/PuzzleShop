using MediatR;
using PuzzleShop.Core.Dtos.PuzzleTypes;

namespace PuzzleShop.Core.Queries.PuzzleTypes
{
    public class GetFriendlyPuzzleTypeQuery : IRequest<PuzzleTypeTableRowDto>
    {
        public long Id { get; set; }
    }
}