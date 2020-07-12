using MediatR;
using PuzzleShop.Core.Dtos.MaterialTypes;

namespace PuzzleShop.Core.Queries.MaterialTypes
{
    public class GetMaterialTypeQuery : IRequest<MaterialTypeDto>
    {
        public long Id { get; set; }
    }
}