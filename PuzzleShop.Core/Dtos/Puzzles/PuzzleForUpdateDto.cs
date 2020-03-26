using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PuzzleShop.Core.Dtos.Images;

// ReSharper disable All

namespace PuzzleShop.Core.Dtos.Puzzles
{
    public class PuzzleForUpdateDto
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(1000, ErrorMessage = "Description should not have more than 1000 characters.")]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
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

        public List<ImageDto> Images { get; set; } = new List<ImageDto>();
    }
}