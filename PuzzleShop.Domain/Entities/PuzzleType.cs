// ReSharper disable All

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Domain.Entities
{
    public class PuzzleType : BaseEntity
    {
        public string TypeName { get; set; }
        public ICollection<Puzzle> Puzzles { get; set; } = new List<Puzzle>();
    }
}