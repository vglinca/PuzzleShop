using System.Collections.Generic;

namespace PuzzleShop.Domain.Entities
{
    public class MaterialType : BaseEntity
    {
        public string Title { get; set; }
        public ICollection<Puzzle> Puzzles { get; set; } = new List<Puzzle>();
    }
}