using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PuzzleShop.Api.Dtos.Images;
// ReSharper disable All

namespace PuzzleShop.Api.Dtos.Puzzles
{
    public class PuzzleForCreationDto
    {
        [Required]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool IsWcaPuzzle { get; set; }
        [Required]
        public long ManufacturerId { get; set; }
        [Required]
        public long PuzzleTypeId { get; set; }
        [Required]
        public long ColorId { get; set; }
        [Required]
        public long DifficultyLevelId { get; set; }
        [Required]
        public long MaterialTypeId { get; set; }
        [Required]
        public List<ImageDto> Images { get; set; } = new List<ImageDto>();
    }
}