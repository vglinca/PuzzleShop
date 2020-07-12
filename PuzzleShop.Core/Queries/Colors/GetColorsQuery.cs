using System.Collections.Generic;
using MediatR;
using PuzzleShop.Core.Dtos.Colors;

namespace PuzzleShop.Core.Queries.Colors
{
    public class GetColorsQuery : IRequest<IEnumerable<ColorDto>>
    {
    }
}