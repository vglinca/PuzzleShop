using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PuzzleShop.Domain.Entities;

// ReSharper disable All

namespace PuzzleShop.Domain.Entities
{
    public class DifficultyLevel : BaseEntity
    {
        public DifficultyLevelId DifficultyLevelId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Puzzle> Puzzles { get; private set; }
    }
}