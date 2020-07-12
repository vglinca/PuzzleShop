// ReSharper disable All

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PuzzleShop.Core.Domain;
using PuzzleShop.Core.Entities;

namespace PuzzleShop.Core.Entities
{
    public class Color : BaseEntity
    {
        public string Title { get; set; }
        public virtual ICollection<Puzzle> Puzzles { get; private set; }
    }
}