using MediatR;
using PuzzleShop.Core.Dtos.Colors;

namespace PuzzleShop.Core.Commands.Colors
{
    public class AddColorCommand : IRequest<ColorDto>
    {
        public string Title { get; set; }
    }
}