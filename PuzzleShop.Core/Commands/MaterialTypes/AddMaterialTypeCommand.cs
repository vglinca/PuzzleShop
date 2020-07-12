using MediatR;
using PuzzleShop.Core.Dtos.MaterialTypes;

namespace PuzzleShop.Core.Commands.MaterialTypes
{
    public class AddMaterialTypeCommand : IRequest<MaterialTypeDto>
    {
        public string Title { get; set; }
    }
}