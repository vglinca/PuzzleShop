using System.Collections.Generic;

// ReSharper disable All

namespace PuzzleShop.Core.Entities
{
    public class DifficultyLevel : BaseEntity
    {
        public DifficultyLevelId DifficultyLevelId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<PuzzleType> PuzzlesTypes { get; private set; }
    }
}