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
        public bool IsWcaPuzzle { get; set; }
        [Required(ErrorMessage = "ManufacturerId is required.")]
        public long ManufacturerId { get; set; }
        [Required(ErrorMessage = "PuzzleTypeId is required.")]
        public long PuzzleTypeId { get; set; }
        [Required(ErrorMessage = "ColorId is required.")]
        public long ColorId { get; set; }
        [Required(ErrorMessage = "DifficultyLevelId is required.")]
        public long DifficultyLevelId { get; set; }
        [Required(ErrorMessage = "MaterialTypeId is required.")]
        public long MaterialTypeId { get; set; }
        public List<ImageDto> Images { get; set; } = new List<ImageDto>();
    }
}