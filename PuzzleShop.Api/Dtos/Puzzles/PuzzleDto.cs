using System.Collections.Generic;
using PuzzleShop.Domain.Entities;
// ReSharper disable All

namespace PuzzleShop.Api.Dtos.Puzzles
{
    public class PuzzleDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsWcaPuzzle { get; set; }
        public double Weight { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public PuzzleType PuzzleType { get; set; }
        public Color Color { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public MaterialType MaterialType { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
    }
}