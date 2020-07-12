using MediatR;

namespace PuzzleShop.Core.Commands.Colors
{
    public class UpdateColorCommand : IRequest<Unit>
    {
        public long Id { get; set; }
        public string Title { get; set; }
    }
}