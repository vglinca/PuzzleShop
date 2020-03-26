// ReSharper disable All

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Domain.Entities
{
    public class Color : BaseEntity
    {
        public string Title { get; set; }
        public virtual ICollection<Puzzle> Puzzles { get; private set; }
    }
}