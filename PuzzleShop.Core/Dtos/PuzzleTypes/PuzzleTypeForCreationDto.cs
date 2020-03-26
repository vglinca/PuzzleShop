using System.ComponentModel.DataAnnotations;

namespace PuzzleShop.Core.Dtos.PuzzleTypes
{
    public class PuzzleTypeForCreationDto
    {
        [Required]
        public string Title { get; set; }
    }
}