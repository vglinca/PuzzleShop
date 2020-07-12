using System.Collections.Generic;
using MediatR;
using PuzzleShop.Core.Dtos.Puzzles;
using PuzzleShop.Core.Dtos.PuzzleTypes;

namespace PuzzleShop.Core.Queries.PuzzleTypes
{
    public class GetPuzzleTypesQuery : IRequest<IEnumerable<PuzzleTypeTableRowDto>>
    {
    }
}