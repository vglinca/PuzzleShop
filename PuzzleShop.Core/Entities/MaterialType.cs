using System.Collections.Generic;

// ReSharper disable All

namespace PuzzleShop.Core.Entities
{
    public class MaterialType : BaseEntity
    {
        public string Title { get; set; }
        public virtual ICollection<Puzzle> Puzzles { get; private set; }
    }
}