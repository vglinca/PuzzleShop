using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PuzzleShop.Domain.Entities;

// ReSharper disable All

namespace PuzzleShop.Domain.Entities
{
    public class DifficultyLevel : BaseEntity
    {
        [Required]
        public string LevelName { get; set; }

        public ICollection<Puzzle> Puzzles { get; set; } = new List<Puzzle>();
    }
}