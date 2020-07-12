using MediatR;
using PuzzleShop.Core.Dtos.Manufacturers;

namespace PuzzleShop.Core.Commands.Manufacturers
{
    public class AddManufacturerCommand : IRequest<ManufacturerDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}