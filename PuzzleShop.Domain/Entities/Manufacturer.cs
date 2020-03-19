using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

// ReSharper disable All

#nullable enable
namespace PuzzleShop.Domain.Entities
{
    public class Manufacturer : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Puzzle> Puzzles { get; private set; } = new List<Puzzle>();
    }
}