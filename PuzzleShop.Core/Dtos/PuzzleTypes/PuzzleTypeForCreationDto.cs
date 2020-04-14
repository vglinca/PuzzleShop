using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Core.Dtos.PuzzleTypes
{
    public class PuzzleTypeForCreationDto
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
    }
}