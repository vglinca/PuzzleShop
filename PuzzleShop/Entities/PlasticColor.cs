// ReSharper disable All

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Entities
{
    public class PlasticColor : BaseEntity
    {
        [Required]
        [MaxLength(25)]
        public string Color { get; set; }

        public ICollection<Puzzle> Puzzles { get; set; } = new List<Puzzle>();
    }
}