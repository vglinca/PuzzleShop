using MediatR;

namespace PuzzleShop.Core.Commands.Puzzles
{
    public class DeletePuzzleCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}