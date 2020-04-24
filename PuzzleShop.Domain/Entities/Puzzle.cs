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
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public bool IsMagnetic { get; set; }
        public double Weight { get; set; }
        public DateTimeOffset DateWhenAdded { get; set; }
        public long ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public long PuzzleTypeId { get; set; }
        public virtual PuzzleType PuzzleType { get; set; }
        public long ColorId { get; set; }
        public virtual Color Color { get; set; }
        public virtual MaterialType MaterialType { get; set; }
        public long MaterialTypeId { get; set; }
        public double? Rating { get; set; }
        public uint AvailableInStock { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}