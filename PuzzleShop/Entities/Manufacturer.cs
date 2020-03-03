using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
// ReSharper disable All

#nullable enable
namespace PuzzleShop.Entities
{
    public class Manufacturer : BaseEntity
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [MaxLength(1500)]
        public string? Description { get; set; }

        public ICollection<Puzzle> Puzzles { get; set; } = new List<Puzzle>();
    }
}