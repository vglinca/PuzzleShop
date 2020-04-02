// ReSharper disable All

using PuzzleShop.Domain.Entities;

namespace PuzzleShop.Core.Dtos.DifficultyLevels
{
    public class DifficultyLevelDto
    {
        public DifficultyLevelId DifficultyLevelId { get; set; }
        public string Title { get; set; }
    }
}