using MediatR;

namespace PuzzleShop.Core.Commands.Manufacturers
{
    public class DeleteManufacturerCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}