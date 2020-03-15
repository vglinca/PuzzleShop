using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PuzzleShop.Domain.Entities;

// ReSharper disable All

namespace PuzzleShop.Domain.Entities
{
    public class DifficultyLevel : BaseEntity
    {
        public string Title { get; set; }
        public ICollection<Puzzle> Puzzles { get; private set; } = new List<Puzzle>();
    }
}