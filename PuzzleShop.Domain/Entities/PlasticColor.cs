// ReSharper disable All

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Domain.Entities
{
    public class PlasticColor : BaseEntity
    {
        [Required]
        public string Color { get; set; }

        public ICollection<Puzzle> Puzzles { get; set; } = new List<Puzzle>();
    }
}