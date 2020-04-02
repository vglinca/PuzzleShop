using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Core.Dtos.Manufacturers
{
    public class ManufacturerForCreateDto
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}