using System.Collections.Generic;
using PuzzleShop.Core.Domain;

// ReSharper disable All

#nullable enable
namespace PuzzleShop.Core.Entities
{
    public class Manufacturer : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Puzzle> Puzzles { get; private set; }
    }
}