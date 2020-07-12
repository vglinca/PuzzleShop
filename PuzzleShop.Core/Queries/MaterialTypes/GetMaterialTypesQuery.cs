using System.Collections.Generic;
using MediatR;
using PuzzleShop.Core.Dtos.MaterialTypes;

namespace PuzzleShop.Core.Queries.MaterialTypes
{
    public class GetMaterialTypesQuery : IRequest<IEnumerable<MaterialTypeDto>>
    {
    }
}