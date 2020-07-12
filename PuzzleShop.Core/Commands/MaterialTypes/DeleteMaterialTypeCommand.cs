using MediatR;

namespace PuzzleShop.Core.Commands.MaterialTypes
{
    public class DeleteMaterialTypeCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}