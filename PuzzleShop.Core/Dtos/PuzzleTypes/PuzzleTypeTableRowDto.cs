// ReSharper disable All

namespace PuzzleShop.Core.Dtos.PuzzleTypes
{
    public class PuzzleTypeTableRowDto
    {
        public long Id { get; set; }
        public bool IsRubicsCube { get; set; }
        public bool IsWca { get; set; }
        public string Title { get; set; }
        public string DifficultyLevel { get; set; }
    }
}