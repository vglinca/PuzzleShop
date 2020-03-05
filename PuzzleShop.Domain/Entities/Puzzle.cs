using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// ReSharper disable All

namespace PuzzleShop.Domain.Entities
{
    public class Puzzle : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool IsWcaPuzzle { get; set; }
        public double Weight { get; set; }
        public DateTimeOffset DateWhenAdded { get; set; }
        public long ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public long PuzzleTypeId { get; set; }
        public PuzzleType PuzzleType { get; set; }
        public long PlasticColorId { get; set; }
        public PlasticColor PlasticColor { get; set; }
        public long DifficultyLevelId { get; set; }
        public DifficultyLevel  DifficultyLevel { get; set; }
        public ICollection<Image> Images { get; set; } = new List<Image>();
    }
}