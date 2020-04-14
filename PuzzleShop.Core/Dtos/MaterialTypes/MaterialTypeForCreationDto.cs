using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Core.Dtos.MaterialTypes
{
    public class MaterialTypeForCreationDto
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
    }
}