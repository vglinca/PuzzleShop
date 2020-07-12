using MediatR;

namespace PuzzleShop.Core.Commands.PuzzleTypes
{
    public class DeletePuzzleTypeCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}