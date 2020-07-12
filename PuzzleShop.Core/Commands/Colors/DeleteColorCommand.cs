using MediatR;

namespace PuzzleShop.Core.Commands.Colors
{
    public class DeleteColorCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}