using MediatR;
using PuzzleShop.Core.Dtos.Colors;

namespace PuzzleShop.Core.Queries.Colors
{
    public class GetSingleColorQuery : IRequest<ColorDto>
    {
        public long Id { get; set; }
    }
}