// ReSharper disable All

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Domain.Entities
{
    public class PuzzleType : BaseEntity
    {
        public string TypeName { get; set; }
        public bool IsRubicsCube { get; set; }
        public bool IsWca { get; set; }
        public DifficultyLevelId DifficultyLevelId { get; set; }
        public virtual DifficultyLevel DifficultyLevel { get; set; }
        public virtual ICollection<Puzzle> Puzzles { get; private set; }
    }
}