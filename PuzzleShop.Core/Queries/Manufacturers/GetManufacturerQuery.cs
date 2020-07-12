using MediatR;
using PuzzleShop.Core.Dtos.Manufacturers;

namespace PuzzleShop.Core.Queries.Manufacturers
{
    public class GetManufacturerQuery : IRequest<ManufacturerDto>
    {
        public long Id { get; set; }
    }
}