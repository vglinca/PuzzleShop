using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Core.Dtos.Manufacturers
{
    public class ManufacturerForCreateDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(25, ErrorMessage = "Name max length must be less than 25.")]
        public string Name { get; set; }
        [MaxLength(1500, ErrorMessage = "Description max length must be less than 1500.")]
        public string Description { get; set; }
    }
}