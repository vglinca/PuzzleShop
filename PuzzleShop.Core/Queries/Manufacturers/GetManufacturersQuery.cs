using System.Collections.Generic;
using MediatR;
using PuzzleShop.Core.Dtos.Manufacturers;

namespace PuzzleShop.Core.Queries.Manufacturers
{
    public class GetManufacturersQuery : IRequest<IEnumerable<ManufacturerDto>>
    {
    }
}