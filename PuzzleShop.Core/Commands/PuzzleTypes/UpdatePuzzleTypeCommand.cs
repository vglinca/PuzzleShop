using MediatR;

namespace PuzzleShop.Core.Commands.PuzzleTypes
{
    public class UpdatePuzzleTypeCommand : IRequest<Unit>
    {
        public long PuzzleTypeId { get; set; }
        public string Title { get; set; }
        public bool IsRubicsCube { get; set; }
        public bool IsWca { get; set; }
        public long DifficultyLevelId { get; set; }
    }
}