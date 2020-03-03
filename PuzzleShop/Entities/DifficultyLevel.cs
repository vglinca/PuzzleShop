using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
// ReSharper disable All

namespace PuzzleShop.Entities
{
    public class DifficultyLevel : BaseEntity
    {
        [Required]
        public string LevelName { get; set; }

        public ICollection<Puzzle> Puzzles { get; set; } = new List<Puzzle>();
    }
}