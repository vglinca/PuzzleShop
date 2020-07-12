using MediatR;
using PuzzleShop.Core.Dtos.PuzzleTypes;

namespace PuzzleShop.Core.Commands.PuzzleTypes
{
    public class AddPuzzleTypeCommand : IRequest<PuzzleTypeDto>
    {
        public string Title { get; set; }
        public bool IsRubicsCube { get; set; }
        public bool IsWca { get; set; }
        public long DifficultyLevelId { get; set; }
    }
}