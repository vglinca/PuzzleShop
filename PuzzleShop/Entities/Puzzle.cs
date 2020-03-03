using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// ReSharper disable All

namespace PuzzleShop.Entities
{
    public class Puzzle : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool IsWcaPuzzle { get; set; }
        public double Weight { get; set; }
        public DateTimeOffset DateWhenAdded { get; set; }
        public long ManufacturerId { get; set; }
        
        [ForeignKey(nameof(ManufacturerId))]
        public Manufacturer Manufacturer { get; set; }
        
        public long PuzzleTypeId { get; set; }
        
        [ForeignKey(nameof(PuzzleTypeId))]
        public PuzzleType PuzzleType { get; set; }
        
        public long PlasticColorId { get; set; }
        
        [ForeignKey(nameof(PlasticColorId))]
        public PlasticColor PlasticColor { get; set; }
        
        public long DifficultyLevelId { get; set; }
        
        [ForeignKey(nameof(DifficultyLevelId))]
        public DifficultyLevel  DifficultyLevel { get; set; }
        
        public ICollection<Image> Images { get; set; } = new List<Image>();
    }
}