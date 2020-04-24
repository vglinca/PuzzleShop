using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using PuzzleShop.Core.Dtos.Images;

// ReSharper disable All

namespace PuzzleShop.Core.Dtos.Puzzles
{
    public class PuzzleForCreationDto
    {
        [Required(ErrorMessage = "PuzzleName is required.")]
        public string Name { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "You just specify if this puzzle is magnetic.")]
        public bool IsMagnetic { get; set; }
        [Required(ErrorMessage = "Weight is required.")]
        public double Weight { get; set; }
        [Required(ErrorMessage = "ManufacturerId is required.")]
        public long ManufacturerId { get; set; }
        [Required(ErrorMessage = "PuzzleTypeId is required.")]
        public long PuzzleTypeId { get; set; }
        [Required(ErrorMessage = "ColorId is required.")]
        public long ColorId { get; set; }
       
        [Required(ErrorMessage = "MaterialTypeId is required.")]
        public long MaterialTypeId { get; set; }
        [Required]
        public uint AvailableInStock { get; set; }
        [Required(ErrorMessage = "At least one image must be specified.")]
        public List<IFormFile> Images { get; set; } = new List<IFormFile>();
        //public List<ImageForCreationDto> Images { get; set; } = new List<ImageForCreationDto>();
    }
}