using System.Collections.Generic;
// ReSharper disable All

namespace PuzzleShop.Domain.Entities
{
    public class MaterialType : BaseEntity
    {
        public string Title { get; set; }
        public ICollection<Puzzle> Puzzles { get; set; } = new List<Puzzle>();
    }
}