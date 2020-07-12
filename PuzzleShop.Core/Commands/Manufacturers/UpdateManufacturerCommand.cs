using MediatR;

namespace PuzzleShop.Core.Commands.Manufacturers
{
    public class UpdateManufacturerCommand : IRequest<Unit>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}