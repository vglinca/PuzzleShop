// ReSharper disable All

using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Api.Dtos.Manufacturers
{
    public class ManufacturerForUpdateDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
    }
}