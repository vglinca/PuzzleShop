using System.Collections.Generic;
using System.Text.Json.Serialization;
using PuzzleShop.Core.Dtos.Images;
using PuzzleShop.Domain.Entities;
// ReSharper disable All

namespace PuzzleShop.Core.Dtos.Puzzles
{
    public class PuzzleTableRowDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsMagnetic { get; set; }
        public double Weight { get; set; }
        public string Manufacturer { get; set; }
        public string PuzzleType { get; set; }
        public string Color { get; set; }
        public string MaterialType { get; set; }
        public double? Rating { get; set; }
        public List<ImageDto> Images { get; set; } = new List<ImageDto>();
    }
}