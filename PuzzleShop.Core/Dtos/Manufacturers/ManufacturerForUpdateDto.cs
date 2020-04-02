// ReSharper disable All

using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Api.Dtos.Manufacturers
{
    public class ManufacturerForUpdateDto
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
    }
}